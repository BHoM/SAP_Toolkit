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
using BH.oM.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the uvalue of a floor dimension objects from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of floors by name to modify.")]
        [Input("uvalue", "The new uvalue for the floors.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyFloors(this SAPReport sapObj, List<string> include, double uvalue = -1)
        {
            //New empty list of building parts
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //Foreach existing building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;

                //New empty list of Floor Dimension objects.
                List<BH.oM.Environment.SAP.XML.FloorDimension> floorList = new List<BH.oM.Environment.SAP.XML.FloorDimension>();

                //foreach floor-dimension object.
                foreach (var f in b.FloorDimensions.FloorDimension)
                {
                    BH.oM.Environment.SAP.XML.FloorDimension floorObj = f;

                    //If the name of the floor is in include then modify floor as specified in input.
                    if (include.Contains(f.Description))
                    {
                        floorObj = floorObj.ModifyFloor(uvalue);
                    }

                    //Add floor (modified or not) to the list of floor
                    floorList.Add(floorObj);
                }

                //Add the list of floors into the building part.
                partObj.FloorDimensions.FloorDimension = floorList;

                //Add the building part to the list of building part list.
                buildingPartList.Add (partObj);  
            }

            //Add the list of building parts to the SAP report.
            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
        }

        [Description("Modify the uvalue of a type of floor object from a SAP report object.")]
        [Input("floor", "The floor dimension object to modify.")]
        [Input("uvalue", "The new uvalue for the floors.")]
        [Output("floorDim", "The modified SAP Report object.")]
        public static BH.oM.Environment.SAP.XML.FloorDimension ModifyFloor(this BH.oM.Environment.SAP.XML.FloorDimension floor, double uvalue)
        {
            //If uvalue is valid
            if (uvalue > 0)
            {
                floor.UValue = uvalue.ToString();
            }

            return floor;
        }
    }
}

