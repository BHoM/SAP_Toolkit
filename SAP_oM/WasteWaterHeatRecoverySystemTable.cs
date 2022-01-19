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
    public class WasteWaterHeatRecoverySystemTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes. ")]
        public virtual string Index { get; set; } = null;

        [Description("Reference to current name of manufacturer (see field 2 in Manufacturers Table).")]
        public virtual string ManufacturerRefNo { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1 = illustrative(non - existent) product, 2 = under investigation, 3 = not valid, 4 = methodology under review.")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the device. If the same system is sold under more than one brand name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model of device, as it appears on the shower casing or leaflet of owner's instructions. If the same unit is sold under more than one model name then separate entries for each will appear in the database.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model. For an instantaneous WWHRS, this is 'System A', 'System B' or 'System C'.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Whether an instantaneous or storage WWHRS, encoded as 1 and 2 respectively.")]
        public virtual string InstantaneousOrStorage { get; set; } = null;

        [Description("For an instantaneous WWHRS, this is A, B or C as defined in the SAP specification.  If data are available for more than one system type, a record for each will be included. For a storage WWHRS this is blank.")]
        public virtual string SystemType { get; set; } = null;

        [Description("For a storage WWHRS, this is “combined” or “separate”, encoded as 1 or 2. For an instantaneous WWHRS this is blank.")]
        public virtual string StorageType { get; set; } = null;

        [Description("Heat recovery efficiency of system (%).")]
        public virtual string Efficiency { get; set; } = null;

        [Description("Utilisation factor for system (fraction between 0 and 1).")]
        public virtual string UtilisationFactor { get; set; } = null;

        [Description("Fraction of total bathing waste water that is routed through the heat recovery system.")]
        public virtual string WasteWaterFraction { get; set; } = null;

        [Description("Dedicated storage volume used in efficiency test in litres. For an instantaneous WWHRS this is blank.")]
        public virtual string TestDedicatedVolume { get; set; } = null;

        [Description("Low end of validity range of dedicated storage in litres. For an instantaneous WWHRS this is blank.")]
        public virtual string LowDedicatedVolume { get; set; } = null;

        [Description("High end of validity range of dedicated solar volume. For an instantaneous WWHRS this is blank")]
        public virtual string HighDedicatedVolume { get; set; } = null;

        [Description("Daily electricity consumption of a storage WWHRS in kWh/day. For an instantaneous WWHRS this is zero.")]
        public virtual string ElectricityConsumption { get; set; } = null;
    }
}
