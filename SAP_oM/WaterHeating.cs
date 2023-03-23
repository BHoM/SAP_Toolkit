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
    [Description("Strategy for the water heating of the dwelling.")]
    public class WaterHeating : BHoMObject
    {

        [Description("The type of Water Heating present in the Property. Code which indicates the type of heating system, as defined in SAP table 4a (codes 901-999).")]
        public virtual WaterHeatingCode Type { get; set; } = WaterHeatingCode.MainSystem;

        [Description(".")]
        public virtual DesignWaterUseCode HeatingDesignWaterUse { get; set; } = DesignWaterUseCode.LessThan125LitresPerPersonPerDay;

        [Description(".")]
        public virtual TypeOfHeatingFuel Fuel { get; set; } = new TypeOfHeatingFuel();

        [Description(".")]
        public virtual CylinderSpecification CylinderSpecification { get; set; } = null;

        [Description(".")]
        public virtual Immersion Immersion { get; set; } = new Immersion();

        [Description(".")]
        public virtual ThermalStoreCode ThermalStore { get; set; } = ThermalStoreCode.None;

        [Description(".")]
        public virtual bool? ThermalStoreNearBoiler { get; set; } = false;

        [Description(".")]
        public virtual bool? ThermalStoreOrCPSUInAiringCupboard {get; set; } = false;
    }
}
