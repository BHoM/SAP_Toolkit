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

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description("")]
    public class Boiler : BHoMObject
    {
        [Description("")]
        public virtual int ID { get; set; } = -1;

        [Description("")]
        public virtual bool InHeatedSpace { get; set; } = false;

        [Description("")]
        public virtual bool FlowTemperatureKnown { get; set; } = false ;

        [Description("")]
        public virtual double FlowTemperature { get; set; } = 0;

        [Description("")] //
        public virtual int EmitterTemperature { get; set; } = 0;

        [Description("")] //
        public virtual int PumpAge { get; set; } = 0;

        [Description("")]
        public virtual string Description { get; set; } = null;

        [Description("")] //
        public virtual int GasBurningType { get; set; } = 0;

        [Description("")] //
        public virtual int FlueType { get; set; } = 0;

        [Description("")]
        public virtual bool FanFlued { get; set; } = false;

        [Description("")]
        public virtual bool PumpHeatPump { get; set; } = false;

        [Description("")]
        public virtual bool BoilerInterlock { get; set; } = false;

        [Description("")]
        public virtual bool LoadWeather { get; set; } = false;

        [Description("")]
        public virtual string LoadWeatherIndexNumber { get; set; } = null;

        [Description("")]
        public virtual bool IncludeKeepHot { get; set; } = false;

        [Description("")]
        public virtual bool KeepHotTimed { get; set; } = false;

        [Description("")] //
        public virtual int KeepHotFuel { get; set; } = 0;

        [Description("")]
        public virtual int CondensingBoilerDistributionTemperature { get; set; } = 0;

        [Description("")]
        public virtual int HeatPumpDistributionTemperature { get; set; } = 0;
    }
}
