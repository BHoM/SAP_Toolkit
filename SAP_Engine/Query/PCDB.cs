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
        public static BH.oM.Environment.SAP.IPCDBObject FromPCDB(this BH.oM.Environment.SAP.ProductType ProductType, string ProductIndex = null, bool run = false)
        {
            if (!run)
                return null;

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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MEVcAndMVHRTable sapTable = new oM.Environment.SAP.MEVcAndMVHRTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerRefNo = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstManufYear = dividedStrings[8];
                sapTable.FinalManufYear = dividedStrings[9];
                sapTable.MainType = dividedStrings[10];
                sapTable.IntegralOnly = dividedStrings[11];
                sapTable.DuctType = dividedStrings[12];
                sapTable.DuctSize = dividedStrings[13];
                sapTable.SummerByPass = dividedStrings[14];
                sapTable.NumExhaustTerminalConfig = dividedStrings[15];
                sapTable.TestFlowRatesBasis = dividedStrings[16];
                sapTable.AddidtionalWetRooms = dividedStrings[17];
                sapTable.TestFlowRate = dividedStrings[18];
                sapTable.FanSpeedSetting = dividedStrings[19];
                sapTable.ApplicableFlowRate = dividedStrings[20];
                sapTable.SpecificFanPower = dividedStrings[21];
                sapTable.HeatExchangerEfficiency = dividedStrings[22];

                return sapTable;
            }
            if (ProductType == BH.oM.Environment.SAP.ProductType.GasAndOilBoiler)
            {
                string firstLine = contentSplit.Where(x => x.StartsWith("# Table 105")).FirstOrDefault();
                string lastLine = contentSplit.Where(x => x.StartsWith("# ... end of Table 105")).FirstOrDefault();
                List<string> allLinesForTable = new List<string>();
                for (int x = Array.IndexOf(contentSplit, firstLine); x < Array.IndexOf(contentSplit, lastLine); x++)
                {
                    allLinesForTable.Add(contentSplit[x]);
                }
                string lineIsStartingWith = allLinesForTable.Where(x => x.StartsWith(ProductIndex)).FirstOrDefault();
                if (lineIsStartingWith == null)
                {
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.GasAndBoilerTable sapTable = new oM.Environment.SAP.GasAndBoilerTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerRefNo = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.BoilerID = dividedStrings[8];
                sapTable.FirstManufYear = dividedStrings[9];
                sapTable.FinalManufYear = dividedStrings[10];
                sapTable.Fuel = dividedStrings[11];
                sapTable.MountingPosition = dividedStrings[12];
                sapTable.ExposureRating = dividedStrings[13];
                sapTable.MainType = dividedStrings[14];
                sapTable.SubsidiaryType = dividedStrings[15];
                sapTable.SubsidiaryTypeTable = dividedStrings[16];
                sapTable.SubsidiaryTypeIndex = dividedStrings[17];
                sapTable.Condensing = dividedStrings[18];
                sapTable.FlueType = dividedStrings[19];
                sapTable.FanAssistance = dividedStrings[20];
                sapTable.BoilerPowerBottom = dividedStrings[21];
                sapTable.BoilerPowerTop = dividedStrings[22];
                sapTable.EnergyEfficiencyClass = dividedStrings[23];
                sapTable.AnnualSeasonalEfficiency = dividedStrings[24];
                sapTable.SAPWinterSeasonalEfficiency = dividedStrings[25];
                sapTable.SAPSummerSeasonalEfficiency = dividedStrings[26];
                sapTable.HotWaterEfficiency1 = dividedStrings[27];
                sapTable.HotWaterEfficiency2 = dividedStrings[28];
                sapTable.SAP2005SeasonalEfficiency = dividedStrings[29];
                sapTable.EfficiencyCategory = dividedStrings[30];
                sapTable.TestGasForLPG = dividedStrings[31];
                sapTable.TestCorrectionForLPG = dividedStrings[32];
                sapTable.SAPEquationUsed = dividedStrings[33];
                sapTable.Ignition = dividedStrings[34];
                sapTable.BurnerControl = dividedStrings[35];
                sapTable.ElectricalPowerFiring = dividedStrings[36];
                sapTable.ElectricalPowerNotFiring = dividedStrings[37];
                sapTable.StoreType = dividedStrings[38];
                sapTable.StoreLossInTest = dividedStrings[39];
                sapTable.SeperateStore = dividedStrings[40];
                sapTable.StoreBoilerVolume = dividedStrings[41];
                sapTable.StoreSolarVolume = dividedStrings[42];
                sapTable.StoreInsulationThickness = dividedStrings[43];
                sapTable.StoreInsulationType = dividedStrings[44];
                sapTable.StoreTemperature = dividedStrings[45];
                sapTable.StoreHeatLossRate = dividedStrings[46];
                sapTable.SeperateDHWTests = dividedStrings[47];
                sapTable.FuelEnergyForHWTest1 = dividedStrings[48];
                sapTable.ElectricalEnergyForHWTest1 = dividedStrings[49];
                sapTable.RejectedEnergyInHWTest1 = dividedStrings[50];
                sapTable.StorageLossFactor = dividedStrings[51];
                sapTable.FuelEnergyForHWTest2 = dividedStrings[52];
                sapTable.ElectricalEnergyForHWTest2 = dividedStrings[53];
                sapTable.RejectedEnergyInHWTest2 = dividedStrings[54];
                sapTable.StorageLossFactor2 = dividedStrings[55];
                sapTable.RejectedFactor3 = dividedStrings[56];
                sapTable.KeepHotFacility = dividedStrings[57];
                sapTable.KeepHotTimer = dividedStrings[58];
                sapTable.KeepHotElectricHeater = dividedStrings[59];
                sapTable.ControlCapabilities = dividedStrings[60];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.FlueGasHeatRecoverySystemTable sapTable = new oM.Environment.SAP.FlueGasHeatRecoverySystemTable();
                 sapTable.Index = ProductIndex;
                 sapTable.ManufacturerReferenceNumber = dividedStrings[1];
                 sapTable.Status = dividedStrings[2];
                 sapTable.DBEntryUpdated = dividedStrings[3];
                 sapTable.ManufacturerName = dividedStrings[4];
                 sapTable.BrandName = dividedStrings[5];
                 sapTable.ModelName = dividedStrings[6];
                 sapTable.ModelQualifier = dividedStrings[7];
                 sapTable.FirstYearOfManufacture = dividedStrings[8];
                 sapTable.FinalYearOfManufacture = dividedStrings[9];
                 sapTable.ApplicableFuel = dividedStrings[10];
                 sapTable.TestFuel = dividedStrings[11];
                 sapTable.ApplicableBoilerTypes = dividedStrings[12];
                 sapTable.IntegralOnly = dividedStrings[13];
                 sapTable.HeatStore = dividedStrings[14];
                 sapTable.HeatStoreTotalVolume = dividedStrings[15];
                 sapTable.HeatStoreRecapturedVolume = dividedStrings[16];
                 sapTable.HeatStoreLossRaste = dividedStrings[17];
                 sapTable.DirectTotalHeatReacovered = dividedStrings[18];
                 sapTable.DirectUsefulHeatRecovered = dividedStrings[19];
                 sapTable.PowerConsumption = dividedStrings[20];
                 sapTable.PhotovoltaicModule = dividedStrings[21];
                 sapTable.CableLoss = dividedStrings[22];
                 sapTable.NumberOfEquations = dividedStrings[23];
                 sapTable.SpaceHeatingRequirementFromBoilerSystem = dividedStrings[24];
                 sapTable.CoefficientA = dividedStrings[25];
                 sapTable.CoefficientB = dividedStrings[26];
                 sapTable.CoefficientC = dividedStrings[27];
                 sapTable.CoefficientA2 = dividedStrings[28];
                 sapTable.CoefficientB2 = dividedStrings[29];
                 sapTable.CoefficientC2 = dividedStrings[30];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.DecentralisedMEVTable sapTable = new oM.Environment.SAP.DecentralisedMEVTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerReferenceNo = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstYearOfManufacture = dividedStrings[8];
                sapTable.FinalYearOfManufacture = dividedStrings[9];
                sapTable.MainType = dividedStrings[10];
                sapTable.FlexibleOrRigidDucting = dividedStrings[11];
                sapTable.NumberConfigurations = dividedStrings[12];
                sapTable.ConfigurationA = dividedStrings[13];
                sapTable.TestFlowRateA = dividedStrings[14];
                sapTable.FanSpeedSettingA = dividedStrings[15];
                sapTable.SpecificFanPowerA = dividedStrings[16];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MVInUseFactorsTable sapTable = new oM.Environment.SAP.MVInUseFactorsTable();
                sapTable.SystemType = dividedStrings[0];
                sapTable.SFPAdjustment1FlexibleDuction = dividedStrings[1];
                sapTable.SFPAdjustment1RigidDucting = dividedStrings[2];
                sapTable.SFPAdjustment1NoDucting = dividedStrings[3];
                sapTable.MVHREfficiencyAdjustment1UninsulatedDucting = dividedStrings[4];
                sapTable.MVHREfficiencyAdjustment1InsulatedDucting = dividedStrings[5];
                sapTable.SFPAdjustment2FlexibleDuction = dividedStrings[6];
                sapTable.SFPAdjustment2RigidDucting = dividedStrings[7];
                sapTable.SFPAdjustment2NoDucting = dividedStrings[8];
                sapTable.MVHREfficiencyAdjustment2UninsulatedDucting = dividedStrings[9];
                sapTable.MVHREfficiencyAdjustment2InsulatedDucting = dividedStrings[10];
                sapTable.DBEntryUpdated = dividedStrings[11];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.MVHRDuctTable sapTable = new oM.Environment.SAP.MVHRDuctTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerReference = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstYearOfManufacture = dividedStrings[8];
                sapTable.FinalYearOfManufacture = dividedStrings[9];
                sapTable.DuctType = dividedStrings[10];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.WasteWaterHeatRecoverySystemTable sapTable = new oM.Environment.SAP.WasteWaterHeatRecoverySystemTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerRefNo = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstYearOfManufacture = dividedStrings[8];
                sapTable.FinalYearOfManufacture = dividedStrings[9];
                sapTable.InstantaneousOrStorage = dividedStrings[10];
                sapTable.SystemType = dividedStrings[11];
                sapTable.StorageType = dividedStrings[12];
                sapTable.Efficiency = dividedStrings[13];
                sapTable.UtilisationFactor = dividedStrings[14];
                sapTable.WasteWaterFraction = dividedStrings[15];
                sapTable.TestDedicatedVolume = dividedStrings[16];
                sapTable.LowDedicatedVolume = dividedStrings[17];
                sapTable.HighDedicatedVolume = dividedStrings[18];
                sapTable.ElectricityConsumption = dividedStrings[19];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.HeatPumpTable sapTable = new oM.Environment.SAP.HeatPumpTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerReferenceNumber = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.APMVersionNumber = dividedStrings[4];
                sapTable.ManufacturerName = dividedStrings[5];
                sapTable.BrandName = dividedStrings[6];
                sapTable.ModelName = dividedStrings[7];
                sapTable.ModelQualifier = dividedStrings[8];
                sapTable.FirstYearOfManufacture = dividedStrings[9];
                sapTable.FinalYearOfManufacture = dividedStrings[10];
                sapTable.DataQuality = dividedStrings[11];
                sapTable.Fuel = dividedStrings[12];
                sapTable.HeatDistrubutionType = dividedStrings[13];
                sapTable.FlueType = dividedStrings[14];
                sapTable.HeatSource = dividedStrings[15];
                sapTable.ServiceProvision = dividedStrings[16];
                sapTable.HWVessel = dividedStrings[17];
                sapTable.VesselVolume = dividedStrings[18];
                sapTable.VesselHeatLoss = dividedStrings[19];
                sapTable.VesselHeatExchangerArea = dividedStrings[20];
                sapTable.EnergyEfficiencyClass = dividedStrings[21];
                sapTable.WaterHeatingEfficiency = dividedStrings[22];
                sapTable.NetSpecificElectricityConsumed = dividedStrings[23];
                sapTable.WaterHeatingEfficiency2 = dividedStrings[24];
                sapTable.NetSoecificElectricityConumed2 = dividedStrings[25];
                sapTable.ControlCapabilities = dividedStrings[26];
                if (dividedStrings.Count > 27)
                {
                    sapTable.Reversible = dividedStrings[27];
                    sapTable.EER = dividedStrings[28];
                    sapTable.MaximumOutput = dividedStrings[29];
                    sapTable.HeatingDuration = dividedStrings[30];
                    sapTable.MEVorMVHRProductIndex = dividedStrings[31];
                    sapTable.CompensatorEffect = dividedStrings[32];
                    sapTable.SeperateCirculator = dividedStrings[33];
                    sapTable.NumberOfAirFlowRates = dividedStrings[34];
                    sapTable.AirFlowRate1 = dividedStrings[35];
                    sapTable.AirFLowRate2 = dividedStrings[36];
                    sapTable.AirflowRate3 = dividedStrings[37];
                    sapTable.NumberOfPlantSizeRatios = dividedStrings[38];
                    sapTable.PlantSizeRatioA = dividedStrings[39];
                    sapTable.SpaceHeatingEfficiencyA = dividedStrings[40];
                    sapTable.SpecificElectricityConsumedA = dividedStrings[41];
                    sapTable.RunningHoursA = dividedStrings[42];
                }
                else
                { return sapTable; }

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.HeatingControlsTable sapTable = new oM.Environment.SAP.HeatingControlsTable();
                sapTable.Index = ProductIndex;
                sapTable.ManufacturerReferenceNumber = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstYearOfManufacture = dividedStrings[8];
                sapTable.FinalYearOfManufacture = dividedStrings[9];
                sapTable.ControllerType = dividedStrings[10];
                sapTable.HeatingSystemCategory = dividedStrings[11];
                sapTable.Fuel = dividedStrings[12];
                sapTable.HeatGeneratorControlRequirements = dividedStrings[13];
                sapTable.EfficiencyAdjustmentForBoiler = dividedStrings[14];
                sapTable.HoursHeatingOff = dividedStrings[15];
                sapTable.DelayedStart = dividedStrings[16];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.HeatingControlRequirementsTable sapTable = new oM.Environment.SAP.HeatingControlRequirementsTable();
                sapTable.BitNumber = dividedStrings[0];
                sapTable.Description = dividedStrings[1];
                sapTable.DBEntryUpdated = dividedStrings[2];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.WarmAirSystemTable sapTable = new oM.Environment.SAP.WarmAirSystemTable();
                sapTable.ProductNumber = dividedStrings[0];
                sapTable.ManufacturerReferenceNumber = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstYearOfManufacture = dividedStrings[8];
                sapTable.FinalYearOfManufacture = dividedStrings[9];
                sapTable.Fuel = dividedStrings[10];
                sapTable.MountingPosition = dividedStrings[11];
                sapTable.HeatExchangerType = dividedStrings[12];
                sapTable.Condensing = dividedStrings[13];
                sapTable.FlueType = dividedStrings[14];
                sapTable.FanAssistance = dividedStrings[15];
                sapTable.FanPosition = dividedStrings[16];
                sapTable.FlowDirection = dividedStrings[17];
                sapTable.OutputPowerBottom = dividedStrings[18];
                sapTable.OutputPowerTop = dividedStrings[19];
                sapTable.EnergyEfficiencyClass = dividedStrings[20];
                sapTable.IntegralWarmAirDistributionFan = dividedStrings[21];
                sapTable.SpecificFanPower = dividedStrings[22];
                sapTable.WaterPump = dividedStrings[23];
                sapTable.PumpElectricity = dividedStrings[24];
                sapTable.Ignition = dividedStrings[25];
                sapTable.BurnerControl = dividedStrings[26];
                sapTable.MaximumFiringRate = dividedStrings[27];
                sapTable.MinimumFiringRate = dividedStrings[28];
                sapTable.MeasuredEfficiencyAtFullLoad = dividedStrings[29];
                sapTable.MeasuredEfficiencyatMinimumLoad = dividedStrings[30];
                sapTable.SeasonalHeatingEfficiency = dividedStrings[31];
                sapTable.ElectricalPowerFiring = dividedStrings[32];
                sapTable.ElectricalPowerNotFiring = dividedStrings[33];
                sapTable.HotWaterService = dividedStrings[34];
                if (dividedStrings.Count > 35)
                {
                    sapTable.HotWaterServiceType = dividedStrings[35];
                    sapTable.NotDefined = dividedStrings[36];
                    sapTable.StoreVolume = dividedStrings[37];
                    sapTable.StoreInsulationThickness = dividedStrings[38];
                    sapTable.StoreLossFactor = dividedStrings[39];
                    sapTable.WaterHeatingEfficiency = dividedStrings[40];
                    sapTable.SeparateDHWTests = dividedStrings[41];
                    sapTable.FuelEnergyForHWTest1 = dividedStrings[42];
                    sapTable.ElectricalEnergyForHWTest1 = dividedStrings[43];
                    sapTable.RejectedEnergyInHWTest1 = dividedStrings[44];
                    sapTable.StorageLossFactor1 = dividedStrings[45];
                    sapTable.FuelEnergyForHWTest2 = dividedStrings[46];
                    sapTable.ElectricalEnergyForHWTest2 = dividedStrings[47];
                    sapTable.RejectedEnergyInHWTest2 = dividedStrings[48];
                    sapTable.StorageLossFactor2 = dividedStrings[49];
                    sapTable.RejectedFactor3 = dividedStrings[50];
                }
                else
                { return sapTable; }
                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.StorageHeatersTable sapTable = new oM.Environment.SAP.StorageHeatersTable();
                sapTable.Index = dividedStrings[0];
                sapTable.ManufacturerReferenceNumber = dividedStrings[1];
                sapTable.Status = dividedStrings[2];
                sapTable.DBEntryUpdated = dividedStrings[3];
                sapTable.ManufacturerName = dividedStrings[4];
                sapTable.BrandName = dividedStrings[5];
                sapTable.ModelName = dividedStrings[6];
                sapTable.ModelQualifier = dividedStrings[7];
                sapTable.FirstYearOfManufacture = dividedStrings[8];
                sapTable.FinalYearOfManufacture = dividedStrings[9];
                sapTable.StorageCapacity = dividedStrings[10];
                sapTable.OutputPower = dividedStrings[11];
                sapTable.BoostOutput = dividedStrings[12];
                sapTable.HeatRetention = dividedStrings[13];
                sapTable.HighHeatRetention = dividedStrings[14];

                return sapTable;
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
                    return null;
                }
                List<string> dividedStrings = lineIsStartingWith.Split(',').ToList();
                BH.oM.Environment.SAP.CommunityHeatNetworksTable sapTable = new oM.Environment.SAP.CommunityHeatNetworksTable();
                sapTable.Index = dividedStrings[0];
                sapTable.Version = dividedStrings[1];
                sapTable.DBEntryUpdated = dividedStrings[2];
                sapTable.DescriptionOfNetwork = dividedStrings[3];
                sapTable.ValidityEndDate = dividedStrings[4];
                sapTable.HeatNetworkName = dividedStrings[5];
                sapTable.PostcodePrimaryEnergyCentre = dividedStrings[6];
                sapTable.Locality = dividedStrings[7];
                sapTable.TownName = dividedStrings[8];
                sapTable.AdministrativeArea = dividedStrings[9];
                sapTable.DateInitialOperation = dividedStrings[10];
                sapTable.TotalDwellingsIncluded = dividedStrings[11];
                sapTable.NumberOfFlats = dividedStrings[12];
                sapTable.NonDomesticFloorArea = dividedStrings[13];
                sapTable.NumberOfExistingDwellings = dividedStrings[14];
                sapTable.ServiceProvision = dividedStrings[15];
                sapTable.ProvisionalOrActualData = dividedStrings[16];
                sapTable.Year = dividedStrings[17];
                sapTable.HeatMeteringOnSupplyToNetwork = dividedStrings[18];
                sapTable.TotalMWhToNetwork = dividedStrings[19];
                sapTable.TotalMWhToCustomers = dividedStrings[20];
                sapTable.IndividualDwellingHeatMetering = dividedStrings[21];
                sapTable.TotalMWhToDwellings = dividedStrings[22];
                sapTable.DistributionRouteLength = dividedStrings[23];
                sapTable.LinearLoss = dividedStrings[24];
                sapTable.DistrubutionLossFactor = dividedStrings[25];
                sapTable.PumpingElectricalEnergy = dividedStrings[26];
                sapTable.PumpingElectricalEnergyPerDwelling = dividedStrings[27];
                sapTable.CarbonDioxideIntensity = dividedStrings[28];
                sapTable.PrimaryEnergyFactor = dividedStrings[29];
                sapTable.NumberOfHeatSources = dividedStrings[30];
                sapTable.HeatSourceTypeA = dividedStrings[31];
                sapTable.CommunityFuelA = dividedStrings[32];
                sapTable.FuelDescriptionA = dividedStrings[33];
                sapTable.HeatEfficiencyA = dividedStrings[34];
                sapTable.PowerEfficiencyA = dividedStrings[35];
                sapTable.HeatFractionA = dividedStrings[36];
                sapTable.CommunityFuelCO2EmissionFactorA = dividedStrings[37];
                sapTable.CommunityFuelPrimaryEnergyFactorA = dividedStrings[38]; //add for more groups

                return sapTable;
            }
            else { return null; }

        }
    }

}