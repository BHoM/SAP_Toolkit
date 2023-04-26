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
        [Description("Convert SAP roof to XML roof.")]
        [Input("sapRoof", "SAP roof to convert.")]
        [MultiOutput(0, "xmlRoof", "XML roof.")]
        [MultiOutput(1, "xmlOpening", "XML opening.")]
        public static Output<BH.oM.Environment.SAP.XML.Roof, List<BH.oM.Environment.SAP.XML.Opening>> ToXML(this BH.oM.Environment.SAP.Roof sapRoof)
        {
            BH.oM.Environment.SAP.XML.Roof xmlRoof = new BH.oM.Environment.SAP.XML.Roof();

            xmlRoof.Name = sapRoof.Name;
            xmlRoof.Description = "Type-" + sapRoof.Type.ToString() + "_Area-" + sapRoof.Area.ToString() + "_Uvalue-" + sapRoof.uValue.ToString();
            xmlRoof.Type = sapRoof.Type.FromSAPToXML();
            xmlRoof.Area = sapRoof.Area.ToString();
            xmlRoof.UValue = sapRoof.uValue.ToString();
            xmlRoof.KappaValue = sapRoof.KappaValue.ToString();
                ;
            List<BH.oM.Environment.SAP.XML.Opening> xmlOpenings = new List<BH.oM.Environment.SAP.XML.Opening>();
            for (int i = 0; i < sapRoof.Openings.Count; i++)
            {
                BH.oM.Environment.SAP.XML.Opening xmlOpening = new BH.oM.Environment.SAP.XML.Opening();
                xmlOpening.Name = sapRoof.Openings[i].Name;
                xmlOpening.Type = sapRoof.Openings[i].OpeningType.Type.ToString();
                xmlOpening.Location = sapRoof.Name;
                xmlOpening.Orientation = sapRoof.Openings[i].Orientation.FromSAPToXML();
                xmlOpening.Width = sapRoof.Openings[i].Width.ToString(); 
                xmlOpening.Height = sapRoof.Openings[i].Height.ToString();
                xmlOpening.Pitch = sapRoof.Pitch.FromSAPToXML();
                xmlOpenings.Add(xmlOpening);
            }

            return new Output<BH.oM.Environment.SAP.XML.Roof, List<BH.oM.Environment.SAP.XML.Opening>>() { Item1 = xmlRoof, Item2 = xmlOpenings };
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfRoof typeOfRoof)
        {
            switch (typeOfRoof)
            {
                case BH.oM.Environment.SAP.TypeOfRoof.ExposedRoof:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfRoof.PartyCeiling:
                    return "4";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.VerticalPitchCode verticalPitchCode)
        {
            switch (verticalPitchCode)
            {
                case BH.oM.Environment.SAP.VerticalPitchCode.Horizontal:
                    return "1";

                case BH.oM.Environment.SAP.VerticalPitchCode._30Degrees:
                    return "2";

                case BH.oM.Environment.SAP.VerticalPitchCode._45Degrees:
                    return "3";

                case BH.oM.Environment.SAP.VerticalPitchCode._60Degrees:
                    return "4";

                case BH.oM.Environment.SAP.VerticalPitchCode.Vertical:
                    return "5";

                default:
                    return "";
            }
        }

    }
}


