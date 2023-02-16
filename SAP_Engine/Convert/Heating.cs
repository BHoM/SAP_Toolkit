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
using BH.oM.Base;
using System.Xml;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP C to XML Heating.")]
        [Input("sapHeating", "SAP Heating object to convert.")]
        [MultiOutput(0, "heating", "XML Heating.")]
        [MultiOutput(1, "cooling", "XML Cooling.")]
        public static Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling> ToXML(this oM.Environment.SAP.Heating heating)
        {
            oM.Environment.SAP.XML.Cooling xmlCooling = new oM.Environment.SAP.XML.Cooling();
            xmlCooling.CooledArea = heating.Cooling.CooledArea;
            xmlCooling.CoolingSystemDataSource = heating.Cooling.DataSource;
            xmlCooling.CoolingSystemClass = null;
            xmlCooling.CoolingSystemSEER = heating.Cooling.SEER;

            oM.Environment.SAP.XML.Heating xmlHeating = new oM.Environment.SAP.XML.Heating();
            oM.Environment.SAP.XML.MainHeatingDetails xmlMainHeatingDetails = new oM.Environment.SAP.XML.MainHeatingDetails();

            List<oM.Environment.SAP.XML.MainHeating> xmlMainHeatingList = new List<oM.Environment.SAP.XML.MainHeating>();
            oM.Environment.SAP.XML.MainHeating xmlMainHeating = new oM.Environment.SAP.XML.MainHeating();
            xmlMainHeating.MainHeatingNumber = "1";
            xmlMainHeating.MainHeatingCategory = heating.Main.HeatingCategoryCode.FromSAPToXML();
            xmlMainHeating.MainHeatingDataSource = heating.Main.HeatingDetails.Source.FromSAPToXML();
            xmlMainHeating.MainHeatingIndexNumber = heating.Main.HeatingDetails.ProductIndex;
            xmlMainHeating.MainHeatingManufacturer = null;
            xmlMainHeating.MainHeatingModel = null;
            xmlMainHeating.MainHeatingCommissioningCertificate = null;
            xmlMainHeating.MainHeatingInstallationEngineer = null;
            xmlMainHeating.IsCondensingBoiler = null;
            xmlMainHeating.HeatPumpHeatDistribution = null;
            xmlMainHeating.GasOrOilBoilerType = null;
            xmlMainHeating.CombiBoilerType = null;
            xmlMainHeating.CaseHeatEmission = null;
            xmlMainHeating.HeatTransferToWater = null;
            xmlMainHeating.SolidFuelBoilerType = null;
            xmlMainHeating.MainHeatingCode = null;
            xmlMainHeating.MainFuelType = heating.Main.HeatingFuel.Fuel.FromSAPToXML();
            xmlMainHeating.PCDFFuelIndex = null;
            xmlMainHeating.MainHeatingControl = heating.Main.HeatingControls.Controls;
            xmlMainHeating.HeatEmitterType = heating.Main.HeatingDetails.EmitterType.FromSAPToXML();
            xmlMainHeating.UnderfloorHeatEmitterType = null;
            xmlMainHeating.MainHeatingFlueType = heating.Main.BoilerInformation.FlueType.FromSAPToXML();
            xmlMainHeating.IsFlueFanPresent = heating.Main.BoilerInformation.FanFlued;
            xmlMainHeating.IsCentralHeatingPumpInHeatedSpace = heating.Main.BoilerInformation.PumpInHeatedSpace;//only if wet system, Need to check these two
            xmlMainHeating.IsOilPumpInHeatedSpace = null;// only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE
            xmlMainHeating.IsInterLockedSystem = heating.Main.BoilerInformation.BoilerInterlock;
            xmlMainHeating.HasSeparateDelayedStart = heating.Main.HeatingControls.DelayedStartThermostat;
            xmlMainHeating.BoilerFuelFeed = null;
            xmlMainHeating.IsMainHeatingHETASApproved = heating.Main.HETASApproved;
            xmlMainHeating.ElectricCPSUOperatingTemperature = null;
            xmlMainHeating.MainHeatingFraction = heating.Main.FractionOfHeat;
            xmlMainHeating.BurnerControl = null;
            xmlMainHeating.EfficiencyType = null;
            xmlMainHeating.MainHeatingEfficiencyWinter = null;
            xmlMainHeating.MainHeatingEfficiencySummer = null;
            xmlMainHeating.MainHeatingEfficiency = null;
            xmlMainHeating.MainHeatingSystemType = null;
            if (heating.Main.FGHRS != null)
            { xmlMainHeating.HasFGHRS = true; }
            else if (heating.Main.FGHRS == null)
            { xmlMainHeating.HasFGHRS = false; }
            xmlMainHeating.FGHRSIndexNumber = heating.Main.FGHRS.IndexNumber;
            xmlMainHeating.FGHRSEnergySource = null;


            //HeatingDeclaredValues
            oM.Environment.SAP.XML.HeatingDeclaredValues xmlMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
            xmlMainHeatingDeclaredValues.Efficiency = null;
            xmlMainHeatingDeclaredValues.MakeModel = null;
            xmlMainHeatingDeclaredValues.TestMethod = null;
            xmlMainHeating.MainHeatingDeclaredValues = xmlMainHeatingDeclaredValues;
            //

            //STORAGEHEATERS
            oM.Environment.SAP.XML.StorageHeaters xmlStorageHeaters = new oM.Environment.SAP.XML.StorageHeaters(); 
            List<oM.Environment.SAP.XML.StorageHeater> xmlStorageHeaterList = new List<oM.Environment.SAP.XML.StorageHeater>();
            oM.Environment.SAP.XML.StorageHeater xmlStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
            xmlStorageHeater.NumberOfHeaters = 0;
            xmlStorageHeater.IndexNumber = null;
            xmlStorageHeater.HighHeatRetention = null;
            xmlStorageHeaterList.Add(xmlStorageHeater);//clean up
            xmlStorageHeaters.StorageHeater = xmlStorageHeaterList;
            xmlMainHeating.StorageHeaters = xmlStorageHeaters;
            //

            xmlMainHeating.EmitterTemperature = heating.Main.HeatingDetails.EmitterTemperature.FromSAPToXML();
            xmlMainHeating.MCSInstalledHeatPump = heating.Main.MCSCertificate;
            xmlMainHeating.CentralHeatingPumpAge = heating.Main.HeatingDetails.PumpAge.FromSAPToXML();
            xmlMainHeating.ControlIndexNumber = null;
            xmlMainHeating.HeatingControllerFunction = null;
            xmlMainHeating.HeatingControllerEcodesignClass = null;
            xmlMainHeating.HeatingControllerManufacturer = null;
            xmlMainHeating.HeatingControllerModel = null;

            xmlMainHeatingList.Add(xmlMainHeating);


            oM.Environment.SAP.XML.MainHeating xmlSecondaryMainHeating = new oM.Environment.SAP.XML.MainHeating();

            if (heating.SecondaryMain == null)
            {
                xmlSecondaryMainHeating.MainHeatingNumber = null;
                xmlSecondaryMainHeating.MainHeatingCategory = null;
                xmlSecondaryMainHeating.MainHeatingDataSource = null;
                xmlSecondaryMainHeating.MainHeatingIndexNumber = null;
                xmlSecondaryMainHeating.MainHeatingManufacturer = null;
                xmlSecondaryMainHeating.MainHeatingModel = null;
                xmlSecondaryMainHeating.MainHeatingCommissioningCertificate = null;
                xmlSecondaryMainHeating.MainHeatingInstallationEngineer = null;
                xmlSecondaryMainHeating.IsCondensingBoiler = null;
                xmlSecondaryMainHeating.HeatPumpHeatDistribution = null;
                xmlSecondaryMainHeating.GasOrOilBoilerType = null;
                xmlSecondaryMainHeating.CombiBoilerType = null;
                xmlSecondaryMainHeating.CaseHeatEmission = null;
                xmlSecondaryMainHeating.HeatTransferToWater = null;
                xmlSecondaryMainHeating.SolidFuelBoilerType = null;
                xmlSecondaryMainHeating.MainHeatingCode = null;
                xmlSecondaryMainHeating.MainFuelType = null;
                xmlSecondaryMainHeating.PCDFFuelIndex = null;
                xmlSecondaryMainHeating.MainHeatingControl = null;
                xmlSecondaryMainHeating.HeatEmitterType = null;
                xmlSecondaryMainHeating.UnderfloorHeatEmitterType = null;
                xmlSecondaryMainHeating.MainHeatingFlueType = null;
                xmlSecondaryMainHeating.IsFlueFanPresent = null;
                xmlSecondaryMainHeating.IsCentralHeatingPumpInHeatedSpace = null;
                xmlSecondaryMainHeating.IsOilPumpInHeatedSpace = null;
                xmlSecondaryMainHeating.IsInterLockedSystem = null;
                xmlSecondaryMainHeating.HasSeparateDelayedStart = null;
                xmlSecondaryMainHeating.BoilerFuelFeed = null;
                xmlSecondaryMainHeating.IsMainHeatingHETASApproved = null;
                xmlSecondaryMainHeating.ElectricCPSUOperatingTemperature = null;
                xmlSecondaryMainHeating.MainHeatingFraction = 0;
                xmlSecondaryMainHeating.BurnerControl = null;
                xmlSecondaryMainHeating.EfficiencyType = null;
                xmlSecondaryMainHeating.MainHeatingEfficiencyWinter = null;
                xmlSecondaryMainHeating.MainHeatingEfficiencySummer = null;
                xmlSecondaryMainHeating.MainHeatingEfficiency = null;
                xmlSecondaryMainHeating.MainHeatingSystemType = null;
                xmlSecondaryMainHeating.HasFGHRS = null;
                xmlSecondaryMainHeating.FGHRSIndexNumber = null;
                xmlSecondaryMainHeating.FGHRSEnergySource = null;

                //HeatingDeclaredValues
                oM.Environment.SAP.XML.HeatingDeclaredValues xmlSecondaryMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
                xmlSecondaryMainHeatingDeclaredValues.Efficiency = null;
                xmlSecondaryMainHeatingDeclaredValues.MakeModel = null;
                xmlSecondaryMainHeatingDeclaredValues.TestMethod = null;
                xmlSecondaryMainHeating.MainHeatingDeclaredValues = xmlSecondaryMainHeatingDeclaredValues;
                //

                //STORAGEHEATERS
                oM.Environment.SAP.XML.StorageHeaters xmlSecondaryStorageHeaters = new oM.Environment.SAP.XML.StorageHeaters();
                List<oM.Environment.SAP.XML.StorageHeater> xmlSecondaryStorageHeaterList = new List<oM.Environment.SAP.XML.StorageHeater>();
                oM.Environment.SAP.XML.StorageHeater xmlSecondaryStorageHeater = new oM.Environment.SAP.XML.StorageHeater();

                xmlSecondaryStorageHeater.NumberOfHeaters = 0;
                xmlSecondaryStorageHeater.IndexNumber = null;
                xmlSecondaryStorageHeater.HighHeatRetention = null;
                xmlSecondaryStorageHeaterList.Add(xmlSecondaryStorageHeater);
                xmlSecondaryStorageHeaters.StorageHeater = xmlSecondaryStorageHeaterList;
                xmlSecondaryMainHeating.StorageHeaters = xmlSecondaryStorageHeaters;


                

                xmlSecondaryMainHeating.EmitterTemperature = null;
                xmlSecondaryMainHeating.MCSInstalledHeatPump = null;
                xmlSecondaryMainHeating.CentralHeatingPumpAge = null;
                xmlSecondaryMainHeating.ControlIndexNumber = null;
                xmlSecondaryMainHeating.HeatingControllerFunction = null;
                xmlSecondaryMainHeating.HeatingControllerEcodesignClass = null;
                xmlSecondaryMainHeating.HeatingControllerManufacturer = null;
                xmlSecondaryMainHeating.HeatingControllerModel = null;

                xmlMainHeatingList.Add(xmlSecondaryMainHeating);
            }

            else if (heating.SecondaryMain != null)
            {
                xmlSecondaryMainHeating.MainHeatingNumber = "2";
                xmlSecondaryMainHeating.MainHeatingCategory = heating.SecondaryMain.HeatingCategoryCode.FromSAPToXML();
                xmlSecondaryMainHeating.MainHeatingDataSource = heating.SecondaryMain.HeatingDetails.Source.FromSAPToXML();
                xmlSecondaryMainHeating.MainHeatingIndexNumber = heating.SecondaryMain.HeatingDetails.ProductIndex;
                xmlSecondaryMainHeating.MainHeatingManufacturer = null;
                xmlSecondaryMainHeating.MainHeatingModel = null;
                xmlSecondaryMainHeating.MainHeatingCommissioningCertificate = null;
                xmlSecondaryMainHeating.MainHeatingInstallationEngineer = null;
                xmlSecondaryMainHeating.IsCondensingBoiler = null;
                xmlSecondaryMainHeating.HeatPumpHeatDistribution = null;
                xmlSecondaryMainHeating.GasOrOilBoilerType = null;
                xmlSecondaryMainHeating.CombiBoilerType = null;
                xmlSecondaryMainHeating.CaseHeatEmission = null;
                xmlSecondaryMainHeating.HeatTransferToWater = null;
                xmlSecondaryMainHeating.SolidFuelBoilerType = null;
                xmlSecondaryMainHeating.MainHeatingCode = null;
                xmlSecondaryMainHeating.MainFuelType = heating.SecondaryMain.HeatingFuel.Fuel.FromSAPToXML();
                xmlSecondaryMainHeating.PCDFFuelIndex = null;
                xmlSecondaryMainHeating.MainHeatingControl = heating.SecondaryMain.HeatingControls.Controls;
                xmlSecondaryMainHeating.HeatEmitterType = heating.SecondaryMain.HeatingDetails.EmitterType.FromSAPToXML();
                xmlSecondaryMainHeating.UnderfloorHeatEmitterType = null;
                xmlSecondaryMainHeating.MainHeatingFlueType = heating.SecondaryMain.BoilerInformation.FlueType.FromSAPToXML();
                xmlSecondaryMainHeating.IsFlueFanPresent = heating.SecondaryMain.BoilerInformation.FanFlued;
                xmlSecondaryMainHeating.IsCentralHeatingPumpInHeatedSpace = heating.SecondaryMain.BoilerInformation.PumpInHeatedSpace;//only if wet system, Need to check these two
                xmlSecondaryMainHeating.IsOilPumpInHeatedSpace = null;// only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE
                xmlSecondaryMainHeating.IsInterLockedSystem = heating.SecondaryMain.BoilerInformation.BoilerInterlock;
                xmlSecondaryMainHeating.HasSeparateDelayedStart = heating.SecondaryMain.HeatingControls.DelayedStartThermostat;
                xmlSecondaryMainHeating.BoilerFuelFeed = null;
                xmlSecondaryMainHeating.IsMainHeatingHETASApproved = heating.SecondaryMain.HETASApproved;
                xmlSecondaryMainHeating.ElectricCPSUOperatingTemperature = null;
                xmlSecondaryMainHeating.MainHeatingFraction = heating.SecondaryMain.FractionOfHeat;
                xmlSecondaryMainHeating.BurnerControl = null;
                xmlSecondaryMainHeating.EfficiencyType = null;
                xmlSecondaryMainHeating.MainHeatingEfficiencyWinter = null;
                xmlSecondaryMainHeating.MainHeatingEfficiencySummer = null;
                xmlSecondaryMainHeating.MainHeatingEfficiency = null;
                xmlSecondaryMainHeating.MainHeatingSystemType = null;
                if (heating.SecondaryMain.FGHRS != null)
                { xmlSecondaryMainHeating.HasFGHRS = true; }
                else if (heating.SecondaryMain.FGHRS == null)
                { xmlSecondaryMainHeating.HasFGHRS = false; }
                xmlSecondaryMainHeating.FGHRSIndexNumber = heating.SecondaryMain.FGHRS.IndexNumber;
                xmlSecondaryMainHeating.FGHRSEnergySource = null;


                //HeatingDeclaredValues
                oM.Environment.SAP.XML.HeatingDeclaredValues xmlSecondaryMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
                xmlSecondaryMainHeatingDeclaredValues.Efficiency = null;
                xmlSecondaryMainHeatingDeclaredValues.MakeModel = null;
                xmlSecondaryMainHeatingDeclaredValues.TestMethod = null;
                xmlSecondaryMainHeating.MainHeatingDeclaredValues = xmlSecondaryMainHeatingDeclaredValues;
                //

                //STORAGEHEATERS
                oM.Environment.SAP.XML.StorageHeaters xmlSecondaryStorageHeaters = new oM.Environment.SAP.XML.StorageHeaters();
                List<oM.Environment.SAP.XML.StorageHeater> xmlSecondaryStorageHeaterList = new List<oM.Environment.SAP.XML.StorageHeater>();
                oM.Environment.SAP.XML.StorageHeater xmlSecondaryStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
                xmlSecondaryStorageHeater.NumberOfHeaters = 0;
                xmlSecondaryStorageHeater.IndexNumber = null;
                xmlSecondaryStorageHeater.HighHeatRetention = null;
                xmlSecondaryStorageHeaterList.Add(xmlSecondaryStorageHeater); //clean up
                xmlSecondaryStorageHeaters.StorageHeater = xmlSecondaryStorageHeaterList;
                xmlSecondaryMainHeating.StorageHeaters = xmlSecondaryStorageHeaters;
                //

                xmlSecondaryMainHeating.EmitterTemperature = heating.SecondaryMain.HeatingDetails.EmitterTemperature.FromSAPToXML();
                xmlSecondaryMainHeating.MCSInstalledHeatPump = heating.SecondaryMain.MCSCertificate;
                xmlSecondaryMainHeating.CentralHeatingPumpAge = heating.SecondaryMain.HeatingDetails.PumpAge.FromSAPToXML();
                xmlSecondaryMainHeating.ControlIndexNumber = null;
                xmlSecondaryMainHeating.HeatingControllerFunction = null;
                xmlSecondaryMainHeating.HeatingControllerEcodesignClass = null;
                xmlSecondaryMainHeating.HeatingControllerManufacturer = null;
                xmlSecondaryMainHeating.HeatingControllerModel = null;

                xmlMainHeatingList.Add(xmlSecondaryMainHeating);
            }

            xmlMainHeatingDetails.MainHeating = xmlMainHeatingList;
            xmlHeating.MainHeatingDetails = xmlMainHeatingDetails;


            xmlHeating.WaterHeatingCode = heating.WaterHeating.Type;
            xmlHeating.WaterFuelType = heating.WaterHeating.Fuel.FromSAPToXML();
            if (heating.WaterHeating.CylinderSpecification != null)
            {
                xmlHeating.HasHotWaterCylinder = true;
                xmlHeating.HotWaterStoreSize = heating.WaterHeating.CylinderSpecification.Volume;
                xmlHeating.HotWaterStoreHeatTransferArea = heating.WaterHeating.Immersion.HeatExchangerArea;
                xmlHeating.HotWaterStoreHeatLoss = heating.WaterHeating.CylinderSpecification.DeclaredLossFactor;
                xmlHeating.HotWaterStoreInsulationType = heating.WaterHeating.CylinderSpecification.InsulationType;
                xmlHeating.HotWaterInsulationThickness = heating.WaterHeating.CylinderSpecification.InsulationThickness;
                xmlHeating.HasCylinderThermostat = heating.WaterHeating.CylinderSpecification.Cylinderstat;
                xmlHeating.IsCylinderInHeatedSpace = heating.WaterHeating.CylinderSpecification.InHeatedSpace;
                xmlHeating.IsHotWaterSeperatlyTimed = heating.WaterHeating.CylinderSpecification.TimedSeperatly;

            }
            if (heating.WaterHeating.CylinderSpecification == null)
            {
                xmlHeating.HasHotWaterCylinder = false;
                xmlHeating.HotWaterStoreSize = null;
                xmlHeating.HotWaterStoreHeatTransferArea = null;
                xmlHeating.HotWaterStoreHeatLoss = null;
                xmlHeating.HotWaterStoreInsulationType = null;
                xmlHeating.HotWaterInsulationThickness = null;
                xmlHeating.HasCylinderThermostat = null;
                xmlHeating.IsCylinderInHeatedSpace = null;
                xmlHeating.IsHotWaterSeperatlyTimed = null;
            }

            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingCategory.FromSAPToXML();//?
            xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source.FromSAPToXML();//?
            xmlHeating.SecondaryHeatingEfficiency = null;
            xmlHeating.SecondaryHeatingCommisioningCertificate = null;
            xmlHeating.SecondaryHeatingInstallationEngineer = null;
            xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingCode;
            xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel.FromSAPToXML();
            xmlHeating.SecondaryHeatingPCDFFuelIndex = null;
            xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType.FromSAPToXML();
            xmlHeating.ThermalStore = heating.WaterHeating.ThermalStore.FromSAPToXML();
            xmlHeating.HasFixedAirConditioning = false;
            xmlHeating.ImmersionHeatingType = heating.WaterHeating.Immersion.Type;
            xmlHeating.IsHeatPumpAssistedByImmersion = heating.WaterHeating.Immersion.UseOfImmersion;
            xmlHeating.IsHeatPumpInstalledToMIS = null; //Add to sap class
            xmlHeating.IsImmersionForSummerUse = heating.WaterHeating.Immersion.SummerImmersion;
            xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
            xmlHeating.HotWaterControlsManufacturer = null;
            xmlHeating.HotWaterStoreModel = null;
            xmlHeating.HotWaterStoreCommissioningCertificate = null;
            xmlHeating.HotWaterStoreInstallerEngineerRegistration = null;
            //Needs to be added in some method
            xmlHeating.HotWaterStoreHeatLossSource = null;
            xmlHeating.IsThermalStoreNearBoiler = null;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = null;
            xmlHeating.HotWaterControlsManufacturer = null;
            xmlHeating.HotWaterControlsModel = null;


            oM.Environment.SAP.XML.CommunityHeatingSystems xmlCommunityHeatingSystems = new oM.Environment.SAP.XML.CommunityHeatingSystems();
            List<oM.Environment.SAP.XML.CommunityHeatingSystem> xmlCommunityHeatingSystemList = new List<oM.Environment.SAP.XML.CommunityHeatingSystem>();
            oM.Environment.SAP.XML.CommunityHeatingSystem xmlCommunityHeatingSystem = new oM.Environment.SAP.XML.CommunityHeatingSystem();

            xmlCommunityHeatingSystem.CommunityHeatingName = null;
            xmlCommunityHeatingSystem.CommunityHeatingCO2EmissionFactor = null; //add to class
            xmlCommunityHeatingSystem.CommunityHeatingPrimaryEnergyFactor = null;
            xmlCommunityHeatingSystem.CommunityHeatingUse = null;
            xmlCommunityHeatingSystem.IsCommunityHeatingCylinderInDwelling = null;
            xmlCommunityHeatingSystem.IsHeatInterfaceUnitInDwelling = null;
            xmlCommunityHeatingSystem.HeatInterfaceUnitIndexNumber = null;
            xmlCommunityHeatingSystem.CommunityHeatingDistributionType = null;

            //CommunityHeatSource
            oM.Environment.SAP.XML.CommunityHeatSources xmlCommunityHeatSources = new oM.Environment.SAP.XML.CommunityHeatSources();
            List<oM.Environment.SAP.XML.CommunityHeatSource> xmlCommunityHeatSourceList = new List<oM.Environment.SAP.XML.CommunityHeatSource>();
            oM.Environment.SAP.XML.CommunityHeatSource xmlCommunityHeatSource = new oM.Environment.SAP.XML.CommunityHeatSource();

            xmlCommunityHeatSource.HeatSourceType = null;
            xmlCommunityHeatSource.HeatFraction = null;
            xmlCommunityHeatSource.FuelType = null;
            xmlCommunityHeatSource.PCDFFuelIndex = null;
            xmlCommunityHeatSource.HeatEfficiency = null;
            xmlCommunityHeatSource.PowerEfficiency = null;
            xmlCommunityHeatSource.Description = null;
            xmlCommunityHeatSource.CHPElectricityGeneration = null;
            xmlCommunityHeatSourceList.Add(xmlCommunityHeatSource);
            xmlCommunityHeatSources.CommunityHeatSource = xmlCommunityHeatSourceList;
            xmlCommunityHeatingSystem.CommunityHeatSources = xmlCommunityHeatSources;


            xmlCommunityHeatingSystem.CommunityHeatingDistributionLossFactor = null;
            xmlCommunityHeatingSystem.ChargingLinkedToHeatUse = null;
            xmlCommunityHeatingSystem.HeatNetworkIndexNumber = null;
            xmlCommunityHeatingSystem.SubNetworkName = null;
            xmlCommunityHeatingSystem.HeatNetworkExisting = null;
            xmlCommunityHeatingSystemList.Add(xmlCommunityHeatingSystem);
            xmlCommunityHeatingSystems.CommunityHeatingSystem = xmlCommunityHeatingSystemList;
            xmlHeating.CommunityHeatingSystems = xmlCommunityHeatingSystems;

            xmlHeating.HeatingDesignWaterUse = null;
            xmlHeating.MainHeatingSystemsInteraction = null;

            //Secondary - heatingDeclaredValues
            oM.Environment.SAP.XML.HeatingDeclaredValues xmlHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
            xmlHeatingDeclaredValues.Efficiency = null;
            xmlHeatingDeclaredValues.MakeModel = null;
            xmlHeatingDeclaredValues.TestMethod = null;
            xmlHeating.SecondaryHeatingDeclaredValues = xmlHeatingDeclaredValues; //maybe link to secondary - main heating class

            xmlHeating.PrimaryPipeworkInsulation = null;

            //SolarHeatingDetails
            oM.Environment.SAP.XML.SolarHeatingDetails xmlSolarHeatingDetails = new oM.Environment.SAP.XML.SolarHeatingDetails();
            xmlSolarHeatingDetails.SolarHeatingCollectorManufacturer = null;
            xmlSolarHeatingDetails.SolarHeatingCertificate = null;
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
            xmlSolarHeatingDetails.CollectorLoopEfficiency = null;
            xmlSolarHeatingDetails.IncidenceAngleModifier = null;
            xmlSolarHeatingDetails.IsCommunitySolar = null;
            xmlSolarHeatingDetails.ServiceProvision = null;
            xmlSolarHeatingDetails.OverallHeatLoss = null;
            xmlHeating.SolarHeatingDetails = xmlSolarHeatingDetails;

            oM.Environment.SAP.XML.InstantaneousWWHRS xmlInstantaneousWWHRS = new oM.Environment.SAP.XML.InstantaneousWWHRS();
            oM.Environment.SAP.XML.StorageWWHRS xmlStorageWWHRS = new oM.Environment.SAP.XML.StorageWWHRS();

            //check if cases are correct - tried to make them as similar to prev closed but ultimatley not sure how the diff cases should be treated
            if (heating.WasteWaterHRS == null)
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = null;
                xmlInstantaneousWWHRS.WWHRSEfficiency1 = null;
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = null;
                xmlInstantaneousWWHRS.WWHRSEfficiency2 = null;
                xmlStorageWWHRS.WWHRSIndexNumber = null;
                xmlStorageWWHRS.WWHRSStoreVolume = null;
                xmlStorageWWHRS.StorageWWHRSEfficiency = null;

            }
            else if (heating.WasteWaterHRS.InstantaneousSystem1 != null)
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = heating.WasteWaterHRS.InstantaneousSystem1.IndexNumber;
                xmlInstantaneousWWHRS.WWHRSEfficiency1 = heating.WasteWaterHRS.InstantaneousSystem1.Efficiency;
            }
            else if (heating.WasteWaterHRS.InstantaneousSystem2 != null)
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = heating.WasteWaterHRS.InstantaneousSystem2.IndexNumber;
                xmlInstantaneousWWHRS.WWHRSEfficiency2 = heating.WasteWaterHRS.InstantaneousSystem2.Efficiency;
            }
            else if (heating.WasteWaterHRS.StorageSystem != null)
            {
                xmlStorageWWHRS.WWHRSIndexNumber = heating.WasteWaterHRS.StorageSystem.IndexNumber;
                xmlStorageWWHRS.WWHRSStoreVolume = heating.WasteWaterHRS.StorageSystem.StoreVolume;
                xmlStorageWWHRS.StorageWWHRSEfficiency = heating.WasteWaterHRS.StorageSystem.Efficiency;
            }

            xmlHeating.InstantaneousWHRS = xmlInstantaneousWWHRS;
            xmlHeating.StorageWHRS = xmlStorageWWHRS;



            List<oM.Environment.SAP.XML.ShowerOutlet> xmlShowerOutlets = new List<oM.Environment.SAP.XML.ShowerOutlet>();

            for (int i = 0; i < heating.ShowerOutlets.Count; i++)
            {
                oM.Environment.SAP.XML.ShowerOutlet xmlShowerOutlet = new oM.Environment.SAP.XML.ShowerOutlet();
                xmlShowerOutlet.ShowerOutletType = heating.ShowerOutlets[i].Type;
                xmlShowerOutlet.ShowerFlowRate = heating.ShowerOutlets[i].FlowRate;
                xmlShowerOutlet.ShowerPower = heating.ShowerOutlets[i].Power;
                xmlShowerOutlet.ShowerWWHRS = heating.ShowerOutlets[i].ShowerWWHRS;//connect with the WWHRS names
                xmlShowerOutlets.Add(xmlShowerOutlet);
            }

            xmlHeating.ShowerOutlets.ShowerOutlet = xmlShowerOutlets;

            xmlHeating.NumberBaths = 0;//check these ( wheres best to include)
            xmlHeating.NumberBathsWWHRS = 0;//check these ( wheres best to include)

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
