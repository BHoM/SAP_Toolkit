/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert lists of SAP Objects to a XML BuildingPart.")]
        [Input("buildingPartNumber", ">An integer value which uniquely identifies the building part in the property.  The value 1 must be assigned to the main dwelling.")]
        [Input("identifier", "Identifier for the Building part - generally only required if there are more that one Building Parts of the same type e.g. West Wing and East Wing Extensions.")]
        [Input("constructionYear", "The year when this building part was constructed.")]
        [Input("sapOpenings", "List of SAP openings to convert.")]
        [Input("sapFloors", "List of SAP floors to convert.")]
        [Input("sapRoofs", "List of SAP roofs to convert.")]
        [Input("sapWalls", "List of SAP walls to convert.")]
        [Input("sapThermalBridges", "List of SAP thermal bridges to convert.")]
        [Output("xmlBuildingPart", "XML BuildingPart.")]
        public static BH.oM.Environment.SAP.XML.BuildingPart ToXML(string buildingPartNumber = "1", string identifier = "Main dwelling", string constructionYear = "2021", BH.oM.Environment.SAP.WindowOvershading overshading = BH.oM.Environment.SAP.WindowOvershading.AverageOrUnknown, List<BH.oM.Environment.SAP.Opening> sapOpenings = null, List<BH.oM.Environment.SAP.Floor> sapFloors = null, List<BH.oM.Environment.SAP.Roof> sapRoofs = null, List<BH.oM.Environment.SAP.Wall> sapWalls = null, List<BH.oM.Environment.SAP.ThermalBridge> sapThermalBridges= null)
        {
            BH.oM.Environment.SAP.XML.BuildingPart xmlBuildingPart = new BH.oM.Environment.SAP.XML.BuildingPart();
            xmlBuildingPart.BuildingPartNumber = buildingPartNumber; 
            xmlBuildingPart.Identifier = identifier;
            xmlBuildingPart.ConstructionYear = constructionYear;
            xmlBuildingPart.Overshading = overshading.FromSAPToXML();
            xmlBuildingPart.Openings = sapOpenings.Select(x => x.ToXML()).ToList();
            xmlBuildingPart.Floors = sapFloors.Select(x => x.ToXML()).ToList();
            xmlBuildingPart.Roofs = sapRoofs.Select(x => x.ToXML()).ToList();
            xmlBuildingPart.Walls = sapWalls.Select(x => x.ToXML()).ToList();
            xmlBuildingPart.ThermalBridges = sapThermalBridges.Select(x => x.ToXML()).ToList();

            return xmlBuildingPart;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.WindowOvershading windowOvershading)
        {
            switch (windowOvershading)
            {
                case BH.oM.Environment.SAP.WindowOvershading.VeryLittle:
                    return "1";

                case BH.oM.Environment.SAP.WindowOvershading.AverageOrUnknown:
                    return "2";

                case BH.oM.Environment.SAP.WindowOvershading.MoreThanAverage:
                    return "3";

                case BH.oM.Environment.SAP.WindowOvershading.Heavy:
                    return "4";

                default:
                    return "";
            }
        }
    }
}

