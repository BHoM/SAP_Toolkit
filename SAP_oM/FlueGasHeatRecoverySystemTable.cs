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
    [Description("Data format specification in database.")]
    public class FlueGasHeatRecoverySystemTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;
        
        [Description("Reference to current name of manufacturer.")]
        public virtual string ManufacturerReferenceNumber { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1=illustrative (non-existent) product, 2=under investigation, 3=not valid, 4=methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the heat recovery device. If none the original manufacturer name will be inserted instead. If the same system is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model of heat recovery device, as it appears on the boiler casing or leaflet of owner's instructions. If the same system is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Fuel to which the data apply, which is any one of the fuel codes specified in SAP Table 12 under sub-headings “gas”, “oil”. If the same device may be used with more than one type of fuel then separate entries for each appear in the database, except that a boiler listed for bulk LPG is also applicable to bottled LPG and LPG subject to special condition 18.")]
        public virtual string ApplicableFuel { get; set; } = null;

        [Description("Fuel used to obtain the test data, which is one of “gas”, “LPG”, or “oil”, encoded as 1, 2 or 4.If this differs from the fuel in field 11, the data have been adjusted.")]
        public virtual string TestFuel { get; set; } = null;

        [Description("Between one and six letters indicating which boiler types the system can be used with: R – regular boiler, C – instantaneous combi without keep - hot facility and without external store K – instantaneous combi with keep - hot facility, E – instantaneous combi with close - coupled external store S – storage combi, P – CPSU. These can be in any order.")]
        public virtual string ApplicableBoilerTypes { get; set; } = null;

        [Description("Whether the FGHRS is used only as an integral part of a boiler. This is 1 if it is integral only and 0 if not.")]
        public virtual string IntegralOnly { get; set; } = null;

        [Description("Whether or not the device has a heat store. This is 1 if it has no store, 2 if it has an internal heat store and 3 if it has a close-coupled external store. Heat store = 3 is valid only with an instantaneous combi boiler with close-coupled external store (applicable boiler type E).")]
        public virtual string HeatStore { get; set; } = null;

        [Description("Total volume of close-coupled external heat store in litres, 0 if no close-coupled external store.")]
        public virtual string HeatStoreTotalVolume { get; set; } = null;

        [Description("Volume of heat store heated by the recovered heat, 0 if no store. For single purpose stores this is the same as the total volume.For multiple purpose stores it is the volume below main heating coil.")]
        public virtual string HeatStoreRecapturedVolume { get; set; } = null;

        [Description("Heat loss rate from close-coupled external store measured according to BS 1566, in kWh/day. Blank if not applicable.")]
        public virtual string HeatStoreLossRaste { get; set; } = null;

        [Description("Total fraction of heat recovered by the device in a hot-water-only test using a combi boiler without keep-hot facility.")]
        public virtual string DirectTotalHeatReacovered { get; set; } = null;

        [Description("Useful fraction of heat recovered by the device in a hot-water-only test using a combi boiler without keep-hot facility. Blank if not applicable")]
        public virtual string DirectUsefulHeatRecovered { get; set; } = null;

        [Description("Annual power consumption of any electrical components in kWh/year (for example a pump). Blank if not applicable")]
        public virtual string PowerConsumption { get; set; } = null;

        [Description("Whether the device includes a PV module connected to a close-coupled external store. This is 1 if it has a PV module and 0 if not.  Valid only if Heat store = 3.")]
        public virtual string PhotovoltaicModule { get; set; } = null;

        [Description("Fraction of PV power dissipated in cable connecting PV array to immersion heater. Blank if not applicable.")]
        public virtual string CableLoss { get; set; } = null;

        [Description("The number of equations. If the device has no heat store (field 15 = 1) this field is zero and the remaining fields of the record are blank.")]
        public virtual string NumberOfEquations { get; set; } = null;

        [Description("This field introduces the parameters for equation A  It contains the monthly space heating requirement from the boiler in kWh as calculated by SAP (before application of boiler efficiency)")]
        public virtual string SpaceHeatingRequirementFromBoilerSystem { get; set; } = null;

        [Description("Coefficient a for equation A, instantaneous combi without keep-hot facility and without external store Fields 26, 27 and 28 are blank if the system does not apply to an instantaneous combi without keep - hot facility and without external store")]
        public virtual string CoefficientA { get; set; } = null;

        [Description("Coefficient b for equation A, instantaneous combi without keep-hot facility and without external store")]
        public virtual string CoefficientB { get; set; } = null;

        [Description("Coefficient c for equation A, instantaneous combi without keep-hot facility and without external store")]
        public virtual string CoefficientC { get; set; } = null;

        [Description("Coefficient a for equation A, other boilers Fields 29, 30 and 31 are blank if the system applies only to an instantaneous combi without keep - hot facility")]
        public virtual string CoefficientA2 { get; set; } = null;

        [Description("Coefficient b for equation A, other boilers")]
        public virtual string CoefficientB2 { get; set; } = null;

        [Description("Coefficient c for equation A, other boilers")]
        public virtual string CoefficientC2 { get; set; } = null;

        //Groups B, C, D, …: Equations in the same format as Group A. n is the value in field 24.32 to 24+7n
    }
}