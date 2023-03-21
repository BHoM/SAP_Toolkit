/////*
//// * This file is part of the Buildings and Habitats object Model (BHoM)
//// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
//// *
//// * Each contributor holds copyright over their respective contributions.
//// * The project versioning (Git) records all such contribution source information.
//// *                                           
//// *                                                                              
//// * The BHoM is free software: you can redistribute it and/or modify         
//// * it under the terms of the GNU Lesser General Public License as published by  
//// * the Free Software Foundation, either version 3.0 of the License, or          
//// * (at your option) any later version.                                          
//// *                                                                              
//// * The BHoM is distributed in the hope that it will be useful,              
//// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
//// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
//// * GNU Lesser General Public License for more details.                          
//// *                                                                            
//// * You should have received a copy of the GNU Lesser General Public License     
//// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
//// */

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using BH.oM.Base.Attributes;
//using BH.oM.Base;
//using System.Xml;
//using BH.oM.Environment.SAP.Stroma10;

//namespace BH.Engine.Environment.SAP
//{
//    public static partial class Convert
//    {
//        [Description("Convert SAP C to XML Heating.")]
//        [Input("sapHeating", "SAP Heating object to convert.")]
//        [MultiOutput(0, "heating", "XML Heating.")]
//        [MultiOutput(1, "cooling", "XML Cooling.")]
//        public static Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling> ToXML(this oM.Environment.SAP.Stroma10.DwellingVersion dwelling)
//        {
            
//            oM.Environment.SAP.XML.Cooling xmlCooling = new oM.Environment.SAP.XML.Cooling();
//            if (dwelling.CoolingSystem == null)
//            {
//                xmlCooling.CooledArea = null;
//                xmlCooling.CoolingSystemDataSource = null;
//                xmlCooling.CoolingSystemClass = null;
//                xmlCooling.CoolingSystemSEER = null;
//            }
//            else if (dwelling.CoolingSystem != null)
//            {
//                xmlCooling.CooledArea = dwelling.CoolingSystem.CooledArea.ToString(); //check this just gives for one dwelling?
//                xmlCooling.CoolingSystemDataSource = null;
//                xmlCooling.CoolingSystemClass = dwelling.CoolingSystem.EnergyLabel.ToString();
//                xmlCooling.CoolingSystemSEER = dwelling.CoolingSystem.EER.ToString();
//            }

            

//            oM.Environment.SAP.XML.Heating xmlHeating = new oM.Environment.SAP.XML.Heating();
//            oM.Environment.SAP.XML.MainHeatingDetails xmlMainHeatingDetails = new oM.Environment.SAP.XML.MainHeatingDetails();
//            List<oM.Environment.SAP.XML.MainHeating> xmlMainHeatingList = new List<oM.Environment.SAP.XML.MainHeating>();
//            oM.Environment.SAP.XML.MainHeating xmlMainHeating = new oM.Environment.SAP.XML.MainHeating();

//            xmlMainHeating.MainHeatingNumber = "1";
//            xmlMainHeating.MainHeatingCategory = dwelling.PrimaryHeating.HeatingCategory.ToString(); //check conversion
//            xmlMainHeating.MainHeatingDataSource = dwelling.PrimaryHeating.Source.ToString();//check conversion
//            xmlMainHeating.MainHeatingIndexNumber = null; //IDK cldnt find
//            xmlMainHeating.MainHeatingManufacturer = dwelling.PrimaryHeating.ComplianceHeatingDetails.Manufacturer;
//            xmlMainHeating.MainHeatingModel = dwelling.PrimaryHeating.ComplianceHeatingDetails.Model;
//            xmlMainHeating.MainHeatingCommissioningCertificate = dwelling.PrimaryHeating.ComplianceHeatingDetails.CommissioningCertificate;
//            xmlMainHeating.MainHeatingInstallationEngineer = dwelling.PrimaryHeating.ComplianceHeatingDetails.InstallationEngineer;
//            xmlMainHeating.IsCondensingBoiler = null;
//            xmlMainHeating.HeatPumpHeatDistribution = null;
//            xmlMainHeating.GasOrOilBoilerType = null;
//            xmlMainHeating.CombiBoilerType = dwelling.WaterHeating.CombiType.ToString();//check types match up
//            xmlMainHeating.CaseHeatEmission = null;//IDK
//            xmlMainHeating.HeatTransferToWater = null;//IDK
//            xmlMainHeating.SolidFuelBoilerType = null;//IDK
//            xmlMainHeating.MainHeatingCode = null;//IDK
//            xmlMainHeating.MainFuelType = dwelling.PrimaryHeating.Fuel.ToString();//check types match
//            xmlMainHeating.PCDFFuelIndex = null; // maybe = dwelling.PrimaryHeating.ControlCodePcdf
//            xmlMainHeating.MainHeatingControl = dwelling.PrimaryHeating.ControlCode.ToString();//CHeck correct num
//            xmlMainHeating.HeatEmitterType = dwelling.PrimaryHeating.Emitter.ToString();//check
//            xmlMainHeating.UnderfloorHeatEmitterType = null;//IDK
//            xmlMainHeating.MainHeatingFlueType = dwelling.PrimaryHeating.Boiler.FlueType.ToString();//check type
//            xmlMainHeating.IsFlueFanPresent = dwelling.PrimaryHeating.Boiler.FanFlued;
//            xmlMainHeating.IsCentralHeatingPumpInHeatedSpace = //IDK//only if wet system, Need to check these two
//            xmlMainHeating.IsOilPumpInHeatedSpace = null;// Only is oil pump in space available - only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE
//            xmlMainHeating.IsInterLockedSystem = dwelling.PrimaryHeating.Boiler.BoilerInterlock;
//            xmlMainHeating.HasSeparateDelayedStart = dwelling.PrimaryHeating.DelayedStart;
//            xmlMainHeating.BoilerFuelFeed = null; //IDK
//            xmlMainHeating.IsMainHeatingHETASApproved = dwelling.PrimaryHeating.HeatingEquipmentTestingAndApprovalsScheme;
//            xmlMainHeating.ElectricCPSUOperatingTemperature = dwelling.WaterHeating.CombinedPrimaryStorageUnitTemperature.ToString();//check conversion
//            xmlMainHeating.MainHeatingFraction = 1; //may finding it from sec heat fraction?
//            xmlMainHeating.BurnerControl = null; //IDK
//            xmlMainHeating.EfficiencyType = null; //IDK
//            xmlMainHeating.MainHeatingEfficiencyWinter = dwelling.PrimaryHeating.WinterEfficiency.ToString();
//            xmlMainHeating.MainHeatingEfficiencySummer = dwelling.PrimaryHeating.SummerEfficiency.ToString();
//            xmlMainHeating.MainHeatingEfficiency = dwelling.PrimaryHeating.Efficiency.ToString();
//            xmlMainHeating.MainHeatingSystemType = dwelling.PrimaryHeating.ComplianceHeatingDetails.SystemType;
//            if (dwelling.WaterHeating.FlueGasHeatRecovery.Include == false)
//            {
//                xmlMainHeating.HasFGHRS = true;
//                xmlMainHeating.FGHRSIndexNumber = dwelling.WaterHeating.FlueGasHeatRecovery.IndexNumber;
//                xmlMainHeating.FGHRSEnergySource = null; //IDK how to convert from Stroma
//            }
//            else if (dwelling.WaterHeating.FlueGasHeatRecovery.Include == true)
//            {
//                xmlMainHeating.HasFGHRS = false;
//                xmlMainHeating.FGHRSIndexNumber = null;
//                xmlMainHeating.FGHRSEnergySource = null; 
//            } 

