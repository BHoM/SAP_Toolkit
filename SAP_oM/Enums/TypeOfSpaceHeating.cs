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
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Code which specifies the emitter temperature.")]
    public enum TypeOfSpaceHeating { NonePresent = 699, BoilerSystem_SolidFuelManualFeed = 151, BoilerSystem_SolidFuelAutoFeed = 153,
        BoilerSystem_SolidFuelWoodChip = 155, BoilerSystem_SolidFuelOpenFire = 156, BoilerSystem_SolidFuelClosedRoom = 158,
        BoilerSystem_SolidFuelStove = 159, BoilerSystem_SolidFuelRangeCookerIntegral = 160, BoilerSystem_SolidFuelRangeCookerIndependent = 161,
        BoilerSystem_ElectricBoilerDirect = 191, BoilerSystem_ElectricBoilerCPSUHeated, BoilerSystem_ElectricBoilerDryCoreStorageHeated,
        BoilerSystem_ElectricBoilerDryCoreStorageUnheated,BoilerSystem_ElectricBoilerWaterStorageHeated, BoilerSystem_ElectricBoilerWaterStorageUnheated,
        HeatPumpWithRadiator_WithRadiatorElectricPumpGroundSourceLessThan35 = 211, HeatPumpWithRadiator_WithRadiatorElectricPumpWaterSourceLessThan35 = 213,
        HeatPumpWithRadiator_WithRadiatorElectricPumpAirSourceLessThan35 = 214, HeatPumpWithRadiator_WithRadiatorElectricPumpGroundSourceOther = 221, 
        HeatPumpWithRadiator_WithRadiatorElectricPumpWaterSourceOther = 223, HeatPumpWithRadiator_WithRadiatorElectricPumpAirSourceOther = 224,
        HeatPumpWithRadiator_WithRadiatorGasPumpGroundSourceLessThan35 = 215, HeatPumpWithRadiator_WithRadiatorGasPumpWaterSourceLessThan35 = 216,
        HeatPumpWithRadiator_WithRadiatorGasPumpAirSourceLessThan35 = 217, HeatPumpWithRadiator_WithRadiatorGasPumpGroundSourceOther = 225,
        HeatPumpWithRadiator_WithRadiatorGasPumpWaterSourceOther = 226 , HeatPumpWithRadiator_WithRadiatorGasPumpAirSourceOther = 227,
        HeatPumpWithWarmAir_WarmAirElectricPumpGroundSource = 521, HeatPumpWithWarmAir_WarmAirElectricPumpWaterSource = 523,
        HeatPumpWithWarmAir_WarmAirElectricPumpAirSource = 524, HeatPumpWithWarmAir_WarmAirGasPumpGroundSource = 525,
        HeatPumpWithWarmAir_WarmAirGasPumpWaterSource = 526,HeatPumpWithWarmAir_WarmAirGasPumpAirSource = 527, HeatNetwork_BoilersOnlyRdSAP = 301, 
        HeatNetwork_CHPAndBoilerRdSAP = 302, HeatNetwork_HeatPumpRdSAP = 304,ElectricStorage_OldHeater = 401, ElectricStorage_Slimline,
        ElectricStorage_Convector, ElectricStorage_Fan,ElectricStorage_SlimlineWithCelect, ElectricStorage_ConvectorWithCelect, 
        ElectricStorage_FanWithCelect,ElectricStorage_Integrated, ElectricStorage_HighHeatRetention, ElectricUnderfloor_InConcrete = 421,
        ElectricUnderfloor_Integrated, ElectricUnderfloor_IntegratedWithLowTariffControl, ElectricUnderfloor_InScreed, ElectricUnderfloor_InTimberFloor, 
        WarmAir_GasFanAssistedDuctedOnOffControlPre1998 = 501,
        WarmAir_GasFanAssistedDuctedOnOffControlPost1998,
        WarmAir_GasFanAssistedDuctedModulatingControlPre1998,
        WarmAir_GasFanAssistedDuctedModulatingControlPost1998,
        WarmAir_GasFanAssistedRoomHeater,
        WarmAir_GasFanAssistedCondensing = 520, 
        WarmAir_GasBalancedOrOpenFlueDuctedOnOffControlPre1998 = 506, WarmAir_GasBalancedOrOpenFlueDuctedOnOffControlPost1998,
        WarmAir_GasBalancedOrOpenFlueDuctedModulatingControlPre1998, WarmAir_GasBalancedOrOpenFlueDuctedModulationControlPost1998,
        WarmAir_GasBalancedOrOpenFlueDuctedWithFlueHeatRecovery, WarmAir_GasBalancedOrOpenFlueCondensing, WarmAir_LiquidDuctedOnOffControl = 512,
        WarmAir_LiquidDuctedModulatingControl, WarmAir_LiquidStubDuctSystem, WarmAir_ElectricaireSystem = 515,RoomHeater_GasOpenFluePre1980 = 601, 
        RoomHeater_OpenFluePre1980BackBoiler, RoomHeater_OpenFluePost1980, RoomHeater_OpenFluePost1980BackBoiler, RoomHeater_FlushFittingGasFire, 
        RoomHeater_FlushFittingGasFireBackBoiler, RoomHeater_FlushFittingGasFireFanAssisted, RoomHeater_GasFireOrWallHeaterBalancedFlue = 609,
        RoomHeater_GasFireClosedFrontedFanAssistes = 610, RoomHeater_CondensingGasFire = 611, RoomHeater_DecorativeFuelGasFire = 612, RoomHeater_FluelessGasFire = 614,
        RoomHeater_LiquidFuelPre2000 = 621, RoomHeater_LiquidFuelPre200WithBoiler = 622, RoomHeater_LiquidFuelPost2000 = 623, RoomHeater_LiquidFuelPost2000WithBoiler, 
        RoomHeater_LiquidFuelBioethanolHeaterSecondaryOnly = 625, RoomHeater_SolidFuelOpenFire = 631, RoomHeater_SolidFuelOpenFireWithBackBoiler = 632, RoomHeater_SolidFuelClosed,
        RoomHeater_SolidFuelClosedWithBoiler, RoomHeater_SolidFuelStove, RoomHeater_SolidFuelStoveWithBoiler, RoomHeater_ElectricPanelConvectorOrRadiant = 691, RoomHeater_ElectricWaterOrOil = 694,
        RoomHeater_ElectricFanHeater = 692, RoomHeater_ElectricPortable = 693, Other_ElectricCeilingHeating = 701, GasBoiler_Post1998NonCondensingAutomaticIgnition = 101,
        GasBoiler_Post1998CondensingWithAutomaticIgnition = 102, GasBoiler_Post1998NonCondensingCombiWithAutomaticIgnition, GasBoiler_Post1998CondensingCombiWithAutomaticIgnition,
        GasBoiler_Post1998NonCondensingWithPilotLight, GasBoiler_Post1998RCondensingWithPilotLight, GasBoiler_Post1998NonCondensingCombiWithPilotLight,
        GasBoiler_Post1998CondensingCombiWithPilotLight, GasBoiler_Post1998BackBoilerToRadiators, GasBoiler_Pre1998WithFanAssistedFlueLowThermalCapacity = 110, 
        GasBoiler_Pre1998WithFanAssistedFlueHighOrUnknownThermalCapacity, GasBoiler_Pre1998WithFanAssistedFlueCombi, GasBoiler_Pre1998WithFanAssistedFlueCondensingCombi,
        GasBoiler_Pre1998WithFanAssistedFlueRegularCondensing, GasBoiler_Pre1998WithOpenFlueWallMounted, GasBoiler_Pre1998WithOpenFlueFloorMountedPre1979, GasBoiler_Pre1998WithOpenFlueFloorMountedPost1979,
        GasBoiler_Pre1998WithOpenFlueCombi, GasBoiler_Pre1998WithOpenFlueBackBoilerToRadiators, CPSU_AutomaticIgnitionNonCondensing, CPSU_AutomaticIgnitionCondensing,
        CPSU_PermanentPilotLightNonCondensing, CPSU_PermanentPilotLightCondensing, LiquidFuel_OilStandardPre1965 = 124, LiquidFuel_OilStandard1985To1997, LiquidFuel_OilStandardPost1998,
        LiquidFuel_CondensingOil = 127, LiquidFuel_CombiOilPre1998, LiquidFuel_CombiOilPost1998, LiquidFuel_CondensingCombiOil, LiquidFuel_OilRoomHeaterWithBoilerToRadiatorsPre2000,
        LiquidFuel_OilRoomHeaterWithBoilerToRadiatorsPost2000, RangeCooker_SingleBurnerWithPermanentPilot, RangeCooker_SingleBurnerWithAutomaticIgnition,
        RangeCooker_TwinBurnerWithPermanentPilotPre1998, RangeCooker_TwinBurnerWithAutomaticIgnitionPre1998, RangeCooker_TwinBurnerWithPermanentPilotPost1998,
        RangeCooker_TwinBurnerWithAutomaticIgnitionPost1998,RangeCookerLiquidFuel_SingleBurner = 139, RangeCookerLiquidFuel_TwinBurnerPre1998, RangeCookerLiquidFuel_TwinBurnerPost1998 = 141 
    }

}

