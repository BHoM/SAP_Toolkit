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
        [Description("Convert SAP ventilation to XML ventilation.")]
        [Input("sapVentilation", "SAP ventilation to convert.")]
        [Output("xmlVentilation", "XML ventilation.")]
        public static BH.oM.Environment.SAP.XML.Ventilation ToXML(this BH.oM.Environment.SAP.Ventilation sapVentilation)
        {
            BH.oM.Environment.SAP.XML.Ventilation xmlVentilation = new BH.oM.Environment.SAP.XML.Ventilation();

            /* From VentilationRates */

            if (sapVentilation.VentilationRates != null)
            {
                xmlVentilation.ClosedFluesCount = sapVentilation.VentilationRates.ClosedFlues;
                xmlVentilation.OpenFluesCount = sapVentilation.VentilationRates.OpenFlues;
                xmlVentilation.BoilerFluesCount = sapVentilation.VentilationRates.BoilerFlues;
                xmlVentilation.OtherFluesCount = sapVentilation.VentilationRates.OtherFlues;
                xmlVentilation.OpenChimneysCount = sapVentilation.VentilationRates.OpenChimneys;
                xmlVentilation.BlockedChimneysCount = sapVentilation.VentilationRates.BlockedChimneys;
                xmlVentilation.ExtractFansCount = sapVentilation.VentilationRates.FansCount;
                xmlVentilation.PSVCount = sapVentilation.VentilationRates.PSV;
            }
            else
            {
                xmlVentilation.ClosedFluesCount = "0";
                xmlVentilation.OpenFluesCount = "0";
                xmlVentilation.BoilerFluesCount = "0";
                xmlVentilation.OtherFluesCount = "0";
                xmlVentilation.OpenChimneysCount = "0";
                xmlVentilation.BlockedChimneysCount = "0";
                xmlVentilation.ExtractFansCount = "0";
                xmlVentilation.PSVCount = "0";
            }

            /*
            FOR BACKWARDS COMPATABILITY ONLY DO NOT USE - xmlVentilation.FluelessGasFiresCount = "0";
            */

            /* From AirPermability */

            if (sapVentilation.AirPermability == null)
            {
                xmlVentilation.PressureTest = null;
                xmlVentilation.AirPermeability = null;
                xmlVentilation.GroundFloorType = null;
                xmlVentilation.WallType = null;
                xmlVentilation.HasDraughtLobby = null;
                xmlVentilation.DraughtStripping = null;
            }
            else if (sapVentilation.AirPermability != null) 
            {
                xmlVentilation.PressureTest = sapVentilation.AirPermability.PressureTest.FromSAPToXML();

                if (xmlVentilation.PressureTest == "")
                {
                    xmlVentilation.AirPermeability = null;

                    xmlVentilation.GroundFloorType = sapVentilation.AirPermability.GroundFloorType.FromSAPToXML();
                    xmlVentilation.WallType = sapVentilation.AirPermability.WallType.FromSAPToXML();
                    xmlVentilation.HasDraughtLobby = sapVentilation.AirPermability.HasDraughtLobby;
                    xmlVentilation.DraughtStripping = sapVentilation.AirPermability.DraughtStripping;
                }
                else
                {
                    xmlVentilation.AirPermeability = sapVentilation.AirPermability.AirPermabilityValue;

                    xmlVentilation.GroundFloorType = null;
                    xmlVentilation.WallType = null;
                    xmlVentilation.HasDraughtLobby = null;
                    xmlVentilation.DraughtStripping = null;
                }
                
            }

            xmlVentilation.PressureTestCertificateNumber = null;
            xmlVentilation.ShelteredSidesCount = sapVentilation.numberShelteredSides;


            /* From Ventilation Strategy */
            if (sapVentilation.VentilationStrategy == null)
            {
                xmlVentilation.VentilationType = null;
                xmlVentilation.IsMechanicalVentApprovedInstallerScheme = null;
                xmlVentilation.MechanicalVentilationDataSource = null;
                xmlVentilation.WetRoomsCount = null;
                xmlVentilation.MechanicalVentDuctInsulation = null;
                xmlVentilation.MechanicalVentDuctInsulationLevel = null;
                xmlVentilation.MechanicalVentSystemIndexNumber = null;
            }
            else if (sapVentilation.VentilationStrategy != null)
            {
                xmlVentilation.VentilationType = sapVentilation.VentilationStrategy.Type.FromSAPToXML();
                xmlVentilation.IsMechanicalVentApprovedInstallerScheme = sapVentilation.VentilationStrategy.ApprovedInstallation;
                xmlVentilation.MechanicalVentilationDataSource = sapVentilation.VentilationStrategy.MechVentDataSource.FromSAPToXML();
                xmlVentilation.WetRoomsCount = sapVentilation.VentilationStrategy.numberWetRooms;
                xmlVentilation.MechanicalVentDuctInsulation = sapVentilation.VentilationStrategy.DuctInsulationType.FromSAPToXML();
                xmlVentilation.MechanicalVentDuctInsulationLevel = sapVentilation.VentilationStrategy.DuctInsulationLevel.FromSAPToXML();
                xmlVentilation.MechanicalVentSystemIndexNumber = sapVentilation.VentilationStrategy.MechVentSystemIndexNumber;
                

                if (sapVentilation.VentilationStrategy.MechVentDetails == null)
                {
                    xmlVentilation.MechanicalVentDuctType = null;
                    xmlVentilation.MechanicalVentDuctPlacement = null;
                    xmlVentilation.MechanicalVentSystemMakeModel = null;
                    xmlVentilation.MechanicalVentSystemIndexNumber = null;
                    xmlVentilation.MechanicalVentSpecificFanPower = null;
                    xmlVentilation.MechanicalVentHeatRecoveryEfficiency = null;
                }
                else if (sapVentilation.VentilationStrategy.MechVentDetails != null)
                {
                    xmlVentilation.MechanicalVentDuctType = sapVentilation.VentilationStrategy.MechVentDetails.DuctType.FromSAPToXML();
                    xmlVentilation.MechanicalVentDuctPlacement = sapVentilation.VentilationStrategy.MechVentDetails.DuctPlacement.FromSAPToXML();
                    xmlVentilation.MechanicalVentSystemIndexNumber = sapVentilation.VentilationStrategy.MechVentDetails.SystemIndexNumber;
                    xmlVentilation.MechanicalVentSystemMakeModel = sapVentilation.VentilationStrategy.MechVentDetails.SystemMakeModel;
                    xmlVentilation.MechanicalVentSpecificFanPower = sapVentilation.VentilationStrategy.MechVentDetails.SpecificFanPower;
                    xmlVentilation.MechanicalVentHeatRecoveryEfficiency = sapVentilation.VentilationStrategy.MechVentDetails.HeatRecoveryEfficiency;
                }
                if (sapVentilation.VentilationStrategy.ExtraFanDetails == null)
                {
                    xmlVentilation.KitchenRoomFansCount = null;
                    xmlVentilation.KitchenRoomFansSpecificPower = null;
                    xmlVentilation.KitchenDuctFansCount = null;
                    xmlVentilation.KitchenDuctFansSpecificPower = null;
                    xmlVentilation.KitchenWallFansCount = null;
                    xmlVentilation.KitchenWallFansSpecificPower = null;
                    xmlVentilation.NonKitchenRoomFansCount = null;
                    xmlVentilation.NonKitchenRoomFansSpecificPower = null;
                    xmlVentilation.NonKitchenDuctFansCount = null;
                    xmlVentilation.NonKitchenDuctFansSpecificPower = null;
                    xmlVentilation.NonKitchenWallFansCount = null;
                    xmlVentilation.NonKitchenWallFansSpecificPower = null;
                }
                else if (sapVentilation.VentilationStrategy.ExtraFanDetails != null)
                {
                    xmlVentilation.KitchenRoomFansCount = sapVentilation.VentilationStrategy.ExtraFanDetails.KitchenRoomFans;
                    xmlVentilation.KitchenRoomFansSpecificPower = sapVentilation.VentilationStrategy.ExtraFanDetails.KitchenRoomFansSpecificPower;
                    xmlVentilation.KitchenDuctFansCount = sapVentilation.VentilationStrategy.ExtraFanDetails.KitchenDuctFans;
                    xmlVentilation.KitchenDuctFansSpecificPower = sapVentilation.VentilationStrategy.ExtraFanDetails.KitchenDuctFansSpecificPower;
                    xmlVentilation.KitchenWallFansCount = sapVentilation.VentilationStrategy.ExtraFanDetails.KitchenWallFans;
                    xmlVentilation.KitchenWallFansSpecificPower = sapVentilation.VentilationStrategy.ExtraFanDetails.KitchenWallFansSpecificPower;
                    xmlVentilation.NonKitchenRoomFansCount = sapVentilation.VentilationStrategy.ExtraFanDetails.nonKitchenRoomFans;
                    xmlVentilation.NonKitchenRoomFansSpecificPower = sapVentilation.VentilationStrategy.ExtraFanDetails.nonKitchenRoomFansSpecificPower;
                    xmlVentilation.NonKitchenDuctFansCount = sapVentilation.VentilationStrategy.ExtraFanDetails.nonKitchenDuctFans;
                    xmlVentilation.NonKitchenDuctFansSpecificPower = sapVentilation.VentilationStrategy.ExtraFanDetails.nonKitchenDuctFansSpecificPower;
                    xmlVentilation.NonKitchenWallFansCount = sapVentilation.VentilationStrategy.ExtraFanDetails.nonKitchenWallFans;
                    xmlVentilation.NonKitchenWallFansSpecificPower = sapVentilation.VentilationStrategy.ExtraFanDetails.nonKitchenWallFansSpecificPower;

                }
            }

            return xmlVentilation;
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.PressureTestCode? pressureTestCode)
        {
            switch (pressureTestCode)
            {
                case BH.oM.Environment.SAP.PressureTestCode.YesMeasured:
                    return "1";

                case BH.oM.Environment.SAP.PressureTestCode.YesDesignValue:
                    return "2";

                case BH.oM.Environment.SAP.PressureTestCode.NoAssumedForCalc:
                    return "3";

                case BH.oM.Environment.SAP.PressureTestCode.ExisitingDwellingSAPAlgorithm:
                    return "4";

                case BH.oM.Environment.SAP.PressureTestCode.NewDwellingAverage:
                    return "5";

                case BH.oM.Environment.SAP.PressureTestCode.YesExistingDwelling:
                    return "6";

                case BH.oM.Environment.SAP.PressureTestCode.YesMeasuredLowPressure:
                    return "7";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfVentilation typeOfVentilation)
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
        {
            switch (dataSource)
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
        private static string FromSAPToXML(this BH.oM.Environment.SAP.FloorConstructionCode floorConstructionCode)
        {
            switch (floorConstructionCode)
            {
                case BH.oM.Environment.SAP.FloorConstructionCode.NotSuspendedTimber:
                    return "1";

                case BH.oM.Environment.SAP.FloorConstructionCode.SuspendedTimberSealed:
                    return "2";

                case BH.oM.Environment.SAP.FloorConstructionCode.SuspendedTimberUnsealed:
                    return "3";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.WallConstructionCode wallConstructionCode)
        {
            switch (wallConstructionCode)
            {
                case BH.oM.Environment.SAP.WallConstructionCode.SteelOrTimberFrame:
                    return "1";

                case BH.oM.Environment.SAP.WallConstructionCode.Other:
                    return "2";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.DuctInsulationLevel ductInsulationLevel)
        {
            switch (ductInsulationLevel)
            {
                case BH.oM.Environment.SAP.DuctInsulationLevel.Level1:
                    return "1";

                case BH.oM.Environment.SAP.DuctInsulationLevel.Level2:
                    return "2";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfDuctPlacement typeOfDuctPlacement)
        {
            switch (typeOfDuctPlacement)
            {
                case BH.oM.Environment.SAP.TypeOfDuctPlacement.InsideHeatedEnvelope:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfDuctPlacement.OutsideHeatedEnvelope:
                    return "2";

                default:
                    return "";
            }
        }
    } 
}

