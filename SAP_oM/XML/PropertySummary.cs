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
using BH.oM.Environment.SAP.Stroma10;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "Property-Summary", IsNullable = false)]
    public class PropertySummary : IObject
    {
        [XmlElement(ElementName = "Walls")]
        public PropertySummaryType Walls { get; set; }

        [XmlElement(ElementName = "Roof")]
        public PropertySummaryType Roof { get; set; }

        [XmlElement(ElementName = "Floor")]
        public PropertySummaryType Floor { get; set; }

        [XmlElement(ElementName = "Windows")]
        public PropertySummaryType Windows { get; set; }

        [XmlElement(ElementName = "Main-Heating")]
        public PropertySummaryType MainHeating { get; set; } //may need a list?

        [XmlElement(ElementName = "Main-Heating-Controls")]
        public PropertySummaryType MainHeatingControls { get; set; }

        [XmlElement(ElementName = "Secondary-Heating")]
        public PropertySummaryType SecondaryHeating { get; set; }

        [XmlElement(ElementName = "Hot-Water")]
        public PropertySummaryType HotWater { get; set; }

        [XmlElement(ElementName = "Lighting")]
        public PropertySummaryType Lighting { get; set; }

        [XmlElement(ElementName = "Air-Tightness")]
        public PropertySummaryType AirTightness { get; set; }

        [XmlElement(ElementName = "Has-Fixed-Air-Conditioning")]
        public bool HasFixedAirConditioning { get; set; } = false;

        [XmlElement(ElementName = "Has-Hot-Water-Cylinder")]
        public bool HasHotWaterCylinder { get; set; } = false;

        [XmlElement(ElementName = "Has-Heated-Separate-Conservatory")]
        public bool HasHeatedSeparateConservatory { get; set; } = false;

        [XmlElement(ElementName = "Dwelling-Type")]
        public DwellingType DwellingType { get; set; }

        [XmlElement(ElementName = "Total-Floor-Area")]
        public int TotalFloorArea { get; set; }

        [XmlElement(ElementName = "Multiple-Glazed-Percentage")]
        public int MultipleGlazedPercentage { get; set; }

        [Description("For backward compatibility only, do not use.")]
        [XmlElement(ElementName = "Multiple-Glazed-Percentage-NR")]
        public int MultipleGlazedPercentageNR { get; set; }

        //may need Is-Zero-Carbon-Home

    }
}

