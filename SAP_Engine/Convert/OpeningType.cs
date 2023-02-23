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
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP opening type to XML opening types.")]
        [Input("sapOpeningType", "SAP opening type to convert.")]
        [Output("xmlOpeningTypes", "XML opening types.")]
        public static BH.oM.Environment.SAP.XML.OpeningTypes ToXML(this BH.oM.Environment.SAP.OpeningType sapOpeningtype)
        {
            List<oM.Environment.SAP.XML.OpeningType> xmlOpeningTypes = new List<oM.Environment.SAP.XML.OpeningType>();


            BH.oM.Environment.SAP.XML.OpeningType xmlOpeningType = new BH.oM.Environment.SAP.XML.OpeningType();
            xmlOpeningType.Name = sapOpeningtype.Name;
            xmlOpeningType.Description = "Type-" + sapOpeningtype.Type.ToString() + "_Uvalue-" + sapOpeningtype.uValue.ToString(); ;
            xmlOpeningType.DataSource = sapOpeningtype.DataSource.FromSAPToXML();
            xmlOpeningType.Type = sapOpeningtype.Type.FromSAPToXML();
            xmlOpeningType.GlazingType = sapOpeningtype.GlazingType.FromSAPToXML();
            xmlOpeningType.GlazingGap = sapOpeningtype.GlazingGap.FromSAPToXML();
            xmlOpeningType.FrameType = sapOpeningtype.FrameType.FromSAPToXML();
            xmlOpeningType.gValue = sapOpeningtype.gValue;
            xmlOpeningType.FrameFactor = sapOpeningtype.FrameFactor;
            xmlOpeningType.uValue = sapOpeningtype.uValue;
            xmlOpeningTypes.Add(xmlOpeningType);
            //Is argon filleD/is krypton filled

            oM.Environment.SAP.XML.OpeningTypes finalXML = new oM.Environment.SAP.XML.OpeningTypes();
            finalXML.OpeningType = xmlOpeningTypes;
            return finalXML;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfOpening typeOfOpening)
        {
            switch (typeOfOpening)
            {
                case BH.oM.Environment.SAP.TypeOfOpening.SolidDoor:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfOpening.SemiGlazedDoor:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfOpening.DoorToCorridor:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfOpening.Window:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfOpening.RoofWindow:
                    return "5";

                case BH.oM.Environment.SAP.TypeOfOpening.Rooflight:
                    return "6";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this GlazingGap glazingGap)
        {
            switch (glazingGap)
            {
                case GlazingGap._6mm:
                    return "1";

                case GlazingGap._12mm:
                    return "1";

                case GlazingGap._16mmOrMore:
                    return "2";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this TypeOfFrame typeOfFrame)
        {
            switch (typeOfFrame)
            {
                case TypeOfFrame.Wood:
                    return "1";

                case TypeOfFrame.PVC:
                    return "2";

                case TypeOfFrame.MetalNoBreak:
                    return "3";

                case TypeOfFrame.Metal4mmBreak:
                    return "4";

                case TypeOfFrame.Metal8mmBreak:
                    return "5";

                case TypeOfFrame.Metal12mmBreak:
                    return "6";

                case TypeOfFrame.Metal20mmBreak:
                    return "7";

                case TypeOfFrame.Metal32mmBreak:
                    return "8";

                case TypeOfFrame.Unknown:
                    return "9";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this OpeningDataSource dataSource)
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
        private static string FromSAPToXML(this TypeOfGlazing glazingType)
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


