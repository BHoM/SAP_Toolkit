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
    public class MVHRDuctTable : BHoMObject, IPCDBObject
    {
        [Description("Unique index number for each record, assigned automatically by database software and used for control and reference purposes.")]
        public virtual string Index { get; set; } = null;

        [Description("Reference to current name of manufacturer (see field 2 in Manufacturers Table).")]
        public virtual string ManufacturerReference { get; set; } = null;

        [Description("Status of the data record, encoded as 0=normal status for an actual product, 1=illustrative (non - existent) product, 2 = under investigation, 3 = not valid, 4 = methodology under review. ")]
        public virtual string Status { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;

        [Description("The original name of the manufacturer, which may be different from the current name.")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description("Name of brand, as shown on the duct system and MHVR unit. If the same system is sold under more than one manufacturer name then separate entries for each will appear in the database.")]
        public virtual string BrandName { get; set; } = null;

        [Description("Name of model of duct system, as shown on the duct system and MHVR unit.")]
        public virtual string ModelName { get; set; } = null;

        [Description("Qualifier to model name, if needed in addition to the model name to discriminate between different versions of same model.")]
        public virtual string ModelQualifier { get; set; } = null;

        [Description("First year of manufacture, if known; otherwise blank.")]
        public virtual string FirstYearOfManufacture { get; set; } = null;

        [Description("Final year of manufacture, or “current” if still in production. If no longer produced but date production ceased is unknown, then “obsolete”.")]
        public virtual string FinalYearOfManufacture { get; set; } = null;

        [Description("Type of ducting: flexible, rigid or semi-rigid, coded as 1, 2 and 3 respectively. Any other value means the data record is not valid.")]
        public virtual string DuctType { get; set; } = null;
    }
}

