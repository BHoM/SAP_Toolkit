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
    public class SpecialFeature : BHoMObject
    {
        [Description("")]
        public virtual int ID { get; set; } = -1;

        [Description("")]
        public string Description { get; set; } = null;

        [Description("")]
        public double EnergySaved { get; set; } = 0;

        [Description("")]
        public int FuelSaved { get; set; } = 0;

        [Description("")]
        public double EnergyUsed { get; set; } = 0;

        [Description("")]
        public int FuelUsed { get; set; } = 0;

        [Description("")]
        public bool IncludeMonthly { get; set; } = false;

        [Description("")]
        public bool MakeEmissionsOnly { get; set; } = false;

        [Description("")]
        public double EmissionsAmount { get; set; } = 0;

        [Description("")]
        public double EmissionsAmountCreated { get; set; } = 0;

        [Description("")]
        public double Month01 { get; set; } = 0;

        [Description("")]
        public double Month02 { get; set; } = 0;

        [Description("")]
        public double Month03 { get; set; } = 0;

        [Description("")]
        public double Month04 { get; set; } = 0;

        [Description("")]
        public double Month05 { get; set; } = 0;

        [Description("")]
        public double Month06 { get; set; } = 0;

        [Description("")]
        public double Month07 { get; set; } = 0;

        [Description("")]
        public double Month08 { get; set; } = 0;

        [Description("")]
        public double Month09 { get; set; } = 0;

        [Description("")]
        public double Month10 { get; set; } = 0;

        [Description("")]
        public double Month11 { get; set; } = 0;

        [Description("")]
        public double Month12 { get; set; } = 0;
    }
}
