﻿using BH.Engine.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BH.oM.Adapters.Excel;
using BH.Adapter.Excel;
using System.Linq;
using BH.oM.Environment.SAP.Excel;
using SXML = BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.XML.Bluebeam;
using BH.oM.Adapter;
using BH.Adapter.SAP.Argyle;
using BH.oM.Data.Requests;
using BH.oM.Environment.SAP.XML;
using BH.Adapter.XML;
using BH.oM.Adapters.XML;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<SXML.SAPReport> ReadSAPReport(SAPPullConfig config)
        {
            var sapMarkupSummary = ReadSAPMarkupSummary(config)?[0];
            if(sapMarkupSummary == null)
            {
                BH.Engine.Base.Compute.RecordError("Mark Up Summary did not return a viable object to produce a SAP Report with.");
                return new List<SXML.SAPReport>();
            }

            //Group by space names
            var allSpaceNames = sapMarkupSummary.Markup.Select(x => x.Space).Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
            Dictionary<string, List<SAPMarkup>> openingDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Openings").ToList());
            Dictionary<string, List<SAPMarkup>> wallDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "External Wall").ToList());
            Dictionary<string, List<SAPMarkup>> roofDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Roofs").ToList());
            Dictionary<string, List<SAPMarkup>> floorDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Floor Areas").ToList());

            Dictionary<string, List<SXML.OpeningType>> xmlOpeningTypesBySpace = XMLOpeningTypesBySpace(openingDefinitionsBySpace, config);

            foreach (string s in allSpaceNames)
            {
                openingDefinitionsBySpace[s] = openingDefinitionsBySpace[s].ModifyOpeningType(); //Update opening type names to meet schema

                var wallsUpdated = wallDefinitionsBySpace[s].ModifyWallNames(openingDefinitionsBySpace[s]); //Update wall type names to meet schema
                wallDefinitionsBySpace[s] = wallsUpdated.Item1;
                openingDefinitionsBySpace[s] = wallsUpdated.Item2;

                var roofsUpdated = roofDefinitionsBySpace[s].ModifyRoofNames(openingDefinitionsBySpace[s]); //Update roof type names to meet schema
                roofDefinitionsBySpace[s] = roofsUpdated.Item1;
                openingDefinitionsBySpace[s] = roofsUpdated.Item2;
            }

            //Openings
            Dictionary<string, List<SXML.Opening>> xmlOpeningsBySpace = XMLOpeningsBySpace(openingDefinitionsBySpace);

            //Walls
            Dictionary<string, List<SXML.Wall>> xmlWallsBySpace = XMLWallsBySpace(wallDefinitionsBySpace, config);

            //Roofs
            Dictionary<string, List<SXML.Roof>> xmlRoofsBySpace = XMLRoofsBySpace(roofDefinitionsBySpace, config);

            //Floors
            Dictionary<string, List<SXML.FloorDimension>> xmlFloorsBySpace = XMLFloorDimensionsBySpace(floorDefinitionsBySpace, config);

            //Thermal bridges
            Dictionary<string, List<SAPMarkup>> thermalBridgesBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Thermal Bridging").ToList());
            Dictionary<string, List<SXML.ThermalBridge>> xmlThermalBridgesBySpace = XMLThermalBridgesBySpace(thermalBridgesBySpace, config);

            //Living area
            var zone1 = sapMarkupSummary.Markup.Where(x => x.Layer == "Zone 1");
            Dictionary<string, double> livingAreaBySpace = new Dictionary<string, double>();

            //Floor area
            var floorAreaMarkups = sapMarkupSummary.Markup.Where(x => x.Layer == "Floor Areas");
            Dictionary<string, double> floorAreaBySpace = new Dictionary<string, double>();

            foreach (string name in allSpaceNames)
            {
                livingAreaBySpace.Add(name, zone1.Where(x => x.Space == name).Select(x => x.Area).FirstOrDefault());

                floorAreaBySpace.Add(name, floorAreaMarkups.Where(x => x.Space == name).Select(x => x.Area).FirstOrDefault());
            }

            //Lights
            Dictionary<string, SXML.FixedLight> xmlLightsBySpace = new Dictionary<string, SXML.FixedLight>();
            foreach(var kvp in floorAreaBySpace)
            {
                SXML.FixedLight light = new SXML.FixedLight();
                light.LightingOutlets = 1;
                light.LightingEfficacy = "80";

                double calc = kvp.Value * 185;
                calc = calc / 80;
                calc = Math.Ceiling(calc);
                calc = Math.Round(calc, 0);

                light.LightingPower = $"{calc}";

                xmlLightsBySpace.Add(kvp.Key, light);
            }

            //Building Parts
            Dictionary<string, SXML.BuildingParts> xmlBuildingPartsBySpace = new Dictionary<string, SXML.BuildingParts>();
            foreach(var space in allSpaceNames)
            {
                SXML.BuildingPart part = new SXML.BuildingPart();

                part.Identifier = space;
                part.BuildingPartNumber = "1";
                part.ConstructionYear = config.ConstructionYear;
                part.FloorDimensions = new SXML.FloorDimensions() { FloorDimension = xmlFloorsBySpace[space] };
                part.Openings = new SXML.Openings() { Opening = xmlOpeningsBySpace[space] };
                part.Roofs = new SXML.Roofs() { Roof = xmlRoofsBySpace[space] };
                part.Walls = new SXML.Walls() { Wall = xmlWallsBySpace[space] };
                part.ThermalBridges = new SXML.ThermalBridges() { ThermalBridge = xmlThermalBridgesBySpace[space], ThermalBridgeCode = "1" };

                xmlBuildingPartsBySpace.Add(space, new SXML.BuildingParts() { BuildingPart = new List<SXML.BuildingPart>() { part } });
            }

            //Property Details
            Dictionary<string, SXML.PropertyDetails> xmlPropertyDetailsBySpace = new Dictionary<string, SXML.PropertyDetails>();
            var dwellingSchedules = ReadDwellingSchedules(config);
            foreach(var space in allSpaceNames)
            {
                SXML.PropertyDetails propertyDetails = new SXML.PropertyDetails();

                propertyDetails.BuildingParts = xmlBuildingPartsBySpace[space];
                propertyDetails.OpeningTypes = new SXML.OpeningTypes() { OpeningType = xmlOpeningTypesBySpace[space] };
                propertyDetails.LivingArea = livingAreaBySpace[space].ToString();
                propertyDetails.LowestStoreyArea = floorAreaBySpace[space].ToString();
                propertyDetails.Lighting = new SXML.Lighting() { FixedLights = new SXML.FixedLights() { FixedLight = new List<SXML.FixedLight>() { xmlLightsBySpace[space] } } };

                if (config.FlatDetails != null)
                    propertyDetails.FlatDetails = config.FlatDetails;

                var schedule = dwellingSchedules.Where(x => x.DwellingTypeName == space).FirstOrDefault();

                propertyDetails.Orientation = ((int)schedule.DwellingOrientation).ToString();
                propertyDetails.PropertyType = ((int)config.PropertyType).ToString();

                xmlPropertyDetailsBySpace.Add(space, propertyDetails);
            }

            //SAP10 data
            Dictionary<string, SXML.SAPReport> sapReportBySpace = new Dictionary<string, SXML.SAPReport>();
            foreach(var space in allSpaceNames)
            {
                SXML.SAP10Data data = new SXML.SAP10Data();

                data.PropertyDetails = xmlPropertyDetailsBySpace[space];
                data.DataType = ((int)config.ConstructionType).ToString();

                SXML.SAPReport report = new SXML.SAPReport();

                report.SAP10Data = data;
                report.ReportHeader = new SXML.ReportHeader() { Property = new SXML.Property() };

                sapReportBySpace.Add(space, report);
            }

            Dictionary<string, SXML.SAPReport> fixedReportBySpace = new Dictionary<string, SXML.SAPReport>();
            var psiValues = ReadPsiValues(config);
            var openingPsiValues = ReadOpeningPsiValues(config);
            foreach(var kvp in sapReportBySpace)
            {
                var newReport = Modify.ThermalBridgesFromOpening(kvp.Value, psiValues, openingPsiValues);
                fixedReportBySpace.Add(kvp.Key, newReport);
            }

            //Heating files
            Dictionary<string, SXML.SAPReport> fixedReportWithHeatingBySpace = new Dictionary<string, SXML.SAPReport>();

            foreach(var dwellingSchedule in dwellingSchedules)
            {
                FileSettings fs = new FileSettings()
                {
                    FileName = dwellingSchedule.FileName,
                    Directory = config.HeatingFileDirectory,
                };

                XMLAdapter argyleAdapter = new XMLAdapter(fs);
                FilterRequest argyleRequest = BH.Engine.Data.Create.FilterRequest(typeof(SAPReport), "");
                var heatingReport = argyleAdapter.Pull(argyleRequest, actionConfig: new BH.oM.Adapters.XML.XMLConfig()).OfType<SAPReport>().FirstOrDefault();

                if (heatingReport != null)
                    fixedReportWithHeatingBySpace.Add(dwellingSchedule.DwellingTypeName, Modify.SAPHeatingTemplate(heatingReport, fixedReportBySpace[dwellingSchedule.DwellingTypeName]));
            }

            return fixedReportWithHeatingBySpace.Select(x => x.Value).ToList();
        }

        private bool CreateSAPReport(SAPReport report, SAPPushConfig config)
        {
            FileSettings fs = new FileSettings()
            {
                Directory = config.OutputDirectory,
                FileName = $"{report?.SAP10Data?.PropertyDetails?.BuildingParts?.BuildingPart?.FirstOrDefault()?.Identifier}.xml",
            };

            XMLConfig xmlConfig = new XMLConfig() { RemoveNils = true };
            XMLAdapter xmlAdapter = new XMLAdapter(fs);
            xmlAdapter.Push(new List<IBHoMObject>() { report }, actionConfig: xmlConfig);
            return true;
        }

        private Dictionary<string, List<SAPMarkup>> MarkUpsBySpace(List<string> spaceNames, List<SAPMarkup> markups)
        {
            Dictionary<string, List<SAPMarkup>> definitionsBySpace = new Dictionary<string, List<SAPMarkup>>();

            foreach (string spaceName in spaceNames)
                definitionsBySpace.Add(spaceName, markups.Where(x => x.Space == spaceName).ToList());

            return definitionsBySpace;
        }

        private Dictionary<string, List<SXML.Opening>> XMLOpeningsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace)
        {
            Dictionary<string, List<SXML.Opening>> xmlOpeningsBySpace = new Dictionary<string, List<SXML.Opening>>();

            foreach (KeyValuePair<string, List<SAPMarkup>> kvp in markupsBySpace)
            {
                List<SXML.Opening> xmlOpenings = new List<SXML.Opening>();
                for(int x = 0; x < kvp.Value.Count; x++)
                    xmlOpenings.Add(Convert.ToSAPOpening(kvp.Value[x], (x + 1).ToString()));

                xmlOpeningsBySpace.Add(kvp.Key, xmlOpenings);
            }

            return xmlOpeningsBySpace;
        }

        private Dictionary<string, List<SXML.FloorDimension>> XMLFloorDimensionsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPPullConfig config)
        {
            Dictionary<string, List<SXML.FloorDimension>> xmlFloorDimensionsBySpace = new Dictionary<string, List<SXML.FloorDimension>>();

            var floorDimensionsFromExcel = ReadFloorDefinitions(config);

            foreach(KeyValuePair<string, List<SAPMarkup>> kvp in markupsBySpace)
            {
                List<SXML.FloorDimension> dimensions = new List<SXML.FloorDimension>();
                for(int x = 0; x < kvp.Value.Count; x++)
                {
                    var importedDimension = floorDimensionsFromExcel.Where(a =>
                    {
                        if (!string.IsNullOrEmpty(a.Dwelling))
                        {
                            if (!string.IsNullOrEmpty(a.Storey))
                                return a.Dwelling == kvp.Key && a.Storey == kvp.Value[x].TFADwellingStorey.ToString() && a.Type.ToString() == kvp.Value[x].TFAFloorType;
                            else
                                return a.Dwelling == kvp.Key && a.Type.ToString() == kvp.Value[x].TFAFloorType;
                        }
                        else
                            return a.Type.ToString() == kvp.Value[x].TFAFloorType;
                    }).FirstOrDefault();

                    dimensions.Add(Convert.ToFloorDimension(kvp.Value[x], importedDimension));
                }

                xmlFloorDimensionsBySpace.Add(kvp.Key, dimensions);
            }

            return xmlFloorDimensionsBySpace;
        }

        private Dictionary<string, List<SXML.Roof>> XMLRoofsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPPullConfig config)
        {
            Dictionary<string, List<SXML.Roof>> xmlRoofsBySpace = new Dictionary<string, List<SXML.Roof>>();

            var roofDimensionsFromExcel = ReadRoofDefinitions(config);

            foreach (KeyValuePair<string, List<SAPMarkup>> kvp in markupsBySpace)
            {
                List<SXML.Roof> roofs = new List<SXML.Roof>();
                for (int x = 0; x < kvp.Value.Count; x++)
                {
                    var importedDimension = roofDimensionsFromExcel.Where(a =>
                    {
                        if (!string.IsNullOrEmpty(a.Dwelling))
                        {
                            if (!string.IsNullOrEmpty(a.Storey))
                                return a.Dwelling == kvp.Key && a.Storey == kvp.Value[x].TFADwellingStorey.ToString() && a.Type.ToString() == kvp.Value[x].RoofType;
                            else
                                return a.Dwelling == kvp.Key && a.Type.ToString() == kvp.Value[x].RoofType;
                        }
                        else
                            return a.Type.ToString() == kvp.Value[x].RoofType;
                    }).FirstOrDefault();

                    roofs.Add(Convert.ToRoof(kvp.Value[x], importedDimension));
                }

                xmlRoofsBySpace.Add(kvp.Key, roofs);
            }

            return xmlRoofsBySpace;
        }

        private Dictionary<string, List<SXML.Wall>> XMLWallsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPPullConfig config)
        {
            Dictionary<string, List<SXML.Wall>> xmlWallsBySpace = new Dictionary<string, List<SXML.Wall>>();

            var wallDefinitionsFromExcel = ReadWallDefinitions(config);

            foreach (KeyValuePair<string, List<SAPMarkup>> kvp in markupsBySpace)
            {
                List<SXML.Wall> walls = new List<SXML.Wall>();
                for (int x = 0; x < kvp.Value.Count; x++)
                {
                    var importedDimension = wallDefinitionsFromExcel.Where(a =>
                    {
                        if (!string.IsNullOrEmpty(a.Dwelling))
                        {
                            if (!string.IsNullOrEmpty(a.Storey))
                                return a.Dwelling == kvp.Key && a.Storey == kvp.Value[x].TFADwellingStorey.ToString() && a.Type.ToString() == kvp.Value[x].RoofType;
                            else
                                return a.Dwelling == kvp.Key && a.Type.ToString() == kvp.Value[x].RoofType;
                        }
                        else
                            return a.Type.ToString() == kvp.Value[x].RoofType;
                    }).FirstOrDefault();

                    walls.Add(Convert.ToWall(kvp.Value[x], importedDimension));
                }

                xmlWallsBySpace.Add(kvp.Key, walls);
            }

            return xmlWallsBySpace;
        }

        private Dictionary<string, List<SXML.OpeningType>> XMLOpeningTypesBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPPullConfig config)
        {
            Dictionary<string, List<SXML.OpeningType>> xmlOpeningsBySpace = new Dictionary<string, List<SXML.OpeningType>>();

            var openingDimensionsFromExcel = ReadOpeningDefinitions(config);

            foreach(var kvp in markupsBySpace)
            {
                List<SXML.OpeningType> types = new List<SXML.OpeningType>();

                var uniqueTypes = kvp.Value.Select(x => x.OpeningType).ToList();
                foreach(var type in uniqueTypes)
                {
                    var importedData = openingDimensionsFromExcel.Where(a => a.OpeningType == type).FirstOrDefault();

                    types.Add(Convert.ToOpeningType(importedData, ((int)(BH.oM.Environment.SAP.TypeOfOpening)Enum.Parse(typeof(BH.oM.Environment.SAP.TypeOfOpening), type)).ToString()));
                }

                xmlOpeningsBySpace.Add(kvp.Key, types);
            }

            return xmlOpeningsBySpace;
        }

        private Dictionary<string, List<SXML.ThermalBridge>> XMLThermalBridgesBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPPullConfig config)
        {
            Dictionary<string, List<SXML.ThermalBridge>> xmlBridgesBySpace = new Dictionary<string, List<SXML.ThermalBridge>>();

            var psiValuesFromExcel = ReadPsiValues(config);

            foreach(var kvp in markupsBySpace)
            {
                List<SXML.ThermalBridge> bridges = new List<SXML.ThermalBridge>();

                foreach (var markup in kvp.Value)
                {

                    var thermalBridge = psiValuesFromExcel.Where(x => x.ThermalBridgeName == markup.ThermalBridgeType).FirstOrDefault();

                    bridges.Add(Convert.ToThermalBridge(markup, thermalBridge));
                }

                xmlBridgesBySpace.Add(kvp.Key, bridges);
            }

            return xmlBridgesBySpace;
        }
    }
}