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
        [Description("Convert SAP thermal bridge to XML thermal bridge.")]
        [Input("sapThermalBridge", "SAP thermal bridge to convert.")]
        [Output("xmlThermalBridge", "XML thermal bridge.")]
        public static BH.oM.Environment.SAP.XML.ThermalBridge ToXML(this BH.oM.Environment.SAP.ThermalBridge sapThermalBridge)
        {
            BH.oM.Environment.SAP.XML.ThermalBridge xmlThermalBridge = new BH.oM.Environment.SAP.XML.ThermalBridge();
            xmlThermalBridge.Type = sapThermalBridge.Reference.FromSAPToXML();
            xmlThermalBridge.Length = sapThermalBridge.Length;
            xmlThermalBridge.PsiValue = sapThermalBridge.PsiValue;
            xmlThermalBridge.PsiSource = sapThermalBridge.Source;

            return xmlThermalBridge;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfThermalBridge typeOfThermalBridge)
        {
            switch (typeOfThermalBridge)
            {
                case BH.oM.Environment.SAP.TypeOfThermalBridge.NotDefined:
                    return "";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.SteelLintelWithPerforatedBase:
                    return "E1";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.OtherLintel:
                    return "E2";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Sill:
                    return "E3";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Jamb:
                    return "E4";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.GroundFloor_Normal:
                    return "E5";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.IntermediateFloorWithinDwelling:
                    return "E6";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.PartyFloorBetweenDwellings:
                    return "E7";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.BalconyWithinDwelling_InsulationContinous:
                    return "E8";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.BalconyBetweenDwellings_InsulationContinous:
                    return "E9";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Eaves_InsulationAtCeiling:
                    return "E10";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Eaves_InsulationAtRafters:
                    return "E11";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Gable_InsulationAtCeiling:
                    return "E12";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Gable_InsulationAtRafter:
                    return "E13";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.FlatRoof:
                    return "E14";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.FlatRoofWithParapet:
                    return "E15";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Corner_Normal:
                    return "E16";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Corner_Inverted:
                    return "E17";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.PartyWallBetweenDwellings:
                    return "E18";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.GroundFloor_Inverted:
                    return "E19";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.ExposedFloor_Normal:
                    return "E20";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.ExposedFloor_Inverted:
                    return "E21";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.BasementFloor:
                    return "E22";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Balcony_SupportPenetratesWallInsulation:
                    return "E23";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Eaves_InsulationAtCeiling_Inverted:
                    return "E24";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.StaggeredPartyWall:
                    return "E25";

                default:
                    return "";
            }
        }
    }
}

