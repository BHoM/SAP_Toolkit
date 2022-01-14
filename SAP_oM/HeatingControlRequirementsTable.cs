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
    public class HeatingControlRequirementsTable : BHoMObject, IPCDBObject
    {
        [Description("Bit number in Control capabilities of a heating system table or the Heat generator control requirements of the Heating controls table. Bit numbers are counted from 0 upwards starting with the least significant.")]
        public virtual string BitNumber { get; set; } = null;

        [Description("Short description of the feature.")]
        public virtual string Description { get; set; } = null;

        [Description("Date and time this record was created or last amended by the database administrator.")]
        public virtual string DBEntryUpdated { get; set; } = null;
    }
}