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
        public virtual List<string> WindowID { get; set; } = new List<string>(); //opening.Name

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = ""; //dwelling.name

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = ""; //dwelling.Reference

        [Description("Window width in mm")]
        public virtual List<double> Width { get; set; } = new List<double>(); //opening.Width() in mm

        [Description("Window height in mm")]
        public virtual List<double> Height { get; set; } = new List<double>(); //Opening.Height() in mm

        [Description("Window area in square meters")]
        public virtual List<double> Area { get; set; } = new List<double>(); //opening.Area() in m^2

        [Description("Window orientation in text")]
        public virtual List<string> Orientation { get; set; } = new List<string>(); //opening.Orientation().ToString()

        [Description("Window orientation in degrees")]
        public virtual List<double> OrientationDegrees { get; set; } = new List<double>(); //opening.Orientation().ToDegrees()

        [Description("Frame percentage of window area")]
        public virtual List<double> FrameFactor { get; set; } = new List<double>(); //Extra input

        [Description("If the window has an overhang wider than the window itself")]
        public virtual List<bool> WideOverhang { get; set; } = new List<bool>(); //Shade balconies - if shade above opening only on floor above and is wider than opening

        [Description("Overhang ratio")]
        public virtual List<double> OverhangRatio { get; set; } = new List<double>(); //Shade balconies - if shade above opening only on floor above then shade depth divided by opening height

        [Description("Window Number, resets with each dwelling")]
        public virtual List<int> Number { get; set; } = new List<int>(); //Same as the silly dwelling ID but with openings on dwellings instead

    }
}