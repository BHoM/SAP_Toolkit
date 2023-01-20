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

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP wall to XML wall.")]
        [Input("sapWall", "SAP wall to convert.")]
        [MultiOutput(0, "xmlWall", "XML wall.")]
        [MultiOutput(1, "xmlOpening", "XML opening.")]
        public static Output<BH.oM.Environment.SAP.XML.Wall, List<BH.oM.Environment.SAP.XML.Opening>> ToXML(this BH.oM.Environment.SAP.Wall sapWall)
        {
            BH.oM.Environment.SAP.XML.Wall xmlWall = new BH.oM.Environment.SAP.XML.Wall();
            xmlWall.Name = sapWall.Name;
            xmlWall.Description = "Type-" + sapWall.Type.ToString() + "_Area-" + sapWall.Area.ToString() + "_Uvalue-" + "0.18";// summary of inputs type_area_uvalue
            xmlWall.Type = sapWall.Type.FromSAPToXMLNumber();
            xmlWall.Area = sapWall.Area;
            xmlWall.UValue = sapWall.uValue;
            xmlWall.KappaValue = 14;
            xmlWall.CurtainWall = sapWall.CurtainWall;
            List<BH.oM.Environment.SAP.XML.Opening> xmlOpenings = new List<BH.oM.Environment.SAP.XML.Opening>();
            for (int i = 0; i < sapWall.Openings.Count; i++)
            {
                BH.oM.Environment.SAP.XML.Opening xmlOpening = new BH.oM.Environment.SAP.XML.Opening();
                xmlOpening.Name = sapWall.Openings[i].Name;
                xmlOpening.Type = sapWall.Openings[i].OpeningType.Type.ToString();
                xmlOpening.Location = sapWall.Name;
                xmlOpening.Orientation = sapWall.Openings[i].Orientation.FromSAPToXMLNumber();
                xmlOpening.Width = Math.Sqrt(sapWall.Openings[i].Area).ToString();
                xmlOpening.Height = Math.Sqrt(sapWall.Openings[i].Area).ToString();
                xmlOpenings.Add(xmlOpening);
            }
            return new Output<BH.oM.Environment.SAP.XML.Wall, List<BH.oM.Environment.SAP.XML.Opening>>() { Item1 = xmlWall, Item2 = xmlOpenings };
        }
        private static string FromSAPToXMLNumber(this BH.oM.Environment.SAP.TypeOfWall typeOfWall)
        {
            switch (typeOfWall)
            {
                case BH.oM.Environment.SAP.TypeOfWall.BasementWall:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfWall.ExposedWall:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfWall.ShelteredWall:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfWall.PartyWall:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfWall.InternalWall:
                    return "5";

                default:
                    return "";
            }
        }
    }
}


