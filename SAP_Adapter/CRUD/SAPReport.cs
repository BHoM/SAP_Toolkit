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

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<SXML.SAPReport> ReadSAPReport(SAPConfig config)
        {
            var sapMarkupSummary = ReadSAPMarkupSummary(config)?[0];
            if(sapMarkupSummary == null)
            {
                BH.Engine.Base.Compute.RecordError("Mark Up Summary did not return a viable object to produce a SAP Report with.");
                return new List<SXML.SAPReport>();
            }

            //Group by space names
            var allSpaceNames = sapMarkupSummary.Markup.Select(x => x.Space).ToList();
            Dictionary<string, List<SAPMarkup>> openingDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Openings").ToList());
            Dictionary<string, List<SAPMarkup>> wallDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "External Wall").ToList());
            Dictionary<string, List<SAPMarkup>> roofDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Roofs").ToList());
            Dictionary<string, List<SAPMarkup>> floorDefinitionsBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Floor Areas").ToList());

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
            Dictionary<string, List<SXML.OpeningType>> xmlOpeningTypesBySpace = XMLOpeningTypesBySpace(openingDefinitionsBySpace, config);

            //Walls
            Dictionary<string, List<SXML.Wall>> xmlWallsBySpace = XMLWallsBySpace(wallDefinitionsBySpace, config);

            //Roofs
            Dictionary<string, List<SXML.Roof>> xmlRoofsBySpace = XMLRoofsBySpace(roofDefinitionsBySpace, config);

            //Floors
            Dictionary<string, List<SXML.FloorDimension>> xmlFloorsBySpace = XMLFloorDimensionsBySpace(floorDefinitionsBySpace, config);

            //Thermal bridges
            Dictionary<string, List<SAPMarkup>> thermalBridgesBySpace = MarkUpsBySpace(allSpaceNames, sapMarkupSummary.Markup.Where(x => x.Layer == "Thermal Bridging").ToList());
            Dictionary<string, List<SXML.ThermalBridge>> xmlThermalBridgesBySpace = XMLThermalBridgesBySpace(thermalBridgesBySpace, config);

            return null;
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

        private Dictionary<string, List<SXML.FloorDimension>> XMLFloorDimensionsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPConfig config)
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

        private Dictionary<string, List<SXML.Roof>> XMLRoofsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPConfig config)
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

        private Dictionary<string, List<SXML.Wall>> XMLWallsBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPConfig config)
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

        private Dictionary<string, List<SXML.OpeningType>> XMLOpeningTypesBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPConfig config)
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

        private Dictionary<string, List<SXML.ThermalBridge>> XMLThermalBridgesBySpace(Dictionary<string, List<SAPMarkup>> markupsBySpace, SAPConfig config)
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
