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
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "Solar-Heating-Details", IsNullable = false)]
    public class SolarHeatingDetails : IObject
    {
        [Description("Panel aperture area in square metres.")]
        [XmlElement("Solar-Panel-Aperture-Area")]
        public virtual string ApertureArea { get; set; } = null;

        [Description("Type of solar panel collector.")]
        [XmlElement("Solar-Panel-Collector-Type")]
        public virtual string CollectorType { get; set; } = null;

        [Description("Source of solar panel collector data.")]
        [XmlElement("Solar-Panel-Collector-Data-Source")]
        public virtual string DataSource { get; set; } = null;

        [Description("Collector zero-loss efficiency; only if declared values.")]
        [XmlElement("Solar-Panel-Collector-Zero-Loss-Efficiency")]
        public virtual string ZeroLossEfficiency { get; set; } = null;

        [Description("Collector heat loss rate; for backward compatibility only, do not use.")]
        [XmlElement("Solar-Panel-Collector-Heat-Loss-Rate")]
        public virtual string HeatLossRate { get; set; } = null;

        [Description("Collector linear heat loss coefficient; only if declared values.")]
        [XmlElement("Solar-Panel-Collector-Linear-Heat-Loss-Coefficient")]
        public virtual string LinearHeatLossCoefficient { get; set; } = null;

        [Description("Collector 2nd order heat loss coefficient; only if declared values.")]
        [XmlElement("Solar-Panel-Collector-Second-Order-Heat-Loss-Coefficient")]
        public virtual string SecondOrderHeatLossCoefficient { get; set; } = null;

        [Description("Collector orientation.")]
        [XmlElement("Solar-Panel-Collector-Orientation")]
        public virtual string Orientation { get; set; } = null;

        [Description("")]
        [XmlElement("Solar-Panel-Collector-Pitch")]
        public virtual string Pitch { get; set; } = null;

        [Description("")]
        [XmlElement("Solar-Panel-Collector-Overshading")]
        public virtual string Overshading { get; set; } = null;

        [Description("")]
        [XmlElement("Has-Solar-Powered-Pump")]
        public virtual bool? HasSolarPoweredPump { get; set; } = null;

        [Description("")]
        [XmlElement("Is-Solar-Store-Combined-Cylinder")]
        public virtual bool? IsSolarStoreCombinedCylinder { get; set; } = null;

        [Description("Dedicated solar store volume in litres.")]
        [XmlElement("Solar-Store-Volume")]
        public virtual string SolarStoreVolume { get; set; } = null;

        [Description("Type of showers in the property.")]
        [XmlElement("Shower-Types")]
        public virtual string ShowerTypes { get; set; } = null;

        public bool ShouldSerializeHasSolarPoweredPump()
        {
            return HasSolarPoweredPump.HasValue;
        }
        public bool ShouldSerializeIsSolarStoreCombinedCylinder()
        {
            return IsSolarStoreCombinedCylinder.HasValue;
        }
    }
}