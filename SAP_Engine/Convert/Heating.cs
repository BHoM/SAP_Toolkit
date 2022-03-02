﻿/*
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
        public static Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling, oM.Environment.SAP.XML.MainHeating, oM.Environment.SAP.XML.MainHeating> ToXML(this oM.Environment.SAP.Heating heating)
        {
            oM.Environment.SAP.XML.Cooling xmlCooling = new oM.Environment.SAP.XML.Cooling();
            xmlCooling.CooledArea = heating.Cooling.CooledArea;
            xmlCooling.CoolingSystemDataSource = heating.Cooling.DataSource;
            xmlCooling.CoolingSystemType = heating.Cooling.Type;
            xmlCooling.CoolingSystemClass = heating.Cooling.EnergyLabel;
            xmlCooling.CoolingSystemEER = heating.Cooling.EER;
            xmlCooling.CoolingSystemControl = heating.Cooling.CompressorControl;

            oM.Environment.SAP.XML.MainHeating xmlMainHeating = new oM.Environment.SAP.XML.MainHeating();
            xmlMainHeating.MainHeatingNumber = 1;
            xmlMainHeating.MainHeatingCategory = heating.Primary.HeatingDetails.HeatingGroup + heating.Primary.HeatingDetails.SubGroup;
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
            xmlMainHeating.IsOilPumpInHeatedSpace = heating.Primary.BoilerInformation.PumpInHeatedSpace;// only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE (IF LOOP)
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

            oM.Environment.SAP.XML.HeatingDeclaredValues xmlMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
            xmlMainHeatingDeclaredValues.Efficiency = null;
            xmlMainHeatingDeclaredValues.MakeModel = null;
            xmlMainHeatingDeclaredValues.TestMethod = null;
            xmlMainHeating.MainHeatingDeclaredValues = xmlMainHeatingDeclaredValues;

            oM.Environment.SAP.XML.StorageHeaters xmlStorageHeaters = new oM.Environment.SAP.XML.StorageHeaters();
            oM.Environment.SAP.XML.StorageHeater xmlStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
            xmlStorageHeater.NumberOfHeaters = null;
            xmlStorageHeater.IndexNumber = null;
            xmlStorageHeater.HighHeatRetention = null;
            xmlStorageHeaters.StorageHeater = xmlStorageHeater;
            xmlMainHeating.StorageHeaters = xmlStorageHeaters;

            xmlMainHeating.EmitterTemperature = null;
            xmlMainHeating.MCSInstalledHeatPump = heating.Primary.MCSCertificate;
            xmlMainHeating.CentralHeatingPumpAge = null;
            xmlMainHeating.CompensatingControllerIndexNumber = null;
            xmlMainHeating.TTZCIndexNumber = null;

            oM.Environment.SAP.XML.MainHeating xmlSecondaryMainHeating = new oM.Environment.SAP.XML.MainHeating();
            xmlSecondaryMainHeating.MainHeatingNumber = 2;
            xmlSecondaryMainHeating.MainHeatingCategory = heating.SecondaryMain.HeatingDetails.HeatingGroup + heating.SecondaryMain.HeatingDetails.SubGroup;
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

            oM.Environment.SAP.XML.HeatingDeclaredValues xmlSecondaryMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
            xmlSecondaryMainHeatingDeclaredValues.Efficiency = null;
            xmlSecondaryMainHeatingDeclaredValues.MakeModel = null;
            xmlSecondaryMainHeatingDeclaredValues.TestMethod = null;
            xmlSecondaryMainHeating.MainHeatingDeclaredValues = xmlMainHeatingDeclaredValues;

            oM.Environment.SAP.XML.StorageHeaters xmlSecondaryStorageHeaters = new oM.Environment.SAP.XML.StorageHeaters();
            oM.Environment.SAP.XML.StorageHeater xmlSecondaryStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
            xmlSecondaryStorageHeater.NumberOfHeaters = null;
            xmlSecondaryStorageHeater.IndexNumber = null;
            xmlSecondaryStorageHeater.HighHeatRetention = null;
            xmlSecondaryStorageHeaters.StorageHeater = xmlStorageHeater;
            xmlSecondaryMainHeating.StorageHeaters = xmlStorageHeaters;

            xmlSecondaryMainHeating.EmitterTemperature = null;
            xmlSecondaryMainHeating.MCSInstalledHeatPump = heating.SecondaryMain.MCSCertificate;
            xmlSecondaryMainHeating.CentralHeatingPumpAge = null;
            xmlSecondaryMainHeating.CompensatingControllerIndexNumber = null;
            xmlSecondaryMainHeating.TTZCIndexNumber = null;

            oM.Environment.SAP.XML.Heating xmlHeating = new oM.Environment.SAP.XML.Heating();
            xmlHeating.WaterHeatingCode = heating.WaterHeating.System;
            xmlHeating.WaterFuelType = heating.WaterHeating.Fuel;
            if (heating.WaterHeating.CylinderSpecification != null)
            {
                xmlHeating.HasHotWaterCylinder = true;
                xmlHeating.HotWaterStoreSize = heating.WaterHeating.CylinderSpecification.Volume;
                xmlHeating.HotWaterStoreInsulationType = heating.WaterHeating.CylinderSpecification.InsulationType;
                xmlHeating.HotWaterInsulationThickness = heating.WaterHeating.CylinderSpecification.InsulationThickness;
                xmlHeating.IsCylinderInHeatedSpace = heating.WaterHeating.CylinderSpecification.InHeatedSpace;
                xmlHeating.IsHotWaterSeperatlyTimed = heating.WaterHeating.CylinderSpecification.TimedSeperatly;
                xmlHeating.HasCylinderThermostat = heating.WaterHeating.CylinderSpecification.Cylinderstat;
                xmlHeating.HotWaterStoreHeatLoss = heating.WaterHeating.CylinderSpecification.DeclaredLossFactor;
            }
            if (heating.WaterHeating.CylinderSpecification == null)
            {
                xmlHeating.HasHotWaterCylinder = false;
                xmlHeating.HotWaterStoreSize = null;
                xmlHeating.HotWaterStoreInsulationType = null;
                xmlHeating.HotWaterInsulationThickness = null;
                xmlHeating.IsCylinderInHeatedSpace = null;
                xmlHeating.IsHotWaterSeperatlyTimed = null;
                xmlHeating.HasCylinderThermostat = null;
                xmlHeating.HotWaterStoreHeatLoss = null;
            }
            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingGroup;
            xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source;
            xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingType;
            xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel;
            xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType;
            xmlHeating.ImmersionHeatingType = heating.WaterHeating.Immersion.Type;
            xmlHeating.IsHeatPumpAssistedByImmersion = heating.WaterHeating.Immersion.UseOfImmersion;
            xmlHeating.IsImmersionForSummerUse = heating.WaterHeating.Immersion.SummerImmersion;
            xmlHeating.ThermalStore = null;
            xmlHeating.HasFixedAirConditioning = null;
            xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
            xmlHeating.HotWaterStoreHeatTransferArea = heating.WaterHeating.Immersion.HeatExchangerArea; // ?
            xmlHeating.HotWaterStoreHeatLossSource = null;
            xmlHeating.IsThermalStoreNearBoiler = null;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = null;

            oM.Environment.SAP.XML.CommunityHeatingSystems xmlCommunityHeatingSystems = new oM.Environment.SAP.XML.CommunityHeatingSystems();
            oM.Environment.SAP.XML.CommunityHeatingSystem xmlCommunityHeatingSystem = new oM.Environment.SAP.XML.CommunityHeatingSystem();
            oM.Environment.SAP.XML.CommunityHeatSources xmlCommunityHeatSources = new oM.Environment.SAP.XML.CommunityHeatSources();
            oM.Environment.SAP.XML.CommunityHeatSource xmlCommunityHeatSource = new oM.Environment.SAP.XML.CommunityHeatSource();
            xmlCommunityHeatingSystems.CommunityHeatingSystem = xmlCommunityHeatingSystem;
            xmlCommunityHeatingSystem.CommunityHeatingUse = null;
            xmlCommunityHeatingSystem.IsCommunityHeatingCylinderInDwelling = null;
            xmlCommunityHeatingSystem.CommunityHeatingDistributionType = null;
            xmlCommunityHeatingSystem.CommunityHeatSources = xmlCommunityHeatSources;
            xmlCommunityHeatSources.CommunityHeatSource = xmlCommunityHeatSource;
            xmlCommunityHeatSource.HeatSourceType = null;
            xmlCommunityHeatSource.HeatFraction = null;
            xmlCommunityHeatSource.FuelType = null;
            xmlCommunityHeatSource.HeatEfficiency = null;
            xmlCommunityHeatSource.PowerEfficiency = null;
            xmlCommunityHeatSource.Description = null;
            xmlCommunityHeatingSystem.CommunityHeatingDistributionLossFactor = null;
            xmlCommunityHeatingSystem.ChargingLinkedToHeatUse = null;
            xmlCommunityHeatingSystem.HeatNetworkIndexNumber = null;
            xmlHeating.CommunityHeatingSystems = xmlCommunityHeatingSystems;

            oM.Environment.SAP.XML.MainHeatingDetails xmlMainHeatingDetails = new oM.Environment.SAP.XML.MainHeatingDetails();
            xmlMainHeatingDetails.MainHeating = xmlMainHeating;
            xmlHeating.MainHeatingDetails = xmlMainHeatingDetails;

            xmlHeating.HeatingDesignWaterUse = null;
            xmlHeating.MainHeatingSystemsInteraction = null;

            oM.Environment.SAP.XML.HeatingDeclaredValues xmlHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
            xmlHeatingDeclaredValues.Efficiency = null;
            xmlHeatingDeclaredValues.MakeModel = null;
            xmlHeatingDeclaredValues.TestMethod = null;
            xmlHeating.SecondaryHeatingDeclaredValues = xmlHeatingDeclaredValues;

            xmlHeating.PrimaryPipeworkInsulation = null;

            oM.Environment.SAP.XML.SolarHeatingDetails xmlSolarHeatingDetails = new oM.Environment.SAP.XML.SolarHeatingDetails();
            xmlSolarHeatingDetails.ApertureArea = heating.SolarPanelDetails.AreaCollector;
            xmlSolarHeatingDetails.CollectorType = heating.SolarPanelDetails.CollectorType;
            xmlSolarHeatingDetails.DataSource = null;
            xmlSolarHeatingDetails.ZeroLossEfficiency = heating.SolarPanelDetails.CollectorEfficiencyη0;
            xmlSolarHeatingDetails.HeatLossRate = null; //for backward compatibility only, do not use.
            xmlSolarHeatingDetails.LinearHeatLossCoefficient = heating.SolarPanelDetails.Coefficienta1;
            xmlSolarHeatingDetails.SecondOrderHeatLossCoefficient = heating.SolarPanelDetails.Coefficienta2;
            xmlSolarHeatingDetails.Orientation = heating.SolarPanelDetails.Orientation;
            xmlSolarHeatingDetails.Pitch = heating.SolarPanelDetails.TiltOfCollector;
            xmlSolarHeatingDetails.Overshading = heating.SolarPanelDetails.Overshading;
            xmlSolarHeatingDetails.HasSolarPoweredPump = heating.SolarPanelDetails.SolarPoweredPump;
            xmlSolarHeatingDetails.IsSolarStoreCombinedCylinder = heating.SolarPanelDetails.IsSolarStoreCombined;
            xmlSolarHeatingDetails.SolarStoreVolume = heating.SolarPanelDetails.DedicatedSolarStorVolume;
            xmlSolarHeatingDetails.ShowerTypes = heating.SolarPanelDetails.ShowersPresent;
            xmlHeating.SolarHeatingDetails = xmlSolarHeatingDetails;

            oM.Environment.SAP.XML.InstantaneousWWHRS xmlInstantaneousWWHRS = new oM.Environment.SAP.XML.InstantaneousWWHRS();
            oM.Environment.SAP.XML.StorageWWHRS xmlStorageWWHRS = new oM.Environment.SAP.XML.StorageWWHRS();
            xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            if (heating.WWHRS.System1.System.InstantaneousOrStorage == "1")
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = heating.WWHRS.System1.System.Index;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithBath = heating.WWHRS.System1.MixerShowersWithBath;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithoutBath = heating.WWHRS.System1.MixerSHowersWithoutBath;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
            }
            if (heating.WWHRS.System2.System.InstantaneousOrStorage == "1")
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = heating.WWHRS.System2.System.Index;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithBath = heating.WWHRS.System2.MixerShowersWithBath;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithoutBath = heating.WWHRS.System2.MixerSHowersWithoutBath;
            }
            if (heating.WWHRS.System1.System.InstantaneousOrStorage == "2")
            {
                xmlStorageWWHRS.WWHRSIndexNumber = heating.WWHRS.System1.System.Index;
                xmlStorageWWHRS.TotalShowersAndBaths = null;
                xmlStorageWWHRS.BathsAndShowersToWWHRS = null;
                xmlStorageWWHRS.WWHRSStoreVolume = heating.WWHRS.System1.System.TestDedicatedVolume;
            }
            if (heating.WWHRS.System2.System.InstantaneousOrStorage == "2")
            {
                xmlStorageWWHRS.WWHRSIndexNumber = heating.WWHRS.System2.System.Index;
                xmlStorageWWHRS.TotalShowersAndBaths = null;
                xmlStorageWWHRS.BathsAndShowersToWWHRS = null;
                xmlStorageWWHRS.WWHRSStoreVolume = heating.WWHRS.System2.System.TestDedicatedVolume;
            }
            if (heating.WWHRS.System1.System.InstantaneousOrStorage != "2" && heating.WWHRS.System1.System.InstantaneousOrStorage != "1")
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithBath = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithoutBath = null;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithBath = null;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithoutBath = null;
                xmlStorageWWHRS.WWHRSIndexNumber = null;
                xmlStorageWWHRS.TotalShowersAndBaths = null;
                xmlStorageWWHRS.BathsAndShowersToWWHRS = null;
                xmlStorageWWHRS.WWHRSStoreVolume = null;
            }
            if (heating.WWHRS.System2.System.InstantaneousOrStorage != "2" && heating.WWHRS.System2.System.InstantaneousOrStorage != "1")
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithBath = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithoutBath = null;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithBath = null;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithoutBath = null;
                xmlStorageWWHRS.WWHRSIndexNumber = null;
                xmlStorageWWHRS.TotalShowersAndBaths = null;
                xmlStorageWWHRS.BathsAndShowersToWWHRS = null;
                xmlStorageWWHRS.WWHRSStoreVolume = null;
            }
            xmlHeating.InstantaneousWHRS = xmlInstantaneousWWHRS;
            xmlHeating.StorageWHRS = xmlStorageWWHRS;

            return new Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling, oM.Environment.SAP.XML.MainHeating, oM.Environment.SAP.XML.MainHeating>() { Item1 = xmlHeating, Item2 = xmlCooling, Item3 = xmlMainHeating, Item4 = xmlSecondaryMainHeating };
        }
    }
}