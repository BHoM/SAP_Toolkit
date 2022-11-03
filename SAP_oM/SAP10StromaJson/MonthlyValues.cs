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

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description("")]
    public class MonthlyValues : BHoMObject
    {
        [Description("")]
        public virtual double M01 { get; set; } = 0;

        [Description("")]
        public virtual double M02 { get; set; } = 0;

        [Description("")]
        public virtual double M03 { get; set; } = 0;

        [Description("")]
        public virtual double M04 { get; set; } = 0;

        [Description("")]
        public virtual double M05 { get; set; } = 0;

        [Description("")]
        public virtual double M06 { get; set; } = 0;

        [Description("")]
        public virtual double M07 { get; set; } = 0;

        [Description("")]
        public virtual double M08 { get; set; } = 0;

        [Description("")]
        public virtual double M09 { get; set; } = 0;

        [Description("")]
        public virtual double M10 { get; set; } = 0;

        [Description("")]
        public virtual double M11 { get; set; } = 0;

        [Description("")]
        public virtual double M12 { get; set; } = 0;

        [Description("")]
        public virtual int Id { get; set; } = 0;
    }
}
