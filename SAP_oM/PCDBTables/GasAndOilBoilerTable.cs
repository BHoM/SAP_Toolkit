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
    [Description("Data format specification in database.")]
    public class GasAndBoilerTable : BHoMObject, IPCDBObject
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

        [Description("Boiler mounting position, which is one of “unknown”, “floor”, “wall”, “either floor or wall”, or “back boiler”. These are encoded as 0, 1, 2, 3 or 4.")]
        public virtual string MountingPosition { get; set; } = null;

        [Description("Exposure rating, which is one of “unknown”, “indoor only”, or “outdoor”. These are encoded as 0, 1 or 2.")]
        public virtual string ExposureRating { get; set; } = null;

        [Description("Main boiler type, for the purpose of SAP efficiency calculation. It is one of “regular” (see SAP 2012 Appendix D clause D1.3), “combi” (clause D1.6), or “CPSU” (clause D1.13). These are encoded as 1, 2 or 3. If not known it is encoded as 0.")]
        public virtual string MainType { get; set; } = null;

        [Description("Subsidiary type, for the purpose of indicating the presence of special features. It is one of “normal” or “with integral PFGHRD”, encoded as 0 or 1 respectively. See note 2 below table. Other values may be introduced later.")]
        public virtual string SubsidiaryType { get; set; } = null;

        [Description("The table number within the database holding data for boiler special features, if special features have been indicated in “Subsidiary type” and it is necessary to refer to additional data.Otherwise this field is blank.")]
        public virtual string SubsidiaryTypeTable { get; set; } = null;

        [Description("The product index number of an entry within the database table number that has been indicated by “Subsidiary type table”. If “Subsidiary type table” is blank then this field is blank.")]
        public virtual string SubsidiaryTypeIndex { get; set; } = null;

        [Description("Either “non-condensing” or “condensing” (see SAP 2012 Appendix D clause D1.2), encoded as 1 or 2. If not known it is encoded as 0.")]
        public virtual string Condensing { get; set; } = null;

        [Description("Flue type, which is one of “unknown”, “open”, “room-sealed”, or “open or room-sealed” encoded as 0, 1, 2 or 3.")]
        public virtual string FlueType { get; set; } = null;

        [Description("Whether or not flue is fan assisted. It is one of “unknown”, “no fan”, or “fan”. These are encoded as  0, 1 or 2.")]
        public virtual string FanAssistance { get; set; } = null;

        [Description("Output power (to water) of the boiler in kW. For range rated boilers it is the lower of the range of values for which the efficiency test results are valid. For other boilers this is the same as field 23.")]
        public virtual string BoilerPowerBottom { get; set; } = null;

        [Description("Output power (to water) of the boiler in kW. For BED-compliant boilers this is the rated output as required for the purpose of Council of the European Communities Directive 92/42/EEC. If the power was originally quoted in BTU/hr then it will have been converted using the factor 1 BTU/hr = 0.000293 kW. For range rated boilers this is the top of the range of values for which the efficiency test results are valid. Where the upper limit of  the range exceeds 70kW this is shown as “>70kW” instead of the exact value. (Not used at present but might be needed in connection with a future App.Q assessment.)")]
        public virtual string BoilerPowerTop { get; set; } = null;

        [Description("The energy efficiency class as defined for the proposed European energy label. Definition and format have not yet been decided. This field is being left blank until the European energy labelling scheme has been defined.")]
        public virtual string EnergyEfficiencyClass { get; set; } = null;

        [Description("Annual seasonal efficiency, expressed as a percentage and rounded to the nearest 0.1%. This will have been obtained by one of the methods defined for the efficiency category (see field 31 and Note 3.) In the case of efficiency categories 1 and 2 the annual seasonal efficiency will be the SEDBUK(2009) value")]
        public virtual string AnnualSeasonalEfficiency { get; set; } = null;

        [Description("Winter seasonal efficiency for use in SAP, expressed as a percentage and rounded to the nearest 0.1%. This will have been obtained by one of the methods defined for the efficiency category.")]
        public virtual string SAPWinterSeasonalEfficiency { get; set; } = null;

        [Description("Summer seasonal efficiency for use in SAP, expressed as a percentage and rounded to the nearest 0.1%. If separate DHW tests this will have been derived from those tests, otherwise it will have been obtained by one of the methods defined for the efficiency category")]
        public virtual string SAPSummerSeasonalEfficiency { get; set; } = null;

        [Description("Hot water efficiency for comparative purposes (not used by SAP). See Note 7 below table. If this field is blank the value is taken from field 29 instead.")]
        public virtual string HotWaterEfficiency1 { get; set; } = null;

        [Description("Hot water efficiency for comparative purposes (not used by SAP). See Note 7 below the table. This value is calculated by the database and is recorded in this field only if field 28 is blank.This field may also be blank.")]
        public virtual string HotWaterEfficiency2 { get; set; } = null;

        [Description("The annual seasonal efficiency used in SAP 2005, expressed as a percentage and rounded to the nearest 0.1%. This will have been obtained by one of the methods defined for the efficiency category (see field 31 and Note 3.) In the case of efficiency categories 1 and 2 the annual seasonal efficiency will be the SEDBUK(2005) value.")]
        public virtual string SAP2005SeasonalEfficiency { get; set; } = null;

        [Description("Category of annual seasonal efficiency, encoded as 0=unknown, 1=SEDBUK based on validated and certified data, 2=SEDBUK based on certified data, 3=estimated (for obsolete boilers only). See Note 3. For category 3 the SAP equation used(in field 34) is entered as 0.")]
        public virtual string EfficiencyCategory { get; set; } = null;

        [Description("This applies only to a LPG boiler with efficiency category 1 or 2. If the efficiency tests from which SEDBUK was calculated were carried out using LPG, this is 0. If the tests were carried out using natural gas and the modified calculation procedure, this is 1. If inapplicable, this is blank.")]
        public virtual string TestGasForLPG { get; set; } = null;

        [Description("This applies only to a LPG boiler tested with LPG. The test procedure allows for a correction to be applied. In some cases this is applied by the test laboratory before results are shown on the test certificate. If the correction was not applied to the results on the test certificate this field is 0; if the correction was applied it is 1.If inapplicable, this is blank.")]
        public virtual string TestCorrectionForLPG { get; set; } = null;

        [Description("The number of the SEDBUK equation used to calculate annual seasonal efficiency. Number 0 indicates that no SEDBUK calculation has been performed. Other numbers are as shown in SAP 2012 Appendix D Tables D2.5 and D2.6. The equation number corresponds to the boiler type and other properties (whether gas/oil, instantaneous/storage/CPSU, condensing/non-condensing, and on-off/modulating).")]
        public virtual string SAPEquationUsed { get; set; } = null;

        [Description("Whether or not has permanent pilot light, encoded as 0=unknown, 1=no, 2=yes.")]
        public virtual string Ignition { get; set; } = null;

        [Description("Whether on-off or variable, encoded as 0=unknown, 1=on-off, 2=variable (stepped or modulating).")]
        public virtual string BurnerControl { get; set; } = null;

        [Description("Average electrical power consumed while the boiler is firing, in watts. This includes fans, motors, heaters, and other electrical equipment but excludes any pump used to circulate water outside the boiler.If unknown or inapplicable, this field is blank.")]
        public virtual string ElectricalPowerFiring { get; set; } = null;

        [Description("Average electrical power consumed while the boiler is not firing, in watts. This includes fans, motors, heaters, and other electrical equipment but excludes any pump used to circulate water outside the boiler.If unknown or inapplicable, this field is blank.")]
        public virtual string ElectricalPowerNotFiring { get; set; } = null;

        [Description("For a storage combination boiler, this is 1 if the internal hot water store contains mainly primary water or 2 if it contains mainly secondary water.For a CPSU, it is 3.If unknown or inapplicable, it is 0.")]
        public virtual string StoreType { get; set; } = null;

        [Description("If heat loss from the internal hot water store has been excluded in the efficiency test values reported, this is 1. If included then this is 2. If unknown or inapplicable, it is blank.")]
        public virtual string StoreLossInTest { get; set; } = null;

        [Description("If the hot water store is within the boiler casing (an ‘internal hot water store’) then this is 0; otherwise it is 1. If unknown or inapplicable, this is blank.")]
        public virtual string SeperateStore { get; set; } = null;

        [Description("The water volume of the internal hot water store that is capable of being heated by the boiler, in litres. This is the total volume of the store less the store solar volume(field 43).May be a real number to 3 decimal places.If unknown or inapplicable, this is blank.")]
        public virtual string StoreBoilerVolume { get; set; } = null;

        [Description("If the internal hot water store includes a dedicated solar zone, the water volume of the dedicated solar zone in litres.May be a real number to 3 decimal places.If unknown or inapplicable, this is 0.0.")]
        public virtual string StoreSolarVolume { get; set; } = null;

        [Description("The thickness of the insulation applied to the internal hot water store in mm. If unknown or inapplicable, this is blank.")]
        public virtual string StoreInsulationThickness { get; set; } = null;

        [Description("The material used to insulate the internal hot water store. This is 1 for mineral wool (rock), 2 for polyurethane foam, or 3 for mineral wool (glass). For other insulants the following values signify that the thermal conductivity is: 4 closest to MW (rock), 5 closest to PU, 6 closest to MW(glass).If unknown or inapplicable, it is blank.")]
        public virtual string StoreInsulationType { get; set; } = null;

        [Description("The average temperature of the hot water in contact with the exterior walls of the internal hot water store in degrees Celsius. If unknown or inapplicable, this is blank.")]
        public virtual string StoreTemperature { get; set; } = null;

        [Description("The measured heat loss from the hot water store in watts. Not used at present (this figure may be used in a future SAP specification in place of calculations based on fields 43 - 44). If unknown or inapplicable, this is blank.")]
        public virtual string StoreHeatLossRate { get; set; } = null;

        [Description("Hot water tests carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26 (oil). Encoded as: 0 = none or not applicable; 1= one test, using schedule 2; 2 = two tests, using schedules 2 and 3; 3 = two tests, using schedules 2 and 1.")]
        public virtual string SeperateDHWTests { get; set; } = null;

        [Description("Fuel input energy (corrected) in kWh/day for domestic hot water test 1 carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26 (oil). Hot water test 1 means tested under draw-off schedule no. 2 as defined in the standard. If the boiler is not a combi, or if domestic hot water test 1 has not been carried out, this is blank.")]
        public virtual string FuelEnergyForHWTest1 { get; set; } = null;

        [Description("Electrical input energy (corrected) in kWh/day for domestic hot water test 1 carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26 (oil). Hot water test 1 means tested under draw-off schedule no. 2 as defined in the standard. If the boiler is not a combi, or if domestic hot water test 1 has not been carried out, this is blank.")]
        public virtual string ElectricalEnergyForHWTest1 { get; set; } = null;

        [Description("Proportion of energy, expressed as a decimal number in the range 0 to 1, rejected in domestic hot water test 1 carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26(oil).If the boiler is not a combi, or if domestic hot water test 1 has not been carried out, this is blank.")]
        public virtual string RejectedEnergyInHWTest1 { get; set; } = null;

        [Description("Loss factor F1  in kWh/day related to domestic hot water test 1 for use in conjunction with SAP 2012 Table 3b. If the boiler is not a combi, or if domestic hot water test 1 has not been carried out, this is blank.")]
        public virtual string StorageLossFactor { get; set; } = null;

        [Description("Fuel input energy (corrected) in kWh/day for domestic hot water test 2 carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26 (oil). If “Separate DHW tests” (field 48) is 2 then hot water test 2 means tested under draw-off schedule no. 3 as defined in the standard. If “Separate DHW tests” (field 48) is 3 then hot water test 2 means tested under draw - off schedule no. 1 as defined in the standard.If the boiler is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string FuelEnergyForHWTest2 { get; set; } = null;

        [Description("Electrical input energy (corrected) in kWh/day for domestic hot water test 2 carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26 (oil). If “Separate DHW tests” (field 48) is 2 then hot water test 2 means tested under draw-off schedule no. 3 as defined in the standard. If “Separate DHW tests” (field 48) is 3 then hot water test 2 means tested under draw-off schedule no. 1 as defined in the standard. If the boiler is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string ElectricalEnergyForHWTest2 { get; set; } = null;

        [Description("Proportion of energy, expressed as a decimal number in the range 0 to 1, rejected in domestic hot water test 2 carried out on a combi boiler in accordance with EN 13203-2 (gas) or OPS 26 (oil). If the boiler is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.This is not used in SAP assessments, only r1.")]
        public virtual string RejectedEnergyInHWTest2 { get; set; } = null;

        [Description("Loss factor F2  in kWh/day related to domestic hot water tests 1 and 2 for use in conjunction with SAP 2012 Table 3c. If the boiler is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string StorageLossFactor2 { get; set; } = null;

        [Description("Rejected factor F3  in litres-1 related to domestic hot water tests 1 and 2 for use in conjunction with SAP 2012 Table 3c (can be negative). If the boiler is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string RejectedFactor3 { get; set; } = null;

        [Description("The type of “keep-hot” facility, intended to keep the internal store hot while not in use. This is 0 if there is no “keep-hot” facility; 1 if there is a “keep-hot” facility fuelled by gas/oil only; 2 if there is a “keep-hot” facility powered by electricity; or 3 if there is a “keep-hot” facility both fuelled by gas/oil and powered by electricity. If inapplicable, this is blank.")]
        public virtual string KeepHotFacility { get; set; } = null;

        [Description("Where there is a “keep-hot” facility, this is 1 if there is a time-switch control which turns off the facility overnight.If there is no such control this is 0.If unknown or inapplicable, this is blank.")]
        public virtual string KeepHotTimer { get; set; } = null;

        [Description("The power rating of the electric heating element in the internal hot water store, in watts. This is 0 if no electric heating element is fitted. If unknown or inapplicable, this is blank.")]
        public virtual string KeepHotElectricHeater { get; set; } = null;

        [Description("Values that indicate features that are relevant for heating controls.")]
        public virtual string ControlCapabilities { get; set; } = null;
    }
}

