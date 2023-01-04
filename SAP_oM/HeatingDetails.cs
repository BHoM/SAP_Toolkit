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
    [Description("Heating details.")]
    public class HeatingDetails : BHoMObject
    {
        [Description("")]
        public virtual string ProductIndex { get; set; } = null;

        [Description("Enum which specifies data source.")]
        public virtual DataSourceCode Source { get; set; } = new DataSourceCode();

        [Description("")]
        public virtual HeatEmitterCode EmitterType { get; set; } = new HeatEmitterCode();

        [Description("")]
        public virtual EmitterTemperatureCode EmitterTemperature { get; set; } = new EmitterTemperatureCode();

        [Description("")]
        public virtual PumpAge PumpAge { get; set; } = new PumpAge();

        [Description("")]
        public virtual string HeatingGroup { get; set; } = null;

        [Description("")]
        public virtual string SubGroup { get; set; } = null;
    }
}
