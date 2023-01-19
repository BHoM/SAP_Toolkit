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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using BH.oM.Base.Attributes;
//using BH.oM.Base;

//namespace BH.Engine.Environment.SAP
//{
//    public static partial class Convert
//    {
//        [Description("Convert SAP roof to XML roof.")]
//        [Input("sapRoof", "SAP roof to convert.")]
//        [MultiOutput(0,"xmlRoof", "XML roof.")]
//        [MultiOutput(1, "xmlOpening", "XML opening.")]
//        public static Output<BH.oM.Environment.SAP.XML.Roof, List<BH.oM.Environment.SAP.XML.Opening>> ToXML(this BH.oM.Environment.SAP.Roof sapRoof)
//        {
//            BH.oM.Environment.SAP.XML.Roof xmlRoof = new BH.oM.Environment.SAP.XML.Roof();
//            xmlRoof.Name = sapRoof.Name;
//            xmlRoof.Description = "Type-" + sapRoof.Type.ToString() + "_Area-" + sapRoof.Area.ToString() + "_Uvalue-" + "0.13"; ;
//            xmlRoof.Type = sapRoof.Type.FromSAPToXMLNumber();
//            xmlRoof.Area = sapRoof.Area;
//            xmlRoof.UValue = sapRoof.uValue;
//            xmlRoof.KappaValue = 9;
//            List<BH.oM.Environment.SAP.XML.Opening> xmlOpenings = new List<BH.oM.Environment.SAP.XML.Opening>();
//            for (int i = 0; i < sapRoof.Openings.Count; i++)
//            {
//                BH.oM.Environment.SAP.XML.Opening xmlOpening = new BH.oM.Environment.SAP.XML.Opening();
//                xmlOpening.Name = sapRoof.Openings[i].Name;
//                xmlOpening.Type = sapRoof.Openings[i].OpeningType.Type.ToString();
//                xmlOpening.Location = sapRoof.Name;
//                xmlOpening.Orientation = sapRoof.Openings[i].Orientation.FromSAPToXMLNumber();
//                xmlOpening.Width = Math.Sqrt(sapRoof.Openings[i].Area).ToString();
//                xmlOpening.Height = Math.Sqrt(sapRoof.Openings[i].Area).ToString();
//                xmlOpenings.Add(xmlOpening);
//            }

//            return new Output<BH.oM.Environment.SAP.XML.Roof, List<BH.oM.Environment.SAP.XML.Opening>>() { Item1 = xmlRoof, Item2 = xmlOpenings };
//        }
//        private static string FromSAPToXMLNumber(this BH.oM.Environment.SAP.TypeOfRoof typeOfRoof)
//        {
//            switch (typeOfRoof)
//            {
//                case BH.oM.Environment.SAP.TypeOfRoof.ExposedRoof:
//                    return "2";

//                case BH.oM.Environment.SAP.TypeOfRoof.PartyCieling:
//                    return "4";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXMLNumber(this BH.oM.Environment.SAP.OrientationCode orientationCode)
//        {
//            switch (orientationCode)
//            {
//                case BH.oM.Environment.SAP.OrientationCode.unknown:
//                    return "0";

//                case BH.oM.Environment.SAP.OrientationCode.North:
//                    return "1";

//                case BH.oM.Environment.SAP.OrientationCode.NorthEast:
//                    return "2";

//                case BH.oM.Environment.SAP.OrientationCode.East:
//                    return "3";

//                case BH.oM.Environment.SAP.OrientationCode.SouthEast:
//                    return "4";

//                case BH.oM.Environment.SAP.OrientationCode.South:
//                    return "5";

//                case BH.oM.Environment.SAP.OrientationCode.SouthWest:
//                    return "6";

//                case BH.oM.Environment.SAP.OrientationCode.West:
//                    return "7";

//                case BH.oM.Environment.SAP.OrientationCode.NorthWest:
//                    return "8";

//                case BH.oM.Environment.SAP.OrientationCode.Horizontal:
//                    return "9";

//                default:
//                    return "";
//            }
//        }
//    }
//}


