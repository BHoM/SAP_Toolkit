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
    [XmlRoot(ElementName = "Improvement", IsNullable = false)]
    public class Improvement : IObject
    {
        [Description(".")]
        [XmlElement(ElementName = "Improvement-Category")]
        public virtual string ImprovementCategory { get; set; } = null;//5

        [Description(".")]
        [XmlElement(ElementName = "Green-Deal-Category")]
        public virtual string GreenDealCategory { get; set; } = null; //5

        [Description(".")]
        [XmlElement(ElementName = "Improvement-Type")]
        public virtual string ImprovementType { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Improvement-Details")]
        public virtual ImprovementDetails ImprovementDetails { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Indicative-Cost")]
        public virtual string IndicativeCost { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Typical-Saving")]
        public virtual Money TypicalSaving { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Performance-Rating")]
        public virtual string EnergyPerformanceRating { get; set; } = null; 

        [Description(".")]
        [XmlElement(ElementName = "Environmental-Impact-Rating")]
        public virtual string EnvironmentalImpactRating { get; set; } = null;

        [Description(".")]
        [XmlElement("Sequence")]
        public virtual int Sequence { get; set; } = 0;

    }
}

