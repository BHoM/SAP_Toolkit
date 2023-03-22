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
    public class HeatPumpTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;

        [Description("Reference to current name of manufacturer.")]
        public virtual string ManufacturerReferenceNumber { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1=illustrative (non-existent) product, 2=under investigation, 3=not valid, 4=methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("Version number of the Annual Performance Method used to generate the data record from test data.")]
        public virtual string APMVersionNumber { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the heat pump package. If none the original manufacturer name will be inserted instead. If the same heat pump package is sold under more than one brand  name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of heat pump model, as it appears on the heat pump unit casing or leaflet of owners’ instructions. If the same heat pump package is sold under more than one model name then separate entries for each should appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Data quality encoded as: 1 UKAS or equivalent, 2 MCS accredited on or after 1 Nov  2009; 3 MCS accredited before 1 Nov 2009.")]
        public virtual string DataQuality { get; set; } = null;

        [Description("Fuel type, which is 39 for electricity or any one of the fuel codes specified in SAP Table 12 under sub-headings “gas” or “oil”. If the heat pump package can use than one type of fuel then separate entries for each appear in the database, except that a heat pump listed for bulk LPG is also applicable to bottled LPG and LPG subject to special condition 18.")]
        public virtual string Fuel { get; set; } = null;

        [Description("Space heat distribution, encoded as: 1 wet system, flow temperature 55°C; 2 wet system, flow temperature 45°C; 3 wet system, flow temperature 35°C; 4 warm air system. Blank if not applicable(service provision code 4).If the heat pump package has been tested for more than one heat distribution type then separate entries for each appear in the database.")]
        public virtual string HeatDistrubutionType { get; set; } = null;

        [Description("Flue type, which is one of “unknown”, “open”, “room-sealed”,  “open or room-sealed”, “none” encoded as 0, 1, 2, 3 or 4.  For electric heat pumps it is 4.")]
        public virtual string FlueType { get; set; } = null;

        [Description("Heat source encoded as: 1 ground, 3 air, 4 exhaust air MEV, 5 exhaust air MVHR,  6 mixed exhaust air MEV and outside air, 7 ground water, 8 surface water, 9 solar assisted.")]
        public virtual string HeatSource { get; set; } = null;

        [Description("Service provision, encoded as: 0 unknown; 1 space and water heating all year, 2 space and water heating during heating season only; 3 space heating only; 4 water heating only.")]
        public virtual string ServiceProvision { get; set; } = null;

        [Description("Hot water storage vessel, encoded as: 1 integral; 2 separate and specified vessel (in fields 19, 20, 21); 3 separate but unspecified vessel; 4 none (service provision code 3).")]
        public virtual string HWVessel { get; set; } = null;

        [Description("Hot water storage vessel volume. In the case of HW vessel code 2 this is the minimum volume of the separate vessel to which the performance data relates (a reduced water heating efficiency applies in the SAP calculation if the actual vessel is smaller). Blank for HW vessel code 3 or 4.")]
        public virtual string VesselVolume { get; set; } = null;

        [Description("Declared vessel heat loss rate at 45K rise above ambient. In the case of HW vessel code 2 this is the maximum heat loss rate of the separate vessel to which the performance data relates(a reduced water heating efficiency applies in the SAP calculation if the actual vessel has a higher heat loss rate).Blank for HW vessel code 3 or 4.")]
        public virtual string VesselHeatLoss { get; set; } = null;

        [Description("Minimum vessel heat exchanger area of the separate vessel to which the performance data relates (a reduced water heating efficiency applies in the SAP calculation if the actual vessel has a lower heat transfer area).  Blank for HW vessel code 3 or 4, may be blank for HW vessel code 1.")]
        public virtual string VesselHeatExchangerArea { get; set; } = null;

        [Description("The energy efficiency class as defined for the proposed European energy label. Definition and format have not yet been decided.This field is being left blank until the European energy labelling scheme has been defined.")]
        public virtual string EnergyEfficiencyClass { get; set; } = null;

        [Description("Water heating efficiency from number 2 test schedule (% gross). Blank if service provision code is 3.")]
        public virtual string WaterHeatingEfficiency { get; set; } = null;

        [Description("Specific electricity consumed during water heating efficiency test number 2 schedule, kWhe per kWhh.  Blank if service provision code is 3. This value is zero for heat pumps powered solely by electricity.")]
        public virtual string NetSpecificElectricityConsumed { get; set; } = null;

        [Description("Water heating efficiency from number 3 test schedule (% gross).  Blank if service provision code is 3 or not tested to this schedule.")]
        public virtual string WaterHeatingEfficiency2 { get; set; } = null;

        [Description("Specific electricity consumed (negative if generated) during water heating efficiency test number 3 schedule, kWhe per kWhh.   Blank if service provision code is 3 or not tested to this schedule. This value is zero for heat pumps powered solely by electricity.")]
        public virtual string NetSoecificElectricityConumed2 { get; set; } = null;

        [Description("Values that indicate features that are relevant for heating controls. See Note 2.")]
        public virtual string ControlCapabilities { get; set; } = null;

        //The remaining items are omitted for service provision code 4 (hot water provision only)

        [Description("Whether the heat pump is reversible to as to provide cooling in summer. Coded as 0=unknown, 1=no, 2=yes.")]
        public virtual string Reversible { get; set; } = null;

        [Description("The Energy Efficiency Ratio of the heat pump in cooling mode. Blank if unknown or inapplicable.")]
        public virtual string EER { get; set; } = null;

        [Description("Maximum heat output of the heat pump in kW.  Note this varies by emitter type.")]
        public virtual string MaximumOutput { get; set; } = null;

        [Description("Coded 24 for continuous; 16 for 16 hours/day; 11 for 9 hours on weekdays and 24 at weekends; V for variable – same as 11 but switches to 16 or 24 hours on colder days before supplementary heating is applied.")]
        public virtual string HeatingDuration { get; set; } = null;

        [Description("The MVHR or MEV for which the space heating data applies. Blank if heat source code is not 4, 5 or 6.")]
        public virtual string MEVorMVHRProductIndex { get; set; } = null;

        [Description("Weather compensator or enhanced load compensator included in the results (1 yes; 2 no)")]
        public virtual string CompensatorEffect { get; set; } = null;

        [Description("Whether the package contains within it a water circulator for the emission system or a separate system circulator must be installed outside the package. This must be confirmed on the test certificate. Encoded as:  0 unknown; 1 within; 2 separate. Blank if not applicable.If within the package the net electricity consumed includes the circulator.")]
        public virtual string SeperateCirculator { get; set; } = null;

        [Description("(2 or 3 or blank) Number of air flow rates for which the group of space heating results apply. Blank if heat source code is not 4, 5 or 6.")]
        public virtual string NumberOfAirFlowRates { get; set; } = null;

        [Description("Lowest or lower air flow rate in l/s when tested for which the groups of results apply. Blank if heat source code is not 4, 5 or 6.")]
        public virtual string AirFlowRate1 { get; set; } = null;

        [Description("Medium or higher flow rate in l/s for which the group of results. Blank if heat source code is not 4, 5 or 6.")]
        public virtual string AirFLowRate2 { get; set; } = null;

        [Description("Highest air flow rate in l/s when tested for which the groups of space heating results apply. Blank if heat source code is not 4, 5 or 6.")]
        public virtual string AirflowRate3 { get; set; } = null;

        [Description("The number of plant size ratios for which data are provided in the record (maximum 7). If there is more than one flow rate (field 34 = 2 or 3), this number is the same for each flow rate in the record.")]
        public virtual string NumberOfPlantSizeRatios { get; set; } = null;

        [Description("Group A: This field introduces a set of results known as group A. It contains the plant size ratio to which the other data in group A relate.If there is more than one flow rate the plant size ratios for each flow rate are the same.")]
        public virtual string PlantSizeRatioA { get; set; } = null;

        [Description("Group A: space heating thermal efficiency expressed (% gross).")]
        public virtual string SpaceHeatingEfficiencyA { get; set; } = null;

        [Description("Group A: specific electricity consumed during space heating, kWhe per kWhh. If the heat pump is powered solely by electricity this is zero.")]
        public virtual string SpecificElectricityConsumedA { get; set; } = null;

        [Description("Group A: heat pump running hours per year. For heat source code 1, 2 or 3 this is blank.")]
        public virtual string RunningHoursA { get; set; } = null;

        //Group B, C, D …  Set of results in the same format as those for group A for other plant size ratios. Plant size ratios are listed in the record in ascending order. n is the value in field 38
        //PSR-dependent results (i.e. Groups A, B etc) for air flow rate 2. n is the value in field 38. Omitted if not applicable
        //PSR-dependent results (i.e. Groups A, B etc) for air flow rate 3. n is the value in field 38. Omitted if not applicable

    }
}
