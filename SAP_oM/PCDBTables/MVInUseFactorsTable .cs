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
    public class MVInUseFactorsTable : BHoMObject, IPCDBObject
    {
        [Description("Main product type to which adjustments are applicable, which is one of 'centralised mechanical extract ventilation', 'decentralised mechanical extract ventilation', 'balanced whole - house mechanical ventilation with or without heat recovery', 'positive input ventilation' or 'default data'  coded as 1, 2, 3, 5 and 10 respectively. If any other value the record should be disregarded.")]
        public virtual string SystemType { get; set; } = null;

        [Description("Multiplying factor to be applied to specific fan power when unit is used with flexible ducting when system is not installed under an approved installation scheme.")]
        public virtual string SFPAdjustment1FlexibleDuction { get; set; } = null;

        [Description("Multiplying factor to be applied to specific fan power when unit is used with rigid ducting.")]
        public virtual string SFPAdjustment1RigidDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to specific fan power when unit is used with no ducting (through - the - wall type) when system is not installed under an approved installation scheme.Blank if not applicable.")]
        public virtual string SFPAdjustment1NoDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to MVHR efficiency when unit is used with uninsulated ducting when system is not installed under an approved installation scheme. Blank if not applicable.")]
        public virtual string MVHREfficiencyAdjustment1UninsulatedDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to MVHR efficiency when unit is used with insulated ducting when system is not installed under an approved installation scheme. Blank if not applicable.")]
        public virtual string MVHREfficiencyAdjustment1InsulatedDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to specific fan power when unit is used with flexible ducting when system is installed under an approved installation scheme.")]
        public virtual string SFPAdjustment2FlexibleDuction { get; set; } = null;

        [Description("Multiplying factor to be applied to specific fan power when unit is used with rigid ducting when system is installed under an approved installation scheme.")]
        public virtual string SFPAdjustment2RigidDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to specific fan power when unit is used with no ducting (through-the-wall type) when system is installed under an approved installation scheme. Blank if not applicable.")]
        public virtual string SFPAdjustment2NoDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to MVHR efficiency when unit is used with uninsulated ducting when system is installed under an approved installation scheme. Blank if not applicable.")]
        public virtual string MVHREfficiencyAdjustment2UninsulatedDucting { get; set; } = null;

        [Description("Multiplying factor to be applied to MVHR efficiency when unit is used with insulated ducting when system is installed under an approved installation scheme. Blank if not applicable.")]
        public virtual string MVHREfficiencyAdjustment2InsulatedDucting { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;
    }
}

