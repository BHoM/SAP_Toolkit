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
    [Description("An exposed/heat loss roof that forms part of the thermal line of the dwelling")]
    public class Roof : BHoMObject
    {
        [Description("Type of roof (exposure).")]
        public virtual TypeOfRoof Type { get; set; } = TypeOfRoof.ExposedRoof;

        [Description("The total (gross - including opening areas) area of the roof as seen from inside the dwelling")]
        public virtual double Area { get; set; } = 0;

        [Description("U-value of the floor.")]
        public virtual double uValue { get; set; } = 0.13;

        [Description("Openings (skylights) that are hosted within the roof")]
        public virtual List<SAP.Opening> Openings { get; set; } = new List<SAP.Opening>();

        [Description("The name of the dwelling that the roof is part of")]
        public virtual string DwellingName { get; set; } = "";

    }
}

