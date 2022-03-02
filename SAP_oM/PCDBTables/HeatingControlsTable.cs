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
    public class HeatingControlsTable : BHoMObject, IPCDBObject
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

        [Description("Name of brand, as shown on the installed product. If the same system is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model of installed product, as it appears on the unit's casing  If the same unit is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Type of control provided, encoded as 1 weather and/or load compensation, 2 time and temperature zone control, 3 both of these.")]
        public virtual string ControllerType { get; set; } = null;

        [Description("Category of heating system to which the control is applicable. Categories are defined in Table 4a of the SAP specification.If the unit is applicable to more than one category, separate entries for each will appear in the database.")]
        public virtual string HeatingSystemCategory { get; set; } = null;

        [Description("Fuel used by heat generator to which the record applies to, which is any one of the fuel codes specified in SAP Table 12. If the same controller may be used with more than one fuel then separate entries for each appear in the database.Blank if not applicable(in which case the control applies to any fuel).")]
        public virtual string Fuel { get; set; } = null;

        [Description("Values that must be in the 'Control type' field of the record for the heat generator (e.g. boiler) for the control to be assigned a benefit. See Notes 1 and 2. If zero the control applies to any heat generator of the category in field 12 subject to any restrictions given in the SAP specification.")]
        public virtual string HeatGeneratorControlRequirements { get; set; } = null;

        [Description("Adjustment to space heating efficiency of a boiler provided by the control, in %. Blank if not applicable.")]
        public virtual string EfficiencyAdjustmentForBoiler { get; set; } = null;

        [Description("For a time and temperature zone control, the number of daytime hours that the heating is off in zone 2. This field should be disregarded for a record with control type = 1.")]
        public virtual string HoursHeatingOff { get; set; } = null;

        [Description("One of 'no', 'yes', 'incompatible with separate control device'. These are encoded as 0, 1 or 2. 'yes' or 'incompatible' means that a separate delayed start cannot be specified.")]
        public virtual string DelayedStart { get; set; } = null;
    }
}