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

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.Excel;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BH.Adapter.SAP
{
    public static partial class Modify
    {
        [Description("Removes existing opening thermal bridges and recalculates them from openings.")]
        [Input("sapReportObj", "SAPReport to modify.")]
        [Input("values", "PsiValues object.")]
        [Input("openingDetails", "The psi value data for the opening.")]
        [Output("sapReport", "Modifed SAP Report.")]
        public static SAPReport ThermalBridgesFromOpening(this SAPReport sapReportObj, List<PsiValueSchedule> values, List<OpeningPsiValueSchedule> openingDetails)
        {
            //List of opening types
            List<BH.oM.Environment.SAP.XML.OpeningType> types = sapReportObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType;

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingParts = new List<oM.Environment.SAP.XML.BuildingPart>();

            List<string> thermalBridgeTypes = new List<string> { "R1", "R2", "R3", "E2", "E3", "E4" };

            foreach (var partObj in sapReportObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                //Remove any window thermal bridges
                List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridges = partObj.ThermalBridges.ThermalBridge.Where(x => !thermalBridgeTypes.Contains(x.Type)).ToList();

                //List of openings
                List<BH.oM.Environment.SAP.XML.Opening> openings = partObj.Openings.Opening;

                //Recalculate window thermal bridges and add back in
                thermalBridges.Concat(partObj.TBFromOpening(types, values, openingDetails));

                partObj.ThermalBridges.ThermalBridge = thermalBridges;
                buildingParts.Add(partObj);

            }
            sapReportObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingParts;

            return sapReportObj;
        }

        [Description("Creates thermalBridge objects from the opening widths/heights.")]
        [Input("buildingObj", "A building part object.")]
        [Input("types", "A list of OpeningType objects.")]
        [Input("values", "PsiValues object.")]
        [Input("openingDetails", "The psi value data for the opening.")]
        [Output("thermalBridge", "A list of ThermalBridge objects.")]
        public static List<BH.oM.Environment.SAP.XML.ThermalBridge> TBFromOpening(this BH.oM.Environment.SAP.XML.BuildingPart buildingObj, List<BH.oM.Environment.SAP.XML.OpeningType> types, List<PsiValueSchedule> values, List<OpeningPsiValueSchedule> openingDetails)
        {
            //Empty list of thermal bridges ( to be final list)
            List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridges = new List<BH.oM.Environment.SAP.XML.ThermalBridge>();

            //List of opening thermal bridges that might be used
            List<string> thermalBridgeTypes = new List<string> { "R1", "R2", "R3", "E2", "E3", "E4" };

            //List of walls for which openings hosted on them will have the thermal bridges calculated
            List<string> wallsWithTB = buildingObj.Walls.Wall.Where(x => x.CurtainWall == false).Select(x => x.Name).ToList();

            //List of all the names of roofs
            List<string> roofNames = buildingObj.Roofs.Roof.Select(x => x.Name).ToList();

            //A list of walls or roofs where openings with thermal bridges will be calculated
            List<string> locations = new List<string>();

            //Null checking
            if (wallsWithTB.Count > 0)
            {
                if (roofNames.Count > 0)
                {
                    locations = wallsWithTB.Concat(roofNames).ToList();
                }
                else
                {
                    locations = wallsWithTB;
                }
            }
            else
            {
                if (roofNames.Count > 0)
                {
                    locations = roofNames;
                }
                else
                {
                    return thermalBridges;
                }
            }

            //List of psi values in general psi value section
            List<PsiValueSchedule> windowTBValues = thermalBridgeTypes.Select(x => values.Where(y => ((y.Type == x) && (y.ThermalBridgeName == x || y.ThermalBridgeName == string.Empty))).FirstOrDefault()).ToList();

            //For each window type
            foreach (var t in types)
            {
                //Openings of type t
                var o = buildingObj.Openings.Opening.Where(x => x.Type == t.Name).ToList();

                //OpeningDetails object that matches type of t
                var openingValues = openingDetails.Where(x => x.OpeningType == t.Description).ToList().FirstOrDefault();

                if (openingValues == null)
                {
                    if (o == null || !o.Any())
                    {
                        continue;
                    }
                    else
                    {
                        BH.Engine.Base.Compute.RecordError($"An opening type has not correctly been defined. Please make sure opening: {t.Description} has been defined.");
                        return thermalBridges;
                    }
                }

                //List of thermal bridges the opening will have
                List<string> openingTBs = new List<string>();
                if (t.Type == "5" || t.Type == "6")
                {
                    openingTBs = new List<string> { "R1", "R2", "R3", "R3" };
                }
                else
                {
                    openingTBs = new List<string> { "E2", "E3", "E4", "E4" };
                }

                var d = openingTBs.Select(x => openingValues.PsiValues.Where(y => y.Type == x).FirstOrDefault()).ToList();

                List<double> openingPsiValues = new List<double>();

                for (int j = 0; j < d.Count; j++)
                {
                    if (d != null && d[j] != null && d[j].PsiValue != 0)
                    {
                        openingPsiValues.Add(d[j].PsiValue);
                    }
                    else
                    {
                        var f = values.Where(y => ((y.Type == openingTBs[j]) && (y.ThermalBridgeName == string.Empty || y.ThermalBridgeName == y.Type))).FirstOrDefault();
                        if (f != null)
                        {
                            openingPsiValues.Add(f.PsiValue);
                        }
                        else
                        {
                            BH.Engine.Base.Compute.RecordError($"There is no value assgined to the thermal bridge {openingTBs[1]} for the opening {t.Description}");
                            return thermalBridges;
                        }
                    }
                };

                List<BH.oM.Environment.SAP.XML.ThermalBridge> typeThermalBridges = new List<oM.Environment.SAP.XML.ThermalBridge>();

                foreach (var opening in o)
                {
                    typeThermalBridges.Add(openingTBs[0].CreateThermalBridge(openingPsiValues[0], opening.Width, t.Description));
                    typeThermalBridges.Add(openingTBs[2].CreateThermalBridge(openingPsiValues[2], opening.Height, t.Description));
                    typeThermalBridges.Add(openingTBs[3].CreateThermalBridge(openingPsiValues[3], opening.Height, t.Description));

                    if (openingValues.FloorIntersection == true)
                    {
                        typeThermalBridges.Add(openingTBs[1].CreateThermalBridge(openingPsiValues[1], 0, t.Description));
                    }
                    else
                    {
                        typeThermalBridges.Add(openingTBs[1].CreateThermalBridge(openingPsiValues[1], opening.Width, t.Description));
                    }
                }

                if (!(typeThermalBridges == null || !typeThermalBridges.Any()))
                {
                    thermalBridges.AddRange(typeThermalBridges);
                }
            }
            return thermalBridges;
        }

        [Description("Creates a thermal bridge object based on inputs.")]
        [Input("type", "The type of thermal bridge.")]
        [Input("psiValue", "The psi value of the thermal bridge.")]
        [Input("length", "The length of the thermal bridge.")]
        [Input("openingType", "The type of the opening the thermal bridge has been created from.")]
        [Output("The thermal bridge created from the inputs.")]
        public static BH.oM.Environment.SAP.XML.ThermalBridge CreateThermalBridge(this string type, double psiValue, double length, string openingType)
        {
            if (type == null)
            {
                BH.Engine.Base.Compute.RecordError("Invalid type");
            };

            BH.oM.Environment.SAP.XML.ThermalBridge tb = new oM.Environment.SAP.XML.ThermalBridge
            {
                Type = type,
                PsiSource = "1",
                PsiValue = psiValue,
                Length = length,
                CalculationReference = $"From opening {openingType}, created by SAP Toolkit, you're welcome :)."
            };

            return tb;
        }
    }
}
