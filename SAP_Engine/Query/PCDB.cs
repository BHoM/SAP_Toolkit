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
using System.Net;
using System.IO;

using BH.oM.Environment.MaterialFragments;

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {   /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Query performance characteristics of specific products.")]
        [Input("ProductType", "Enum. mech vent/heat pump/boiler etc.")]
        [Input("ProductIndex", "Unique ID for specific product make and model.")]
        [Input("run", "Toggle to activate the component.")]
        [Output("PCDB", "Performance characteristics of the specified product.")]
        public static BH.oM.Environment.SAP.IPCDBObject PCDB(this BH.oM.Environment.SAP.ProductType ProductType, string ProductIndex = null, bool run = false)
        {
            if (!run)
            { return null; }

            WebClient readWeb = new WebClient();
            Stream stream = readWeb.OpenRead("http://www.boilers.org.uk/data1/pcdf2012.dat");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            string[] contentSplit = content.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

            if (ProductType == BH.oM.Environment.SAP.ProductType.MEVcAndMVHR)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 323")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 323")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MEVcAndMVHRTable productTable = new oM.Environment.SAP.MEVcAndMVHRTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerRefNo = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstManufYear = dividedStrings[8];
                productTable.FinalManufYear = dividedStrings[9];
                productTable.MainType = dividedStrings[10];
                productTable.IntegralOnly = dividedStrings[11];
                productTable.DuctType = dividedStrings[12];
                productTable.DuctSize = dividedStrings[13];
                productTable.SummerByPass = dividedStrings[14];
                productTable.NumExhaustTerminalConfig = dividedStrings[15];
                productTable.TestFlowRatesBasis = dividedStrings[16];
                productTable.AddidtionalWetRooms = dividedStrings[17];
                productTable.TestFlowRate = dividedStrings[18];
                productTable.FanSpeedSetting = dividedStrings[19];
                productTable.ApplicableFlowRate = dividedStrings[20];
                productTable.SpecificFanPower = dividedStrings[21];
                productTable.HeatExchangerEfficiency = dividedStrings[22];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.GasAndOilBoiler)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("$105,210,175,2022,01,31,2")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("$122,224,48,2021,04,19,1")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.GasAndBoilerTable productTable = new oM.Environment.SAP.GasAndBoilerTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerRefNo = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.BoilerID = dividedStrings[8];
                productTable.FirstManufYear = dividedStrings[9];
                productTable.FinalManufYear = dividedStrings[10];
                productTable.Fuel = dividedStrings[11];
                productTable.MountingPosition = dividedStrings[12];
                productTable.ExposureRating = dividedStrings[13];
                productTable.MainType = dividedStrings[14];
                productTable.SubsidiaryType = dividedStrings[15];
                productTable.SubsidiaryTypeTable = dividedStrings[16];
                productTable.SubsidiaryTypeIndex = dividedStrings[17];
                productTable.Condensing = dividedStrings[18];
                productTable.FlueType = dividedStrings[19];
                productTable.FanAssistance = dividedStrings[20];
                productTable.BoilerPowerBottom = dividedStrings[21];
                productTable.BoilerPowerTop = dividedStrings[22];
                productTable.EnergyEfficiencyClass = dividedStrings[23];
                productTable.AnnualSeasonalEfficiency = dividedStrings[24];
                productTable.SAPWinterSeasonalEfficiency = dividedStrings[25];
                productTable.SAPSummerSeasonalEfficiency = dividedStrings[26];
                productTable.HotWaterEfficiency1 = dividedStrings[27];
                productTable.HotWaterEfficiency2 = dividedStrings[28];
                productTable.SAP2005SeasonalEfficiency = dividedStrings[29];
                productTable.EfficiencyCategory = dividedStrings[30];
                productTable.TestGasForLPG = dividedStrings[31];
                productTable.TestCorrectionForLPG = dividedStrings[32];
                productTable.SAPEquationUsed = dividedStrings[33];
                productTable.Ignition = dividedStrings[34];
                productTable.BurnerControl = dividedStrings[35];
                productTable.ElectricalPowerFiring = dividedStrings[36];
                productTable.ElectricalPowerNotFiring = dividedStrings[37];
                productTable.StoreType = dividedStrings[38];
                productTable.StoreLossInTest = dividedStrings[39];
                productTable.SeperateStore = dividedStrings[40];
                productTable.StoreBoilerVolume = dividedStrings[41];
                productTable.StoreSolarVolume = dividedStrings[42];
                productTable.StoreInsulationThickness = dividedStrings[43];
                productTable.StoreInsulationType = dividedStrings[44];
                productTable.StoreTemperature = dividedStrings[45];
                productTable.StoreHeatLossRate = dividedStrings[46];
                productTable.SeperateDHWTests = dividedStrings[47];
                productTable.FuelEnergyForHWTest1 = dividedStrings[48];
                productTable.ElectricalEnergyForHWTest1 = dividedStrings[49];
                productTable.RejectedEnergyInHWTest1 = dividedStrings[50];
                productTable.StorageLossFactor = dividedStrings[51];
                productTable.FuelEnergyForHWTest2 = dividedStrings[52];
                productTable.ElectricalEnergyForHWTest2 = dividedStrings[53];
                productTable.RejectedEnergyInHWTest2 = dividedStrings[54];
                productTable.StorageLossFactor2 = dividedStrings[55];
                productTable.RejectedFactor3 = dividedStrings[56];
                productTable.KeepHotFacility = dividedStrings[57];
                productTable.KeepHotTimer = dividedStrings[58];
                productTable.KeepHotElectricHeater = dividedStrings[59];
                productTable.ControlCapabilities = dividedStrings[60];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.FlueGasHeatRecoverySystem)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 313")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 313")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.FlueGasHeatRecoverySystemTable productTable = new oM.Environment.SAP.FlueGasHeatRecoverySystemTable();
                 productTable.Index = ProductIndex;
                 productTable.ManufacturerReferenceNumber = dividedStrings[1];
                 productTable.Status = dividedStrings[2];
                 productTable.DBEntryUpdated = dividedStrings[3];
                 productTable.ManufacturerName = dividedStrings[4];
                 productTable.BrandName = dividedStrings[5];
                 productTable.ModelName = dividedStrings[6];
                 productTable.ModelQualifier = dividedStrings[7];
                 productTable.FirstYearOfManufacture = dividedStrings[8];
                 productTable.FinalYearOfManufacture = dividedStrings[9];
                 productTable.ApplicableFuel = dividedStrings[10];
                 productTable.TestFuel = dividedStrings[11];
                 productTable.ApplicableBoilerTypes = dividedStrings[12];
                 productTable.IntegralOnly = dividedStrings[13];
                 productTable.HeatStore = dividedStrings[14];
                 productTable.HeatStoreTotalVolume = dividedStrings[15];
                 productTable.HeatStoreRecapturedVolume = dividedStrings[16];
                 productTable.HeatStoreLossRaste = dividedStrings[17];
                 productTable.DirectTotalHeatReacovered = dividedStrings[18];
                 productTable.DirectUsefulHeatRecovered = dividedStrings[19];
                 productTable.PowerConsumption = dividedStrings[20];
                 productTable.PhotovoltaicModule = dividedStrings[21];
                 productTable.CableLoss = dividedStrings[22];
                 productTable.NumberOfEquations = dividedStrings[23];
                 productTable.SpaceHeatingRequirementFromBoilerSystem = dividedStrings[24];
                 productTable.CoefficientA = dividedStrings[25];
                 productTable.CoefficientB = dividedStrings[26];
                 productTable.CoefficientC = dividedStrings[27];
                 productTable.CoefficientA2 = dividedStrings[28];
                 productTable.CoefficientB2 = dividedStrings[29];
                 productTable.CoefficientC2 = dividedStrings[30];
                 return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.MEVdc) 
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 322")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 322")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.DecentralisedMEVTable productTable = new oM.Environment.SAP.DecentralisedMEVTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerReferenceNo = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstYearOfManufacture = dividedStrings[8];
                productTable.FinalYearOfManufacture = dividedStrings[9];
                productTable.MainType = dividedStrings[10];
                productTable.FlexibleOrRigidDucting = dividedStrings[11];
                productTable.NumberConfigurations = dividedStrings[12];
                productTable.ConfigurationA = dividedStrings[13];
                productTable.TestFlowRateA = dividedStrings[14];
                productTable.FanSpeedSettingA = dividedStrings[15];
                productTable.SpecificFanPowerA = dividedStrings[16];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.MVInUseFactors)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 329")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 329")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MVInUseFactorsTable productTable = new oM.Environment.SAP.MVInUseFactorsTable();
                productTable.SystemType = dividedStrings[0];
                productTable.SFPAdjustment1FlexibleDuction = dividedStrings[1];
                productTable.SFPAdjustment1RigidDucting = dividedStrings[2];
                productTable.SFPAdjustment1NoDucting = dividedStrings[3];
                productTable.MVHREfficiencyAdjustment1UninsulatedDucting = dividedStrings[4];
                productTable.MVHREfficiencyAdjustment1InsulatedDucting = dividedStrings[5];
                productTable.SFPAdjustment2FlexibleDuction = dividedStrings[6];
                productTable.SFPAdjustment2RigidDucting = dividedStrings[7];
                productTable.SFPAdjustment2NoDucting = dividedStrings[8];
                productTable.MVHREfficiencyAdjustment2UninsulatedDucting = dividedStrings[9];
                productTable.MVHREfficiencyAdjustment2InsulatedDucting = dividedStrings[10];
                productTable.DBEntryUpdated = dividedStrings[11];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.MVHRDuct)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 341")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 341")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MVHRDuctTable productTable = new oM.Environment.SAP.MVHRDuctTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerReference = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstYearOfManufacture = dividedStrings[8];
                productTable.FinalYearOfManufacture = dividedStrings[9];
                productTable.DuctType = dividedStrings[10];

                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.WasteWaterHeatRecoverySystem)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 353")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 353")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.WasteWaterHeatRecoverySystemTable productTable = new oM.Environment.SAP.WasteWaterHeatRecoverySystemTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerRefNo = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstYearOfManufacture = dividedStrings[8];
                productTable.FinalYearOfManufacture = dividedStrings[9];
                productTable.InstantaneousOrStorage = dividedStrings[10];
                productTable.SystemType = dividedStrings[11];
                productTable.StorageType = dividedStrings[12];
                productTable.Efficiency = dividedStrings[13];
                productTable.UtilisationFactor = dividedStrings[14];
                productTable.WasteWaterFraction = dividedStrings[15];
                productTable.TestDedicatedVolume = dividedStrings[16];
                productTable.LowDedicatedVolume = dividedStrings[17];
                productTable.HighDedicatedVolume = dividedStrings[18];
                productTable.ElectricityConsumption = dividedStrings[19];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.HeatPump)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 362")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 362")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.HeatPumpTable productTable = new oM.Environment.SAP.HeatPumpTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerReferenceNumber = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.APMVersionNumber = dividedStrings[4];
                productTable.ManufacturerName = dividedStrings[5];
                productTable.BrandName = dividedStrings[6];
                productTable.ModelName = dividedStrings[7];
                productTable.ModelQualifier = dividedStrings[8];
                productTable.FirstYearOfManufacture = dividedStrings[9];
                productTable.FinalYearOfManufacture = dividedStrings[10];
                productTable.DataQuality = dividedStrings[11];
                productTable.Fuel = dividedStrings[12];
                productTable.HeatDistrubutionType = dividedStrings[13];
                productTable.FlueType = dividedStrings[14];
                productTable.HeatSource = dividedStrings[15];
                productTable.ServiceProvision = dividedStrings[16];
                productTable.HWVessel = dividedStrings[17];
                productTable.VesselVolume = dividedStrings[18];
                productTable.VesselHeatLoss = dividedStrings[19];
                productTable.VesselHeatExchangerArea = dividedStrings[20];
                productTable.EnergyEfficiencyClass = dividedStrings[21];
                productTable.WaterHeatingEfficiency = dividedStrings[22];
                productTable.NetSpecificElectricityConsumed = dividedStrings[23];
                productTable.WaterHeatingEfficiency2 = dividedStrings[24];
                productTable.NetSoecificElectricityConumed2 = dividedStrings[25];
                productTable.ControlCapabilities = dividedStrings[26];
                if (dividedStrings.Count > 27)
                {
                    productTable.Reversible = dividedStrings[27];
                    productTable.EER = dividedStrings[28];
                    productTable.MaximumOutput = dividedStrings[29];
                    productTable.HeatingDuration = dividedStrings[30];
                    productTable.MEVorMVHRProductIndex = dividedStrings[31];
                    productTable.CompensatorEffect = dividedStrings[32];
                    productTable.SeperateCirculator = dividedStrings[33];
                    productTable.NumberOfAirFlowRates = dividedStrings[34];
                    productTable.AirFlowRate1 = dividedStrings[35];
                    productTable.AirFLowRate2 = dividedStrings[36];
                    productTable.AirflowRate3 = dividedStrings[37];
                    productTable.NumberOfPlantSizeRatios = dividedStrings[38];
                    productTable.PlantSizeRatioA = dividedStrings[39];
                    productTable.SpaceHeatingEfficiencyA = dividedStrings[40];
                    productTable.SpecificElectricityConsumedA = dividedStrings[41];
                    productTable.RunningHoursA = dividedStrings[42];
                }

                else
                { return productTable; }
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.HeatingControls)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 371")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 371")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.HeatingControlsTable productTable = new oM.Environment.SAP.HeatingControlsTable();
                productTable.Index = ProductIndex;
                productTable.ManufacturerReferenceNumber = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstYearOfManufacture = dividedStrings[8];
                productTable.FinalYearOfManufacture = dividedStrings[9];
                productTable.ControllerType = dividedStrings[10];
                productTable.HeatingSystemCategory = dividedStrings[11];
                productTable.Fuel = dividedStrings[12];
                productTable.HeatGeneratorControlRequirements = dividedStrings[13];
                productTable.EfficiencyAdjustmentForBoiler = dividedStrings[14];
                productTable.HoursHeatingOff = dividedStrings[15];
                productTable.DelayedStart = dividedStrings[16];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.HeatingControlRequirements) 
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 372")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 372")).FirstOrDefault(); 
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.HeatingControlRequirementsTable productTable = new oM.Environment.SAP.HeatingControlRequirementsTable();
                productTable.BitNumber = dividedStrings[0];
                productTable.Description = dividedStrings[1];
                productTable.DBEntryUpdated = dividedStrings[2];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.WarmAirSystem) 
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 381")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 381")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.WarmAirSystemTable productTable = new oM.Environment.SAP.WarmAirSystemTable();
                productTable.ProductNumber = dividedStrings[0];
                productTable.ManufacturerReferenceNumber = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstYearOfManufacture = dividedStrings[8];
                productTable.FinalYearOfManufacture = dividedStrings[9];
                productTable.Fuel = dividedStrings[10];
                productTable.MountingPosition = dividedStrings[11];
                productTable.HeatExchangerType = dividedStrings[12];
                productTable.Condensing = dividedStrings[13];
                productTable.FlueType = dividedStrings[14];
                productTable.FanAssistance = dividedStrings[15];
                productTable.FanPosition = dividedStrings[16];
                productTable.FlowDirection = dividedStrings[17];
                productTable.OutputPowerBottom = dividedStrings[18];
                productTable.OutputPowerTop = dividedStrings[19];
                productTable.EnergyEfficiencyClass = dividedStrings[20];
                productTable.IntegralWarmAirDistributionFan = dividedStrings[21];
                productTable.SpecificFanPower = dividedStrings[22];
                productTable.WaterPump = dividedStrings[23];
                productTable.PumpElectricity = dividedStrings[24];
                productTable.Ignition = dividedStrings[25];
                productTable.BurnerControl = dividedStrings[26];
                productTable.MaximumFiringRate = dividedStrings[27];
                productTable.MinimumFiringRate = dividedStrings[28];
                productTable.MeasuredEfficiencyAtFullLoad = dividedStrings[29];
                productTable.MeasuredEfficiencyatMinimumLoad = dividedStrings[30];
                productTable.SeasonalHeatingEfficiency = dividedStrings[31];
                productTable.ElectricalPowerFiring = dividedStrings[32];
                productTable.ElectricalPowerNotFiring = dividedStrings[33];
                productTable.HotWaterService = dividedStrings[34];
                if (dividedStrings.Count > 35)
                {
                    productTable.HotWaterServiceType = dividedStrings[35];
                    productTable.NotDefined = dividedStrings[36];
                    productTable.StoreVolume = dividedStrings[37];
                    productTable.StoreInsulationThickness = dividedStrings[38];
                    productTable.StoreLossFactor = dividedStrings[39];
                    productTable.WaterHeatingEfficiency = dividedStrings[40];
                    productTable.SeparateDHWTests = dividedStrings[41];
                    productTable.FuelEnergyForHWTest1 = dividedStrings[42];
                    productTable.ElectricalEnergyForHWTest1 = dividedStrings[43];
                    productTable.RejectedEnergyInHWTest1 = dividedStrings[44];
                    productTable.StorageLossFactor1 = dividedStrings[45];
                    productTable.FuelEnergyForHWTest2 = dividedStrings[46];
                    productTable.ElectricalEnergyForHWTest2 = dividedStrings[47];
                    productTable.RejectedEnergyInHWTest2 = dividedStrings[48];
                    productTable.StorageLossFactor2 = dividedStrings[49];
                    productTable.RejectedFactor3 = dividedStrings[50];
                }

                else
                { return productTable; }
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.StorageHeaters)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 391")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 391")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.StorageHeatersTable productTable = new oM.Environment.SAP.StorageHeatersTable();
                productTable.Index = dividedStrings[0];
                productTable.ManufacturerReferenceNumber = dividedStrings[1];
                productTable.Status = dividedStrings[2];
                productTable.DBEntryUpdated = dividedStrings[3];
                productTable.ManufacturerName = dividedStrings[4];
                productTable.BrandName = dividedStrings[5];
                productTable.ModelName = dividedStrings[6];
                productTable.ModelQualifier = dividedStrings[7];
                productTable.FirstYearOfManufacture = dividedStrings[8];
                productTable.FinalYearOfManufacture = dividedStrings[9];
                productTable.StorageCapacity = dividedStrings[10];
                productTable.OutputPower = dividedStrings[11];
                productTable.BoostOutput = dividedStrings[12];
                productTable.HeatRetention = dividedStrings[13];
                productTable.HighHeatRetention = dividedStrings[14];
                return productTable;
            }

            if (ProductType == BH.oM.Environment.SAP.ProductType.CommunityHeatNetworks)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 501")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 501")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }

                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    BH.Engine.Base.Compute.RecordError("ProductIndex does not exist in the specified ProductType. Please check your inputs.");
                    return null;
                }

                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.CommunityHeatNetworksTable productTable = new oM.Environment.SAP.CommunityHeatNetworksTable();
                productTable.Index = dividedStrings[0];
                productTable.Version = dividedStrings[1];
                productTable.DBEntryUpdated = dividedStrings[2];
                productTable.DescriptionOfNetwork = dividedStrings[3];
                productTable.ValidityEndDate = dividedStrings[4];
                productTable.HeatNetworkName = dividedStrings[5];
                productTable.PostcodePrimaryEnergyCentre = dividedStrings[6];
                productTable.Locality = dividedStrings[7];
                productTable.TownName = dividedStrings[8];
                productTable.AdministrativeArea = dividedStrings[9];
                productTable.DateInitialOperation = dividedStrings[10];
                productTable.TotalDwellingsIncluded = dividedStrings[11];
                productTable.NumberOfFlats = dividedStrings[12];
                productTable.NonDomesticFloorArea = dividedStrings[13];
                productTable.NumberOfExistingDwellings = dividedStrings[14];
                productTable.ServiceProvision = dividedStrings[15];
                productTable.ProvisionalOrActualData = dividedStrings[16];
                productTable.Year = dividedStrings[17];
                productTable.HeatMeteringOnSupplyToNetwork = dividedStrings[18];
                productTable.TotalMWhToNetwork = dividedStrings[19];
                productTable.TotalMWhToCustomers = dividedStrings[20];
                productTable.IndividualDwellingHeatMetering = dividedStrings[21];
                productTable.TotalMWhToDwellings = dividedStrings[22];
                productTable.DistributionRouteLength = dividedStrings[23];
                productTable.LinearLoss = dividedStrings[24];
                productTable.DistrubutionLossFactor = dividedStrings[25];
                productTable.PumpingElectricalEnergy = dividedStrings[26];
                productTable.PumpingElectricalEnergyPerDwelling = dividedStrings[27];
                productTable.CarbonDioxideIntensity = dividedStrings[28];
                productTable.PrimaryEnergyFactor = dividedStrings[29];
                productTable.NumberOfHeatSources = dividedStrings[30];
                productTable.HeatSourceTypeA = dividedStrings[31];
                productTable.CommunityFuelA = dividedStrings[32];
                productTable.FuelDescriptionA = dividedStrings[33];
                productTable.HeatEfficiencyA = dividedStrings[34];
                productTable.PowerEfficiencyA = dividedStrings[35];
                productTable.HeatFractionA = dividedStrings[36];
                productTable.CommunityFuelCO2EmissionFactorA = dividedStrings[37];
                productTable.CommunityFuelPrimaryEnergyFactorA = dividedStrings[38];
                return productTable;
            }

            else { return null; }
        }
    }
}
