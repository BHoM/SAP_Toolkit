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

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the Psi value of a type of thermal bridges from a report object.")]
        public static SAPReport ModifyThermalBridge(this SAPReport sapObj, List<string> tbType, List<double> psiValue)
        {
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;

                partObj.ThermalBridges.ThermalBridge = partObj.ThermalBridges.ThermalBridge.ModifyThermalBridge(tbType, psiValue);

                buildingPartList.Add (partObj);  
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
        }

        [Description("Modify the Psi value of a type of thermal bridges from a list of thermal bridges.")]
        public static List<BH.oM.Environment.SAP.XML.ThermalBridge> ModifyThermalBridge(this List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridgesObj, List<string> tbType, List<double> psiValue)
        {
            var dict = tbType.Zip(psiValue, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            List<BH.oM.Environment.SAP.XML.ThermalBridge> thermalBridgeList = new List<BH.oM.Environment.SAP.XML.ThermalBridge>();

            foreach (var t in thermalBridgesObj)
            {
                BH.oM.Environment.SAP.XML.ThermalBridge tbObj = t;
                if (dict.ContainsKey(t.Type))
                {
                    tbObj.PsiValue = dict[tbObj.Type];
                }

                thermalBridgeList.Add(tbObj);
            }

            return thermalBridgeList;
        }
    }
}