//            //HeatingDeclaredValues
//            oM.Environment.SAP.XML.HeatingDeclaredValues xmlMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
//            xmlMainHeatingDeclaredValues.Efficiency = null;
//            xmlMainHeatingDeclaredValues.MakeModel = null;
//            xmlMainHeatingDeclaredValues.TestMethod = null;
//            xmlMainHeating.MainHeatingDeclaredValues = xmlMainHeatingDeclaredValues;
//            //

//            //STORAGEHEATERS
//            List<oM.Environment.SAP.XML.StorageHeater> xmlStorageHeaters = new List<oM.Environment.SAP.XML.StorageHeater>();

//            for (int i = 0; i < dwelling.PrimaryHeating.StorageHeaters.Count; i++)
//            {
//                oM.Environment.SAP.XML.StorageHeater xmlStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
//                xmlStorageHeater.NumberOfHeaters = dwelling.PrimaryHeating.StorageHeaters[i].NumberOfHeaters;
//                xmlStorageHeater.IndexNumber = dwelling.PrimaryHeating.StorageHeaters[i].IndexNumber;
//                xmlStorageHeater.HighHeatRetention = dwelling.PrimaryHeating.StorageHeaters[i].HighRetention;
//                xmlStorageHeaters.Add(xmlStorageHeater);
//            }
//            xmlMainHeating.StorageHeaters.StorageHeater = xmlStorageHeaters;

//            //

//            xmlMainHeating.EmitterTemperature = dwelling.PrimaryHeating.Boiler.EmitterTemperature.ToString(); //Change to xml nums
//            xmlMainHeating.MCSInstalledHeatPump = dwelling.PrimaryHeating.MicroCertificationSchemeHeatPump;
//            xmlMainHeating.CentralHeatingPumpAge = dwelling.PrimaryHeating.Boiler.PumpAge.ToString();//Change to xml number
//            xmlMainHeating.ControlIndexNumber = null;
//            xmlMainHeating.HeatingControllerFunction = dwelling.PrimaryHeating.ComplianceHeatingDetails.ControllerFunction;
//            xmlMainHeating.HeatingControllerEcodesignClass = dwelling.PrimaryHeating.ComplianceHeatingDetails.ControllerEcodesignClass;
//            xmlMainHeating.HeatingControllerManufacturer = dwelling.PrimaryHeating.ComplianceHeatingDetails.ControllerManufacturer;
//            xmlMainHeating.HeatingControllerModel = dwelling.PrimaryHeating.ComplianceHeatingDetails.ControllerModel;

//            xmlMainHeatingList.Add(xmlMainHeating);


//            oM.Environment.SAP.XML.MainHeating xmlSecondaryMainHeating = new oM.Environment.SAP.XML.MainHeating();

