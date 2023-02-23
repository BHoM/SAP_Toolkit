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
using BH.oM.Environment.SAP.Stroma10;

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
            xmlThermalBridge.PsiSource = sapThermalBridge.Source.FromSAPToXML();

            return xmlThermalBridge;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfThermalBridge typeOfThermalBridge)
        {
            switch (typeOfThermalBridge)
            {
                case BH.oM.Environment.SAP.TypeOfThermalBridge.NotDefined:
                    return "ND";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.SteelLintelWithPerforatedSteelBasePlate:
                    return "E1";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.OtherLintels:
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

                case BH.oM.Environment.SAP.TypeOfThermalBridge.BalconyWithinADwelling:
                    return "E8";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.BalconyBetweenDwellings:
                    return "E9";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Eaves_InsulationAtCeilingLevel:
                    return "E10";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Eaves_InsulationAtRafterLevel:
                    return "E11";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Gable_InsulationAtCeilingLevel:
                    return "E12";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Gable_InsulationAtRafterLevel:
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

                case BH.oM.Environment.SAP.TypeOfThermalBridge.BalconyWithinOrBetweenDwellings:
                    return "E23";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Eaves_InsulationAtCeilingLevel_Inverted:
                    return "E24";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.StaggeredPartyWall:
                    return "E25";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.GroundFloor:
                    return "P1";

                case oM.Environment.SAP.TypeOfThermalBridge.IntermediateFloorWithinADwelling:
                    return "P2";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.IntermediateFloorBetweenDwellings:
                    return "P3";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Roof_InsulationAtCeilingLevel:
                    return "P4";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Roof_InsulationAtRafterLevel:
                    return "P5";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.HeadOfRoofWindow:
                    return "R1";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.SillOfRoofWindow:
                    return "R2";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.JambOfRoofWindow:
                    return "R3";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Ridge_VaultedCeiling:
                    return "R4";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.Ridge_Inverted:
                    return "R5";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.FlatCeiling:
                    return "R6";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.FlatCeiling_Inverted:
                    return "R7";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.RoofToWall_Rafter:
                    return "R8";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.RoofToWall_FlatCeiling:
                    return "R9";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.AllOtherRoofOrRoomInRoofJunctions:
                    return "R10";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.UpstandsOfRooflights:
                    return "R11";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.OtherType1:
                    return "O1";

                case BH.oM.Environment.SAP.TypeOfThermalBridge.OtherType2:
                    return "O2";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.PsiSourceCode psiSourceCode)
        {
            switch (psiSourceCode)
            {
                case BH.oM.Environment.SAP.PsiSourceCode.CalculatedByPersonWithSuitableExpertise:
                    return "1";

                case BH.oM.Environment.SAP.PsiSourceCode.GovernmentApprovedScheme:
                    return "2";

                case BH.oM.Environment.SAP.PsiSourceCode.NotGovernmentApprovedScheme:
                    return "3";

                case BH.oM.Environment.SAP.PsiSourceCode.SAPTableDefault:
                    return "4";

                default:
                    return "";
            }
        }


    }
}

