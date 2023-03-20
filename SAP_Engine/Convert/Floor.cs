///*
// * This file is part of the Buildings and Habitats object Model (BHoM)
// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
// *
// * Each contributor holds copyright over their respective contributions.
// * The project versioning (Git) records all such contribution source information.
// *                                           
// *                                                                              
// * The BHoM is free software: you can redistribute it and/or modify         
// * it under the terms of the GNU Lesser General Public License as published by  
// * the Free Software Foundation, either version 3.0 of the License, or          
// * (at your option) any later version.                                          
// *                                                                              
// * The BHoM is distributed in the hope that it will be useful,              
// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
// * GNU Lesser General Public License for more details.                          
// *                                                                            
// * You should have received a copy of the GNU Lesser General Public License     
// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
// */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Floor to XML floor.")]
        [Input("sapFloor", "SAP floor to convert.")]
        [Input("sapStorey", "SAP storey to convert.")]
        [Output("xmlFloor", "XML floor.")]
        public static BH.oM.Environment.SAP.XML.FloorDimensions ToXML(this List<BH.oM.Environment.SAP.FloorDimension> sapFloorDimensions)
        {
            List<BH.oM.Environment.SAP.XML.FloorDimension> xmlFloors = new List<oM.Environment.SAP.XML.FloorDimension>();

            for (int i = 0; i < sapFloorDimensions.Count; i++)
            {

                BH.oM.Environment.SAP.XML.FloorDimension xmlFloor = new BH.oM.Environment.SAP.XML.FloorDimension();

                xmlFloor.Name = sapFloorDimensions[i].Floor.DwellingName;
                xmlFloor.Description = "Type-" + sapFloorDimensions[i].Floor.Type.ToString() + "_Area-" + sapFloorDimensions[i].Floor.HeatLossArea.ToString() + "_Uvalue-" + sapFloorDimensions[i].Floor.uValue.ToString() + "_Kappavalue-" + sapFloorDimensions[i].Floor.KappaValue.ToString();
                xmlFloor.Type = sapFloorDimensions[i].Floor.Type.FromSAPToXML();
                xmlFloor.HeatLossArea = sapFloorDimensions[i].Floor.HeatLossArea;
                xmlFloor.uValue = sapFloorDimensions[i].Floor.uValue;
                xmlFloor.KappaValue = sapFloorDimensions[i].Floor.KappaValue;
                xmlFloor.KappaValueFromBelow = sapFloorDimensions[i].Floor.KappaValueFromBelow;

                xmlFloor.Storey = sapFloorDimensions[i].Storey.StoreyNumber.ToString();
                xmlFloor.StoreyHeight = sapFloorDimensions[i].Storey.StoreyNumber;
                xmlFloor.Area = sapFloorDimensions[i].Storey.Area;

                xmlFloors.Add(xmlFloor);
            }

            BH.oM.Environment.SAP.XML.FloorDimensions xmlFloorDims = new oM.Environment.SAP.XML.FloorDimensions();
            xmlFloorDims.FloorDimension = xmlFloors;
            return xmlFloorDims;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfFloor typeOfFloor)
        {
            switch (typeOfFloor)
            {
                case BH.oM.Environment.SAP.TypeOfFloor.BasementFloor:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfFloor.GroundFloor:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfFloor.UpperFloor:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfFloor.PartyFloor:
                    return "4";

                default:
                    return "";
            }
        }
    }
}