//            xmlSecondaryMainHeating.MainHeatingNumber = "2";
//            xmlSecondaryMainHeating.MainHeatingCategory = dwelling.PrimaryHeating2.HeatingCategory.ToString(); //check conversion
//            xmlSecondaryMainHeating.MainHeatingDataSource = dwelling.PrimaryHeating2.Source.ToString();//check conversion
//            xmlSecondaryMainHeating.MainHeatingIndexNumber = null; //IDK cldnt find
//            xmlSecondaryMainHeating.MainHeatingManufacturer = dwelling.PrimaryHeating2.ComplianceHeatingDetails.Manufacturer;
//            xmlSecondaryMainHeating.MainHeatingModel = dwelling.PrimaryHeating2.ComplianceHeatingDetails.Model;
//            xmlSecondaryMainHeating.MainHeatingCommissioningCertificate = dwelling.PrimaryHeating2.ComplianceHeatingDetails.CommissioningCertificate;
//            xmlSecondaryMainHeating.MainHeatingInstallationEngineer = dwelling.PrimaryHeating2.ComplianceHeatingDetails.InstallationEngineer;
//            xmlSecondaryMainHeating.IsCondensingBoiler = null;
//            xmlSecondaryMainHeating.HeatPumpHeatDistribution = null;
//            xmlSecondaryMainHeating.GasOrOilBoilerType = null;
//            xmlSecondaryMainHeating.CombiBoilerType = dwelling.WaterHeating.CombiType.ToString();//check types match up
//            xmlSecondaryMainHeating.CaseHeatEmission = null;//IDK
//            xmlSecondaryMainHeating.HeatTransferToWater = null;//IDK
//            xmlSecondaryMainHeating.SolidFuelBoilerType = null;//IDK
//            xmlSecondaryMainHeating.MainHeatingCode = null;//IDK
//            xmlSecondaryMainHeating.MainFuelType = dwelling.PrimaryHeating2.Fuel.ToString();//check types match
//            xmlSecondaryMainHeating.PCDFFuelIndex = null; // maybe = dwelling.PrimaryHeating2.ControlCodePcdf
//            xmlSecondaryMainHeating.MainHeatingControl = dwelling.PrimaryHeating2.ControlCode.ToString();//CHeck correct num
//            xmlSecondaryMainHeating.HeatEmitterType = dwelling.PrimaryHeating2.Emitter.ToString();//check
//            xmlSecondaryMainHeating.UnderfloorHeatEmitterType = null;//IDK
//            xmlSecondaryMainHeating.MainHeatingFlueType = dwelling.PrimaryHeating2.Boiler.FlueType.ToString();//check type
//            xmlSecondaryMainHeating.IsFlueFanPresent = dwelling.PrimaryHeating2.Boiler.FanFlued;
//            xmlSecondaryMainHeating.IsCentralHeatingPumpInHeatedSpace = //IDK//only if wet system, Need to check these two
//            xmlSecondaryMainHeating.IsOilPumpInHeatedSpace = null;// Only is oil pump in space available - only if oil boiler NEED TO DIFFERENTIATE THESE DEPENIDING ON TYPE
//            xmlSecondaryMainHeating.IsInterLockedSystem = dwelling.PrimaryHeating2.Boiler.BoilerInterlock;
//            xmlSecondaryMainHeating.HasSeparateDelayedStart = dwelling.PrimaryHeating2.DelayedStart;
//            xmlSecondaryMainHeating.BoilerFuelFeed = null; //IDK
//            xmlSecondaryMainHeating.IsMainHeatingHETASApproved = dwelling.PrimaryHeating2.HeatingEquipmentTestingAndApprovalsScheme;
//            xmlSecondaryMainHeating.ElectricCPSUOperatingTemperature = dwelling.WaterHeating.CombinedPrimaryStorageUnitTemperature.ToString();//check conversion
//            xmlSecondaryMainHeating.MainHeatingFraction = 1; //may finding it from sec heat fraction?
//            xmlSecondaryMainHeating.BurnerControl = null; //IDK
//            xmlSecondaryMainHeating.EfficiencyType = null; //IDK
//            xmlSecondaryMainHeating.MainHeatingEfficiencyWinter = dwelling.PrimaryHeating2.WinterEfficiency.ToString();
//            xmlSecondaryMainHeating.MainHeatingEfficiencySummer = dwelling.PrimaryHeating2.SummerEfficiency.ToString();
//            xmlSecondaryMainHeating.MainHeatingEfficiency = dwelling.PrimaryHeating2.Efficiency.ToString();
//            xmlSecondaryMainHeating.MainHeatingSystemType = dwelling.PrimaryHeating2.ComplianceHeatingDetails.SystemType;

//            if (dwelling.WaterHeating.FlueGasHeatRecovery.Include == false)
//            {
//                xmlSecondaryMainHeating.HasFGHRS = true;
//                xmlSecondaryMainHeating.FGHRSIndexNumber = dwelling.WaterHeating.FlueGasHeatRecovery.IndexNumber;
//                xmlSecondaryMainHeating.FGHRSEnergySource = null; //IDK how to convert from Stroma
//            }
//            else if (dwelling.WaterHeating.FlueGasHeatRecovery.Include == true)
//            {
//                xmlSecondaryMainHeating.HasFGHRS = false;
//                xmlSecondaryMainHeating.FGHRSIndexNumber = null;
//                xmlSecondaryMainHeating.FGHRSEnergySource = null;
//            }

//            //HeatingDeclaredValues
//            oM.Environment.SAP.XML.HeatingDeclaredValues xmlSecondaryMainHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
//            xmlSecondaryMainHeatingDeclaredValues.Efficiency = null;
//            xmlSecondaryMainHeatingDeclaredValues.MakeModel = null;
//            xmlSecondaryMainHeatingDeclaredValues.TestMethod = null;
//            xmlSecondaryMainHeating.MainHeatingDeclaredValues = xmlSecondaryMainHeatingDeclaredValues;
//            //

