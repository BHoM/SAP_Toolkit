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
        [Description("Creates thermalBridge objects from the opening widths/heights.")]
        [Input("types", "A list of OpeningType objects.")]
        [Input("openings", "A list of Opening objects.")]
        [Input("values", "PsiValues object.")]
        [Output("tb", "A list of ThermalBridge objects.")]
        public static List<BH.oM.Environment.SAP.XML.ThermalBridge> ThermalBridgesFromOpening(this List<BH.oM.Environment.SAP.XML.OpeningType> types, List<BH.oM.Environment.SAP.XML.Opening> openings, PsiValues values)
        {
            List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridges = new List<BH.oM.Environment.SAP.XML.ThermalBridge>();

            Dictionary<string, string> properties = types.Select(x => new { x.Name, x.Type }).ToDictionary(x => x.Name, x => x.Type);
            foreach (var opening in openings)
            {
                if (properties[opening.Type] == "5" || properties[opening.Type] == "6")
                {
                    List<string> tbs = new List<string> { "R1", "R2", "R3", "R3" };

                    List<double> roofValues = tbs.Select(x => (double)values.GetType().GetProperty(x).GetValue(values, null)).ToList();

                    if ((roofValues.Any(x => x < 0)) != true)
                    {
                        BH.Engine.Base.Compute.RecordError("Thermal bridges for rooflights/skylights are not defined properly.");
                        return null;
                    }
                    List<(string, double)> roofTB = tbs.Zip(roofValues, (t, r) => (t, r)).ToList();

                    foreach (var i in roofTB)
                    {
                        BH.oM.Environment.SAP.XML.ThermalBridge tb = new oM.Environment.SAP.XML.ThermalBridge();

                        tb.Type = i.Item1;
                        tb.PsiValue = i.Item2;
                        tb.CalculationReference = $"{opening.Name}_{opening.Type}_{opening.Location}";
                        if (i.Item1.EndsWith("3")) { tb.Length = double.Parse(opening.Height); }
                        else { tb.Length = double.Parse(opening.Width); }

                        thermalBridges.Add(tb);
                    }
                }
                else
                {
                    List<string> tbs = new List<string> { "E2", "E4", "E4" };
                    if (properties[opening.Type] == "4")
                    {
                        tbs.Add("E3");
                    }

                    List<double> roofValues = tbs.Select(x => (double)values.GetType().GetProperty(x).GetValue(values, null)).ToList();

                    //test.Add(roofValues);

                    if ((roofValues.Any(x => x < 0)) == true)
                    {
                        BH.Engine.Base.Compute.RecordError("Thermal bridges for external junctions are not defined properly.");
                        return null;
                    }
                    List<(string, double)> externalTB = tbs.Zip(roofValues, (t, r) => (t, r)).ToList();

                    foreach (var i in externalTB)
                    {
                        BH.oM.Environment.SAP.XML.ThermalBridge tb = new oM.Environment.SAP.XML.ThermalBridge();

                        tb.Type = i.Item1;
                        tb.PsiValue = i.Item2;
                        tb.CalculationReference = $"{opening.Name}_{opening.Type}_{opening.Location}";
                        if (i.Item1.EndsWith("4")) { tb.Length = double.Parse(opening.Height); }
                        else { tb.Length = double.Parse(opening.Width); }

                        thermalBridges.Add(tb);
                    }
                }
            }
            return thermalBridges; 
        }
    }
}


