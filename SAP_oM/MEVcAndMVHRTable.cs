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
    public class MEVcAndMVHRTable : BHoMObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;

        [Description("Reference to current name of manufacturer.")]
        public virtual string ManufacturerRefNo { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1=illustrative (non-existent) product, 2=under investigation, 3=not valid, 4=methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the ventilation unit. If none the original manufacturer name will be inserted instead. If the same system is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model of ventilation unit, as it appears on the unit's casing or leaflet of owners’ instructions. If the same system is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstManufYear { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalManufYear { get; set; } = null;

        [Description("Main product type, which is one of 'centralised mechanical extract ventilation', 'balanced whole - house mechanical ventilation with heat recovery', 'balanced whole - house mechanical ventilation without heat recovery' or positive input ventilation' coded as 1, 3, 4 and 5 respectively.")]
        public virtual string MainType { get; set; } = null;

        [Description("Whether the MEV or MVHR is used only as an integral part of an exhaust air heat pump system. This is 1 if it is integral only and 0 if not.")]
        public virtual string IntegralOnly { get; set; } = null;

        [Description("Whether tested using flexible or rigid ducting, coded as 1 and 2 respectively. Any other value means the data record is not valid. If the same system has been tested for both flexible and rigid ducting then separate entries for each appear in the database.")]
        public virtual string DuctType { get; set; } = null;

        [Description("Coded as 1 for 125 mm diameter or 204 x 60 rectangular or larger, coded as 2 for 100 mm diameter or 100 x 50 rectangular. If the same system has been tested with both sizes thenseparate entries for each will appear in the database.")]
        public virtual string DuctSize { get; set; } = null;

        [Description("Whether an MVHR has a by-pass of the heat recovery unit which can be used during summer, encoded as 0 = unknown; 1 = no; 2 = optional; 3 = yes.Optional means that the unit is available both with and without a by - pass.Blank if not applicable.")]
        public virtual string SummerByPass { get; set; } = null;

        [Description("The number of different configurations tested. This will include the kitchen and at least one other wet room.")]
        public virtual string NumExhaustTerminalConfig { get; set; } = null;

        [Description("For MVHR, whether the test flow rates were those for SAP 2005/2009 or SAP 2012, indicated as 2005 or 2012 respectively. If the tests were done for SAP 2005/2009 flow rates, the SFP and efficiency will have been adjusted to the SAP 2012 rates.Blank if not applicable.")]
        public virtual string TestFlowRatesBasis { get; set; } = null;

        [Description("This field introduces a set of test results known as group A. It contains the number of additional wet rooms (i.e. in addition to the kitchen) to which the other data in group A relate.")]
        public virtual string AddidtionalWetRooms { get; set; } = null;// someway make possible for more of these groups, A B C etc

        [Description("Test flow rate in litres/sec")]
        public virtual string TestFlowRate { get; set; } = null;

        [Description("The fan speed setting for the test, as marked on the MEV or MVHR unit.")]
        public virtual string FanSpeedSetting { get; set; } = null;

        [Description("Flow rate for the values in the next two fields.")]
        public virtual string ApplicableFlowRate { get; set; } = null;

        [Description("Specific fan power in watts per (litre per second)..")]
        public virtual string SpecificFanPower { get; set; } = null;

        [Description("Heat exchanger efficiency in %. MVHR only, blank if not applicable.")] 
        public virtual string HeatExchangerEfficiency { get; set; } = null;
    }
}
