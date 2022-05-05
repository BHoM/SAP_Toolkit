﻿/*
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
    [XmlRoot(ElementName = "Instantaneous-WWHRS", IsNullable = false)]
    public class InstantaneousWWHRS : IObject
    {
        [Description("")]
        [XmlElement("WWHRS-Index-Number1")]
        public virtual string WWHRSIndexNumber1 { get; set; } = null;

        [Description("Omit if no second system.")]
        [XmlElement("WWHRS-Index-Number2")]
        public virtual string WWHRSIndexNumber2 { get; set; } = null;

        [Description("")]
        [XmlElement("Rooms-With-Bath-And-Or-Shower")]
        public virtual string RoomsWithBathAndOrShower { get; set; } = null;

        [Description("")]
        [XmlElement("Mixer-Showers-With-System1-With-Bath")]
        public virtual string MixerShowersWithSystem1WithBath { get; set; } = null;

        [Description("")]
        [XmlElement("Mixer-Showers-With-System1-Without-Bath")]
        public virtual string MixerShowersWithSystem1WithoutBath { get; set; } = null;

        [Description("Omit if no second system.")]
        [XmlElement("Mixer-Showers-With-System2-With-Bath")]
        public virtual string MixerShowersWithSystem2WithBath { get; set; } = null;

        [Description("Collector 2nd order heat loss coefficient; only if declared values.")]
        [XmlElement("Solar-Panel-Collector-Second-Order-Heat-Loss-Coefficient")]
        public virtual string SecondOrderHeatLossCoefficient { get; set; } = null;

        [Description("Omit if no second system.")]
        [XmlElement("Mixer-Showers-With-System2-Without-Bath")]
        public virtual string MixerShowersWithSystem2WithoutBath { get; set; } = null;
    }
}