//            //STORAGEHEATERS
//            List<oM.Environment.SAP.XML.StorageHeater> xmlStorageHeaters2 = new List<oM.Environment.SAP.XML.StorageHeater>();

//            for (int i = 0; i < dwelling.PrimaryHeating2.StorageHeaters.Count; i++)
//            {
//                oM.Environment.SAP.XML.StorageHeater xmlStorageHeater = new oM.Environment.SAP.XML.StorageHeater();
//                xmlStorageHeater.NumberOfHeaters = dwelling.PrimaryHeating2.StorageHeaters[i].NumberOfHeaters;
//                xmlStorageHeater.IndexNumber = dwelling.PrimaryHeating2.StorageHeaters[i].IndexNumber;
//                xmlStorageHeater.HighHeatRetention = dwelling.PrimaryHeating2.StorageHeaters[i].HighRetention;
//                xmlStorageHeaters2.Add(xmlStorageHeater);
//            }
//            xmlSecondaryMainHeating.StorageHeaters.StorageHeater = xmlStorageHeaters2;

//            //

//            xmlSecondaryMainHeating.EmitterTemperature = dwelling.PrimaryHeating2.Boiler.EmitterTemperature.ToString(); //Change to xml nums
//            xmlSecondaryMainHeating.MCSInstalledHeatPump = dwelling.PrimaryHeating2.MicroCertificationSchemeHeatPump;
//            xmlSecondaryMainHeating.CentralHeatingPumpAge = dwelling.PrimaryHeating2.Boiler.PumpAge.ToString();//Change to xml number
//            xmlSecondaryMainHeating.ControlIndexNumber = null;
//            xmlSecondaryMainHeating.HeatingControllerFunction = dwelling.PrimaryHeating2.ComplianceHeatingDetails.ControllerFunction;
//            xmlSecondaryMainHeating.HeatingControllerEcodesignClass = dwelling.PrimaryHeating2.ComplianceHeatingDetails.ControllerEcodesignClass;
//            xmlSecondaryMainHeating.HeatingControllerManufacturer = dwelling.PrimaryHeating2.ComplianceHeatingDetails.ControllerManufacturer;
//            xmlSecondaryMainHeating.HeatingControllerModel = dwelling.PrimaryHeating2.ComplianceHeatingDetails.ControllerModel;

//            xmlMainHeatingList.Add(xmlSecondaryMainHeating);

//            xmlMainHeatingDetails.MainHeating = xmlMainHeatingList;
//            xmlHeating.MainHeatingDetails = xmlMainHeatingDetails;

//            ///////////////////////////////////
//            List<oM.Environment.SAP.XML.CommunityHeatingSystem> xmlCommunityHeatingList = new List<oM.Environment.SAP.XML.CommunityHeatingSystem>();
//            oM.Environment.SAP.XML.CommunityHeatingSystem xmlCommunityHeating = new oM.Environment.SAP.XML.CommunityHeatingSystem();

//            xmlCommunityHeating.CommunityHeatingName = dwelling.PrimaryHeating.CommunityHeating.CommunityHeatingName;
//            xmlCommunityHeating.CommunityHeatingCO2EmissionFactor = null; //IDK
//            xmlCommunityHeating.CommunityHeatingPrimaryEnergyFactor = null;
//            xmlCommunityHeating.CommunityHeatingUse = null;
//            xmlCommunityHeating.IsCommunityHeatingCylinderInDwelling = null;
//            xmlCommunityHeating.IsHeatInterfaceUnitInDwelling = null; //IDK
//            xmlCommunityHeating.HeatInterfaceUnitIndexNumber = null;//IDK
//            xmlCommunityHeating.CommunityHeatingDistributionType = dwelling.PrimaryHeating.CommunityHeating.HeatDistributionSystem.ToString();//check xml number conversion is correct

//            ////CommunityHeatSource
//            List<oM.Environment.SAP.XML.CommunityHeatSource> xmlCommunityHeatSourceList = new List<oM.Environment.SAP.XML.CommunityHeatSource>();
//            for (int i = 0; i < dwelling.PrimaryHeating.CommunityHeating.HeatSources.Count; i++)
//            {
//                oM.Environment.SAP.XML.CommunityHeatSource xmlHeatSource = new oM.Environment.SAP.XML.CommunityHeatSource();
//                xmlHeatSource.HeatSourceType = dwelling.PrimaryHeating.CommunityHeating.HeatSources[i].HeatSourceType.ToString();//Check
//                xmlHeatSource.HeatFraction = dwelling.PrimaryHeating.CommunityHeating.HeatSources[i].HeatFraction.ToString();
//                xmlHeatSource.FuelType = dwelling.PrimaryHeating.CommunityHeating.HeatSources[i].Fuel.ToString();//CheckType
//                xmlHeatSource.PCDFFuelIndex = null;//IDK
//                xmlHeatSource.HeatEfficiency = dwelling.PrimaryHeating.CommunityHeating.HeatSources[i].Efficiency.ToString();
//                xmlHeatSource.PowerEfficiency = null;
//                xmlHeatSource.Description = null;
//                xmlHeatSource.CHPElectricityGeneration = null;
//                xmlCommunityHeatSourceList.Add(xmlHeatSource);
//            }
//            xmlCommunityHeating.CommunityHeatSources.CommunityHeatSource = xmlCommunityHeatSourceList;


