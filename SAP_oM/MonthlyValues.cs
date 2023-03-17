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
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Monthly Data")]
    public class MonthlyValues: BHoMObject
    {
        [Description("January values")]
        public virtual double Jan { get; set; } = 0;

        [Description("February values")]
        public virtual double Feb { get; set;} = 0;

        [Description("March values")]
        public virtual double Mar { get; set; } = 0;

        [Description("April values")]
        public virtual double Apr { get; set; } = 0;

        [Description("May values")]
        public virtual double May { get; set; } = 0;

        [Description("June values")]
        public virtual double Jun { get; set; } = 0;

        [Description("July values")]
        public virtual double Jul { get; set; } = 0;

        [Description("August values")]
        public virtual double Aug { get; set; } = 0;

        [Description("September values")]
        public virtual double Sep { get; set; } = 0;

        [Description("October values")]
        public virtual double Oct { get; set; } = 0;

        [Description("November values")]
        public virtual double Nov { get; set; } = 0;

        [Description("December values")]
        public virtual double Dec { get; set; } = 0;
        
    }
}

