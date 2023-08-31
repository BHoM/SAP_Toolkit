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
    [XmlRoot(ElementName = "Property-Summary", IsNullable = false)]
    public class PropertySummary : IObject
    {
        [Description(".")]
        [XmlElement(ElementName = "Walls")]
        public virtual PropertySummaryType Walls { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Roof")]
        public virtual PropertySummaryType Roof { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Floor")]
        public virtual PropertySummaryType Floor { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Windows")]
        public virtual PropertySummaryType Windows { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Main-Heating")]
        public virtual PropertySummaryType MainHeating { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Main-Heating-Controls")]
        public virtual PropertySummaryType MainHeatingControls { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Secondary-Heating")]
        public virtual PropertySummaryType SecondaryHeating { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Hot-Water")]
        public virtual PropertySummaryType HotWater { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Lighting")]
        public virtual PropertySummaryType Lighting { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Air-Tightness")]
        public virtual PropertySummaryType AirTightness { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Has-Fixed-Air-Conditioning")]
        public virtual bool? HasFixedAirConditioning { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Has-Hot-Water-Cylinder")]
        public virtual bool? HasHotWaterCylinder { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Has-Heated-Separate-Conservatory")]
        public virtual bool? HasHeatedSeparateConservatory { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Dwelling-Type")]
        public virtual string DwellingType { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Total-Floor-Area")]
        public virtual string TotalFloorArea { get; set; } = null;

        [Description("Fraction of windows that are multiply glazed to nearest 1%.")]
        [XmlElement(ElementName = "Multiple-Glazed-Percentage")]
        public virtual string MultipleGlazedPercentage { get; set; } = null;

        [Description("For backward compatibility only, do not use.")]
        [XmlElement(ElementName = "Multiple-Glazed-Percentage-NR")]
        public virtual string MultipleGlazedPercentageNR { get; set; } = null;

        [Description("Is dwelling a Zero Carbon Home?.")]
        [XmlElement(ElementName = "Is-Zero-Carbon-Home")]
        public virtual bool? IsZeroCarbonHome { get; set; } = null;
     
    }
}

