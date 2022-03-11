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
        public static Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling> ToXML(this oM.Environment.SAP.Heating heating)
        {
            oM.Environment.SAP.XML.Cooling xmlCooling = new oM.Environment.SAP.XML.Cooling();
            xmlCooling.CooledArea = heating.Cooling.CooledArea;
            xmlCooling.CoolingSystemDataSource = heating.Cooling.DataSource;
            xmlCooling.CoolingSystemType = heating.Cooling.Type;
            xmlCooling.CoolingSystemClass = heating.Cooling.EnergyLabel;
            xmlCooling.CoolingSystemEER = heating.Cooling.EER;
            xmlCooling.CoolingSystemControl = heating.Cooling.CompressorControl;

            List<oM.Environment.SAP.XML.MainHeating> xmlMainHeatingList = new List<oM.Environment.SAP.XML.MainHeating>();
            oM.Environment.SAP.XML.MainHeating xmlMainHeating = new oM.Environment.SAP.XML.MainHeating();
            oM.Environment.SAP.XML.StorageHeaters xmlStorageHeaters = new oM.Environment.SAP.XML.StorageHeaters();
            oM.Environment.SAP.XML.StorageHeater xmlStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
            oM.Environment.SAP.XML.HeatingDeclaredValues xmlMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
            xmlMainHeating.MainHeatingIndexNumber = heating.Main.HeatingDetails.ProductIndex;
            xmlMainHeating.IsCondensingBoiler = null;
            xmlMainHeating.GasOrOilBoilerType = null;
            xmlMainHeating.EfficiencyType = null;
            xmlMainHeating.MainHeatingEfficiencyWinter = null;
            xmlMainHeating.MainHeatingEfficiencySummer = null;
            xmlStorageHeater.IndexNumber = null;
            xmlStorageHeater.HighHeatRetention = null;
            xmlMainHeating.MainHeatingNumber = 1;
            xmlMainHeating.MainHeatingCategory = heating.Main.HeatingCategoryCode.FromSAPToXML();
            xmlMainHeating.MainHeatingDataSource = heating.Main.HeatingDetails.Source.FromSAPToXML();
            xmlMainHeating.CombiBoilerType = null;
            xmlMainHeating.CaseHeatEmission = null;
            xmlMainHeating.HeatTransferToWater = null;
            xmlMainHeating.SolidFuelBoilerType = null;
            xmlMainHeating.MainHeatingCode = null;
            xmlMainHeating.MainFuelType = heating.Main.HeatingFuel.Fuel.FromSAPToXML();
            xmlMainHeating.MainHeatingControl = heating.Main.HeatingControls.Controls;
            xmlMainHeating.HeatEmitterType = heating.Main.HeatingDetails.EmitterType.FromSAPToXML();
            xmlMainHeating.UnderfloorHeatEmitterType = null;
            xmlMainHeating.MainHeatingFlueType = heating.Main.BoilerInformation.FlueType.FromSAPToXML();
            xmlMainHeating.IsFlueFanPresent = heating.Main.BoilerInformation.FanFlued;
            xmlMainHeating.IsCentralHeatingPumpInHeatedSpace = heating.Main.BoilerInformation.PumpInHeatedSpace;//only if wet system, Need to check these two
            xmlMainHeating.IsOilPumpInHeatedSpace = null;// only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE
            xmlMainHeating.IsInterLockedSystem = heating.Main.BoilerInformation.BoilerInterlock;
            xmlMainHeating.HasSeparateDelayedStart = heating.Main.HeatingControls.DelayedStartThermostat;
            xmlMainHeating.HasLoadOrWeatherCompensation = null;
            xmlMainHeating.BoilerFuelFeed = null;
            xmlMainHeating.IsMainHeatingHETASApproved = heating.Main.HETASApproved;
            xmlMainHeating.ElectricCPSUOperatingTemperature = null;
            xmlMainHeating.LoadOrWeatherCompensation = heating.Main.HeatingControls.HasLoadOrWeatherCompensation.FromSAPToXML();
            xmlMainHeating.MainHeatingFraction = heating.Main.FractionOfHeat;
            xmlMainHeating.BurnerControl = null;
            if (heating.Main.FGHRS != null)
            { xmlMainHeating.HasFGHRS = true; }
            else if (heating.Main.FGHRS == null)
            { xmlMainHeating.HasFGHRS = false; }
            xmlMainHeating.FGHRSIndexNumber = heating.Main.FGHRS.IndexNumber;
            xmlMainHeating.FGHRSEnergySource = null;
            xmlMainHeatingDeclaredValues.Efficiency = null;
            xmlMainHeatingDeclaredValues.MakeModel = null;
            xmlMainHeatingDeclaredValues.TestMethod = null;
            xmlMainHeating.MainHeatingDeclaredValues = xmlMainHeatingDeclaredValues;
            xmlStorageHeater.NumberOfHeaters = null;
            xmlStorageHeaters.StorageHeater = xmlStorageHeater;
            xmlMainHeating.StorageHeaters = xmlStorageHeaters;
            xmlMainHeating.EmitterTemperature = heating.Main.HeatingDetails.EmitterTemperature.FromSAPToXML();   
            xmlMainHeating.MCSInstalledHeatPump = heating.Main.MCSCertificate;
            xmlMainHeating.CentralHeatingPumpAge = heating.Main.HeatingDetails.PumpAge.FromSAPToXML();
            xmlMainHeating.CompensatingControllerIndexNumber = null;
            xmlMainHeating.TTZCIndexNumber = null;

            xmlMainHeatingList.Add(xmlMainHeating);

            oM.Environment.SAP.XML.MainHeating xmlSecondaryMainHeating = new oM.Environment.SAP.XML.MainHeating();
            if (heating.SecondaryMain == null)
            {
                xmlSecondaryMainHeating.MainHeatingNumber = null;
                xmlSecondaryMainHeating.MainHeatingCategory = null;
                xmlSecondaryMainHeating.MainHeatingDataSource = null;
                xmlSecondaryMainHeating.MainHeatingIndexNumber = null;
                xmlSecondaryMainHeating.IsCondensingBoiler = null;
                xmlSecondaryMainHeating.GasOrOilBoilerType = null;
                xmlSecondaryMainHeating.CombiBoilerType = null;
                xmlSecondaryMainHeating.CaseHeatEmission = null;
                xmlSecondaryMainHeating.HeatTransferToWater = null;
                xmlSecondaryMainHeating.SolidFuelBoilerType = null;
                xmlSecondaryMainHeating.MainHeatingCode = null;
                xmlSecondaryMainHeating.MainFuelType = null;
                xmlSecondaryMainHeating.MainHeatingControl = null;
                xmlSecondaryMainHeating.HeatEmitterType = null;
                xmlSecondaryMainHeating.UnderfloorHeatEmitterType = null;
                xmlSecondaryMainHeating.MainHeatingFlueType = null;
                xmlSecondaryMainHeating.IsFlueFanPresent = null;
                xmlSecondaryMainHeating.IsCentralHeatingPumpInHeatedSpace = null;
                xmlSecondaryMainHeating.IsOilPumpInHeatedSpace = null;
                xmlSecondaryMainHeating.IsInterLockedSystem = null;
                xmlSecondaryMainHeating.HasSeparateDelayedStart = null;
                xmlSecondaryMainHeating.HasLoadOrWeatherCompensation = null;
                xmlSecondaryMainHeating.BoilerFuelFeed = null;
                xmlSecondaryMainHeating.IsMainHeatingHETASApproved = null;
                xmlSecondaryMainHeating.ElectricCPSUOperatingTemperature = null;
                xmlSecondaryMainHeating.LoadOrWeatherCompensation = null;
                xmlSecondaryMainHeating.MainHeatingFraction = 0;
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
                xmlSecondaryMainHeating.MCSInstalledHeatPump = null;
                xmlSecondaryMainHeating.CentralHeatingPumpAge = null;
                xmlSecondaryMainHeating.CompensatingControllerIndexNumber = null;
                xmlSecondaryMainHeating.TTZCIndexNumber = null;
            }
            else if (heating.SecondaryMain != null)
            {
                xmlSecondaryMainHeating.MainHeatingNumber = 2;

                xmlSecondaryMainHeating.MainHeatingCategory = heating.SecondaryMain.HeatingCategoryCode.FromSAPToXML(); ;
                xmlSecondaryMainHeating.MainHeatingDataSource = heating.SecondaryMain.HeatingDetails.Source.FromSAPToXML();
                xmlSecondaryMainHeating.MainHeatingIndexNumber = null;
                xmlSecondaryMainHeating.IsCondensingBoiler = null;
                xmlSecondaryMainHeating.GasOrOilBoilerType = null;
                xmlSecondaryMainHeating.CombiBoilerType = null;
                xmlSecondaryMainHeating.CaseHeatEmission = null;
                xmlSecondaryMainHeating.HeatTransferToWater = null;
                xmlSecondaryMainHeating.SolidFuelBoilerType = null;
                xmlSecondaryMainHeating.MainHeatingCode = null;
                xmlSecondaryMainHeating.MainFuelType = heating.SecondaryMain.HeatingFuel.Fuel.FromSAPToXML();
                xmlSecondaryMainHeating.MainHeatingControl = heating.SecondaryMain.HeatingControls.Controls;
                xmlSecondaryMainHeating.HeatEmitterType = heating.SecondaryMain.HeatingDetails.EmitterType.FromSAPToXML();
                xmlSecondaryMainHeating.UnderfloorHeatEmitterType = null;
                xmlSecondaryMainHeating.MainHeatingFlueType = heating.SecondaryMain.BoilerInformation.FlueType.FromSAPToXML();
                xmlSecondaryMainHeating.IsFlueFanPresent = heating.SecondaryMain.BoilerInformation.FanFlued;
                xmlSecondaryMainHeating.IsCentralHeatingPumpInHeatedSpace = heating.SecondaryMain.BoilerInformation.PumpInHeatedSpace;
                xmlSecondaryMainHeating.IsOilPumpInHeatedSpace = heating.SecondaryMain.BoilerInformation.PumpInHeatedSpace;
                xmlSecondaryMainHeating.IsInterLockedSystem = heating.SecondaryMain.BoilerInformation.BoilerInterlock;
                xmlSecondaryMainHeating.HasSeparateDelayedStart = heating.SecondaryMain.HeatingControls.DelayedStartThermostat;
                xmlSecondaryMainHeating.HasLoadOrWeatherCompensation = null;
                xmlSecondaryMainHeating.BoilerFuelFeed = null;
                xmlSecondaryMainHeating.IsMainHeatingHETASApproved = heating.SecondaryMain.HETASApproved;
                xmlSecondaryMainHeating.ElectricCPSUOperatingTemperature = null;
                xmlSecondaryMainHeating.LoadOrWeatherCompensation = heating.SecondaryMain.HeatingControls.HasLoadOrWeatherCompensation.FromSAPToXML();
                xmlSecondaryMainHeating.MainHeatingFraction = heating.SecondaryMain.FractionOfHeat;
                xmlSecondaryMainHeating.BurnerControl = null;
                xmlSecondaryMainHeating.EfficiencyType = null;
                xmlSecondaryMainHeating.MainHeatingEfficiencyWinter = null;
                xmlSecondaryMainHeating.MainHeatingEfficiencySummer = null;
                if (heating.SecondaryMain.FGHRS != null)
                { xmlSecondaryMainHeating.HasFGHRS = true; }
                else if (heating.SecondaryMain.FGHRS == null)
                { xmlSecondaryMainHeating.HasFGHRS = false;  }
                xmlSecondaryMainHeating.FGHRSIndexNumber = heating.SecondaryMain.FGHRS.IndexNumber;
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

                xmlSecondaryMainHeating.EmitterTemperature = heating.SecondaryMain.HeatingDetails.EmitterTemperature.FromSAPToXML();
                xmlSecondaryMainHeating.MCSInstalledHeatPump = heating.SecondaryMain.MCSCertificate;
                xmlSecondaryMainHeating.CentralHeatingPumpAge = heating.SecondaryMain.HeatingDetails.PumpAge.FromSAPToXML();
                xmlSecondaryMainHeating.CompensatingControllerIndexNumber = null;
                xmlSecondaryMainHeating.TTZCIndexNumber = null;

                xmlMainHeatingList.Add(xmlSecondaryMainHeating);
            }   

            oM.Environment.SAP.XML.Heating xmlHeating = new oM.Environment.SAP.XML.Heating();
            xmlHeating.WaterHeatingCode = heating.WaterHeating.Type;
            xmlHeating.WaterFuelType = heating.WaterHeating.Fuel.FromSAPToXML();
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
            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingCategory.FromSAPToXML();
            xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source.FromSAPToXML();
            xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingCode;
            xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel.FromSAPToXML();
            xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType.FromSAPToXML();
            xmlHeating.ImmersionHeatingType = heating.WaterHeating.Immersion.Type;
            xmlHeating.IsHeatPumpAssistedByImmersion = heating.WaterHeating.Immersion.UseOfImmersion;
            xmlHeating.IsImmersionForSummerUse = heating.WaterHeating.Immersion.SummerImmersion;
            xmlHeating.ThermalStore = heating.WaterHeating.ThermalStore.FromSAPToXML();
            xmlHeating.HasFixedAirConditioning = false; //Needs to be added in some method
            xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
            xmlHeating.HotWaterStoreHeatTransferArea = heating.WaterHeating.Immersion.HeatExchangerArea;//?
            xmlHeating.HotWaterStoreHeatLossSource = null;
            xmlHeating.IsThermalStoreNearBoiler = null;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = null;

            oM.Environment.SAP.XML.CommunityHeatingSystems xmlCommunityHeatingSystems = new oM.Environment.SAP.XML.CommunityHeatingSystems();
            oM.Environment.SAP.XML.CommunityHeatingSystem xmlCommunityHeatingSystem = new oM.Environment.SAP.XML.CommunityHeatingSystem();
            oM.Environment.SAP.XML.CommunityHeatSources xmlCommunityHeatSources = new oM.Environment.SAP.XML.CommunityHeatSources();
            oM.Environment.SAP.XML.CommunityHeatSource xmlCommunityHeatSource = new oM.Environment.SAP.XML.CommunityHeatSource();
                xmlCommunityHeatingSystem.CommunityHeatingUse = null;
                xmlCommunityHeatingSystem.IsCommunityHeatingCylinderInDwelling = null;
                xmlCommunityHeatingSystem.CommunityHeatingDistributionType = null;
                xmlCommunityHeatSource.HeatSourceType = null;
                xmlCommunityHeatSource.HeatFraction = null;
                xmlCommunityHeatSource.FuelType = null;
                xmlCommunityHeatSource.HeatEfficiency = null;
                xmlCommunityHeatSource.PowerEfficiency = null;
                xmlCommunityHeatSource.Description = null;
                xmlCommunityHeatingSystem.CommunityHeatingDistributionLossFactor = null;
                xmlCommunityHeatingSystem.ChargingLinkedToHeatUse = null;
                xmlCommunityHeatingSystem.HeatNetworkIndexNumber = null;
            xmlCommunityHeatingSystems.CommunityHeatingSystem = xmlCommunityHeatingSystem;
            xmlCommunityHeatingSystem.CommunityHeatSources = xmlCommunityHeatSources;
            xmlCommunityHeatSources.CommunityHeatSource = xmlCommunityHeatSource;
            xmlHeating.CommunityHeatingSystems = xmlCommunityHeatingSystems;

            oM.Environment.SAP.XML.MainHeatingDetails xmlMainHeatingDetails = new oM.Environment.SAP.XML.MainHeatingDetails();
            xmlMainHeatingDetails.MainHeating = xmlMainHeatingList;
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
            if (heating.WWHRS == null)
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
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = null;
            }
            else if (heating.WWHRS.System1.System.InstantaneousOrStorage == "1")
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = heating.WWHRS.System1.System.Index;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithBath = heating.WWHRS.System1.MixerShowersWithBath;
                xmlInstantaneousWWHRS.MixerShowersWithSystem1WithoutBath = heating.WWHRS.System1.MixerSHowersWithoutBath;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            }
            else if (heating.WWHRS.System2.System.InstantaneousOrStorage == "1")
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = heating.WWHRS.System2.System.Index;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithBath = heating.WWHRS.System2.MixerShowersWithBath;
                xmlInstantaneousWWHRS.SecondOrderHeatLossCoefficient = null;
                xmlInstantaneousWWHRS.MixerShowersWithSystem2WithoutBath = heating.WWHRS.System2.MixerSHowersWithoutBath;
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            }
            else if (heating.WWHRS.System1.System.InstantaneousOrStorage == "2")
            {
                xmlStorageWWHRS.WWHRSIndexNumber = heating.WWHRS.System1.System.Index;
                xmlStorageWWHRS.TotalShowersAndBaths = null;
                xmlStorageWWHRS.BathsAndShowersToWWHRS = null;
                xmlStorageWWHRS.WWHRSStoreVolume = heating.WWHRS.System1.System.TestDedicatedVolume;
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            }
            else if (heating.WWHRS.System2.System.InstantaneousOrStorage == "2")
            {
                xmlStorageWWHRS.WWHRSIndexNumber = heating.WWHRS.System2.System.Index;
                xmlStorageWWHRS.TotalShowersAndBaths = null;
                xmlStorageWWHRS.BathsAndShowersToWWHRS = null;
                xmlStorageWWHRS.WWHRSStoreVolume = heating.WWHRS.System2.System.TestDedicatedVolume;
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            }
            else if (heating.WWHRS.System1.System.InstantaneousOrStorage != "2" && heating.WWHRS.System1.System.InstantaneousOrStorage != "1")
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
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            }
            else if (heating.WWHRS.System2.System.InstantaneousOrStorage != "2" && heating.WWHRS.System2.System.InstantaneousOrStorage != "1")
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
                xmlInstantaneousWWHRS.RoomsWithBathAndOrShower = heating.WWHRS.TotalRoomsWithShowerOrBath;
            }
            xmlHeating.InstantaneousWHRS = xmlInstantaneousWWHRS;
            xmlHeating.StorageWHRS = xmlStorageWWHRS;

            return new Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling>() { Item1 = xmlHeating, Item2 = xmlCooling };
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.MainHeatingCategoryCode categoryCode)
        {
            switch (categoryCode)
            {
                case BH.oM.Environment.SAP.MainHeatingCategoryCode.None:
                    return "1";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.BoilerWRadiatorsOrUnderfloor:
                    return "2";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.MicroCogeneration:
                    return "3";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.HeatPumpWRadiatorsOrUnderfloor:
                    return "4";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.HeatPumpWWarmAirDistribution:
                    return "5";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.CommunityHeatingSystem:
                    return "6";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.ElectricStorageHeaters:
                    return "7";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.ElectricUnderfloorHeating:
                    return "8";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.WarmAirSystem:
                    return "9";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.RoomHeaters:
                    return "10";

                case BH.oM.Environment.SAP.MainHeatingCategoryCode.OtherSystem:
                    return "11";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.DataSourceCode sourceCode)
        {
            switch (sourceCode)
            {
                case BH.oM.Environment.SAP.DataSourceCode.ManufacturerDeclaration:
                    return "2";

                case BH.oM.Environment.SAP.DataSourceCode.SAPtable:
                    return "3";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.HeatingFuelTypeCode fuelCode)
        {
            switch (fuelCode)
            {
                case BH.oM.Environment.SAP.HeatingFuelTypeCode.MainsGas:
                    return "1";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BulkLPG:
                    return "2";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BottledLPG:
                    return "3";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.HeatingOil:
                    return "4";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Biogas:
                    return "7";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.LNG:
                    return "8";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.LPGSpecialCondition:
                    return "9";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.SolidFuelMineralAndWood:
                    return "10";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.HouseCoal:
                    return "11";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ManufacturedSmokelessFuel:
                    return "12";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Anthracite:
                    return "15";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodLogs:
                    return "20";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodChips:
                    return "21";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodPelletsSecondaryHeating:
                    return "22";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodPelletsMainHeating:
                    return "23";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ElectricitySoldToGrid:
                    return "36";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ElectricityDisplacedFromGrid:
                    return "37";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ElectricityUnspecTariff:
                    return "39";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityHeatPump:
                    return "41";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersWaste:
                    return "42";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersBiomass:
                    return "43";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersBiogas:
                    return "44";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityWastePowerStations:
                    return "45";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityGeothermal:
                    return "46";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityCHP:
                    return "48";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityElectricityCHP:
                    return "49";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityElectricityNetwork:
                    return "50";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityMainsGas:
                    return "51";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityLPG:
                    return "52";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityOil:
                    return "53";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityCoal:
                    return "54";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityB30D:
                    return "55";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersMineralOilBiodiesel:
                    return "56";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersBiodiesel:
                    return "57";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBiodieselVegetableOil:
                    return "58";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Biodiesel:
                    return "71";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BiodieselUsedCookingOil:
                    return "72";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BiodieselVegetableOil:
                    return "73";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.MineralOilLiquidBiofuel:
                    return "74";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.B30K:
                    return "75";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Bioethanol:
                    return "76";

                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunitySpecial:
                    return "99";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.EmitterTemperatureCode temperatureCode)
        {
            switch (temperatureCode)
            {
                case BH.oM.Environment.SAP.EmitterTemperatureCode.Unknown:
                    return "0";

                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over45:
                    return "1";

                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over35:
                    return "2";

                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over35LessThan45:
                    return "3";

                case BH.oM.Environment.SAP.EmitterTemperatureCode.LessThan35:
                    return "4";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.PumpAge ageCode)
        {
            switch (ageCode)
            {
                case BH.oM.Environment.SAP.PumpAge.Unknown:
                    return "0";

                case BH.oM.Environment.SAP.PumpAge.Earlier2012:
                    return "1";

                case BH.oM.Environment.SAP.PumpAge.Later2013:
                    return "2";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.HeatEmitterCode emitterCode)
        {
            switch (emitterCode)
            {
                case BH.oM.Environment.SAP.HeatEmitterCode.Radiators:
                    return "1";

                case BH.oM.Environment.SAP.HeatEmitterCode.Underfloor:
                    return "2";

                case BH.oM.Environment.SAP.HeatEmitterCode.RadiatorsAndUnderfloor:
                    return "3";

                case BH.oM.Environment.SAP.HeatEmitterCode.FanCoilUnits:
                    return "4";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.FlueTypeCode flueCode)
        {
            switch (flueCode)
            {
                case BH.oM.Environment.SAP.FlueTypeCode.OpenFlue:
                    return "1";

                case BH.oM.Environment.SAP.FlueTypeCode.BalancedFlue:
                    return "2";

                case BH.oM.Environment.SAP.FlueTypeCode.Chimney:
                    return "3";

                case BH.oM.Environment.SAP.FlueTypeCode.Omitted:
                    return "4";

                case BH.oM.Environment.SAP.FlueTypeCode.Unknown:
                    return "5";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.HasLoadOrWeatherCompensation compensationCode)
        {
            switch (compensationCode)
            {
                case BH.oM.Environment.SAP.HasLoadOrWeatherCompensation.None:
                    return "0";

                case BH.oM.Environment.SAP.HasLoadOrWeatherCompensation.LoadOrWeatherCompensation:
                    return "4";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.SecondaryHeatingCategory categoryCode)
        {
            switch (categoryCode)
            {
                case BH.oM.Environment.SAP.SecondaryHeatingCategory.None:
                    return "1";

                case BH.oM.Environment.SAP.SecondaryHeatingCategory.RoomHeaters:
                    return "10";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.ThermalStoreCode storeCode)
        {
            switch (storeCode)
            {
                case BH.oM.Environment.SAP.ThermalStoreCode.None:
                    return "1";

                case BH.oM.Environment.SAP.ThermalStoreCode.HotWaterOnly:
                    return "2";

                case BH.oM.Environment.SAP.ThermalStoreCode.Integrated:
                    return "3";

                default:
                    return "";
            }
        }
    }
}