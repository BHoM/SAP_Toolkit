/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Reflection.Attributes;


namespace BH.oM.Environment.SAP.Convert
{
    public static partial class Convert
    {
        [Description("Convert SAP openingtype to XML openingtype.")]
        [Input("openingType", "SAP openingtype to convert.")]
        [Output("openingType", "XML openingtype.")]
        public static BH.oM.Environment.SAP.XML.OpeningType xmlOpeningtype(this BH.oM.Environment.SAP.OpeningType sapOpeningtype)
        {
            BH.oM.Environment.SAP.XML.OpeningType xmlOpeningType = new BH.oM.Environment.SAP.XML.OpeningType();
            xmlOpeningType.Name = sapOpeningtype.Name;
            xmlOpeningType.Description = FromSAPToXML(sapOpeningtype.Type);
            xmlOpeningType.DataSource = "2"; //manufacturer declaration
            xmlOpeningType.Type = sapOpeningtype.Type.FromSAPToXMLNumber(); //Type of opening
            xmlOpeningType.GlazingType = "4"; //1-13, 4 being double low-E hard 0.2
            xmlOpeningType.gValue = sapOpeningtype.gValue;
            xmlOpeningType.FrameFactor = sapOpeningtype.FrameFactor;
            xmlOpeningType.uValue = sapOpeningtype.uValue;
            return xmlOpeningType;
        }

        public static string FromSAPToXMLNumber(this TypeOfOpening typeOfOpening)
        {
            switch(typeOfOpening)
            {
                case TypeOfOpening.SolidDoor:
                    return "0";

                case TypeOfOpening.HalfGlazedDoor:
                    return "1";

                case TypeOfOpening.GlazedWindow:
                    return "2";

                case TypeOfOpening.Rooflight:
                    return "3";

                default:
                    return "";
            }
        }

        public static string FromSAPToXML(this TypeOfOpening typeOfOpening)
        {
            switch (typeOfOpening)
            {
                case TypeOfOpening.SolidDoor:
                    return "Solid door";

                case TypeOfOpening.HalfGlazedDoor:
                    return "Half glazed door";

                case TypeOfOpening.GlazedWindow:
                    return "Glazed window";

                case TypeOfOpening.Rooflight:
                    return "Rooflight";

                default:
                    return "";
            }
        }
                
    }
}