//            if (dwelling.PrimaryHeating.CommunityHeating.KnownLoss == true)
//            {
//                xmlCommunityHeating.CommunityHeatingDistributionLossFactor = dwelling.PrimaryHeating.CommunityHeating.KnownLossValue.ToString();
//            }
//            else if (dwelling.PrimaryHeating.CommunityHeating.KnownLoss == false)
//            {
//                xmlCommunityHeating.CommunityHeatingDistributionLossFactor = null;
//            }
//            xmlCommunityHeating.ChargingLinkedToHeatUse = null;//IDK
//            xmlCommunityHeating.HeatNetworkIndexNumber = null;//IDK
//            xmlCommunityHeating.SubNetworkName = dwelling.PrimaryHeating.CommunityHeating.SubNetworkName;
//            xmlCommunityHeating.HeatNetworkExisting = dwelling.PrimaryHeating.CommunityHeating.HeatNetworkExisting;

//            xmlCommunityHeatingList.Add(xmlCommunityHeating);

//            ////
            
//            oM.Environment.SAP.XML.CommunityHeatingSystem xmlCommunityHeating2 = new oM.Environment.SAP.XML.CommunityHeatingSystem();

//            xmlCommunityHeating2.CommunityHeatingName = dwelling.PrimaryHeating2.CommunityHeating.CommunityHeatingName;
//            xmlCommunityHeating2.CommunityHeatingCO2EmissionFactor = null; //IDK
//            xmlCommunityHeating2.CommunityHeatingPrimaryEnergyFactor = null;
//            xmlCommunityHeating2.CommunityHeatingUse = null;
//            xmlCommunityHeating2.IsCommunityHeatingCylinderInDwelling = null;
//            xmlCommunityHeating2.IsHeatInterfaceUnitInDwelling = null; //IDK
//            xmlCommunityHeating2.HeatInterfaceUnitIndexNumber = null;//IDK
//            xmlCommunityHeating2.CommunityHeatingDistributionType = dwelling.PrimaryHeating2.CommunityHeating.HeatDistributionSystem.ToString();//check xml number conversion is correct

//            ////CommunityHeatSource
//            List<oM.Environment.SAP.XML.CommunityHeatSource> xmlCommunityHeatSourceList2 = new List<oM.Environment.SAP.XML.CommunityHeatSource>();
//            for (int i = 0; i < dwelling.PrimaryHeating2.CommunityHeating.HeatSources.Count; i++)
//            {
//                oM.Environment.SAP.XML.CommunityHeatSource xmlHeatSource = new oM.Environment.SAP.XML.CommunityHeatSource();
//                xmlHeatSource.HeatSourceType = dwelling.PrimaryHeating2.CommunityHeating.HeatSources[i].HeatSourceType.ToString();//Check
//                xmlHeatSource.HeatFraction = dwelling.PrimaryHeating2.CommunityHeating.HeatSources[i].HeatFraction.ToString();
//                xmlHeatSource.FuelType = dwelling.PrimaryHeating2.CommunityHeating.HeatSources[i].Fuel.ToString();//CheckType
//                xmlHeatSource.PCDFFuelIndex = null;//IDK
//                xmlHeatSource.HeatEfficiency = dwelling.PrimaryHeating2.CommunityHeating.HeatSources[i].Efficiency.ToString();
//                xmlHeatSource.PowerEfficiency = null;
//                xmlHeatSource.Description = null;
//                xmlHeatSource.CHPElectricityGeneration = null;
//                xmlCommunityHeatSourceList2.Add(xmlHeatSource);
//            }
//            xmlCommunityHeating2.CommunityHeatSources.CommunityHeatSource = xmlCommunityHeatSourceList2;


//            if (dwelling.PrimaryHeating2.CommunityHeating.KnownLoss == true)
//            {
//                xmlCommunityHeating2.CommunityHeatingDistributionLossFactor = dwelling.PrimaryHeating2.CommunityHeating.KnownLossValue.ToString();
//            }
//            else if (dwelling.PrimaryHeating2.CommunityHeating.KnownLoss == false)
//            {
//                xmlCommunityHeating2.CommunityHeatingDistributionLossFactor = null;
//            }
//            xmlCommunityHeating2.ChargingLinkedToHeatUse = null;//IDK
//            xmlCommunityHeating2.HeatNetworkIndexNumber = null;//IDK
//            xmlCommunityHeating2.SubNetworkName = dwelling.PrimaryHeating2.CommunityHeating.SubNetworkName;
//            xmlCommunityHeating2.HeatNetworkExisting = dwelling.PrimaryHeating2.CommunityHeating.HeatNetworkExisting;

//            xmlCommunityHeatingList.Add(xmlCommunityHeating2);

//            xmlHeating.CommunityHeatingSystems.CommunityHeatingSystem = xmlCommunityHeatingList;


//            xmlHeating.WaterHeatingCode = dwelling.WaterHeating.System.ToString();//maybe?? also check
//            xmlHeating.WaterFuelType = dwelling.WaterHeating.Fuel.ToString();//change

//            if (dwelling.WaterHeating.Cylinder != null)
//            {
//                xmlHeating.HasHotWaterCylinder = true;
//                xmlHeating.HotWaterStoreSize = dwelling.WaterHeating.Cylinder.Volume.ToString();
//                xmlHeating.HotWaterStoreHeatTransferArea = null; //IDK
//                xmlHeating.HotWaterStoreHeatLoss = dwelling.WaterHeating.Cylinder.DeclaredLoss.ToString();
//                xmlHeating.HotWaterStoreInsulationType = dwelling.WaterHeating.Cylinder.Insulation.ToString();
//                xmlHeating.HotWaterInsulationThickness = dwelling.WaterHeating.Cylinder.InsulationThickness.ToString();
//                xmlHeating.HasCylinderThermostat = dwelling.WaterHeating.Cylinder.Thermostat;
//                xmlHeating.IsCylinderInHeatedSpace = dwelling.WaterHeating.Cylinder.InHeatedSpace;
//                xmlHeating.IsHotWaterSeperatlyTimed = dwelling.WaterHeating.Cylinder.Timed;

