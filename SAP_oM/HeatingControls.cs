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
    [Description("Information about the Heating Controls in a dwelling.")]
    public class HeatingControls : BHoMObject
    {
        [Description("Code which indicates the type of heating control, as described in SAP table 4e. Max 2999 min 2001.")]
        public virtual HeatingControlCode Controls { get; set; } = HeatingControlCode.HeatNetworks_FlatRateProgrammerAndTRVs;

        [Description(".")]
        public virtual bool DelayedStartThermostat { get; set; } = false;

        [Description(".")]
        public virtual string BurnerControl { get; set; } = null;

        [Description("The ID of the time and temperature zone control from the product database.")]
        public virtual string ControlIndexNumber { get; set; } = null;

        [Description(".")]
        public virtual string HeatingControllerFunction { get; set; } = null;

        [Description(".")]
        public virtual string HeatingControllerEcodesignClass { get; set; } = null;

        [Description(".")]
        public virtual Details HeatingControllerDetails { get; set; } = null;   
    }
}
