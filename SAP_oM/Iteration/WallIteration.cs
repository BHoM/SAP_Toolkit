/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Describe a single iteration for wall changes within the SAP Context. If values for both UValue and Curtain Wall are provided, both will be applied to the walls specified, i.e. they will not be blended to produce one iteration for the UValue change, one for Curtain Wall change, and one for both.")]
    public class WallIteration : BHoMObject, IIteration
    {
        [Description("New UValue to use for the Wall(s). Must be a positive number. Measured in Watts per Meter Squared Kelvin (W/m2K).")]
        public virtual double UValue { get; set; } = double.NaN;

        [Description("Flag whether this iteration is to consider the wall a Curtain Wall (fully glazed).")]
        public virtual bool? IsCurtainWall { get; set; } = null;

        [Description("A list of Wallnames to make changes to. If this is left blank, then all walls in the SAP Report will be updated to have this UValue.")]
        public virtual List<string> Include { get; set; } = null;

        [Description("Provide the name of this iteration. The name should be unique across all iterations in your model, and should match any coordination with other models (over heating, daylighting, etc.) you may be running parametrics on.")]
        public override string Name { get; set; } = null;

        [Description("What value should be used to prefix the name of this iteration when combining with other iterations.")]
        public virtual string Prefix { get; set; } = "_";
    }
}

