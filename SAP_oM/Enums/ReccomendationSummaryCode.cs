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

/*
//Help
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("")]
    public enum RecommendationSummaryCode { InsulateHotWaterCylinderWith80MmJacket = 1, IncreaseHotWaterCylinderInsulation = 2, AddAdditional80MmJacketToHotWaterCylinder = 3, 
		HotWaterCylinderThermostat = 4, IncreaseLoftInsulationTo270Mm = 5, CavityWallInsulation = 6, InternalOrExternalWallInsulation = 7, ReplaceSingleGlazedWindowsWithLowEDoubleGlazing = 8,
		SecondaryGlazingToSingleGlazedWindows = 9, DraughtProofing = 10, HeatingControls_Programmer_RoomThermostatAndTrvs = 11, HeatingControls_RoomThermostatAndTrvs = 12,
		HeatingControls_ThermostaticRadiatorValves = 13, HeatingControls_RoomThermostat = 14, HeatingControls_ProgrammerAndTrvs = 15, HeatingControls_TimeAndTemperatureZoneControl = 16,
		HeatingControls_ProgrammerAndRoomThermostat = 17, HeatingControls_RoomThermostat = 18, SolarWaterHeating = 19, ReplaceBoilerWithNewCondensingBoiler = 20, 
		ReplaceBoilerWithNewCondensingBoiler = 21, ReplaceBoilerWithBiomassBoiler = 22, WoodPelletStoveWithBoilerAndRadiators = 23, FanAssistedStorageHeatersAndDualImmersionCylinder = 24,
		FanAssistedStorageHeaters = 25, ReplacementWarmAirUnit = 26, ChangeHeatingToGasCondensingBoiler = 27, CondensingOilBoilerWithRadiators = 28, ChangeHeatingToGasCondensingBoiler = 29, 
		FanAssistedStorageHeatersAndDualImmersionCylinder = 30, FanAssistedStorageHeaters = 31, ChangeHeatingToGasCondensingBoiler = 32, SolarPhotovoltaicPanels,2.5Kwp = 34, 
		LowEnergyLightingForAllFixedOutlets = 35, ReplaceHeatingUnitWithCondensingUnit = 36, CondensingBoiler_SeparateFromTheRangeCooker = 37, 
		CondensingBoiler_SeparateFromTheRangeCooker = 38, WoodPelletStoveWithBoilerAndRadiators = 39, ChangeRoomHeatersToCondensingBoiler = 40, ChangeRoomHeatersToCondensingBoiler = 41,
		ReplaceHeatingUnitWithMainsGasCondensingUnit = 42, CondensingOilBoilerWithRadiators = 43, WindTurbine = 44, FlatRoofInsulation = 45, RoomInRoofInsulation = 46, FloorInsulation = 47,
		HighPerformanceExternalDoors = 48, HeatRecoverySystemForMixerShowers = 49, FlueGasHeatRecoveryDeviceInConjunctionWithBoiler = 50, AirOrGroundSourceHeatPump = 51, 
		AirOrGroundSourceHeatPumpWithUnderfloorHeating = 52, MicroCHP = 53, BiomassBoiler_ExemptedApplianceIfInSmokeControlArea = 54, ExternalInsulationWithCavityWallInsulation = 55 }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.RecommendationSummaryCode recommendationSummaryCode)
{
	switch (recommendationSummaryCode)
	{
		case BH.oM.Environment.SAP.RecommendationSummaryCode.InsulateHotWaterCylinderWith80MmJacket:
			return "1";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.IncreaseHotWaterCylinderInsulation:
			return "2";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.AddAdditional80MmJacketToHotWaterCylinder:
			return "3";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HotWaterCylinderThermostat:
			return "4";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.IncreaseLoftInsulationTo270Mm:
			return "5";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.CavityWallInsulation:
			return "6";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.InternalOrExternalWallInsulation:
			return "7";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplaceSingleGlazedWindowsWithLowEDoubleGlazing:
			return "8";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.SecondaryGlazingToSingleGlazedWindows:
			return "9";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.DraughtProofing:
			return "10";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(Programmer,RoomThermostatAndTrvs):
			return "11";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(RoomThermostatAndTrvs):
			return "12";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(ThermostaticRadiatorValves):
			return "13";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(RoomThermostat):
			return "14";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(ProgrammerAndTrvs):
			return "15";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(TimeAndTemperatureZoneControl):
			return "16";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(ProgrammerAndRoomThermostat):
			return "17";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatingControls(RoomThermostat):
			return "18";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.SolarWaterHeating:
			return "19";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplaceBoilerWithNewCondensingBoiler:
			return "20";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplaceBoilerWithNewCondensingBoiler:
			return "21";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplaceBoilerWithBiomassBoiler:
			return "22";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.WoodPelletStoveWithBoilerAndRadiators:
			return "23";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FanAssistedStorageHeatersAndDualImmersionCylinder:
			return "24";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FanAssistedStorageHeaters:
			return "25";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplacementWarmAirUnit:
			return "26";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ChangeHeatingToGasCondensingBoiler:
			return "27";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.CondensingOilBoilerWithRadiators:
			return "28";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ChangeHeatingToGasCondensingBoiler:
			return "29";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FanAssistedStorageHeatersAndDualImmersionCylinder:
			return "30";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FanAssistedStorageHeaters:
			return "31";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ChangeHeatingToGasCondensingBoiler:
			return "32";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.SolarPhotovoltaicPanels,2.5Kwp:
			return "34";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.LowEnergyLightingForAllFixedOutlets:
			return "35";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplaceHeatingUnitWithCondensingUnit:
			return "36";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.CondensingBoiler(SeparateFromTheRangeCooker):
			return "37";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.CondensingBoiler(SeparateFromTheRangeCooker):
			return "38";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.WoodPelletStoveWithBoilerAndRadiators:
			return "39";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ChangeRoomHeatersToCondensingBoiler:
			return "40";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ChangeRoomHeatersToCondensingBoiler:
			return "41";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ReplaceHeatingUnitWithMainsGasCondensingUnit:
			return "42";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.CondensingOilBoilerWithRadiators:
			return "43";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.WindTurbine:
			return "44";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FlatRoofInsulation:
			return "45";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.RoomInRoofInsulation:
			return "46";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FloorInsulation:
			return "47";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HighPerformanceExternalDoors:
			return "48";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.HeatRecoverySystemForMixerShowers:
			return "49";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.FlueGasHeatRecoveryDeviceInConjunctionWithBoiler:
			return "50";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.AirOrGroundSourceHeatPump:
			return "51";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.AirOrGroundSourceHeatPumpWithUnderfloorHeating:
			return "52";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.MicroCHP:
			return "53";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.BiomassBoiler(ExemptedApplianceIfInSmokeControlArea):
			return "54";

		case BH.oM.Environment.SAP.RecommendationSummaryCode.ExternalInsulationWithCavityWallInsulation:
			return "55";

		default:
			return"";
	}
}
 */


