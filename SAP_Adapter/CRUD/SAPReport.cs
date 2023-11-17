/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.Engine.Adapter;
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
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private bool CreateSAPReport(SAPReport report, SAPPushConfig config)
        {
            FileSettings fs = new FileSettings()
            {
                Directory = config.OutputDirectory,
                FileName = $"{report?.SAP10Data?.PropertyDetails?.BuildingParts?.BuildingPart?.FirstOrDefault()?.Identifier}.xml",
            };

            XMLConfig xmlConfig = new XMLConfig() { RemoveNils = true, File = fs };
            XMLAdapter xmlAdapter = new XMLAdapter();
            xmlAdapter.Push(new List<IBHoMObject>() { report }, actionConfig: xmlConfig);
            return true;
        }

        private List<SXML.SAPReport> ReadSAPReport(SAPReportPullConfig config)
        {
            if (config.SAPReportFile == null)
            {
                BH.Engine.Base.Compute.RecordError("Please provide a valid SAP Report File Location.");
                return new List<SXML.SAPReport>();
            }

            string fullFileName = config.SAPReportFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<SXML.SAPReport>();
            }

            XMLConfig xmlConfig = new XMLConfig() { Schema = oM.Adapters.XML.Enums.Schema.Undefined, File = config.SAPReportFile };
            XMLAdapter xmlAdapter = new XMLAdapter();
            FilterRequest xmlRequest = BH.Engine.Data.Create.FilterRequest(typeof(SXML.SAPReport), "");

            return xmlAdapter.Pull(xmlRequest, actionConfig: xmlConfig).OfType<SXML.SAPReport>().ToList();
        }

        private List<SXML.SAPReport> ReadSAPReport(SAPMarkUpPullConfig config)
        {
            var sapMarkupSummary = ReadSAPMarkupSummary(config)?[0];
            if (sapMarkupSummary == null)
            {
                BH.Engine.Base.Compute.RecordError("Mark Up Summary did not return a viable object to produce a SAP Report with.");
                return new List<SXML.SAPReport>();
            }

            //Group by space names
            var allSpaceNames = sapMarkupSummary.Markup.Select(x => x.Space).Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
            Dictionary<string, List<SAPMarkup>> openingDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.OpeningLayerName).ToList());
            Dictionary<string, List<SAPMarkup>> wallDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.WallLayerName).ToList());
            Dictionary<string, List<SAPMarkup>> roofDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.RoofLayerName).ToList());
            Dictionary<string, List<SAPMarkup>> floorDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.FloorLayerName).ToList());

            Dictionary<string, List<SXML.OpeningType>> xmlOpeningTypesBySpace = XMLOpeningTypesBySpace(openingDefinitionsBySpace, config);

            foreach (string s in allSpaceNames)
            {
                var openingTypesUpdated = openingDefinitionsBySpace[s].ModifyOpeningType(xmlOpeningTypesBySpace[s]); //Update opening type names to meet schema
                openingDefinitionsBySpace[s] = openingTypesUpdated.Item1;
                xmlOpeningTypesBySpace[s] = openingTypesUpdated.Item2;

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
            var dummyRoof = new SXML.Roof()
            {
                Area = "0",
                Name = "Party Ceiling",
                Description = "Ceiling",
                UValue = "0.0",
                Type = "4",
            };
            foreach (var s in allSpaceNames)
            {
                if (xmlRoofsBySpace[s].Count == 0)
                    xmlRoofsBySpace[s].Add(dummyRoof);
            }

            //Floors
            Dictionary<string, List<SXML.FloorDimension>> xmlFloorsBySpace = XMLFloorDimensionsBySpace(floorDefinitionsBySpace, config);

            //Thermal bridges
            var psiValuesFromExcel = ReadPsiValues(config);
            Dictionary<string, List<SAPMarkup>> thermalBridgesBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.ThermalBridgeLayerName).ToList());
            Dictionary<string, List<SXML.ThermalBridge>> xmlThermalBridgesBySpace = XMLThermalBridgesBySpace(thermalBridgesBySpace, psiValuesFromExcel);

            Dictionary<string, List<SXML.ThermalBridge>> xmlOpeningThermalBridgesBySpace = OpeningThermalBridges(xmlOpeningsBySpace, xmlOpeningTypesBySpace, psiValuesFromExcel);
            foreach (var kvp in xmlOpeningThermalBridgesBySpace)
                xmlThermalBridgesBySpace[kvp.Key].AddRange(kvp.Value);

            //Living area
            var zone1 = sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.LivingAreaLayerName);
            Dictionary<string, double> livingAreaBySpace = new Dictionary<string, double>();

            //Floor area
            var floorAreaMarkups = sapMarkupSummary.Markup.Where(x => x.Layer == config.BluebeamConfig.FloorLayerName);
            Dictionary<string, double> floorAreaBySpace = new Dictionary<string, double>();

            foreach (string name in allSpaceNames)
            {
                livingAreaBySpace.Add(name, zone1.Where(x => x.Space == name).Select(x => x.Area).FirstOrDefault());

                floorAreaBySpace.Add(name, floorAreaMarkups.Where(x => x.Space == name).Select(x => x.Area).FirstOrDefault());
            }

            //Lights
            Dictionary<string, SXML.FixedLight> xmlLightsBySpace = new Dictionary<string, SXML.FixedLight>();
            foreach (var kvp in floorAreaBySpace)
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
            var dwellingSchedules = ReadDwellingSchedules(config);
            Dictionary<string, SXML.BuildingParts> xmlBuildingPartsBySpace = new Dictionary<string, SXML.BuildingParts>();
            foreach (var space in allSpaceNames)
            {
                SXML.BuildingPart part = new SXML.BuildingPart();

                var schedule = dwellingSchedules.Where(x => x.DwellingTypeName == space).FirstOrDefault();

                if (schedule == null)
                {
                    BH.Engine.Base.Compute.RecordError($"Could not find a Dwelling Schedule for dwelling with name '{space}'. Please check your Dwelling Schedules and try again.");
                    continue;
                }

                part.Identifier = space;
                part.BuildingPartNumber = "1";
                part.ConstructionYear = schedule.ConstructionYear;
                part.FloorDimensions = new SXML.FloorDimensions() { FloorDimension = xmlFloorsBySpace[space] };
                part.Openings = new SXML.Openings() { Opening = xmlOpeningsBySpace[space] };
                part.Roofs = new SXML.Roofs() { Roof = xmlRoofsBySpace[space] };
                part.Walls = new SXML.Walls() { Wall = xmlWallsBySpace[space] };
                part.ThermalBridges = new SXML.ThermalBridges() { ThermalBridge = xmlThermalBridgesBySpace[space], ThermalBridgeCode = "5" };

                xmlBuildingPartsBySpace.Add(space, new SXML.BuildingParts() { BuildingPart = new List<SXML.BuildingPart>() { part } });
            }

            //Property Details
            Dictionary<string, SXML.PropertyDetails> xmlPropertyDetailsBySpace = new Dictionary<string, SXML.PropertyDetails>();
            foreach (var space in allSpaceNames)
            {
                SXML.PropertyDetails propertyDetails = new SXML.PropertyDetails();

                propertyDetails.BuildingParts = xmlBuildingPartsBySpace[space];
                propertyDetails.OpeningTypes = new SXML.OpeningTypes() { OpeningType = xmlOpeningTypesBySpace[space] };
                propertyDetails.LivingArea = livingAreaBySpace[space].ToString();
                propertyDetails.LowestStoreyArea = floorAreaBySpace[space].ToString();
                propertyDetails.Lighting = new SXML.Lighting() { FixedLights = new SXML.FixedLights() { FixedLight = new List<SXML.FixedLight>() { xmlLightsBySpace[space] } } };

                var schedule = dwellingSchedules.Where(x => x.DwellingTypeName == space).FirstOrDefault();

                if (schedule != null)
                {
                    propertyDetails.FlatDetails = new FlatDetails()
                    {
                        Storeys = schedule.Storeys,
                        Level = schedule.Level,
                    };

                    propertyDetails.Orientation = ((int)schedule.DwellingOrientation).ToString();
                    propertyDetails.PropertyType = ((int)schedule.PropertyType).ToString();

                    if (propertyDetails.Ventilation == null)
                        propertyDetails.Ventilation = new Ventilation();

                    propertyDetails.Ventilation.WetRoomsCount = schedule.WetRooms.ToString("#.##");
                    propertyDetails.Ventilation.ShelteredSidesCount = schedule.ShelteredSides.ToString("#.##");
                }

                xmlPropertyDetailsBySpace.Add(space, propertyDetails);
            }

            //SAP10 data
            Dictionary<string, SXML.SAPReport> sapReportBySpace = new Dictionary<string, SXML.SAPReport>();
            foreach (var space in allSpaceNames)
            {
                SXML.SAP10Data data = new SXML.SAP10Data();

                var schedule = dwellingSchedules.Where(x => x.DwellingTypeName == space).FirstOrDefault();

                data.PropertyDetails = xmlPropertyDetailsBySpace[space];

                if (schedule != null)
                    data.DataType = ((int)schedule.ConstructionType).ToString();

                SXML.SAPReport report = new SXML.SAPReport();

                report.SAP10Data = data;
                report.ReportHeader = new SXML.ReportHeader() { Property = new SXML.Property() };

                sapReportBySpace.Add(space, report);
            }

            Dictionary<string, SXML.SAPReport> fixedReportBySpace = new Dictionary<string, SXML.SAPReport>();
            var psiValues = ReadPsiValues(config);
            var openingPsiValues = ReadOpeningPsiValues(config);
            foreach (var kvp in sapReportBySpace)
            {
                var newReport = Modify.ThermalBridgesFromOpening(kvp.Value, psiValues, openingPsiValues);
                fixedReportBySpace.Add(kvp.Key, newReport);
            }

            //Heating files
            Dictionary<string, SXML.SAPReport> fixedReportWithHeatingBySpace = new Dictionary<string, SXML.SAPReport>();

            foreach (var dwellingSchedule in dwellingSchedules)
            {
                FileSettings fs = new FileSettings()
                {
                    FileName = dwellingSchedule.FileName,
                    Directory = config.HeatingFileDirectory,
                };

                XMLAdapter argyleAdapter = new XMLAdapter();
                FilterRequest argyleRequest = BH.Engine.Data.Create.FilterRequest(typeof(SAPReport), "");
                var heatingReport = argyleAdapter.Pull(argyleRequest, actionConfig: new BH.oM.Adapters.XML.XMLConfig() { File = fs }).OfType<SAPReport>().FirstOrDefault();

                if (heatingReport != null)
                    fixedReportWithHeatingBySpace.Add(dwellingSchedule.DwellingTypeName, Modify.SAPHeatingTemplate(heatingReport, fixedReportBySpace[dwellingSchedule.DwellingTypeName]));
            }

            return fixedReportWithHeatingBySpace.Select(x => x.Value).ToList();
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
                for (int x = 0; x < kvp.Value.Count; x++)
                    xmlOpenings.Add(Convert.ToSAPOpening(kvp.Value[x], (x + 1).ToString())); 

                xmlOpeningsBySpace.Add(kvp.Key, xmlOpenings);
            }

            return xmlOpeningsBySpace;
        }

        private Dictionary<string, List<SXML.FloorDimension>> XMLFloorDimensionsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPMarkUpPullConfig config)
        {
            Dictionary<string, List<SXML.FloorDimension>> xmlFloorDimensionsBySpace = new Dictionary<string, List<SXML.FloorDimension>>();

            var floorDimensionsFromExcel = ReadFloorDefinitions(config);

            foreach (KeyValuePair<string, List<SAPMarkup>> kvp in markupsBySpace)
            {
                List<SXML.FloorDimension> dimensions = new List<SXML.FloorDimension>();
                for (int x = 0; x < kvp.Value.Count; x++)
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

        private Dictionary<string, List<SXML.Roof>> XMLRoofsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPMarkUpPullConfig config)
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

        private Dictionary<string, List<SXML.Wall>> XMLWallsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPMarkUpPullConfig config)
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

        private Dictionary<string, List<SXML.OpeningType>> XMLOpeningTypesBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPMarkUpPullConfig config)
        {
            Dictionary<string, List<SXML.OpeningType>> xmlOpeningsBySpace = new Dictionary<string, List<SXML.OpeningType>>();

            var openingDimensionsFromExcel = ReadOpeningDefinitions(config);

            foreach (var kvp in markupsBySpace)
            {
                List<SXML.OpeningType> types = new List<SXML.OpeningType>();

                foreach (var markup in kvp.Value)
                {
                    var importedData = openingDimensionsFromExcel.Where(a => a.OpeningType == markup.Subject).FirstOrDefault(); //Group by the Bluebeam subject rather than the opening type for e.g. Glazed doors

                    types.Add(Convert.ToOpeningType(importedData, ((int)(BH.oM.Environment.SAP.TypeOfOpening)Enum.Parse(typeof(BH.oM.Environment.SAP.TypeOfOpening), markup.OpeningType)).ToString(), markup.OpeningType));
                }

                types = types.Distinct().ToList();
                xmlOpeningsBySpace.Add(kvp.Key, types);
            }

            return xmlOpeningsBySpace;
        }

        private Dictionary<string, List<SXML.ThermalBridge>> XMLThermalBridgesBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, List<PsiValueSchedule> psiValuesFromExcel)
        {
            Dictionary<string, List<SXML.ThermalBridge>> xmlBridgesBySpace = new Dictionary<string, List<SXML.ThermalBridge>>();

            foreach (var kvp in markupsBySpace)
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

        private Dictionary<string, List<SXML.ThermalBridge>> OpeningThermalBridges(Dictionary<string, List<SXML.Opening>> openings, Dictionary<string, List<SXML.OpeningType>> openingTypesBySpace, List<PsiValueSchedule> psiValuesFromExcel)
        {
            ConcurrentDictionary<string, List<SXML.OpeningType>> concurrentOpeningTypes = new ConcurrentDictionary<string, List<OpeningType>>(openingTypesBySpace);

            ConcurrentDictionary<string, ConcurrentBag<SXML.ThermalBridge>> thermalBridges = new ConcurrentDictionary<string, ConcurrentBag<ThermalBridge>>();

            Parallel.ForEach(openings, openingBySpace =>
            {
                thermalBridges.TryAdd(openingBySpace.Key, new ConcurrentBag<ThermalBridge>());

                Parallel.ForEach(openingBySpace.Value, opening =>
                {
                    var openingTypes = concurrentOpeningTypes[openingBySpace.Key];
                    var type = openingTypes.Where(y => y.Type == opening.Type).FirstOrDefault();
                    bool intersects = false;
                    if (type != null)
                        intersects = type.IntersectsFloor;

                    var e2psi = psiValuesFromExcel.Where(x => x.ThermalBridgeName.ToLower() == "e2").FirstOrDefault();
                    var e3psi = psiValuesFromExcel.Where(x => x.ThermalBridgeName.ToLower() == "e3").FirstOrDefault();
                    var e4psi = psiValuesFromExcel.Where(x => x.ThermalBridgeName.ToLower() == "e4").FirstOrDefault();

                    //E2 = width - All openings
                    ThermalBridge e2 = new ThermalBridge();
                    e2.Length = opening.Width;
                    e2.Type = "E2";
                    if (e2psi != null)
                        e2.PsiValue = e2psi.PsiValue;

                    //E4 = 2 * height
                    ThermalBridge e4 = new ThermalBridge();
                    e4.Length = opening.Height * 2;
                    e4.Type = "E4";
                    if (e4psi != null)
                        e4.PsiValue = e4psi.PsiValue;

                    thermalBridges[openingBySpace.Key].Add(e2);
                    thermalBridges[openingBySpace.Key].Add(e4);

                    if (!intersects)
                    {
                        //E3 = width but only for openings that do not intersect with the floor
                        ThermalBridge e3 = new ThermalBridge();
                        e3.Length = opening.Width;
                        e3.Type = "E3";
                        if (e3psi != null)
                            e3.PsiValue = e3psi.PsiValue;

                        thermalBridges[openingBySpace.Key].Add(e3);
                    }
                });
            });

            Dictionary<string, List<SXML.ThermalBridge>> rtn = new Dictionary<string, List<ThermalBridge>>();

            foreach (var kvp in thermalBridges)
                rtn.Add(kvp.Key,kvp.Value.ToList());

            return rtn;
        }
    }
}