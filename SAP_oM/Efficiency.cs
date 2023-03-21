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
    [Description("Whether there has been a pressure test, include information depending on if pressure test or not.")]
    public class Efficiency : BHoMObject
    {

        [Description("")]
        public virtual TypeOfEfficiency EfficiencyType { get; set; } = TypeOfEfficiency.SEDBUK2009;

        [Description("")]
        public virtual string MainHeatingSystemType { get; set; } = null;

        [Description("To be used if main heating data is manufacturer declaration and Efficiency-Type is winter and summer.")]
        public virtual string MainHeatingEfficiencyWinter { get; set; } = null;

        [Description("To be used if main heating data is manufacturer declaration and Efficiency-Type is winter and summer.")]
        public virtual string MainHeatingEfficiencySummer { get; set; } = null;

        [Description("If main heating is any system other than heat network.")]
        public virtual string MainHeatingEfficiency { get; set; } = null;
    }
}

