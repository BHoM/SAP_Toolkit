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
using BH.oM.Base.Attributes;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "Community-Heat-Source", IsNullable = false)]
    [NoAutoConstructor]
    public class CommunityHeatSource : BHoMObject
    {
        [Description(".")]
        [XmlElement("Heat-Source-Type")]
        public virtual string HeatSourceType { get; set; } = null;

        [Description("Fraction of heat for the system provided by this heat source.")]
        [XmlElement("Heat-Fraction")]
        public virtual string HeatFraction { get; set; } = null;

        [Description(".")]
        [XmlElement("Fuel-Type")]
        public virtual string FuelType { get; set; } = null;//41

        [Description(".")]
        [XmlElement(ElementName = "PCDF-Fuel-Index")]
        public virtual string PCDFFuelIndex { get; set; } = null;

        [Description("Heat efficiency in %.")]
        [XmlElement("Heat-Efficiency")]
        public virtual string HeatEfficiency { get; set; } = null; //400

        [Description("Power efficiency in %. Include when heat source is CHP.")]
        [XmlElement("Power-Efficiency")]
        public virtual string PowerEfficiency { get; set; } = null;

        [Description(".")]
        [XmlElement("Description")]
        public virtual string Description { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "CHP-Electricity-Generation")]
        public virtual string CHPElectricityGeneration { get; set; } = null;
    }
}

