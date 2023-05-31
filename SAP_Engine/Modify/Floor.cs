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
using BH.oM.Base.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        
        [Description("Modify the uvalue of a type of floor dimension objects from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of floors by name to modify.")]
        [Input("floorName", "The floor name for the modified floor.")]
        [Input("uvalue", "The new uvalue for the floors.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyFloors(this SAPReport sapObj, List<string> include, string floorName, string uvalue)
        {
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //Foreach building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.FloorDimension> floorList = new List<BH.oM.Environment.SAP.XML.FloorDimension>();

                //foreach floordimension object
                foreach (var w in b.FloorDimensions.FloorDimension)
                {
                    BH.oM.Environment.SAP.XML.FloorDimension floorObj = w;

                    if (include.Contains(w.Description))
                    {
                        floorObj = floorObj.ModifyFloor(uvalue,floorName);
                    }

                    floorList.Add(floorObj);
                }

                partObj.FloorDimensions.FloorDimension = floorList;
                buildingPartList.Add (partObj);  
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
        }

        [Description("Modify the uvalue of a type of floor object from a SAP report object.")]
        [Input("floor", "The floor dimension object to modify.")]
        [Input("description", "The floor name for the modified floor.")]
        [Input("uvalue", "The new uvalue for the floors.")]
        [Output("floorDim", "The modified SAP Report object.")]
        public static BH.oM.Environment.SAP.XML.FloorDimension ModifyFloor(this BH.oM.Environment.SAP.XML.FloorDimension floor, string uvalue, string description)
        {
            string tempDesc = floor.Description;

            if (uvalue != null)
            {
                floor.UValue= uvalue;
                tempDesc = $"uvalue_{uvalue}_{tempDesc}";
            }

            if (description != null)
            {
                floor.Description= description;
            }
            else
            {
                floor.Description = tempDesc;
            }

            return floor;
        }
    }
}

