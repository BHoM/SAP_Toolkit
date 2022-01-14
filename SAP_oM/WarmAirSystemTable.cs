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
    public class WarmAirSystemTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string ProductNumber { get; set; } = null;

        [Description("Reference to current name of manufacturer.")]
        public virtual string ManufacturerReferenceNumber { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1 = illustrative(non - existent) product, 2 = under investigation, 3 = not valid, 4 = methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the warm air unit. If none the original manufacturer name will be inserted instead. If the same model is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model, as it appears on the unit casing or leaflet of owners’ instructions. If the same unit is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Fuel type, which is any one of the fuel codes for a gaseous or liquid fuel as specified in SAP Table 12 under sub-headings “gas” or “oil”. If the same unit may use more than one type of fuel then separate entries for each appear in the database, except that a unit listed for bulk LPG is also applicable to bottled LPG and LPG subject to special condition 18.")]
        public virtual string Fuel { get; set; } = null;

        [Description("Mounting position, which is one of “unknown”, “floor”, “wall” or “either floor or wall”,. These are encoded as 0, 1, 2, or 3 respectively.")]
        public virtual string MountingPosition { get; set; } = null;

        [Description("Whether heating is provided by a combustion products to warm air heat exchanger or by a secondary heat exchanger (water to warm air) encoded as 1 primary air to air, 2 secondary(water to air).")]
        public virtual string HeatExchangerType { get; set; } = null;

        [Description("Either “non-condensing” or “condensing”, encoded as 1 or 2.")]
        public virtual string Condensing { get; set; } = null;

        [Description("Flue type, which is one of “unknown”, “open”, “room-sealed”, or “open or room-sealed” encoded as 0, 1, 2 or 3.")]
        public virtual string FlueType { get; set; } = null;

        [Description("Whether or not flue is fan assisted. It is one of “unknown”, “no fan”, or “fan”. These are encoded as  0, 1 or 2.")]
        public virtual string FanAssistance { get; set; } = null;

        [Description("If fan flue assisted, position of combustion fan position upstream or downstream of heat exchanger encoded (0 no fan, 1 upstream and 2 downstream).  Will be 0 if field 16 is 1.")]
        public virtual string FanPosition { get; set; } = null;

        [Description("Flow direction within the unit, which is one of “unknown”, “upflow” or “downflow”, encoded as 0, 1 or 2 respectively.")]
        public virtual string FlowDirection { get; set; } = null;

        [Description("Output power of the unit in kW. For range rated units it is the lower of the range of values for which the efficiency test results are valid. For other units this is the same as field 20.")]
        public virtual string OutputPowerBottom { get; set; } = null;

        [Description("Output power of the unit in kW. For range rated units this is the top of the range of values for which the efficiency test results are valid. Where the upper limit of the range exceeds 70kW this is shown as “>70kW” instead of the exact value.")]
        public virtual string OutputPowerTop { get; set; } = null;

        [Description("The energy efficiency class as defined for the proposed European energy label. Definition and format have not yet been decided. This field is being left blank until the European energy labelling scheme has been defined.")]
        public virtual string EnergyEfficiencyClass { get; set; } = null;

        [Description("Whether system contains a warm air distribution fan, encoded 1 = no, 2= yes")]
        public virtual string IntegralWarmAirDistributionFan { get; set; } = null;

        [Description("Specific fan power in W/(l/s), inclusive of in-use factor. Blank if field 22 is 1.")]
        public virtual string SpecificFanPower { get; set; } = null;

        [Description("Whether system requires a water pump, encoded 1=no, 2=yes.  This will be usually no for heat exchanger type 1 and yes for heat exchanger type 2.")]
        public virtual string WaterPump { get; set; } = null;

        [Description("Annual electricity used by water pump. Blank if not applicable.")]
        public virtual string PumpElectricity { get; set; } = null;

        [Description("Whether or not has permanent pilot light, encoded as 0=unknown, 1=no, 2=yes.")]
        public virtual string Ignition { get; set; } = null;

        [Description("Whether on-off or variable, encoded as 0=unknown, 1=on-off, 2=variable (stepped or modulating).")]
        public virtual string BurnerControl { get; set; } = null;

        [Description("Heat output at maximum firing rate in during efficiency measurements in kW")]
        public virtual string MaximumFiringRate { get; set; } = null;

        [Description("Heat output at minimum firing rate, if any, during efficiency measurements in kW.  For on-off burner control this is blank.")]
        public virtual string MinimumFiringRate { get; set; } = null;

        [Description("Measured heating efficiency at full load (% gross)")]
        public virtual string MeasuredEfficiencyAtFullLoad { get; set; } = null;

        [Description("Measured heating efficiency at part load, if any (% gross). This is blank for on-off burner control.")]
        public virtual string MeasuredEfficiencyatMinimumLoad { get; set; } = null;

        [Description("Heating seasonal efficiency based on the gross calorific value, expressed as a percentage and rounded to the nearest 0.1%, derived from laboratory measurements above.")]
        public virtual string SeasonalHeatingEfficiency { get; set; } = null;

        [Description("Average electrical power consumed while the unit is firing, in watts. This includes fans, motors, heaters, and other electrical equipment but excludes any fan used to distribute warm air outside the unit. If unknown or inapplicable, this field is blank.")]
        public virtual string ElectricalPowerFiring { get; set; } = null;

        [Description("Average electrical power consumed while the unit is not firing, in watts. This includes fans, motors, heaters, and other electrical equipment but excludes any fan used to distribute warm air outside the unit. If unknown or inapplicable, this field is blank.")]
        public virtual string ElectricalPowerNotFiring { get; set; } = null;

        [Description("Whether the unit provides domestic hot water, encoded as 0=no, 1=yes.")]
        public virtual string HotWaterService { get; set; } = null;

        [Description("Hot water service type regular or instant combi or storage combi encoded as 1=regular, 2=instant combi, 3=storage combi")]
        public virtual string HotWaterServiceType { get; set; } = null;

        [Description("This field is undefined at present and is blank")]
        public virtual string NotDefined { get; set; } = null;

        [Description("The water volume of the internal hot water store that is capable of being heated by the warm air unit, in litres. If unknown or inapplicable, this is blank.")]
        public virtual string StoreVolume { get; set; } = null;

        [Description("The thickness of the insulation applied to the internal hot water store in mm. If not a storage combi, it is blank.")]
        public virtual string StoreInsulationThickness { get; set; } = null;

        [Description("Store loss factor in kWh/day. If not a storage combi, it is blank")]
        public virtual string StoreLossFactor { get; set; } = null;

        [Description("Water heating efficiency based on the gross calorific value (%) derived from the data below or from obtained by methods deemed to satisfy European Council Directive 92 / 42 / EEC")]
        public virtual string WaterHeatingEfficiency { get; set; } = null;

        [Description("Hot water tests carried out on a combi type in accordance with EN 13203-2 (gas) or OPS 26 (oil). Encoded as: 0 = not applicable; 1= one test, using schedule 2; 2 = two tests, using schedules 2 and 3; 3 = two tests, using schedules 2 and 1. This must not be 0 or blank for hot water service type instant combi or storage combi.")]
        public virtual string SeparateDHWTests { get; set; } = null;

        [Description("Fuel input energy (corrected) in kWh/day for domestic hot water test 1 carried out on a combi type in accordance with EN 13203-2 (gas) or OPS 26 (oil), based on gross calorific value. Hot water test 1 means tested under draw-off schedule no. 2 as defined in the standard. If the unit is not a combi, this is blank.")]
        public virtual string FuelEnergyForHWTest1 { get; set; } = null;

        [Description("Electrical input energy (corrected) in kWh/day for domestic hot water test 1 carried out on a combi in accordance with EN 13203-2 (gas) or OPS 26 (oil). Hot water test 1 means tested under draw-off schedule no. 2 as defined in the standard. If the unit is not a combi this is blank.")]
        public virtual string ElectricalEnergyForHWTest1 { get; set; } = null;

        [Description("Proportion of energy, expressed as a decimal number in the range 0 to 1, rejected in domestic hot water test 1 carried out on a combi in accordance with EN 13203-2 (gas) or OPS 26 (oil). If the unit is not a combi this is blank.")]
        public virtual string RejectedEnergyInHWTest1 { get; set; } = null;

        [Description("Loss factor F1  in kWh/day related to domestic hot water test 1 for use in conjunction with SAP 2012 Table 3b. If not a combi this is blank.")]
        public virtual string StorageLossFactor1 { get; set; } = null;

        [Description("Fuel input energy (corrected) in kWh/day for domestic hot water test 2 carried out on a combi appliance in accordance with EN 13203-2 (gas) or OPS 26 (oil), based on gross calorific value. If “Separate DHW tests” (field 37) is 2 then hot water test 2 means tested under draw-off schedule no. 3 as defined in the standard. If “Separate DHW tests” (field 37) is 3 then hot water test 2 means tested under draw-off schedule no. 1 as defined in the standard.If the appliance is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string FuelEnergyForHWTest2 { get; set; } = null;

        [Description("Electrical input energy (corrected) in kWh/day for domestic hot water test 2 carried out on a combi appliance in accordance with EN 13203-2 (gas) or OPS 26 (oil). If “Separate DHW tests” (field 37) is 2 then hot water test 2 means tested under draw-off schedule no. 3 as defined in the standard. If “Separate DHW tests” (field 37) is 3 then hot water test 2 means tested under draw-off schedule no. 1 as defined in the standard. If the appliance is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string ElectricalEnergyForHWTest2 { get; set; } = null;

        [Description("Proportion of energy, expressed as a decimal number in the range 0 to 1, rejected in domestic hot water test 2 carried out on a combi appliance in accordance with EN 13203-2 (gas) or OPS 26 (oil). If the appliance is not a combi, or if domestic hot water test 2 has not been carried out, this is blank. This is not used in SAP assessments, only r1.")]
        public virtual string RejectedEnergyInHWTest2 { get; set; } = null;

        [Description("Loss factor F2  in kWh/day related to domestic hot water tests 1 and 2 for use in conjunction with SAP 2012 Table 3c. If the appliance is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string StorageLossFactor2 { get; set; } = null;

        [Description("Rejected factor F3  in litres-1 related to domestic hot water tests 1 and 2 for use in conjunction with SAP 2012 Table 3c (can be negative). If the unit is not a combi, or if domestic hot water test 2 has not been carried out, this is blank.")]
        public virtual string RejectedFactor3 { get; set; } = null;
    }
}