//            }
//            if (dwelling.WaterHeating.Cylinder == null)
//            {
//                xmlHeating.HasHotWaterCylinder = false;
//                xmlHeating.HotWaterStoreSize = null;
//                xmlHeating.HotWaterStoreHeatTransferArea = null;
//                xmlHeating.HotWaterStoreHeatLoss = null;
//                xmlHeating.HotWaterStoreInsulationType = null;
//                xmlHeating.HotWaterInsulationThickness = null;
//                xmlHeating.HasCylinderThermostat = null;
//                xmlHeating.IsCylinderInHeatedSpace = null;
//                xmlHeating.IsHotWaterSeperatlyTimed = null;
//            }








//            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingCategory.FromSAPToXML();//?
//            //xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source.FromSAPToXML();//?
//            //xmlHeating.SecondaryHeatingEfficiency = null;
//            //xmlHeating.SecondaryHeatingCommisioningCertificate = null;
//            //xmlHeating.SecondaryHeatingInstallationEngineer = null;
//            //xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingCode;
//            //xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel.FromSAPToXML();
//            //xmlHeating.SecondaryHeatingPCDFFuelIndex = null;
//            //xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType.FromSAPToXML();
//            //xmlHeating.ThermalStore = heating.WaterHeating.ThermalStore.FromSAPToXML();
//            //xmlHeating.HasFixedAirConditioning = false;
//            //xmlHeating.ImmersionHeatingType = heating.WaterHeating.Immersion.Type;
//            //xmlHeating.IsHeatPumpAssistedByImmersion = heating.WaterHeating.Immersion.UseOfImmersion;
//            //xmlHeating.IsHeatPumpInstalledToMIS = null; //Add to sap class
//            //xmlHeating.IsImmersionForSummerUse = heating.WaterHeating.Immersion.SummerImmersion;
//            //xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
//            //xmlHeating.HotWaterControlsManufacturer = null;
//            //xmlHeating.HotWaterStoreModel = null;
//            //xmlHeating.HotWaterStoreCommissioningCertificate = null;
//            //xmlHeating.HotWaterStoreInstallerEngineerRegistration = null;
//            ////Needs to be added in some method
//            //xmlHeating.HotWaterStoreHeatLossSource = null;
//            //xmlHeating.IsThermalStoreNearBoiler = null;
//            //xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = null;
//            //xmlHeating.HotWaterControlsManufacturer = null;
//            //xmlHeating.HotWaterControlsModel = null;




//            //xmlHeating.HeatingDesignWaterUse = null;
//            //xmlHeating.MainHeatingSystemsInteraction = null;

//            ////Secondary - heatingDeclaredValues
//            //oM.Environment.SAP.XML.HeatingDeclaredValues xmlHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();
//            //xmlHeatingDeclaredValues.Efficiency = null;
//            //xmlHeatingDeclaredValues.MakeModel = null;
//            //xmlHeatingDeclaredValues.TestMethod = null;
//            //xmlHeating.SecondaryHeatingDeclaredValues = xmlHeatingDeclaredValues; //maybe link to secondary - main heating class

//            //xmlHeating.PrimaryPipeworkInsulation = null;

//            ////SolarHeatingDetails
//            //oM.Environment.SAP.XML.SolarHeatingDetails xmlSolarHeatingDetails = new oM.Environment.SAP.XML.SolarHeatingDetails();
//            //xmlSolarHeatingDetails.SolarHeatingCollectorManufacturer = null;
//            //xmlSolarHeatingDetails.SolarHeatingCertificate = null;
//            //xmlSolarHeatingDetails.ApertureArea = heating.SolarPanelDetails.AreaCollector;
//            //xmlSolarHeatingDetails.CollectorType = heating.SolarPanelDetails.CollectorType;
//            //xmlSolarHeatingDetails.DataSource = null;
//            //xmlSolarHeatingDetails.ZeroLossEfficiency = heating.SolarPanelDetails.CollectorEfficiencyη0;
//            //xmlSolarHeatingDetails.HeatLossRate = null; //for backward compatibility only, do not use.
//            //xmlSolarHeatingDetails.LinearHeatLossCoefficient = heating.SolarPanelDetails.Coefficienta1;
//            //xmlSolarHeatingDetails.SecondOrderHeatLossCoefficient = heating.SolarPanelDetails.Coefficienta2;
//            //xmlSolarHeatingDetails.Orientation = heating.SolarPanelDetails.Orientation;
//            //xmlSolarHeatingDetails.Pitch = heating.SolarPanelDetails.TiltOfCollector;
//            //xmlSolarHeatingDetails.Overshading = heating.SolarPanelDetails.Overshading;
//            //xmlSolarHeatingDetails.HasSolarPoweredPump = heating.SolarPanelDetails.SolarPoweredPump;
//            //xmlSolarHeatingDetails.IsSolarStoreCombinedCylinder = heating.SolarPanelDetails.IsSolarStoreCombined;
//            //xmlSolarHeatingDetails.SolarStoreVolume = heating.SolarPanelDetails.DedicatedSolarStorVolume;
//            //xmlSolarHeatingDetails.CollectorLoopEfficiency = null;
//            //xmlSolarHeatingDetails.IncidenceAngleModifier = null;
//            //xmlSolarHeatingDetails.IsCommunitySolar = null;
//            //xmlSolarHeatingDetails.ServiceProvision = null;
//            //xmlSolarHeatingDetails.OverallHeatLoss = null;
//            //xmlHeating.SolarHeatingDetails = xmlSolarHeatingDetails;

