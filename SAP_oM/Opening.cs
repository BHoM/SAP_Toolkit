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
    [Description("An opening that is hosted on a Wall, Floor or Roof that forms part of the thermal line of the dwelling.")]
    public class Opening : BHoMObject
    {
        [Description("The opening type which defines its thermal properties e.g. u-value.")]
        public virtual BH.oM.Environment.SAP.OpeningType OpeningType { get; set; } = new BH.oM.Environment.SAP.OpeningType();

        [Description("Unique name that identifies the opening.")]
        public virtual string OpeningName { get; set; } = "Opening";

        [Description("Orientation of Opening.")]
        public virtual OrientationCode Orientation { get; set; } = OrientationCode.Unknown;

        [Description("The total width of the opening as seen from inside the dwelling (including frame).")]
        public virtual double Width { get; set; } = 0;

        [Description("The total height of the opening as seen from inside the dwelling (including frame).")]
        public virtual double Height { get; set; } = 0;

        [Description("The name of the dwelling that the opening is part of.")]
        public virtual string DwellingName { get; set; } = "";

    }

}

