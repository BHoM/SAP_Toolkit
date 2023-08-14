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
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.ComponentModel;
using BH.oM.Adapter;
using BH.Engine.Diffing;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using BH.Engine.Base;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Environment.Elements;
using BH.oM.Base;
using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.JSON;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the Psi value of a type of thermal bridges from a report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of floors by name to modify.")]
        [Input("psiValue", "New PsiValue for thermal bridge.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToThermalBridges", "Tracking the changes made to the psiValues of the thermal bridges.")]
        public static Output<SAPReport, List<oM.Environment.SAP.JSON.ThermalBridge>> ModifyThermalBridges(this SAPReport sapObj, List<string> include, double psiValue = -1)
        {
            //Null handling
            if (psiValue < 0 || sapObj == null || include == null)
            {
                return new Output<SAPReport, List<oM.Environment.SAP.JSON.ThermalBridge>>() { Item1 = sapObj, Item2 = null };
            }

            //QA file - tracking changes to psi values of thermal bridges
            List<oM.Environment.SAP.JSON.ThermalBridge> changes = new List<oM.Environment.SAP.JSON.ThermalBridge>();

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //Foreach building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridgeList = new List<oM.Environment.SAP.XML.ThermalBridge>();

                //foreach thermal bridge object
                foreach (var tb in b.ThermalBridges.ThermalBridge)
                {
                    BH.oM.Environment.SAP.XML.ThermalBridge tbObj = tb;

                    //TODO
                    if (include.Contains(tb.Type)) //or change this to be include.Contains(tb.CalculationReference  based on SAPchat
                    {
                        //QA file
                        oM.Environment.SAP.JSON.ThermalBridge tbChanges = new oM.Environment.SAP.JSON.ThermalBridge
                        { 
                            Type = tb.Type, Name = tb.CalculationReference 
                        };

                        tbChanges.PsiValue = new Changes { Initial = tb.PsiValue.ToString(), Final = psiValue.ToString() };
                        changes.Add(tbChanges); 

                        //Modification of psi value
                        tbObj = tbObj.ModifyThermalBridge(psiValue);
                    }

                    thermalBridgeList.Add(tbObj);
                }
                partObj.ThermalBridges.ThermalBridge = thermalBridgeList;
                buildingPartList.Add(partObj);
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return new Output<SAPReport, List<oM.Environment.SAP.JSON.ThermalBridge>>() { Item1 = sapObj, Item2 = changes };
        }

        [Description("Modify the Psi value of a type of thermal bridges from a list of thermal bridges.")]
        [Input("tb", "Thermal bridge to modify.")]
        [Input("psiValue", "New PsiValue for thermal bridge.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static BH.oM.Environment.SAP.XML.ThermalBridge ModifyThermalBridge(this BH.oM.Environment.SAP.XML.ThermalBridge tb, double psiValue)
        {
            if (psiValue > 0)
            {
                tb.PsiValue = psiValue;
            }

            return tb;
        }
    }
}

