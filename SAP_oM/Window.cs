/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
    [Description("A BHoMObject for SAP analysis. Contains info about window properties and overhang")]
    public class Window : BHoMObject
    {

        [Description("Window layer name")]
        public virtual List <string> WindowID { get; set; }

        [Description("Dwelling name")]
        public virtual List <string> DwellingName { get; set; } 

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual List<string> Reference { get; set; }

        [Description("Window width in mm")]
        public virtual List<double> Width { get; set; }

        [Description("Window height in mm")]
        public virtual List<double> Height { get; set; }

        [Description("Window area in square meters")]
        public virtual List<double> Area { get; set; }

        [Description("Window orientation in text")]
        public virtual List<string> Orientation { get; set; }

        [Description("Window orientation in degrees")]
        public virtual List<double> OrientationDegrees { get; set; }

        [Description("Frame percentage of window area")]
        public virtual List<double> FrameFactor { get; set; }

        [Description("If the window has an overhang wider than the window itself")]
        public virtual List<string> WideOverhang { get; set; }

        [Description("Overhang ratio")]
        public virtual List<double> OverhangRatio { get; set; }

        [Description("Window Number, resets with each dwelling")]
        public virtual List<int> Number { get; set; }

    }
}