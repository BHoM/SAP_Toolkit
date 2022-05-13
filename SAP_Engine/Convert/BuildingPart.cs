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
        [Description("Convert lists of SAP BuildingParts to a XML BuildingParts.")]
        [Input("sapBuldingPart","SAP Building parts to convert.")]
        [MultiOutput(0,"xmlBuildingParts", "XML BuildingParts.")]
        [MultiOutput(1, "xmlOpeningTypes", "XML OpeningTypes.")]
        public static Output<BH.oM.Environment.SAP.XML.BuildingParts, BH.oM.Environment.SAP.XML.OpeningTypes> ToXML(this List<oM.Environment.SAP.BuildingPart> sapBuildingPart)
        {
            List<BH.oM.Environment.SAP.XML.BuildingPart> xmlBuildingParts = new List<BH.oM.Environment.SAP.XML.BuildingPart>();
            BH.oM.Environment.SAP.XML.OpeningTypes openingTypes = new oM.Environment.SAP.XML.OpeningTypes();
            for (int i = 0; i < sapBuildingPart.Count; i++)
            {
                BH.oM.Environment.SAP.XML.BuildingPart xmlBuildingPart = new BH.oM.Environment.SAP.XML.BuildingPart();
                xmlBuildingPart.BuildingPartNumber = (i + 1).ToString();
                xmlBuildingPart.Identifier = sapBuildingPart[i].identifier;
                xmlBuildingPart.ConstructionYear = DateTime.Today.Year.ToString();
                xmlBuildingPart.Overshading = sapBuildingPart[i].Overshading.FromSAPToXML();
                List<oM.Environment.SAP.Opening> opening = new List<oM.Environment.SAP.Opening>();
                if (sapBuildingPart[i].Walls.SelectMany(x => x.Openings).ToList() == null && sapBuildingPart[i].Roofs.SelectMany(x => x.Openings).ToList() == null)
                {
                    xmlBuildingPart.Openings = null;
                }

                else
                {
                    opening.AddRange(sapBuildingPart[i].Walls.SelectMany(x => x.Openings).ToList());
                    opening.AddRange(sapBuildingPart[i].Roofs.SelectMany(x => x.Openings).ToList());
                    for (int u = 0; u < opening.Count; u++)
                    {
                        openingTypes.OpeningType.AddRange(opening[u].OpeningType.ToXML().OpeningType); //method to only keep unique ones
                        xmlBuildingPart.Openings = opening.ToXML();
                    }
                }
                List<oM.Environment.SAP.XML.FloorDimension> xmlFloorDimensions = new List<oM.Environment.SAP.XML.FloorDimension>();
                xmlFloorDimensions.Add(ToXML(sapBuildingPart[i].Floor, sapBuildingPart[i].Storeys));
                xmlBuildingPart.Floors = xmlFloorDimensions;
                xmlBuildingPart.Roofs = sapBuildingPart[i].Roofs.Select(x => x.ToXML()).ToList();
                xmlBuildingPart.Walls = sapBuildingPart[i].Walls.Select(x => x.ToXML()).ToList();
                xmlBuildingPart.ThermalBridges = sapBuildingPart[i].ThermalBridges.Select(x => x.ToXML()).ToList();
                xmlBuildingParts.Add(xmlBuildingPart);
            }
            oM.Environment.SAP.XML.BuildingParts finalXML = new oM.Environment.SAP.XML.BuildingParts();
            finalXML.BuildingPart = xmlBuildingParts;
            /*for (int i = 0; i < openingTypes.OpeningType.Count; i++)
            { 
            openingTypes.OpeningType[i].BHoM_Guid
            }*/

            return new Output<BH.oM.Environment.SAP.XML.BuildingParts, BH.oM.Environment.SAP.XML.OpeningTypes>() { Item1 = finalXML, Item2 = openingTypes };
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

