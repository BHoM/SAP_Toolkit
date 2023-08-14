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
using BH.oM.Base;
using BH.oM.Environment.SAP.JSON;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify the uvalue and if it is a curtain wall of wall objects from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("include", "A list of walls by name to modify.")]
        [Input("uvalue", "The new uvalue for the walls.")]
        [Input("curtainWall", "Is this wall a curtain wall.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToWalls", "Tracking the changes made to the uvalue, and the curtain wall status of the floors.")]
        public static Output<SAPReport, List<oM.Environment.SAP.JSON.Wall>> ModifyWalls(this SAPReport sapObj, List<string> include, double uvalue = -1, bool? curtainWall = null)
        {
            //Null handling
            if (sapObj == null || include == null || (uvalue < 0 && curtainWall == null))
            {
                return new Output<SAPReport, List<oM.Environment.SAP.JSON.Wall>>() { Item1 = sapObj, Item2 = null };
            }

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            //QA file - tracking changes to the uvalue and curtain wall values for the walls
            List<oM.Environment.SAP.JSON.Wall> changes = new List<oM.Environment.SAP.JSON.Wall>();

            //Foreach building part
            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.Wall> wallList = new List<BH.oM.Environment.SAP.XML.Wall>();

                //foreach wall object
                foreach (var w in b.Walls.Wall)
                {
                    BH.oM.Environment.SAP.XML.Wall wallObj = w;

                    //If the name of the wall object is in include(list of wall objects to modify) then modify it.
                    if (include.Contains(w.Description))
                    {
                        //QA file
                        oM.Environment.SAP.JSON.Wall wallChanges = new oM.Environment.SAP.JSON.Wall
                        {
                            Type = w.Type, Name = w.Description 
                        };

                        wallChanges.Uvalue = (uvalue > 0 ? new Changes { Initial = w.UValue, Final = uvalue.ToString() } : null);
                        wallChanges.CurtainWall = (curtainWall != null ? new Changes { Initial = w.CurtainWall.ToString(), Final = curtainWall.ToString() } : null);

                        changes.Add(wallChanges);

                        //Modification of properties of wall
                        wallObj = wallObj.ModifyWall(uvalue, curtainWall);
                    }

                    wallList.Add(wallObj);
                }

                partObj.Walls.Wall = wallList;
                buildingPartList.Add (partObj);  
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return new Output<SAPReport, List<oM.Environment.SAP.JSON.Wall>>() { Item1 = sapObj, Item2 = changes };
        }

        [Description("Modify the uvaluev and if it is a curtain wall of a wall object.")]
        [Input("wall", "The wall object to modify.")]
        [Input("uvalue", "The new uvalue for the walls.")]
        [Input("curtainWall", "Is this wall a curtain wall.")]
        [Output("wall", "The modified wall object.")]
        public static BH.oM.Environment.SAP.XML.Wall ModifyWall(this BH.oM.Environment.SAP.XML.Wall wall, double uvalue, bool? curtainWall)
        {
            if (uvalue > 0)
            {
                wall.UValue = uvalue.ToString();
            }

            if (curtainWall != null)
            {
                wall.CurtainWall = (bool)curtainWall;
            }

            return wall;
        }
    }
}

