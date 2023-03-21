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
    [Description("")]
    public class Boiler : BHoMObject
    {
        [Description("")]
        public virtual bool IsCondensingBoiler { get; set; } = false;

        [Description("The temperature distribution of the condensing boiler.")]
        public virtual string CondensingBoilerHeatDistribution { get; set; } = "55";

        [Description("Case heat emission at full load in kW; if it is a range cooker boiler and boiler efficiency is manufacturer declaration.")]
        public virtual string CaseHeatEmission { get; set; } = null;

        [Description("Heat transfer to water at full load in kW; if it is a range cooker boiler and boiler efficiency is manufacturer declaration.")]
        public virtual string HeatTransferToWater { get; set; } = null;

        [Description("The type of boiler fuel feed; only if solid fuel boiler with manufacturer declaration.")]
        public virtual BoilerFuelFeedCode BoilerFuelFeed { get; set; } = BoilerFuelFeedCode.Gravity;

    }
}

