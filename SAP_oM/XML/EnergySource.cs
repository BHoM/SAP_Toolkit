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
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-Energy-Source", IsNullable = false)]
    public class EnergySource : IObject
    {
        [XmlElement("PV-Arrays")]
        public virtual PVArrays PVArrays { get; set; } = null;

        [XmlElement("Wind-Turbines-Count")]
        public virtual string WindTurbinesCount { get; set; } = "0";

        [XmlElement("Wind-Turbine-Rotor-Diameter")]
        public virtual string WindTurbineRotorDiameter { get; set; } = null;

        [XmlElement("Wind-Turbine-Hub-Height")]
        public virtual string WindTurbineHubHeight { get; set; } = null;

        [XmlElement("Wind-Turbine-Terrain-Type")]
        public virtual string WindTurbineTerrainType { get; set; } = "1";

        [XmlElement("Fixed-Lighting-Outlets-Count")]
        public virtual string FixedLightingOutletsCount { get; set; } = "10";

        [XmlElement("Low-Energy-Fixed-Lighting-Outlets-Count")]
        public virtual string LowEnergyFixedLightingOutletsCount { get; set; } = "10";

        [XmlElement("Low-Energy-Fixed-Lighting-Outlets-Percentage")]
        public virtual string LowEnergyFixedLightingOutletsPercentage { get; set; } = "100";

        [XmlElement("Electricity-Tariff")]
        public virtual string ElectricityTariff { get; set; } = "1";

        [XmlElement("Hydro-Electric-Generation")]
        public virtual string HydroElectricGeneration { get; set; } = null;
    }
}