//            //oM.Environment.SAP.XML.InstantaneousWWHRS xmlInstantaneousWWHRS = new oM.Environment.SAP.XML.InstantaneousWWHRS();
//            //oM.Environment.SAP.XML.StorageWWHRS xmlStorageWWHRS = new oM.Environment.SAP.XML.StorageWWHRS();

//            ////check if cases are correct - tried to make them as similar to prev closed but ultimatley not sure how the diff cases should be treated
//            //if (heating.WWHRS == null)
//            //{
//            //    xmlInstantaneousWWHRS.WWHRSIndexNumber1 = null;
//            //    xmlInstantaneousWWHRS.WWHRSEfficiency1 = null;
//            //    xmlInstantaneousWWHRS.WWHRSIndexNumber2 = null;
//            //    xmlInstantaneousWWHRS.WWHRSEfficiency2 = null;
//            //    xmlStorageWWHRS.WWHRSIndexNumber = null;
//            //    xmlStorageWWHRS.WWHRSStoreVolume = null;
//            //    xmlStorageWWHRS.StorageWWHRSEfficiency = null;

//            //}
//            //else if (heating.WWHRS.InstantaneousSystem1 != null)
//            //{
//            //    xmlInstantaneousWWHRS.WWHRSIndexNumber1 = heating.WWHRS.InstantaneousSystem1.IndexNumber;
//            //    xmlInstantaneousWWHRS.WWHRSEfficiency1 = heating.WWHRS.InstantaneousSystem1.Efficiency;
//            //}
//            //else if (heating.WWHRS.InstantaneousSystem2 != null)
//            //{
//            //    xmlInstantaneousWWHRS.WWHRSIndexNumber2 = heating.WWHRS.InstantaneousSystem2.IndexNumber;
//            //    xmlInstantaneousWWHRS.WWHRSEfficiency2 = heating.WWHRS.InstantaneousSystem2.Efficiency;
//            //}
//            //else if (heating.WWHRS.StorageSystem != null)
//            //{
//            //    xmlStorageWWHRS.WWHRSIndexNumber = heating.WWHRS.StorageSystem.IndexNumber;
//            //    xmlStorageWWHRS.WWHRSStoreVolume = heating.WWHRS.StorageSystem.StoreVolume;
//            //    xmlStorageWWHRS.StorageWWHRSEfficiency = heating.WWHRS.StorageSystem.Efficiency;
//            //}

//            //xmlHeating.InstantaneousWHRS = xmlInstantaneousWWHRS;
//            //xmlHeating.StorageWHRS = xmlStorageWWHRS;



//            //List<oM.Environment.SAP.XML.ShowerOutlet> xmlShowerOutlets = new List<oM.Environment.SAP.XML.ShowerOutlet>();

//            //for (int i = 0; i < heating.ShowerOutlets.Count; i++)
//            //{
//            //    oM.Environment.SAP.XML.ShowerOutlet xmlShowerOutlet = new oM.Environment.SAP.XML.ShowerOutlet();
//            //    xmlShowerOutlet.ShowerOutletType = heating.ShowerOutlets[i].Type;
//            //    xmlShowerOutlet.ShowerFlowRate = heating.ShowerOutlets[i].FlowRate;
//            //    xmlShowerOutlet.ShowerPower = heating.ShowerOutlets[i].Power;
//            //    xmlShowerOutlet.ShowerWWHRS = heating.ShowerOutlets[i].ShowerWWHRS;//connect with the WWHRS names
//            //    xmlShowerOutlets.Add(xmlShowerOutlet);
//            //}

//            //xmlHeating.ShowerOutlets.ShowerOutlet = xmlShowerOutlets;

//            //xmlHeating.NumberBaths = 0;//check these ( wheres best to include)
//            //xmlHeating.NumberBathsWWHRS = 0;//check these ( wheres best to include)

//            return new Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling>() { Item1 = xmlHeating, Item2 = xmlCooling };
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.MainHeatingCategoryCode categoryCode)
//        {
//            switch (categoryCode)
//            {
//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.None:
//                    return "1";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.BoilerWRadiatorsOrUnderfloor:
//                    return "2";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.MicroCogeneration:
//                    return "3";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.HeatPumpWRadiatorsOrUnderfloor:
//                    return "4";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.HeatPumpWWarmAirDistribution:
//                    return "5";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.CommunityHeatingSystem:
//                    return "6";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.ElectricStorageHeaters:
//                    return "7";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.ElectricUnderfloorHeating:
//                    return "8";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.WarmAirSystem:
//                    return "9";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.RoomHeaters:
//                    return "10";

//                case BH.oM.Environment.SAP.MainHeatingCategoryCode.OtherSystem:
//                    return "11";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.DataSourceCode sourceCode)
//        {
//            switch (sourceCode)
//            {
//                case BH.oM.Environment.SAP.DataSourceCode.ManufacturerDeclaration:
//                    return "2";

