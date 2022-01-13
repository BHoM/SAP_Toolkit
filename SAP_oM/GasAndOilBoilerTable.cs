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
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Details of the means by which the building is ventilated")]
    public class GasAndBoilerTable : BHoMObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;

        [Description("Reference to current name of manufacturer.")]
        public virtual string ManufacturerRefNo { get; set; } = null;

        [Description("Status of the data record, encoded as 0 = normal status for an actual product, 1 = illustrative(non - existent) product, 2 = under investigation, 3 = not valid, 4 = methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the boiler. If none the original manufacturer name will be inserted instead. If the same boiler model is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of boiler model, as it appears on the boiler casing or leaflet of owners’ instructions. For boilers that comply with EN 483 this should be “the trade name of the appliance” shown on the data plate, as specified in clause 8.1.2 of EN 483:1999. If the same boiler is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("Boiler identifier. It may be GC (formerly Gas Council) number for a gas boiler or OFTEC Registration number for an oil boiler, but if not available the manufacturer may choose another identifier marked on the boiler.")]
        public virtual string BoilerID { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstManufYear { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalManufYear { get; set; } = null;

        [Description("Fuel type, which is any one of the fuel codes for a gaseous or liquid fuel as specified in SAP Table 12 under sub-headings “gas” or “oil”. If the same boiler may use more than one type of fuel then separate entries for each appear in the database, except that a boiler listed for bulk LPG is also applicable to bottled LPG and LPG subject to special condition 18.")]
        public virtual string Fuel { get; set; } = null;

        [Description("")]
        public virtual string MountingPosition { get; set; } = null;

        [Description("")]
        public virtual string ExposureRating { get; set; } = null;

        [Description("")]
        public virtual string MainType { get; set; } = null;

        [Description("")]
        public virtual string SubsidiaryType { get; set; } = null;

        [Description("")]
        public virtual string SubsidiaryTypeTable { get; set; } = null;

        [Description("")]
        public virtual string SubsidiaryTypeIndex { get; set; } = null;

        [Description("")]
        public virtual string Condensing { get; set; } = null;

        [Description("")]
        public virtual string FlueType { get; set; } = null;

        [Description("")]
        public virtual string FanAssistance { get; set; } = null;

        [Description("")]
        public virtual string BoilerPowerBottom { get; set; } = null;

        [Description("")]
        public virtual string BoilerPowerTop { get; set; } = null;

        [Description("")]
        public virtual string EnergyEfficiencyClass { get; set; } = null;

        [Description("")]
        public virtual string AnnualSeasonalEfficiency { get; set; } = null;

        [Description("")]
        public virtual string SAPWinterSeasonalEfficiency { get; set; } = null;

        [Description("")]
        public virtual string SAPSummerSeasonalEfficiency { get; set; } = null;

        [Description("")]
        public virtual string HotWaterEfficiency1 { get; set; } = null;

        [Description("")]
        public virtual string HotWaterEfficiency2 { get; set; } = null;

        [Description("")]
        public virtual string SAP2005SeasonalEfficiency { get; set; } = null;

        [Description("")]
        public virtual string EfficiencyCategory { get; set; } = null;

        [Description("")]
        public virtual string TestGasForLPG { get; set; } = null;

        [Description("")]
        public virtual string TestCorrectionForLPG { get; set; } = null;

        [Description("")]
        public virtual string SAPEquationUsed { get; set; } = null;

        [Description("")]
        public virtual string Ignition { get; set; } = null;

        [Description("")]
        public virtual string BurnerControl { get; set; } = null;

        [Description("")]
        public virtual string ElectricalPowerFiring { get; set; } = null;

        [Description("")]
        public virtual string ElectricalPowerNotFiring { get; set; } = null;

        [Description("")]
        public virtual string StoreType { get; set; } = null;

        [Description("")]
        public virtual string StoreLossInTest { get; set; } = null;

        [Description("")]
        public virtual string SeperateStore { get; set; } = null;

        [Description("")]
        public virtual string StoreBoilerVolume { get; set; } = null;

        [Description("")]
        public virtual string StoreSolarVolume { get; set; } = null;

        [Description("")]
        public virtual string StoreInsulationThickness { get; set; } = null;

        [Description("")]
        public virtual string StoreInsulationType { get; set; } = null;

        [Description("")]
        public virtual string StoreTemperature { get; set; } = null;

        [Description("")]
        public virtual string StoreHeatLossRate { get; set; } = null;

        [Description("")]
        public virtual string SeperateDHWTests { get; set; } = null;

        [Description("")]
        public virtual string FuelEnergyForHWTest1 { get; set; } = null;

        [Description("")]
        public virtual string ElectricalEnergyForHWTest1 { get; set; } = null;

        [Description("")]
        public virtual string RejectedEnergyInHWTest1 { get; set; } = null;

        [Description("")]
        public virtual string StorageLossFactor { get; set; } = null;

        [Description("")]
        public virtual string FuelEnergyForHWTest2 { get; set; } = null;

        [Description("")]
        public virtual string ElectricalEnergyForHWTest2 { get; set; } = null;

        [Description("")]
        public virtual string RejectedEnergyInHWTest2 { get; set; } = null;

        [Description("")]
        public virtual string StorageLossFactor2 { get; set; } = null;

        [Description("")]
        public virtual string RejectedFactor3 { get; set; } = null;

        [Description("")]
        public virtual string KeepHotFacility { get; set; } = null;

        [Description("")]
        public virtual string KeepHotTimer { get; set; } = null;

        [Description("")]
        public virtual string KeepHotElectricHeater { get; set; } = null;

        [Description("")]
        public virtual string ControlCapabilities { get; set; } = null;

    }
}
