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

using BH.oM.Environment.SAP.JSON;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the uvalue of roof objects from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of roofs by name to modify.")]
        [Input("uvalue", "The new uvalue for the roofs.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToRoofs", "Tracking the changes made to the uvalue of the roofs.")]
        public static Output<SAPReport, List<UValue>> ModifyRoofs(this SAPReport sapObj, List<string> include, double uvalue = -1)
        {
            if (uvalue < 0)
            {
                return new Output<SAPReport, List<UValue>>() { Item1 = sapObj, Item2 = null };
            }
            //New empty list of building parts
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //QA file - tracking changes to uvalue of roof
            List<UValue> changes = new List<UValue>();

            //Foreach existing building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;

                //New empty list of roof objects.
                List<BH.oM.Environment.SAP.XML.Roof> roofList = new List<BH.oM.Environment.SAP.XML.Roof>();

                //foreach roof object
                foreach (var r in b.Roofs.Roof)
                {
                    BH.oM.Environment.SAP.XML.Roof roofObj = r;

                    //If the name of the roof object is in include(list of roof objects to modify) then modify it.
                    if (include.Contains(r.Description))
                    {
                        //QA file
                        UValue roofChanges = new UValue
                        {
                            Type = r.Type, Name = r.Description
                        };
                        roofChanges.Uvalue = new Changes { Initial = r.UValue, Final = uvalue.ToString() };
                        changes.Add(roofChanges);

                        //Modification to roof uvalue
                        roofObj = roofObj.ModifyRoof(uvalue);
                    }

                    //Add roof (modified or not) to the list of floor
                    roofList.Add(roofObj);
                }
                //Add the list of roofs into the building part.
                partObj.Roofs.Roof = roofList;

                //Add the building part to the list of building part list.
                buildingPartList.Add (partObj);  
            }

            //Add the list of building parts to the SAP report.
            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return new Output<SAPReport, List<UValue>>() { Item1 = sapObj, Item2 = changes };
        }

        [Description("Modify the uvalue of a type of roof object from a SAP report object.")]
        [Input("roof", "The roof dimension object to modify.")]
        [Input("uvalue", "The new uvalue for the roofs.")]
        [Output("roof", "The modified SAP Report object.")]
        public static BH.oM.Environment.SAP.XML.Roof ModifyRoof(this BH.oM.Environment.SAP.XML.Roof roof, double uvalue)
        {
            if (uvalue > -1)
            {
                roof.UValue = uvalue.ToString();
            }

            return roof;
        }
    }
}

