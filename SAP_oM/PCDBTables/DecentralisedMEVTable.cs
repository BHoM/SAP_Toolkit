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
    public class DecentralisedMEVTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;
        
        [Description("Reference to current name of manufacturer.")]
        public virtual string ManufacturerReferenceNo { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1=illustrative (non-existent) product, 2=under investigation, 3=not valid, 4=methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the ventilation unit. If none the original manufacturer name will be inserted instead. If the same system is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model of ventilation unit, as it appears on the unit's casing or leaflet of owners’ instructions.If the same system is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Main product type, which is “decentralised mechanical extract ventilation”  coded as 2. Note: If an unknown value is encountered, skip record and treat the ventilation system as non-existent. Do not report a file format error.")]
        public virtual string MainType { get; set; } = null;

        [Description("Whether tested using flexible or rigid ducting, coded as 1 and 2 respectively. This is for 'in-room' and 'in duct' configurations. Any other value means the data record is not valid. If the same system has been tested for both flexible and rigid ducting then separate entries for each appear in the database.")]
        public virtual string FlexibleOrRigidDucting { get; set; } = null;

        [Description("The number of different configurations tested. At present this is 6 (two types of wet room and three types of fan location)")]
        public virtual string NumberConfigurations { get; set; } = null;

        [Description("This field introduces a set of test results known as group A. It defines the configuration which the other data in group A relate, encoded as:1 In - room fan, kitchen ;2 In - room fan, other wet room. 3; In-duct fan, kitchen. 4; In-duct fan, other wet room. 5; Through - wall fan, kitchen. 6; Through - wall fan, other wet room")]
        public virtual string ConfigurationA { get; set; } = null;

        [Description("Test flow rate in litres/sec. Blank if this configuration has not been tested.")]
        public virtual string TestFlowRateA { get; set; } = null;

        [Description("The fan speed setting for the test, as marked on the fan unit. Blank if this configuration has not been tested.")]
        public virtual string FanSpeedSettingA { get; set; } = null;

        [Description("Specific fan power in watts per (litre per second) in minimum flow rate test. Blank if this configuration has not been tested.")]
        public virtual string SpecificFanPowerA { get; set; } = null;

        //Groups B, C, D, …: Sets of results in the same format as Group A. n is the value in field 12. 18 to (13+4n)

    }
}