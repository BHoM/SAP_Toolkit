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
        [Description("Modify pitch of an opening from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of openings by name to modify.")]
        [Input("height", "New height for the windows.")]
        [Input("width", "New width for windows.")]
        [Input("pitch", "New pitch for windows.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyOpenings(this SAPReport sapObj, List<string> include, string height, string width, string pitch)
        {
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //Foreach building part in the dwelling
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.Opening> openingList = new List<oM.Environment.SAP.XML.Opening>();

                //Foreach opening
                foreach (var o in b.Openings.Opening)
                {
                    BH.oM.Environment.SAP.XML.Opening openingObj = o;

                    //If the opening object type is in include(list of opening Types to modify) then modify it.
                    if (include.Contains(o.Type)) //change based on example
                    {
                        openingObj = openingObj.ModifyOpening(height, width, pitch);
                    }

                    openingList.Add(openingObj);
                }

                partObj.Openings.Opening = openingList;
                buildingPartList.Add(partObj);
            }
            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
        }

        [Description("Change the width and height and pitch of opening.")]
        [Input("opening", "The sap opening object to modify.")]
        [Input("height", "New height for the windows.")]
        [Input("width", "New width for windows.")]
        [Input("pitch", "New pitch for windows.")]
        [Output("opening", "The modified SAP opening object.")]
        public static BH.oM.Environment.SAP.XML.Opening ModifyOpening(this BH.oM.Environment.SAP.XML.Opening opening, string height, string width, string pitch)
        {
            if (height != null)
            {
                opening.Height = height;
            }

            if (width != null)
            {
                opening.Width = width;
            }

            if (pitch != null)
            {
                opening.Pitch = pitch;
            }

            return opening;
        }
    }
}