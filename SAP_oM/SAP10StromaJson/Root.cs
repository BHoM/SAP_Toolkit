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
using BH.oM.Environment.SAP.Stroma10;

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description("")]
    public class Root : BHoMObject
    {
        [Description("")]
        public virtual int ID { get; set; } = -1;

        [Description("")]
        public virtual string GUID { get; set; } = null;

        [Description("")]
        public virtual DateTime DateTimeCreated { get; set; } = DateTime.Now;

        [Description("")]
        public virtual DateTime DateTimeSaved { get; set; } = DateTime.Now;

        [Description("")]
        public virtual int UserID { get; set; } = 0;

        [Description("")]
        public virtual string Reference { get; set; } = null;

        [Description("")]
        public virtual List<Dwelling> Dwellings { get; set; } = null;

        [Description("")]
        public virtual Address Address { get; set; } = null;

        [Description("")]
        public virtual ClientDetails ClientDetails { get; set; } = null;

        [Description("")]
        public virtual Elements Elements { get; set; } = null;

        [Description("")]
        public virtual Assessor Assessor { get; set; }

        [Description("")]
        public virtual int DwellingCount { get; set; } = 0;
    }
}
