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
using BH.oM.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Heating to XML Heating.")]
        [Input("sapHeating", "SAP Heating object to convert.")]
        [MultiOutput(0, "heating", "XML Heating.")]
        [MultiOutput(1, "cooling", "XML Cooling.")]
        [MultiOutput(2, "mainHeating", "XML Main Heating.")]
        [MultiOutput(3, "secondaryMainHeating", "XML Secondary Main Heating if defined.")]
        public static Output<BH.oM.Environment.SAP.XML.Heating, BH.oM.Environment.SAP.XML.Cooling, BH.oM.Environment.SAP.XML.MainHeating, BH.oM.Environment.SAP.XML.MainHeating> ToXML(this BH.oM.Environment.SAP.Heating heating)
        {
            BH.oM.Environment.SAP.XML.Heating xmlHeating = new BH.oM.Environment.SAP.XML.Heating();
            xmlHeating.WaterHeatingCode = null;
            xmlHeating.WaterFuelType = null;
            xmlHeating.HasHotWaterCylinder = null;
            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingGroup;
            xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source;
            xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingType;
            xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel;
            xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType;
            xmlHeating.ThermalStore = null ;
            xmlHeating.HasFixedAirConditioning = null;
            xmlHeating.ImmersionHeatingType = null;
            xmlHeating.IsHeatPumpAssistedByImmersion = null;
            xmlHeating.IsImmersionForSummerUse = null;
            xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
            xmlHeating.HotWaterStoreSize = null;
            xmlHeating.HotWaterStoreHeatTransferArea = null;
            xmlHeating.HotWaterStoreHeatLossSource = null;
            xmlHeating.HotWaterStoreHeatLoss = null;
            xmlHeating.HotWaterStoreInsulationType = null;
            xmlHeating.HotWaterInsulationThickness = null;
            xmlHeating.IsThermalStoreNearBoiler = null;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = null;
            xmlHeating.HasCylinderThermostat = null;
            xmlHeating.IsCylinderInHeatedSpace = null;
            xmlHeating.IsHotWaterSeperatlyTimed = null;
            xmlHeating.CommunityHeatingSystems = null;
            xmlHeating.MainHeatingDetails.MainHeating.BoilerFuelFeed = null;
            xmlHeating.HeatingDesignWaterUse = null;
            xmlHeating.MainHeatingSystemsInteraction = null;
            xmlHeating.SecondaryHeatingDeclaredValues = null;
            xmlHeating.PrimaryPipeworkInsulation = null;
            xmlHeating.SolarHeatingDetails = null;
            xmlHeating.InstantaneousWHRS = null;
            xmlHeating.StorageWHRS = null;

            BH.oM.Environment.SAP.XML.Cooling xmlCooling = new BH.oM.Environment.SAP.XML.Cooling();
            xmlCooling.CooledArea = heating.Cooling.CooledArea;
            xmlCooling.CoolingSystemDataSource = heating.Cooling.DataSource;
            xmlCooling.CoolingSystemType = heating.Cooling.Type;
            xmlCooling.CoolingSystemClass = heating.Cooling.EnergyLabel;
            xmlCooling.CoolingSystemEER = heating.Cooling.EER;
            xmlCooling.CoolingSystemControl = heating.Cooling.CompressorControl;

            BH.oM.Environment.SAP.XML.MainHeating xmlMainHeating = new BH.oM.Environment.SAP.XML.MainHeating();
            xmlMainHeating.MainHeatingNumber = 1;
            xmlMainHeating.MainHeatingCategory = heating.Primary.HeatingDetails.HeatingGroup;
            xmlMainHeating.MainHeatingDataSource = heating.Primary.HeatingDetails.Source;
            xmlMainHeating.MainHeatingIndexNumber = null;//when implementing PCDB
            xmlMainHeating.IsCondensingBoiler = null;
            xmlMainHeating.GasOrOilBoilerType = null;
            xmlMainHeating.CombiBoilerType = null;
            xmlMainHeating.CaseHeatEmission = null;
            xmlMainHeating.HeatTransferToWater = null;
            xmlMainHeating.SolidFuelBoilerType = null;
            xmlMainHeating.MainHeatingCode = null;
            xmlMainHeating.MainFuelType = heating.Primary.HeatingFuel.Fuel;
            xmlMainHeating.MainHeatingControl = heating.Primary.HeatingControls.Controls;
            xmlMainHeating.HeatEmitterType = heating.Primary.HeatingDetails.Emitter;
            xmlMainHeating.UnderfloorHeatEmitterType = null;
            xmlMainHeating.MainHeatingFlueType = heating.Primary.BoilerInformation.FlueType;
            xmlMainHeating.IsFlueFanPresent = heating.Primary.BoilerInformation.FanFLued;
            xmlMainHeating.IsCentralHeatingPumpInHeatedSpace = heating.Primary.BoilerInformation.PumpInHeatedSpace;//only if wet system, Need to check these two
            xmlMainHeating.IsOilPumpInHeatedSpace = heating.Primary.BoilerInformation.PumpInHeatedSpace;// only if oil boiler
            xmlMainHeating.IsInterLockedSystem = heating.Primary.BoilerInformation.BoilerInterlock;
            xmlMainHeating.HasSeparateDelayedStart = heating.Primary.HeatingControls.DelayedStartThermostat;
            xmlMainHeating.HasLoadOrWeatherCompensation = null;
            xmlMainHeating.BoilerFuelFeed = null;
            xmlMainHeating.IsMainHeatingHETASApproved = heating.Primary.HETASApproved;
            xmlMainHeating.ElectricCPSUOperatingTemperature = null;
            xmlMainHeating.LoadOrWeatherCompensation = null;
            xmlMainHeating.MainHeatingFraction = heating.Primary.FractionOfHeat;
            xmlMainHeating.BurnerControl = null;
            xmlMainHeating.EfficiencyType = null;
            xmlMainHeating.MainHeatingEfficiencyWinter = null;
            xmlMainHeating.MainHeatingEfficiencySummer = null;
            xmlMainHeating.HasFGHRS = null;
            xmlMainHeating.FGHRSIndexNumber = null;
            xmlMainHeating.FGHRSEnergySource = null;
            xmlMainHeating.MainHeatingDeclaredValues = null;
            xmlMainHeating.StorageHeaters = null;
            xmlMainHeating.EmitterTemperature = null;
            xmlMainHeating.MCSInstalledHeatPump = heating.Primary.MCSCertificate;
            xmlMainHeating.CentralHeatingPumpAge = null;
            xmlMainHeating.CompensatingControllerIndexNumber = null;
            xmlMainHeating.TTZCIndexNumber = null;

            BH.oM.Environment.SAP.XML.MainHeating xmlSecondaryMainHeating = new BH.oM.Environment.SAP.XML.MainHeating();
            xmlSecondaryMainHeating.MainHeatingNumber = 2;
            xmlSecondaryMainHeating.MainHeatingCategory = heating.SecondaryMain.HeatingDetails.HeatingGroup;
            xmlSecondaryMainHeating.MainHeatingDataSource = heating.SecondaryMain.HeatingDetails.Source;
            xmlSecondaryMainHeating.MainHeatingIndexNumber = null;//when implementing PCDB
            xmlSecondaryMainHeating.IsCondensingBoiler = null;
            xmlSecondaryMainHeating.GasOrOilBoilerType = null;
            xmlSecondaryMainHeating.CombiBoilerType = null;
            xmlSecondaryMainHeating.CaseHeatEmission = null;
            xmlSecondaryMainHeating.HeatTransferToWater = null;
            xmlSecondaryMainHeating.SolidFuelBoilerType = null;
            xmlSecondaryMainHeating.MainHeatingCode = null;
            xmlSecondaryMainHeating.MainFuelType = heating.SecondaryMain.HeatingFuel.Fuel;
            xmlSecondaryMainHeating.MainHeatingControl = heating.SecondaryMain.HeatingControls.Controls;
            xmlSecondaryMainHeating.HeatEmitterType = heating.SecondaryMain.HeatingDetails.Emitter;
            xmlSecondaryMainHeating.UnderfloorHeatEmitterType = null;
            xmlSecondaryMainHeating.MainHeatingFlueType = heating.SecondaryMain.BoilerInformation.FlueType;
            xmlSecondaryMainHeating.IsFlueFanPresent = heating.SecondaryMain.BoilerInformation.FanFLued;
            xmlSecondaryMainHeating.IsCentralHeatingPumpInHeatedSpace = heating.SecondaryMain.BoilerInformation.PumpInHeatedSpace;//only if wet system, Need to check these two
            xmlSecondaryMainHeating.IsOilPumpInHeatedSpace = heating.SecondaryMain.BoilerInformation.PumpInHeatedSpace;// only if oil boiler
            xmlSecondaryMainHeating.IsInterLockedSystem = heating.SecondaryMain.BoilerInformation.BoilerInterlock;
            xmlSecondaryMainHeating.HasSeparateDelayedStart = heating.SecondaryMain.HeatingControls.DelayedStartThermostat;
            xmlSecondaryMainHeating.HasLoadOrWeatherCompensation = null;
            xmlSecondaryMainHeating.BoilerFuelFeed = null;
            xmlSecondaryMainHeating.IsMainHeatingHETASApproved = heating.SecondaryMain.HETASApproved;
            xmlSecondaryMainHeating.ElectricCPSUOperatingTemperature = null;
            xmlSecondaryMainHeating.LoadOrWeatherCompensation = null;
            xmlSecondaryMainHeating.MainHeatingFraction = heating.SecondaryMain.FractionOfHeat;
            xmlSecondaryMainHeating.BurnerControl = null;
            xmlSecondaryMainHeating.EfficiencyType = null;
            xmlSecondaryMainHeating.MainHeatingEfficiencyWinter = null;
            xmlSecondaryMainHeating.MainHeatingEfficiencySummer = null;
            xmlSecondaryMainHeating.HasFGHRS = null;
            xmlSecondaryMainHeating.FGHRSIndexNumber = null;
            xmlSecondaryMainHeating.FGHRSEnergySource = null;
            xmlSecondaryMainHeating.MainHeatingDeclaredValues = null;
            xmlSecondaryMainHeating.StorageHeaters = null;
            xmlSecondaryMainHeating.EmitterTemperature = null;
            xmlSecondaryMainHeating.MCSInstalledHeatPump = heating.SecondaryMain.MCSCertificate;
            xmlSecondaryMainHeating.CentralHeatingPumpAge = null;
            xmlSecondaryMainHeating.CompensatingControllerIndexNumber = null;
            xmlSecondaryMainHeating.TTZCIndexNumber = null;

            return new Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling, oM.Environment.SAP.XML.MainHeating, oM.Environment.SAP.XML.MainHeating>() { Item1 = xmlHeating, Item2 = xmlCooling, Item3 = xmlMainHeating, Item4 = xmlSecondaryMainHeating };
        }
    }
}