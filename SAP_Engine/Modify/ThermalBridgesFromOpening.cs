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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.Engine.Geometry;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.XML;
using BH.Engine.Base;
using System.Security.Cryptography.X509Certificates;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Removes existing opening thermal bridges and recalculates them from openings.")]
        [Input("sapReportObj", "SAPReport to modify.")]
        [Input("values", "PsiValues object.")]
        [Output("sapReport", "Modifed SAP Report.")]
        public static SAPReport ThermalBridgesFromOpening(this SAPReport sapReportObj, PsiValues values)// List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridgeObjs, List<BH.oM.Environment.SAP.XML.OpeningType> types, List<BH.oM.Environment.SAP.XML.Opening> openings, PsiValues values)
        {
            List<string> windowTB = new List<string> { "R1", "R2", "R3", "E2", "E3", "E4",};

            //List of opening types
            List<BH.oM.Environment.SAP.XML.OpeningType> types = sapReportObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType;

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingParts = new List<oM.Environment.SAP.XML.BuildingPart>();

            foreach (var partObj in sapReportObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                //Remove any window thermal bridges
                List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridges = partObj.ThermalBridges.ThermalBridge.Where(x => !windowTB.Contains(x.Type)).ToList();

                //List of openings
                List<BH.oM.Environment.SAP.XML.Opening> openings = partObj.Openings.Opening;

                //For each wall, is it a curtain wall
                Dictionary<string,bool> abc = partObj.Walls.Wall.Select(x => new { x.Name, x.CurtainWall }).ToDictionary(x => x.Name, x => x.CurtainWall);

                //Recalculate window thermal bridges and add back in
                thermalBridges.AddRange(types.ThermalBridgesFromOpening(partObj.Openings.Opening, values, abc));

                partObj.ThermalBridges.ThermalBridge = thermalBridges;
                buildingParts.Add(partObj);

            }
            sapReportObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingParts;

            return sapReportObj;
        }

        [Description("Creates thermalBridge objects from the opening widths/heights.")]
        [Input("types", "A list of OpeningType objects.")]
        [Input("openings", "A list of Opening objects.")]
        [Input("values", "PsiValues object.")]
        [Output("thermalBridge", "A list of ThermalBridge objects.")]
        public static List<BH.oM.Environment.SAP.XML.ThermalBridge> ThermalBridgesFromOpening(this List<BH.oM.Environment.SAP.XML.OpeningType> types, List<BH.oM.Environment.SAP.XML.Opening> openings, PsiValues values, Dictionary<string,bool> walls)
        {
            List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridges = new List<BH.oM.Environment.SAP.XML.ThermalBridge>();

            Dictionary<string, string> properties = types.Select(x => new { x.Name, x.Type }).ToDictionary(x => x.Name, x => x.Type);
            foreach (var opening in openings)
            {
                //If opening location is a curtain wall then ignore it
                if (walls.ContainsKey(opening.Location))
                {
                    if (walls[opening.Location] == true)
                    {
                        continue;
                    }
                }

                //If opening is a rooflight/roof window
                if (properties[opening.Type] == "5" || properties[opening.Type] == "6")
                {
                    //Roof opening thermal bridges
                    List<string> tbs = new List<string> { "R1", "R2", "R3", "R3" };

                    //Get the psi values for the thermal bridges specified
                    List<double> roofPsiValues = tbs.Select(x => (double)values.GetType().GetProperty(x).GetValue(values, null)).ToList();

                    if ((roofPsiValues.Any(x => x < 0)) != true)
                    {
                        BH.Engine.Base.Compute.RecordError("Thermal bridges for rooflights/skylights are not defined properly.");
                        return null;
                    }

                    List<(string, double)> roofThermalBridge = tbs.Zip(roofPsiValues, (t, r) => (t, r)).ToList();

                    //For each thermal Bridge
                    foreach (var i in roofThermalBridge)
                    {
                        BH.oM.Environment.SAP.XML.ThermalBridge thermalBridge = new oM.Environment.SAP.XML.ThermalBridge();
                        //Assign properties
                        thermalBridge.Type = i.Item1;
                        thermalBridge.PsiValue = i.Item2;
                        thermalBridge.PsiSource = "3";
                        thermalBridge.CalculationReference = $"{opening.Name}_{opening.Type}_{opening.Location}";
                        if (i.Item1.EndsWith("3")) 
                        { 
                            thermalBridge.Length = opening.Height; 
                        }
                        else 
                        { 
                            thermalBridge.Length = opening.Width; 
                        }

                        thermalBridges.Add(thermalBridge);
                    }
                }
                else
                {
                    //Other opening thermal bridges
                    List<string> tbs = new List<string> { "E2", "E4", "E4" };
                    if (properties[opening.Type] == "4")
                    {
                        tbs.Add("E3");
                    }

                    //Get the psi values for the thermal bridges specified
                    List<double> roofValues = tbs.Select(x => (double)values.GetType().GetProperty(x).GetValue(values, null)).ToList();

                    if ((roofValues.Any(x => x < 0)) == true)
                    {
                        BH.Engine.Base.Compute.RecordError("Thermal bridges for external junctions are not defined properly.");
                        return null;
                    }

                    List<(string, double)> externalTB = tbs.Zip(roofValues, (t, r) => (t, r)).ToList();

                    //For each thermal Bridge
                    foreach (var i in externalTB)
                    {
                        BH.oM.Environment.SAP.XML.ThermalBridge tb = new oM.Environment.SAP.XML.ThermalBridge();
                        //Assign properties
                        tb.Type = i.Item1;
                        tb.PsiValue = i.Item2;
                        tb.PsiSource = "3";
                        tb.CalculationReference = $"{opening.Name}_{opening.Type}_{opening.Location}";
                        if (i.Item1.EndsWith("4"))
                        { 
                            tb.Length = opening.Height; 
                        }
                        else 
                        { 
                            tb.Length = opening.Width; 
                        }

                        thermalBridges.Add(tb);
                    }
                }
            }
            return thermalBridges; 
        }
    }
}


