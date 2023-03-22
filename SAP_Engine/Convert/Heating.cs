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
using BH.oM.Base;
using System.Xml;
using BH.oM.Environment.SAP;
using System.Runtime.CompilerServices;
using BH.oM.Environment.SAP.XML;

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
            oM.Environment.SAP.XML.Heating xmlHeating = new oM.Environment.SAP.XML.Heating();

            /************************General Heating************************/

            xmlHeating.WaterHeatingCode = heating.WaterHeating.Type;
            xmlHeating.WaterFuelType = heating.WaterHeating.Fuel.FromSAPToXML();
            xmlHeating.HasFixedAirConditioning = false;
            xmlHeating.MainHeatingSystemsInteraction = null;
            xmlHeating.PrimaryPipeworkInsulation= null;


            if (heating.WaterHeating.CylinderSpecification != null)
            {
                xmlHeating.HasHotWaterCylinder = true;
                xmlHeating.HotWaterStoreSize = heating.WaterHeating.CylinderSpecification.Volume;
                xmlHeating.HotWaterStoreHeatTransferArea = heating.WaterHeating.Immersion.HeatExchangerArea;
                xmlHeating.HotWaterStoreHeatLoss = heating.WaterHeating.CylinderSpecification.DeclaredLossFactor;
                xmlHeating.HotWaterStoreHeatLossSource = heating.WaterHeating.CylinderSpecification.DeclaredLossFactorSource.FromSAPToXML();
                xmlHeating.HotWaterStoreInsulationType = heating.WaterHeating.CylinderSpecification.InsulationType.FromSAPToXML();
                xmlHeating.HotWaterInsulationThickness = heating.WaterHeating.CylinderSpecification.InsulationThickness;
                xmlHeating.HasCylinderThermostat = heating.WaterHeating.CylinderSpecification.Cylinderstat;
                xmlHeating.IsCylinderInHeatedSpace = heating.WaterHeating.CylinderSpecification.InHeatedSpace;
                xmlHeating.IsHotWaterSeperatlyTimed = heating.WaterHeating.CylinderSpecification.TimedSeperatly;
                xmlHeating.PrimaryPipeworkInsulation = heating.WaterHeating.CylinderSpecification.PrimaryPipeworkInsulated.FromSAPToXML();
                xmlHeating.HeatingDesignWaterUse = heating.WaterHeating.HeatingDesignWaterUse.FromSAPToXML();
                xmlHeating.HotWaterControlsManufacturer = null;
                xmlHeating.HotWaterControlsModel = null;

                if (heating.WaterHeating.CylinderSpecification.CyclinderDetails != null)
                {
                    xmlHeating.HotWaterStoreManufacturer = heating.WaterHeating.CylinderSpecification.CyclinderDetails.Manufacturer;
                    xmlHeating.HotWaterStoreModel = heating.WaterHeating.CylinderSpecification.CyclinderDetails.Model;
                    xmlHeating.HotWaterStoreCommissioningCertificate = null;
                    xmlHeating.HotWaterStoreInstallerEngineerRegistration = null;
                }
            }

            else
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


            xmlHeating.ThermalStore = heating.WaterHeating.ThermalStore.FromSAPToXML();
            xmlHeating.IsThermalStoreNearBoiler = heating.WaterHeating.ThermalStoreNearBoiler;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = heating.WaterHeating.ThermalStoreOrCPSUInAiringCupboard;
            xmlHeating.ImmersionHeatingType = heating.WaterHeating.Immersion.Type.FromSAPToXML();
            xmlHeating.IsHeatPumpAssistedByImmersion = heating.WaterHeating.Immersion.UseOfImmersion;
            xmlHeating.IsHeatPumpInstalledToMIS = heating.WaterHeating.Immersion.InstalledToMIS;
            xmlHeating.IsImmersionForSummerUse = heating.WaterHeating.Immersion.SummerImmersion;

            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingCategory.FromSAPToXML();
            xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source.FromSAPToXML();
            xmlHeating.SecondaryHeatingEfficiency = heating.SecondaryHeating.Efficiency;
            xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingCode.FromSAPToXML();
            xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel.FromSAPToXML();
            xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType.FromSAPToXML();
            xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
            xmlHeating.SecondaryHeatingPCDFFuelIndex = null;


            oM.Environment.SAP.XML.HeatingDeclaredValues xmlHeatingDeclaredValues = new oM.Environment.SAP.XML.HeatingDeclaredValues();

            xmlHeatingDeclaredValues.Efficiency = heating.SecondaryHeating.HeatingDeclaredValues.Efficiency;
            xmlHeatingDeclaredValues.MakeModel = heating.SecondaryHeating.HeatingDeclaredValues.MakeModel;
            xmlHeatingDeclaredValues.TestMethod = heating.SecondaryHeating.HeatingDeclaredValues.TestMethod;

            xmlHeating.SecondaryHeatingDeclaredValues = xmlHeatingDeclaredValues;

            /**********************Cooling*************************/

            oM.Environment.SAP.XML.Cooling xmlCooling = new oM.Environment.SAP.XML.Cooling();

            xmlCooling.CooledArea = heating.Cooling.CooledArea;
            xmlCooling.CoolingSystemDataSource = heating.Cooling.DataSource.FromSAPToXML();
            xmlCooling.CoolingSystemClass = heating.Cooling.EnergyLabel.FromSAPToXML();
            xmlCooling.CoolingSystemSEER = heating.Cooling.SEER;

            /********************Main Heating Details**********************/

            oM.Environment.SAP.XML.MainHeatingDetails xmlMainHeatingDetails = new oM.Environment.SAP.XML.MainHeatingDetails();
            List<oM.Environment.SAP.XML.MainHeating> xmlMainHeatingList = new List<oM.Environment.SAP.XML.MainHeating>();

            if (heating.Main != null)
            {
                oM.Environment.SAP.XML.MainHeating xmlMain = heating.Main.ToXML();
                xmlMain.MainHeatingNumber = "1";
                xmlMainHeatingList.Add(xmlMain);

            }
            if (heating.SecondaryMain != null)
            {
                oM.Environment.SAP.XML.MainHeating xmlSecondary = heating.SecondaryMain.ToXML();
                xmlSecondary.MainHeatingNumber = "2";
                xmlMainHeatingList.Add(xmlSecondary);

            }

            xmlHeating.MainHeatingDetails.MainHeating = xmlMainHeatingList;


            /********************Water Heating**********************/

            xmlHeating.WaterHeatingCode = heating.WaterHeating.Type;
            xmlHeating.WaterFuelType = heating.WaterHeating.Fuel.FromSAPToXML();

            if (heating.WaterHeating.CylinderSpecification != null)
            {
                xmlHeating.HasHotWaterCylinder = true;
                xmlHeating.HotWaterStoreSize = heating.WaterHeating.CylinderSpecification.Volume;
                xmlHeating.HotWaterStoreHeatTransferArea = heating.WaterHeating.Immersion.HeatExchangerArea;
                xmlHeating.HotWaterStoreHeatLoss = heating.WaterHeating.CylinderSpecification.DeclaredLossFactor;
                xmlHeating.HotWaterStoreInsulationType = heating.WaterHeating.CylinderSpecification.InsulationType.FromSAPToXML();
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


            /*********************************CommunityHeating***************************************/



            if (heating.CommunityHeating != null) { 

                List<oM.Environment.SAP.XML.CommunityHeatingSystem> xmlCommunityHeatingSystemList = new List<oM.Environment.SAP.XML.CommunityHeatingSystem>();
                foreach (var sapHeatingSystem in heating.CommunityHeating)
                {
                    oM.Environment.SAP.XML.CommunityHeatingSystem xmlCommunityHeatingSystem = new oM.Environment.SAP.XML.CommunityHeatingSystem();

                    xmlCommunityHeatingSystem.CommunityHeatingName = sapHeatingSystem.Name;
                    xmlCommunityHeatingSystem.CommunityHeatingCO2EmissionFactor = sapHeatingSystem.CommunityHeatingCO2EmissionFactor;
                    xmlCommunityHeatingSystem.CommunityHeatingPrimaryEnergyFactor = sapHeatingSystem.CommunityHeatingPrimaryEnergyFactor;
                    xmlCommunityHeatingSystem.CommunityHeatingUse = sapHeatingSystem.CommunityHeatingUse.FromSAPToXML();
                    xmlCommunityHeatingSystem.IsCommunityHeatingCylinderInDwelling = sapHeatingSystem.IsCommunityHeatingCylinderInDwelling;
                    xmlCommunityHeatingSystem.IsHeatInterfaceUnitInDwelling = sapHeatingSystem.IsHeatInterfaceUnitInDwelling;
                    xmlCommunityHeatingSystem.HeatInterfaceUnitIndexNumber = sapHeatingSystem.HeatInterfaceUnitIndexNumber;
                    xmlCommunityHeatingSystem.CommunityHeatingDistributionType = sapHeatingSystem.CommunityHeatingDistributionType.FromSAPToXML();
                    xmlCommunityHeatingSystem.CommunityHeatingDistributionLossFactor = sapHeatingSystem.CommunityHeatingDistributionLossFactor;
                    xmlCommunityHeatingSystem.ChargingLinkedToHeatUse = sapHeatingSystem.ChargingLinkedToHeatUse;
                    xmlCommunityHeatingSystem.HeatNetworkIndexNumber = sapHeatingSystem.HeatNetworkIndexNumber;
                    xmlCommunityHeatingSystem.SubNetworkName = sapHeatingSystem.SubNetworkName;
                    xmlCommunityHeatingSystem.HeatNetworkExisting = sapHeatingSystem.HeatNetworkExisting;

                    if (sapHeatingSystem.CommunityHeatSources != null)
                    {
                        List<oM.Environment.SAP.XML.CommunityHeatSource> xmlCommunityHeatSourceList = new List<oM.Environment.SAP.XML.CommunityHeatSource>();

                        foreach (var sapHeatSource in sapHeatingSystem.CommunityHeatSources)
                        {
                            oM.Environment.SAP.XML.CommunityHeatSource xmlHeatSource = new oM.Environment.SAP.XML.CommunityHeatSource();

                            xmlHeatSource.HeatSourceType = sapHeatSource.HeatSourceType.FromSAPToXML();
                            xmlHeatSource.HeatFraction= sapHeatSource.HeatFraction;
                            xmlHeatSource.FuelType = sapHeatSource.FuelType.FromSAPToXML();
                            xmlHeatSource.PCDFFuelIndex = sapHeatSource.PCDFFuelIndex;
                            xmlHeatSource.HeatEfficiency= sapHeatSource.HeatEfficiency;
                            xmlHeatSource.PowerEfficiency= sapHeatSource.PowerEfficiency;
                            xmlHeatSource.CHPElectricityGeneration = sapHeatSource.CHPElectricityGeneration.FromSAPToXML();
                            xmlCommunityHeatSourceList.Add(xmlHeatSource);
                        }

                        xmlCommunityHeatingSystem.CommunityHeatSources.CommunityHeatSource = xmlCommunityHeatSourceList;
                    }

                    xmlCommunityHeatingSystemList.Add(xmlCommunityHeatingSystem);

                }

                xmlHeating.CommunityHeatingSystems.CommunityHeatingSystem= xmlCommunityHeatingSystemList;

            }

            
            /******************************SolarHeatingDetails**********************************/

            oM.Environment.SAP.XML.SolarHeatingDetails xmlSolarHeatingDetails = new oM.Environment.SAP.XML.SolarHeatingDetails();

            xmlSolarHeatingDetails.SolarHeatingCollectorManufacturer = null;
            xmlSolarHeatingDetails.SolarHeatingCertificate = null;
            xmlSolarHeatingDetails.ApertureArea = heating.SolarPanelDetails.AreaCollector;
            xmlSolarHeatingDetails.CollectorType = heating.SolarPanelDetails.CollectorType.FromSAPToXML();
            xmlSolarHeatingDetails.DataSource = null;
            xmlSolarHeatingDetails.ZeroLossEfficiency = heating.SolarPanelDetails.CollectorEfficiencyη0;
            xmlSolarHeatingDetails.HeatLossRate = null; 
            xmlSolarHeatingDetails.LinearHeatLossCoefficient = heating.SolarPanelDetails.Coefficienta1;
            xmlSolarHeatingDetails.SecondOrderHeatLossCoefficient = heating.SolarPanelDetails.Coefficienta2;
            xmlSolarHeatingDetails.Orientation = heating.SolarPanelDetails.Orientation.FromSAPToXML();
            xmlSolarHeatingDetails.Pitch = heating.SolarPanelDetails.TiltOfCollector.FromSAPToXML();
            xmlSolarHeatingDetails.Overshading = heating.SolarPanelDetails.Overshading.FromSAPToXML();
            xmlSolarHeatingDetails.HasSolarPoweredPump = heating.SolarPanelDetails.SolarPoweredPump;
            xmlSolarHeatingDetails.IsSolarStoreCombinedCylinder = heating.SolarPanelDetails.IsSolarStoreCombined;
            xmlSolarHeatingDetails.SolarStoreVolume = heating.SolarPanelDetails.DedicatedSolarStoreVolume;
            xmlSolarHeatingDetails.CollectorLoopEfficiency = null;
            xmlSolarHeatingDetails.IncidenceAngleModifier = null;
            xmlSolarHeatingDetails.IsCommunitySolar = heating.SolarPanelDetails.IsCommunitySolar;
            xmlSolarHeatingDetails.ServiceProvision = null;
            xmlSolarHeatingDetails.OverallHeatLoss = null;

            xmlHeating.SolarHeatingDetails = xmlSolarHeatingDetails;

            /******************************WWHRS*************************************/

            oM.Environment.SAP.XML.InstantaneousWWHRS xmlInstantaneousWWHRS = new oM.Environment.SAP.XML.InstantaneousWWHRS();
            oM.Environment.SAP.XML.StorageWWHRS xmlStorageWWHRS = new oM.Environment.SAP.XML.StorageWWHRS();

            if (heating.WasteWaterHRS == null)
            {
                xmlInstantaneousWWHRS.WWHRSIndexNumber1 = null;
                xmlInstantaneousWWHRS.WWHRSEfficiency1 = null;
                xmlInstantaneousWWHRS.WWHRSIndexNumber2 = null;
                xmlInstantaneousWWHRS.WWHRSEfficiency2 = null;
                xmlInstantaneousWWHRS.WWHRSManufacturer1 = null;
                xmlInstantaneousWWHRS.WWHRSManufacturer2= null;
                xmlInstantaneousWWHRS.WWHRSModel1= null;
                xmlInstantaneousWWHRS.WWHRSModel2 = null;
                xmlStorageWWHRS.WWHRSIndexNumber = null;
                xmlStorageWWHRS.WWHRSStoreVolume = null;
                xmlStorageWWHRS.StorageWWHRSEfficiency = null;
                xmlStorageWWHRS.StorageWWHRSManufacturer = null;
                xmlStorageWWHRS.StorageWWHRSModel= null;

            }
            else if (heating.WasteWaterHRS != null)
            {
                if (heating.WasteWaterHRS.InstantaneousSystem1 != null)
                {
                    xmlInstantaneousWWHRS.WWHRSIndexNumber1 = heating.WasteWaterHRS.InstantaneousSystem1.IndexNumber;
                    xmlInstantaneousWWHRS.WWHRSEfficiency1 = heating.WasteWaterHRS.InstantaneousSystem1.Efficiency;
                    xmlInstantaneousWWHRS.WWHRSManufacturer1 = heating.WasteWaterHRS.InstantaneousSystem1.Details.Manufacturer;
                    xmlInstantaneousWWHRS.WWHRSModel1 = heating.WasteWaterHRS.InstantaneousSystem1.Details.Model;
                }

                if (heating.WasteWaterHRS.InstantaneousSystem2 != null)
                {
                    if (heating.WasteWaterHRS.InstantaneousSystem1 == null)
                    {
                        xmlInstantaneousWWHRS.WWHRSIndexNumber1 = heating.WasteWaterHRS.InstantaneousSystem2.IndexNumber;
                        xmlInstantaneousWWHRS.WWHRSEfficiency1 = heating.WasteWaterHRS.InstantaneousSystem2.Efficiency;
                        xmlInstantaneousWWHRS.WWHRSManufacturer1 = heating.WasteWaterHRS.InstantaneousSystem2.Details.Manufacturer;
                        xmlInstantaneousWWHRS.WWHRSModel1 = heating.WasteWaterHRS.InstantaneousSystem2.Details.Model;
                    }
                    else
                    {
                        xmlInstantaneousWWHRS.WWHRSIndexNumber2 = heating.WasteWaterHRS.InstantaneousSystem2.IndexNumber;
                        xmlInstantaneousWWHRS.WWHRSEfficiency2 = heating.WasteWaterHRS.InstantaneousSystem2.Efficiency;
                        xmlInstantaneousWWHRS.WWHRSManufacturer2 = heating.WasteWaterHRS.InstantaneousSystem2.Details.Manufacturer;
                        xmlInstantaneousWWHRS.WWHRSModel2 = heating.WasteWaterHRS.InstantaneousSystem2.Details.Model;
                    }

                }

                if (heating.WasteWaterHRS.StorageSystem != null)
                {
                    xmlStorageWWHRS.WWHRSIndexNumber = heating.WasteWaterHRS.StorageSystem.IndexNumber;
                    xmlStorageWWHRS.WWHRSStoreVolume = heating.WasteWaterHRS.StorageSystem.StoreVolume;
                    xmlStorageWWHRS.StorageWWHRSEfficiency = heating.WasteWaterHRS.StorageSystem.Efficiency;
                    xmlStorageWWHRS.StorageWWHRSManufacturer = heating.WasteWaterHRS.StorageSystem.Details.Manufacturer;
                    xmlStorageWWHRS.StorageWWHRSModel = heating.WasteWaterHRS.StorageSystem.Details.Model;
                }
                
            }

            xmlHeating.InstantaneousWHRS = xmlInstantaneousWWHRS;
            xmlHeating.StorageWHRS = xmlStorageWWHRS;

            /**************************Bath and showers ***************************/

            List<oM.Environment.SAP.XML.ShowerOutlet> xmlShowerOutlets = new List<oM.Environment.SAP.XML.ShowerOutlet>();

            if (heating.BathAndShowerDetails != null) 
            {
                if (heating.BathAndShowerDetails.ShowerOutlets != null)
                {
                  
                    for (int i = 0; i < heating.BathAndShowerDetails.ShowerOutlets.Count; i++)
                    {
                        oM.Environment.SAP.XML.ShowerOutlet xmlShowerOutlet = new oM.Environment.SAP.XML.ShowerOutlet();
                        xmlShowerOutlet.ShowerOutletType = heating.BathAndShowerDetails.ShowerOutlets[i].Type;
                        xmlShowerOutlet.ShowerFlowRate = heating.BathAndShowerDetails.ShowerOutlets[i].FlowRate;
                        xmlShowerOutlet.ShowerPower = heating.BathAndShowerDetails.ShowerOutlets[i].Power;
                        xmlShowerOutlet.ShowerWWHRS = heating.BathAndShowerDetails.ShowerOutlets[i].ShowerWWHRS;//connect with the WWHRS names
                        xmlShowerOutlets.Add(xmlShowerOutlet);
                    }

                    xmlHeating.ShowerOutlets.ShowerOutlet = xmlShowerOutlets;
                }

                xmlHeating.NumberBaths = heating.BathAndShowerDetails.NumberBaths;
                xmlHeating.NumberBathsWWHRS = heating.BathAndShowerDetails.NumberBathsWWHRS;
            }
           

            return new Output<oM.Environment.SAP.XML.Heating, oM.Environment.SAP.XML.Cooling>() { Item1 = xmlHeating, Item2 = xmlCooling };
        }

        /*****************************ENUMS*********************************/

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfHotWaterStoreInsulation typeOfHotWaterStoreInsulation)
        {
            switch (typeOfHotWaterStoreInsulation)
            {
                case BH.oM.Environment.SAP.TypeOfHotWaterStoreInsulation.FactoryApplied:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfHotWaterStoreInsulation.LooseJacket:
                    return "2";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfGasOrOilBoiler typeOfGasOrOilBoiler)
        {
            switch (typeOfGasOrOilBoiler)
            {
                case BH.oM.Environment.SAP.TypeOfGasOrOilBoiler.Regular:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfGasOrOilBoiler.Combi:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfGasOrOilBoiler.CPSU:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfGasOrOilBoiler.RangeCooker:
                    return "4";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfHeatSource typeOfHeatSource)
        {
            switch (typeOfHeatSource)
            {
                case BH.oM.Environment.SAP.TypeOfHeatSource.CHP:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfHeatSource.Boilers:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfHeatSource.HeatPump:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfHeatSource.WasteHeat:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfHeatSource.Geothermal:
                    return "5";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.CommunityHeatingUseCode communityHeatingUseCode)
        {
            switch (communityHeatingUseCode)
            {
                case BH.oM.Environment.SAP.CommunityHeatingUseCode.SpaceHeatingOnly:
                    return "1";

                case BH.oM.Environment.SAP.CommunityHeatingUseCode.WaterHeatingOnly:
                    return "2";

                case BH.oM.Environment.SAP.CommunityHeatingUseCode.SpaceAndWaterHeating:
                    return "3";

                default:
                    return "";
            }
        }



        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfSolarCollector typeOfSolarCollector)
        {
            switch (typeOfSolarCollector)
            {
                case BH.oM.Environment.SAP.TypeOfSolarCollector.Unglazed:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfSolarCollector.FlatPanel:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfSolarCollector.EvacuatedTube:
                    return "3";

                default:
                    return "";
            }
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
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfImmersion typeOfImmersion)
        {
            switch (typeOfImmersion)
            {
                case BH.oM.Environment.SAP.TypeOfImmersion.Dual:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfImmersion.Single:
                    return "2";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.CoolingClassCode typeOfImmersion)
        {
            switch (typeOfImmersion)
            {
                case BH.oM.Environment.SAP.CoolingClassCode.A3:
                    return "1";
                case BH.oM.Environment.SAP.CoolingClassCode.A2:
                    return "2";
                case BH.oM.Environment.SAP.CoolingClassCode.A1:
                    return "3";
                case BH.oM.Environment.SAP.CoolingClassCode.A:
                    return "4";
                case BH.oM.Environment.SAP.CoolingClassCode.B:
                    return "5";
                case BH.oM.Environment.SAP.CoolingClassCode.C:
                    return "6";
                case BH.oM.Environment.SAP.CoolingClassCode.D:
                    return "7";
                case BH.oM.Environment.SAP.CoolingClassCode.E:
                    return "8";
                case BH.oM.Environment.SAP.CoolingClassCode.F:
                    return "9";
                case BH.oM.Environment.SAP.CoolingClassCode.G:
                    return "10";
                case BH.oM.Environment.SAP.CoolingClassCode.ND:
                    return "11";
                case BH.oM.Environment.SAP.CoolingClassCode.Unknown:
                    return "12";
                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.DataSourceCode sourceCode)
        {
            switch (sourceCode)
            {
                case BH.oM.Environment.SAP.DataSourceCode.FromDatabase:
                    return "1";

                case BH.oM.Environment.SAP.DataSourceCode.ManufacturerDeclaration:
                    return "2";

                case BH.oM.Environment.SAP.DataSourceCode.SAPTable:
                    return "3";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfHeatingFuel typeOfHeatingFuel)
        {
            switch (typeOfHeatingFuel)
            {
                case BH.oM.Environment.SAP.TypeOfHeatingFuel.MainsGas:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.BulkLPG:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.BottledLPG:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.HeatingOil:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.Biogas:
                    return "7";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.LNG:
                    return "8";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.LPGSpecialCondition:
                    return "9";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.SolidFuelMineralAndWood:
                    return "10";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.HouseCoal:
                    return "11";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.ManufacturedSmokelessFuel:
                    return "12";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.Anthracite:
                    return "15";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodLogs:
                    return "20";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodChips:
                    return "21";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodPelletsSecondaryHeating:
                    return "22";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodPelletsMainHeating:
                    return "23";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.ElectricitySoldToGrid:
                    return "36";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.ElectricityDisplacedFromGrid:
                    return "37";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.ElectricityUnspecTariff:
                    return "39";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityHeatPump:
                    return "41";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersWaste:
                    return "42";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersBiomass:
                    return "43";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersBiogas:
                    return "44";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityWastePowerStations:
                    return "45";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityGeothermal:
                    return "46";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityCHP:
                    return "48";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityElectricityCHP:
                    return "49";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityElectricityNetwork:
                    return "50";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityMainsGas:
                    return "51";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityLPG:
                    return "52";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityOil:
                    return "53";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityCoal:
                    return "54";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityB30D:
                    return "55";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersMineralOilBiodiesel:
                    return "56";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersBiodiesel:
                    return "57";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBiodieselVegetableOil:
                    return "58";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.Biodiesel:
                    return "71";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.BiodieselUsedCookingOil:
                    return "72";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.BiodieselVegetableOil:
                    return "73";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.MineralOilLiquidBiofuel:
                    return "74";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.B30K:
                    return "75";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.Bioethanol:
                    return "76";

                case BH.oM.Environment.SAP.TypeOfHeatingFuel.FuelDataFromPcdb:
                    return "99";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfCombiBoiler typeOfCombiBoiler)
        {
            switch (typeOfCombiBoiler)
            {
                case BH.oM.Environment.SAP.TypeOfCombiBoiler.InstantaneousNoStoreOrKeepHot:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.PrimaryStorage:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.SecondaryStorage:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.CPSU:
                    return "4";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.UntimedKeepHotByFuel:
                    return "5";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.TimedKeepHotByFuel:
                    return "6";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.UntimedKeepHotByElectricity:
                    return "7";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.TimedKeepHotByElectricity:
                    return "8";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.UntimedKeepHotByFuelAndElectricity:
                    return "9";

                case BH.oM.Environment.SAP.TypeOfCombiBoiler.TimedKeepHotByFuelAndElectricity:
                    return "10";

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

                case BH.oM.Environment.SAP.EmitterTemperatureCode.Over35LessThanOrEqual45:
                    return "3";

                case BH.oM.Environment.SAP.EmitterTemperatureCode.LessThanOrEqual35:
                    return "4";

                case BH.oM.Environment.SAP.EmitterTemperatureCode.NotApplicable:
                    return "NA";

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

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfSolidFuelBoiler typeOfSolidFuelBoiler)
        {
            switch (typeOfSolidFuelBoiler)
            {
                case BH.oM.Environment.SAP.TypeOfSolidFuelBoiler.Independent:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfSolidFuelBoiler.OpenFire:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfSolidFuelBoiler.ClosedRoomHeater:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfSolidFuelBoiler.RangeCooker:
                    return "4";

                default:
                    return "";
            }
        }
        private static string FromSAPToXML(this BH.oM.Environment.SAP.CHPElectricityGenerationCode cHPElectricityGenerationCode)
        {
            switch (cHPElectricityGenerationCode)
            {
                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.NewCHPExportOnly:
                    return "81";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.NewCHPFlexibleOperation:
                    return "82";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.NewCHPStandard:
                    return "83";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.ExistingCHP2015ExportOnly:
                    return "84";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.ExistingCHP2015FlexibleOperation:
                    return "85";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.ExistingCHP2015Standard:
                    return "86";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.ExistingCHPPre2015ExportOnly:
                    return "87";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.ExistingCHPPre2015FlexibleOperation:
                    return "88";

                case BH.oM.Environment.SAP.CHPElectricityGenerationCode.ExistingCHPPre2015Standard:
                    return "89";

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

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfEfficiency typeOfEfficiency)
        {
            switch (typeOfEfficiency)
            {
                case BH.oM.Environment.SAP.TypeOfEfficiency.NotGasOrOilBoiler:
                    return "1";

                case BH.oM.Environment.SAP.TypeOfEfficiency.SEDBUK2005:
                    return "2";

                case BH.oM.Environment.SAP.TypeOfEfficiency.SEDBUK2009:
                    return "3";

                case BH.oM.Environment.SAP.TypeOfEfficiency.WinterAndSummer:
                    return "4";

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

        private static string FromSAPToXML(this BH.oM.Environment.SAP.PipeworkInsulationCode pipeworkInsulationCode)
        {
            switch (pipeworkInsulationCode)
            {
                case BH.oM.Environment.SAP.PipeworkInsulationCode.NotInsulated:
                    return "1";

                case BH.oM.Environment.SAP.PipeworkInsulationCode.First1MetreFromCylinderInsulated:
                    return "2";

                case BH.oM.Environment.SAP.PipeworkInsulationCode.AllAccessiblePipeworkInsulated:
                    return "3";

                case BH.oM.Environment.SAP.PipeworkInsulationCode.FullyInsulated:
                    return "4";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.HeatingControlCode heatingControlCode)
        {
            switch (heatingControlCode)
            {
                case BH.oM.Environment.SAP.HeatingControlCode.None:
                    return "2699";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_OnlyDHW:
                    return "2100";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_NoTimeOrThermostaticControl:
                    return "2101";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerOnly:
                    return "2102";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ThermostatOnly:
                    return "2103";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerAndThermostat:
                    return "2104";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerAndMoreThanOneThermostat:
                    return "2105";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ThermostatAndTRVs:
                    return "2113";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerThermostatAndTRVs:
                    return "2106";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_TRVsAndBypass:
                    return "2111";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerTRVsAndBypass:
                    return "2107";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerTRVsAndFlowSwitch:
                    return "2108";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_ProgrammerTRVsAndEnergyManager:
                    return "2109";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_TimeAndTempControlByPlumbingAndElectrical:
                    return "2110";

                case BH.oM.Environment.SAP.HeatingControlCode.Boiler_TimeAndTempControlByPCDB:
                    return "2112";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_NoTimeOrThermostaticControl:
                    return "2201";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ProgrammerOnly:
                    return "2202";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ThermostatOnly:
                    return "2203";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ProgrammerAndThermostat:
                    return "2204";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ProgrammerAndMoreThanOneThermostat:
                    return "2205";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ThermostatAndTRVs:
                    return "2209";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ProgrammerThermostatAndTRVs:
                    return "2210";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_ProgrammerTRVsAndBypass:
                    return "2206";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_TimeAndTempControlByPlumbingAndElectrical:
                    return "2207";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatPump_TimeAndTempControlByPCDB:
                    return "2208";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateNoThermostaticControl:
                    return "2301";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateProgrammerOnly:
                    return "2302";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateThermostatOnly:
                    return "2303";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateProgrammerAndThermostat:
                    return "2304";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateThermostatAndTRVs:
                    return "2313";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateTRVs:
                    return "2307";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateProgrammerAndTRVs:
                    return "2305";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_FlatRateProgrammerAndMoreThanOneThermostat:
                    return "2311";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_ChargingSystemThermostatOnly:
                    return "2308";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_ChargingSystemProgrammerAndThermostat:
                    return "2309";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_ChargingSystemThermostatAndTRVs:
                    return "2314";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_ChargingSystemTRVs:
                    return "2310";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_ChargingSystemProgrammerAndTRVs:
                    return "2306";

                case BH.oM.Environment.SAP.HeatingControlCode.HeatNetworks_ChargingSystemProgrammerAndMoreThanOneThermostat:
                    return "2312";

                case BH.oM.Environment.SAP.HeatingControlCode.ElectricStorage_Manual:
                    return "2401";

                case BH.oM.Environment.SAP.HeatingControlCode.ElectricStorage_Automatic:
                    return "2402";

                case BH.oM.Environment.SAP.HeatingControlCode.ElectricStorage_CelectType:
                    return "2403";

                case BH.oM.Environment.SAP.HeatingControlCode.ElectricStorage_ControlsForHighHeatRetention:
                    return "2404";

                case BH.oM.Environment.SAP.HeatingControlCode.WarmAir_NoTimeOrThermostaticControl:
                    return "2501";

                case BH.oM.Environment.SAP.HeatingControlCode.WarmAir_ProgrammerOnly:
                    return "2502";

                case BH.oM.Environment.SAP.HeatingControlCode.WarmAir_ThermostatOnly:
                    return "2503";

                case BH.oM.Environment.SAP.HeatingControlCode.WarmAir_ProgrammerAndThermostat:
                    return "2504";

                case BH.oM.Environment.SAP.HeatingControlCode.WarmAir_ProgrammerAndMoreThanOneThermostat:
                    return "2505";

                case BH.oM.Environment.SAP.HeatingControlCode.WarmAir_TimeAndTemperatureZoneControl:
                    return "2506";

                case BH.oM.Environment.SAP.HeatingControlCode.RooomHeater_NoThermostaticControl:
                    return "2601";

                case BH.oM.Environment.SAP.HeatingControlCode.RooomHeater_ApplianceThermostats:
                    return "2602";

                case BH.oM.Environment.SAP.HeatingControlCode.RooomHeater_ProgrammerAndApplianceThermostats:
                    return "2603";

                case BH.oM.Environment.SAP.HeatingControlCode.RooomHeater_RoomThermostatsOnly:
                    return "2604";

                case BH.oM.Environment.SAP.HeatingControlCode.RooomHeater_ProgrammerAndRoomThermostats:
                    return "2605";

                case BH.oM.Environment.SAP.HeatingControlCode.Other_NoTimeOrThermostaticControl:
                    return "2701";

                case BH.oM.Environment.SAP.HeatingControlCode.Other_ProgrammerOnly:
                    return "2702";

                case BH.oM.Environment.SAP.HeatingControlCode.Other_RoomThermostatOnly:
                    return "2703";

                case BH.oM.Environment.SAP.HeatingControlCode.Other_ProgrammerAndRoomThermostat:
                    return "2704";

                case BH.oM.Environment.SAP.HeatingControlCode.Other_TemperatureZoneControl:
                    return "2705";

                case BH.oM.Environment.SAP.HeatingControlCode.Other_TimeAndTemperatureZoneControl:
                    return "2706";

                default:
                    return "";


            }
        }


        private static string FromSAPToXML(this BH.oM.Environment.SAP.HeatingDistributionCode heatingDistributionCode)
        {
            switch (heatingDistributionCode)
            {
                case BH.oM.Environment.SAP.HeatingDistributionCode.Calculated:
                    return "5";

                case BH.oM.Environment.SAP.HeatingDistributionCode.Unknown:
                    return "6";

                case BH.oM.Environment.SAP.HeatingDistributionCode.NetworkNotCompliantWithCodeOfPractice:
                    return "7";

                case BH.oM.Environment.SAP.HeatingDistributionCode.NetworkCompliantWithCodeOfPractice:
                    return "8";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.BoilerFuelFeedCode boilerFuelFeedCode)
        {
            switch (boilerFuelFeedCode)
            {
                case BH.oM.Environment.SAP.BoilerFuelFeedCode.Gravity:
                    return "1";

                case BH.oM.Environment.SAP.BoilerFuelFeedCode.Manual:
                    return "2";

                case BH.oM.Environment.SAP.BoilerFuelFeedCode.Screw:
                    return "3";

                case BH.oM.Environment.SAP.BoilerFuelFeedCode.Other:
                    return "4";

                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfSpaceHeating typeOfSpaceHeating)
        {
            switch (typeOfSpaceHeating)
            {
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.NonePresent:
                    return "699";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelManualFeed:
                    return "151";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelAutoFeed:
                    return "153";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelWoodChip:
                    return "155";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelOpenFire:
                    return "156";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelClosedRoom:
                    return "158";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelStove:
                    return "159";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelRangeCookerIntegral:
                    return "160";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_SolidFuelRangeCookerIndependent:
                    return "161";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_ElectricBoilerDirect:
                    return "191";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_ElectricBoilerCPSUHeated:
                    return "192";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_ElectricBoilerDryCoreStorageHeated:
                    return "193";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_ElectricBoilerDryCoreStorageUnheated:
                    return "194";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_ElectricBoilerWaterStorageHeated:
                    return "195";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.BoilerSystem_ElectricBoilerWaterStorageUnheated:
                    return "196";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorElectricPumpGroundSourceLessThan35:
                    return "211";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorElectricPumpWaterSourceLessThan35:
                    return "213";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorElectricPumpAirSourceLessThan35:
                    return "214";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorElectricPumpGroundSourceOther:
                    return "221";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorElectricPumpWaterSourceOther:
                    return "223";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorElectricPumpAirSourceOther:
                    return "224";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatPumpWithRadiator_WithRadiatorGasPumpGroundSourceLessThan35: 
                    return "215"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatPumpWithRadiator_WithRadiatorGasPumpWaterSourceLessThan35 : 
                    return "216";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorGasPumpAirSourceLessThan35:
                    return "217";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatPumpWithRadiator_WithRadiatorGasPumpGroundSourceOther : 
                    return "225";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithRadiator_WithRadiatorGasPumpWaterSourceOther:
                    return "226";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatPumpWithRadiator_WithRadiatorGasPumpAirSourceOther:
                    return "227";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithWarmAir_WarmAirElectricPumpGroundSource:
                    return "521";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatPumpWithWarmAir_WarmAirElectricPumpWaterSource:
                    return "523";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithWarmAir_WarmAirElectricPumpAirSource:
                    return "524";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatPumpWithWarmAir_WarmAirGasPumpGroundSource : 
                    return "525";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithWarmAir_WarmAirGasPumpWaterSource:
                    return "526";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatPumpWithWarmAir_WarmAirGasPumpAirSource: 
                    return "527";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatNetwork_BoilersOnlyRdSAP:
                    return "301"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.HeatNetwork_CHPAndBoilerRdSAP: 
                    return "302"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. HeatNetwork_HeatPumpRdSAP : 
                    return "304";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_OldHeater:
                    return "401";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_Slimline:
                    return "402";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_Convector:
                    return "403";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_Fan:
                    return "404";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_SlimlineWithCelect:
                    return "405";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_ConvectorWithCelect:
                    return "406";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_FanWithCelect:
                    return "407";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_Integrated:
                    return "408";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricStorage_HighHeatRetention:
                    return "409";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricUnderfloor_InConcrete:
                    return "421";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricUnderfloor_Integrated:
                    return "422";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricUnderfloor_IntegratedWithLowTariffControl:
                    return "423";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricUnderfloor_InScreed:
                    return "424";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.ElectricUnderfloor_InTimberFloor:
                    return "425";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasFanAssistedDuctedOnOffControlPre1998:
                    return "501";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasFanAssistedDuctedOnOffControlPost1998:
                    return "502";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasFanAssistedDuctedModulatingControlPre1998:
                    return "503";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasFanAssistedDuctedModulatingControlPost1998:
                    return "504";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasFanAssistedRoomHeater:
                    return "505";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasFanAssistedCondensing:
                    return "520";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasBalancedOrOpenFlueDuctedOnOffControlPre1998:
                    return "506";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasBalancedOrOpenFlueDuctedOnOffControlPost1998:
                    return "507"; 

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasBalancedOrOpenFlueDuctedModulatingControlPre1998:
                    return "508";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasBalancedOrOpenFlueDuctedModulationControlPost1998:
                    return "509";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasBalancedOrOpenFlueDuctedWithFlueHeatRecovery:
                    return "510";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_GasBalancedOrOpenFlueCondensing:
                    return "511";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_LiquidDuctedOnOffControl:
                    return "512";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_LiquidDuctedModulatingControl:
                    return "513";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_LiquidStubDuctSystem:
                    return "514";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.WarmAir_ElectricaireSystem: 
                    return "515";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_GasOpenFluePre1980:
                    return "601";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_OpenFluePre1980BackBoiler:
                    return "602";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_OpenFluePost1980:
                    return "603";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_OpenFluePost1980BackBoiler:
                    return "604";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_FlushFittingGasFire:
                    return "605";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_FlushFittingGasFireBackBoiler:
                    return "606";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_FlushFittingGasFireFanAssisted:
                    return "607";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_GasFireOrWallHeaterBalancedFlue:
                    return "609";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_GasFireClosedFrontedFanAssistes: 
                    return "610";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_CondensingGasFire:
                    return "611";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_DecorativeFuelGasFire:
                    return "612";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_FluelessGasFire: 
                    return "614";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_LiquidFuelPre2000:
                    return "621";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. RoomHeater_LiquidFuelPre200WithBoiler:
                    return "622";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_LiquidFuelPost2000:
                    return "623"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_LiquidFuelPost2000WithBoiler:
                    return "624";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_LiquidFuelBioethanolHeaterSecondaryOnly: 
                    return "625";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. RoomHeater_SolidFuelOpenFire:
                    return "631";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_SolidFuelOpenFireWithBackBoiler:
                    return "632"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. RoomHeater_SolidFuelClosed:
                    return "633";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_SolidFuelClosedWithBoiler:
                    return "634";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_SolidFuelStove:
                    return "635";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_SolidFuelStoveWithBoiler:
                    return "636";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_ElectricPanelConvectorOrRadiant: 
                    return "691";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating. RoomHeater_ElectricWaterOrOil: 
                    return "694";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_ElectricFanHeater:
                    return "692";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RoomHeater_ElectricPortable: 
                    return "693";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.Other_ElectricCeilingHeating: 
                    return "701"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998NonCondensingAutomaticIgnition: 
                    return "101";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998CondensingWithAutomaticIgnition:
                    return "102"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998NonCondensingCombiWithAutomaticIgnition:
                    return "103";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998CondensingCombiWithAutomaticIgnition:
                    return "104";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998NonCondensingWithPilotLight:
                    return "105";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998RCondensingWithPilotLight:
                    return "106";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998NonCondensingCombiWithPilotLight:
                    return "107";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998CondensingCombiWithPilotLight:
                    return "108";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Post1998BackBoilerToRadiators:
                    return "109";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithFanAssistedFlueLowThermalCapacity:
                    return "110";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithFanAssistedFlueHighOrUnknownThermalCapacity:
                    return "111";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithFanAssistedFlueCombi:
                    return "112";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithFanAssistedFlueCondensingCombi:
                    return "113";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithFanAssistedFlueRegularCondensing:
                    return "114";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithOpenFlueWallMounted:
                    return "115";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithOpenFlueFloorMountedPre1979:
                    return "116";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithOpenFlueFloorMountedPost1979:
                    return "117";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithOpenFlueCombi:
                    return "118";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.GasBoiler_Pre1998WithOpenFlueBackBoilerToRadiators:
                    return "119";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.CPSU_AutomaticIgnitionNonCondensing:
                    return "120";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.CPSU_AutomaticIgnitionCondensing:
                    return "121";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.CPSU_PermanentPilotLightNonCondensing:
                    return "122";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.CPSU_PermanentPilotLightCondensing:
                    return "123";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_OilStandardPre1965:
                    return "124";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_OilStandard1985To1997:
                    return "125";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_OilStandardPost1998:
                    return "126";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_CondensingOil: 
                    return "127"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_CombiOilPre1998:
                    return "128";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_CombiOilPost1998:
                    return "129";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_CondensingCombiOil:
                    return "130";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_OilRoomHeaterWithBoilerToRadiatorsPre2000:
                    return "131";
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.LiquidFuel_OilRoomHeaterWithBoilerToRadiatorsPost2000:
                    return "132";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCooker_SingleBurnerWithPermanentPilot:
                    return "133";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCooker_SingleBurnerWithAutomaticIgnition:
                    return "134";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCooker_TwinBurnerWithPermanentPilotPre1998:
                    return "135";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCooker_TwinBurnerWithAutomaticIgnitionPre1998:
                    return "136";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCooker_TwinBurnerWithPermanentPilotPost1998:
                    return "137";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCooker_TwinBurnerWithAutomaticIgnitionPost1998:
                    return "138";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCookerLiquidFuel_SingleBurner:
                    return "139"; 
                
                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCookerLiquidFuel_TwinBurnerPre1998:
                    return "140";

                case BH.oM.Environment.SAP.TypeOfSpaceHeating.RangeCookerLiquidFuel_TwinBurnerPost1998:
                    return "141";


                default:
                    return "";
            }
        }

        private static string FromSAPToXML(this BH.oM.Environment.SAP.UnderfloorHeatEmitterCode underfloorHeatEmitterCode)
        {
            switch (underfloorHeatEmitterCode)
            {
                case BH.oM.Environment.SAP.UnderfloorHeatEmitterCode.InConcreteSlab:
                    return "1";

                case BH.oM.Environment.SAP.UnderfloorHeatEmitterCode.InScreedAboveInsulation:
                    return "2";

                case BH.oM.Environment.SAP.UnderfloorHeatEmitterCode.InTimberFloor:
                    return "3";

                default:
                    return "";
            }
        }



        private static string FromSAPToXML(this BH.oM.Environment.SAP.WaterHeatingCode heatingCode)
        {
            switch (heatingCode)
            {
                case BH.oM.Environment.SAP.WaterHeatingCode.NoHotWaterSystem:
                    return "999";

                case BH.oM.Environment.SAP.WaterHeatingCode.MainSystem:
                    return "901";

                case BH.oM.Environment.SAP.WaterHeatingCode.SecondMainSystem:
                    return "914";

                case BH.oM.Environment.SAP.WaterHeatingCode.SecondarySystem:
                    return "902";

                case BH.oM.Environment.SAP.WaterHeatingCode.ElectricImmersion:
                    return "903";

                case BH.oM.Environment.SAP.WaterHeatingCode.SinglePointGas:
                    return "907";

                case BH.oM.Environment.SAP.WaterHeatingCode.MultiPointGas:
                    return "908";

                case BH.oM.Environment.SAP.WaterHeatingCode.ElectricInstantaneous:
                    return "908";

                case BH.oM.Environment.SAP.WaterHeatingCode.GasBoilerOnlyForWater:
                    return "911";

                case BH.oM.Environment.SAP.WaterHeatingCode.LiquidFuelOnlyForWater:
                    return "912";

                case BH.oM.Environment.SAP.WaterHeatingCode.SolidFuelOnlyForWater:
                    return "913";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerGasSinglePermanent:
                    return "921";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerGasSingleAutomatic:
                    return "922";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerGasTwinPermanentPre1998:
                    return "923";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerGasTwinAutoPre1998:
                    return "924";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerGasTwinPermanentPost1998:
                    return "925";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerGasTwinAutoPost1998:
                    return "926";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerLiquidSingle:
                    return "927";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerLiquidTwinPre1998:
                    return "928";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerLiquidTwinPost1998:
                    return "929";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerSolidIntegralOvenBoiler:
                    return "930";

                case BH.oM.Environment.SAP.WaterHeatingCode.RangeCookerSolidIndependentOvenBoiler:
                    return "931";

                case BH.oM.Environment.SAP.WaterHeatingCode.ElectricPumpOnlyWater:
                    return "941";

                case BH.oM.Environment.SAP.WaterHeatingCode.Boilers_RdSAP:
                    return "950";

                case BH.oM.Environment.SAP.WaterHeatingCode.CHP_RdSAP:
                    return "951";

                case BH.oM.Environment.SAP.WaterHeatingCode.HeatPumpRdSAP:
                    return "952";

                default:
                    return "";
            }
        }
    }
}

