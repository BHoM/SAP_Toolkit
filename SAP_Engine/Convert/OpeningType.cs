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
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP opening type to XML opening types.")]
        [Input("sapOpeningType", "SAP opening type to convert.")]
        [Output("xmlOpeningTypes", "XML opening types.")]
        public static BH.oM.Environment.SAP.XML.OpeningTypes ToXML(this List<BH.oM.Environment.SAP.OpeningType> sapOpeningtype)
        {
            List<oM.Environment.SAP.XML.OpeningType> xmlOpeningTypes = new List<oM.Environment.SAP.XML.OpeningType>();
            for (int i = 0; i < sapOpeningtype.Count; i++)
            {
                BH.oM.Environment.SAP.XML.OpeningType xmlOpeningType = new BH.oM.Environment.SAP.XML.OpeningType();
                xmlOpeningType.Name = sapOpeningtype[i].Name;
                xmlOpeningType.Description = "Type-" + sapOpeningtype[i].Type.ToString() + "_Uvalue-" + sapOpeningtype[i].uValue.ToString(); ;
                xmlOpeningType.DataSource = sapOpeningtype[i].DataSource.FromSAPToXMLData();
                xmlOpeningType.Type = sapOpeningtype[i].Type.FromSAPToXMLNumber();
                xmlOpeningType.GlazingType = sapOpeningtype[i].GlazingType.FromSAPToXMLGlazing();
                xmlOpeningType.gValue = sapOpeningtype[i].gValue;
                xmlOpeningType.FrameFactor = sapOpeningtype[i].FrameFactor;
                xmlOpeningType.uValue = sapOpeningtype[i].uValue;
                xmlOpeningTypes.Add(xmlOpeningType);
            }
            oM.Environment.SAP.XML.OpeningTypes finalXML = new oM.Environment.SAP.XML.OpeningTypes();
            finalXML.OpeningType = xmlOpeningTypes;
            return finalXML;
        }
        private static string FromSAPToXMLNumber(this TypeOfOpening typeOfOpening)
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
        private static string FromSAPToXMLData(this OpeningDataSource dataSource)
        {
            switch (dataSource)
            {
                case OpeningDataSource.ManufacturerDeclaration:
                    return "2";

                case OpeningDataSource.SAPtable:
                    return "3";

                case OpeningDataSource.BFRCdata:
                    return "4";

                default:
                    return "";
            }
        }
        private static string FromSAPToXMLGlazing(this TypeOfGlazing glazingType)
        {
            switch (glazingType)
            {
                case TypeOfGlazing.NotAppicable:
                    return "1";

                case TypeOfGlazing.Single:
                    return "2";

                case TypeOfGlazing.Double:
                    return "3";
                
                case TypeOfGlazing.DoubleLowEHard02:
                    return "4";

                case TypeOfGlazing.DoubleLowEHard015:
                    return "5";

                case TypeOfGlazing.DoubleLowESoft01:
                    return "6";

                case TypeOfGlazing.DoubleLowESoft005:
                    return "7";

                case TypeOfGlazing.Triple:
                    return "8";

                case TypeOfGlazing.TripleLowEHard02:
                    return "9";

                case TypeOfGlazing.TripleLowEHard015:
                    return "10";

                case TypeOfGlazing.TripleLowESoft01:
                    return "11";

                case TypeOfGlazing.TripleLowESoft005:
                    return "12";

                case TypeOfGlazing.SecondaryGlazing:
                    return "13";

                default:
                    return "";
            }
        }
    }
}

