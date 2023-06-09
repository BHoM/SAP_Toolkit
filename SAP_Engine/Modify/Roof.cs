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
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the uvalue of roof objects from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of roofs by name to modify.")]
        [Input("newRoofName", "The roof name for the modified roof.")]
        [Input("uvalue", "The new uvalue for the roofs.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyRoofs(this SAPReport sapObj, List<string> include, string newRoofName, string uvalue)
        {
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //Foreach building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.Roof> roofList = new List<BH.oM.Environment.SAP.XML.Roof>();

                //foreach roof object
                foreach (var w in b.Roofs.Roof)
                {
                    BH.oM.Environment.SAP.XML.Roof roofObj = w;

                    //If the name of the roof object is in include(list of roof objects to modify) then modify it.
                    if (include.Contains(w.Description))
                    {
                        roofObj = roofObj.ModifyRoof(uvalue, newRoofName);
                    }

                    roofList.Add(roofObj);
                }

                partObj.Roofs.Roof = roofList;
                buildingPartList.Add (partObj);  
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
        }

        [Description("Modify the uvalue of a type of roof object from a SAP report object.")]
        [Input("roof", "The roof dimension object to modify.")]
        [Input("uvalue", "The new uvalue for the roofs.")]
        [Input("description", "The roof name for the modified roof.")]
        [Output("roof", "The modified SAP Report object.")]
        public static BH.oM.Environment.SAP.XML.Roof ModifyRoof(this BH.oM.Environment.SAP.XML.Roof roof, string uvalue, string description)
        {
            string tempDesc = roof.Description;

            if (uvalue != null)
            {
                roof.UValue = uvalue;
                tempDesc = $"uvalue_{uvalue}_{tempDesc}";
            }

            //If floor description(its name) is null, replace with the string which combines the new uvalue and the name of the new floor.
            roof.Description = (description != null ? description : tempDesc);
           
            return roof;
        }
    }
}

