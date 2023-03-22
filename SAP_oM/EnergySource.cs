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
    [Description("Information about the energy source in the dwelling.")]
    public class EnergySource : BHoMObject
    {
        [Description("")]
        public virtual ElectricityTariffCode ElectricityTariff { get; set; } = ElectricityTariffCode.StandardTariff;

        [Description("Photovoltaic Arrays.")]
        public virtual List<PhotovolaticArray> PhotovoltaicArrays { get; set; } = new List<PhotovolaticArray>();

        [Description("PV connection details.")]
        public virtual PvConnection PvConnection { get; set; } = new PvConnection();

        [Description("Wind Turbines.")]
        public virtual List<WindTurbine> WindTurbines { get; set; } = new List<WindTurbine>();

        [Description("Whether the wind turbine is connected to the Dwelling's meter.")]
        public virtual bool? IsWindTurbineConnectedToDwellingMeter { get; set; } = false;

        [Description("Hydro Electric Generation.")]
        public virtual HydroElectric HydroElectricGeneration { get; set; }  = new HydroElectric();


    }
}