//                case BH.oM.Environment.SAP.DataSourceCode.SAPtable:
//                    return "3";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.HeatingFuelTypeCode fuelCode)
//        {
//            switch (fuelCode)
//            {
//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.MainsGas:
//                    return "1";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BulkLPG:
//                    return "2";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BottledLPG:
//                    return "3";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.HeatingOil:
//                    return "4";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Biogas:
//                    return "7";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.LNG:
//                    return "8";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.LPGSpecialCondition:
//                    return "9";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.SolidFuelMineralAndWood:
//                    return "10";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.HouseCoal:
//                    return "11";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ManufacturedSmokelessFuel:
//                    return "12";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Anthracite:
//                    return "15";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodLogs:
//                    return "20";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodChips:
//                    return "21";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodPelletsSecondaryHeating:
//                    return "22";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.WoodPelletsMainHeating:
//                    return "23";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ElectricitySoldToGrid:
//                    return "36";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ElectricityDisplacedFromGrid:
//                    return "37";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.ElectricityUnspecTariff:
//                    return "39";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityHeatPump:
//                    return "41";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersWaste:
//                    return "42";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersBiomass:
//                    return "43";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersBiogas:
//                    return "44";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityWastePowerStations:
//                    return "45";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityGeothermal:
//                    return "46";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityCHP:
//                    return "48";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityElectricityCHP:
//                    return "49";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityElectricityNetwork:
//                    return "50";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityMainsGas:
//                    return "51";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityLPG:
//                    return "52";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityOil:
//                    return "53";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityCoal:
//                    return "54";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityB30D:
//                    return "55";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersMineralOilBiodiesel:
//                    return "56";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBoilersBiodiesel:
//                    return "57";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunityBiodieselVegetableOil:
//                    return "58";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Biodiesel:
//                    return "71";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BiodieselUsedCookingOil:
//                    return "72";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.BiodieselVegetableOil:
//                    return "73";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.MineralOilLiquidBiofuel:
//                    return "74";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.B30K:
//                    return "75";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.Bioethanol:
//                    return "76";

//                case BH.oM.Environment.SAP.HeatingFuelTypeCode.CommunitySpecial:
//                    return "99";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.EmitterTemperatureCode temperatureCode)
//        {
//            switch (temperatureCode)
//            {
//                case BH.oM.Environment.SAP.EmitterTemperatureCode.Unknown:
//                    return "0";

//                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over45:
//                    return "1";

//                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over35:
//                    return "2";

//                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over35LessThan45:
//                    return "3";

//                case BH.oM.Environment.SAP.EmitterTemperatureCode.LessThan35:
//                    return "4";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.PumpAge ageCode)
//        {
//            switch (ageCode)
//            {
//                case BH.oM.Environment.SAP.PumpAge.Unknown:
//                    return "0";

//                case BH.oM.Environment.SAP.PumpAge.Earlier2012:
//                    return "1";

//                case BH.oM.Environment.SAP.PumpAge.Later2013:
//                    return "2";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.HeatEmitterCode emitterCode)
//        {
//            switch (emitterCode)
//            {
//                case BH.oM.Environment.SAP.HeatEmitterCode.Radiators:
//                    return "1";

//                case BH.oM.Environment.SAP.HeatEmitterCode.Underfloor:
//                    return "2";

//                case BH.oM.Environment.SAP.HeatEmitterCode.RadiatorsAndUnderfloor:
//                    return "3";

//                case BH.oM.Environment.SAP.HeatEmitterCode.FanCoilUnits:
//                    return "4";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.FlueTypeCode flueCode)
//        {
//            switch (flueCode)
//            {
//                case BH.oM.Environment.SAP.FlueTypeCode.OpenFlue:
//                    return "1";

//                case BH.oM.Environment.SAP.FlueTypeCode.BalancedFlue:
//                    return "2";

//                case BH.oM.Environment.SAP.FlueTypeCode.Chimney:
//                    return "3";

//                case BH.oM.Environment.SAP.FlueTypeCode.Omitted:
//                    return "4";

//                case BH.oM.Environment.SAP.FlueTypeCode.Unknown:
//                    return "5";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.HasLoadOrWeatherCompensation compensationCode)
//        {
//            switch (compensationCode)
//            {
//                case BH.oM.Environment.SAP.HasLoadOrWeatherCompensation.None:
//                    return "0";

//                case BH.oM.Environment.SAP.HasLoadOrWeatherCompensation.LoadOrWeatherCompensation:
//                    return "4";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.SecondaryHeatingCategory categoryCode)
//        {
//            switch (categoryCode)
//            {
//                case BH.oM.Environment.SAP.SecondaryHeatingCategory.None:
//                    return "1";

//                case BH.oM.Environment.SAP.SecondaryHeatingCategory.RoomHeaters:
//                    return "10";

//                default:
//                    return "";
//            }
//        }
//        private static string FromSAPToXML(this BH.oM.Environment.SAP.ThermalStoreCode storeCode)
//        {
//            switch (storeCode)
//            {
//                case BH.oM.Environment.SAP.ThermalStoreCode.None:
//                    return "1";

//                case BH.oM.Environment.SAP.ThermalStoreCode.HotWaterOnly:
//                    return "2";

//                case BH.oM.Environment.SAP.ThermalStoreCode.Integrated:
//                    return "3";

//                default:
//                    return "";
//            }
//        }
//    }
//}
