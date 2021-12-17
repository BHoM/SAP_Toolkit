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

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP ventilation to XML ventilation.")]
        [Input("sapVentilation", "SAP ventilation to convert.")]
        [Output("xmlVentilation", "XML ventilation.")]
        public static BH.oM.Environment.SAP.XML.Ventilation ToXML(this BH.oM.Environment.SAP.VentilationRates sapVentilation)
        {
            BH.oM.Environment.SAP.XML.Ventilation xmlVentilation = new BH.oM.Environment.SAP.XML.Ventilation();

            xmlVentilation.numOpenFireplaces = sapVentilation.numOpenFireplaces;
            xmlVentilation.numOpenFlues = sapVentilation.numOpenFlues;
            xmlVentilation.numFluelessGasFires = sapVentilation.numFluelessGasFires;
            if (sapVentilation.PressureTest.NoPressureTest.Type == null && sapVentilation.PressureTest.Made.Type == null)
            {
                xmlVentilation.PressureTest = null;
            }
            else if (sapVentilation.PressureTest.Made.Type == null)
            {
                xmlVentilation.PressureTest = sapVentilation.PressureTest.NoPressureTest.Type.FromSAPToXML();
            }
            else if (sapVentilation.PressureTest.NoPressureTest.Type == null)
            {
                xmlVentilation.PressureTest = sapVentilation.PressureTest.Made.Type.FromSAPToXML();
            }
            
            xmlVentilation.AirPermability = sapVentilation.PressureTest.Made.AirPermability;
            xmlVentilation.GroundFloorType = sapVentilation.PressureTest.NoPressureTest.GroundFloorType;
            xmlVentilation.WallType = sapVentilation.PressureTest.NoPressureTest.WallType;
            xmlVentilation.HasDraughtLobby = sapVentilation.PressureTest.NoPressureTest.HasDraughtLobby;
            xmlVentilation.DraughtStripping = sapVentilation.PressureTest.NoPressureTest.DraughtStripping;
            xmlVentilation.numShelteredSides = sapVentilation.numShelteredSides;
            if (sapVentilation.Type.MechanicalVentilation.Type == null && sapVentilation.Type.NaturalVentilation.Type == null)
            {
                xmlVentilation.Type = null;
            }
            else if (sapVentilation.Type.MechanicalVentilation.Type == null)
            {
                xmlVentilation.Type = sapVentilation.Type.MechanicalVentilation.Type.FromSAPToXML();
            }
            else if (sapVentilation.Type.MechanicalVentilation.Type == null)
            {
                xmlVentilation.Type = sapVentilation.Type.MechanicalVentilation.Type.FromSAPToXML();
            }

            xmlVentilation.MechanicalVentilationDataSource = sapVentilation.Type.MechanicalVentilation.DataSource.FromSAPToXML();
            xmlVentilation.MechanicalVentSystemIndexNumber = sapVentilation.Type.MechanicalVentilation.SystemIndexNumber;
            xmlVentilation.MechanicalVentSystemMakeModel = sapVentilation.Type.MechanicalVentilation.SystemMakeModel;
            xmlVentilation.numWetRooms = sapVentilation.Type.MechanicalVentilation.numWetRooms;
            xmlVentilation.MechanicalVentSpecificFanPower = sapVentilation.Type.MechanicalVentilation.SpecificFanPower;
            xmlVentilation.MechanicalVentHeatRecoveryEfficiency = sapVentilation.Type.MechanicalVentilation.HeatRecoveryEfficiency;
            xmlVentilation.MechanicalVentDuctType = sapVentilation.Type.MechanicalVentilation.DuctType.FromSAPToXML();
            xmlVentilation.MechanicalVentDuctInsulation = sapVentilation.Type.MechanicalVentilation.DuctInsulation.FromSAPToXML();
            xmlVentilation.numKitchenRoomFans = sapVentilation.Type.AdditionalVentData.KitchenVentilation.RoomFans;
            xmlVentilation.KitchenRoomFansSpecificPower = sapVentilation.Type.AdditionalVentData.KitchenVentilation.RoomFansSpecificPower;
            xmlVentilation.numNonKitchenRoomFans = sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.RoomFans;
            xmlVentilation.NonKitchenRoomFansSpecificPower = sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.RoomFansSpecificPower;
            xmlVentilation.numKitchenDuctFans = sapVentilation.Type.AdditionalVentData.KitchenVentilation.DuctFans;
            xmlVentilation.KitchenDuctFansSpecificPower = sapVentilation.Type.AdditionalVentData.KitchenVentilation.DuctFansSpecificPower;
            xmlVentilation.numNonKitchenDuctFans = sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.DuctFans;
            xmlVentilation.NonKitchenDuctFansSpecificPower = sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.DuctFansSpecificPower;
            xmlVentilation.numKitchenWallFans = sapVentilation.Type.AdditionalVentData.KitchenVentilation.WallFans;
            xmlVentilation.KitchenWallFansSpecificPower = sapVentilation.Type.AdditionalVentData.KitchenVentilation.WallFansSpecificPower;
            xmlVentilation.numNonKitchenWallFans = sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.WallFans;
            xmlVentilation.NonKitchenWallFansSpecificPower = sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.WallFansSpecificPower;
            xmlVentilation.ExtractFansCount = sapVentilation.Type.AdditionalVentData.KitchenVentilation.RoomFans + sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.RoomFans + sapVentilation.Type.AdditionalVentData.KitchenVentilation.DuctFans + sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.DuctFans + sapVentilation.Type.AdditionalVentData.KitchenVentilation.WallFans + sapVentilation.Type.AdditionalVentData.NonKitchenVentilation.WallFans;
            xmlVentilation.PSVCount = sapVentilation.PSVCount;
            xmlVentilation.IsMechanicalVentApprovedInstallerScheme = sapVentilation.Type.MechanicalVentilation.ApprovedInstallerScheme;
            xmlVentilation.MechanicalVentDuctsIndexNumber = sapVentilation.MechanicalVentDuctsIndexNumber;

            return xmlVentilation;
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.PressureTestDone? pressureTestDone)
        {
            switch (pressureTestDone)
            {
                case BH.oM.Environment.SAP.PressureTestDone.YesMeasured:
                    return "1";

                case BH.oM.Environment.SAP.PressureTestDone.YesDesignValue:
                    return "2";

                case BH.oM.Environment.SAP.PressureTestDone.YesExistingDwelling:
                    return "6";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.PressureTestCode? pressureTestCode)
        {
            switch (pressureTestCode)
            {
                case BH.oM.Environment.SAP.PressureTestCode.NoAssumedForCalc:
                    return "3";

                case BH.oM.Environment.SAP.PressureTestCode.ExisitingDwellingSAPAlgorithm:
                    return "4";

                case BH.oM.Environment.SAP.PressureTestCode.NewDwellingAverage:
                    return "5";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfVentilation? typeOfVentilation)
        {
            switch (typeOfVentilation)
            {
                case BH.oM.Environment.SAP.TypeOfVentilation.NaturalIntermittentExtractFans:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfVentilation.NaturalPassiveVents:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfVentilation.PositiveInputFromLoft:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfVentilation.PositiveInputFromOutside:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfVentilation.MEVc:
                    return "5";

                case BH.oM.Environment.SAP.TypeOfVentilation.MEVdc:
                    return "6";

                case BH.oM.Environment.SAP.TypeOfVentilation.MV:
                    return "7";

                case BH.oM.Environment.SAP.TypeOfVentilation.MVHR:
                    return "8";

                case BH.oM.Environment.SAP.TypeOfVentilation.NaturalIntermittentExtractFansAndPassiveVents:
                    return "10";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.VentilationDataSource dataSource)
        { switch (dataSource)
            {
                case BH.oM.Environment.SAP.VentilationDataSource.FromDatabase:
                    return "1";

                case BH.oM.Environment.SAP.VentilationDataSource.ManufacturerDeclaration:
                    return "2";

                case BH.oM.Environment.SAP.VentilationDataSource.SAPTable:
                    return "3";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeofDuct typeofDuct)
        {
            switch (typeofDuct)
            {
                case BH.oM.Environment.SAP.TypeofDuct.Flexible:
                    return "1";

                case BH.oM.Environment.SAP.TypeofDuct.Rigid:
                    return "2";

                case BH.oM.Environment.SAP.TypeofDuct.SemiRigid:
                    return "3";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeofDuctInsulation ductInsulation)
        {
            switch (ductInsulation)
            {
                case BH.oM.Environment.SAP.TypeofDuctInsulation.NotInsulated:
                    return "1";

                case BH.oM.Environment.SAP.TypeofDuctInsulation.Insulated:
                    return "2";

                default:
                    return "";
            }
        }
    }
}