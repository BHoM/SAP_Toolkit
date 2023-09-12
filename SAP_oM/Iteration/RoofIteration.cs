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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.XML
{
    [Description("Describe a single UValue change for roofs within the SAP context.")]
    public class RoofIteration : BHoMObject, IIteration
    {
        [Description("New UValue to use for the Roof(s). Must be a positive number. Measured in Watts per Meter Squared Kelvin (W/m2K).")]
        public virtual double UValue { get; set; } = double.NaN;

        [Description("A list of Roof names to make changes to. If this is left blank, then all roofs in the SAP Report will be updated to have this UValue.")]
        public virtual List<string> Include { get; set; } = null;
    }
}