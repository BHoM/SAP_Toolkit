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
    [XmlRoot(ElementName = "Energy-Assessment", IsNullable = false)]
    public class EnergyAssessment : IObject
    {
        [XmlElement(ElementName = "Assessment-Date")]
        public virtual DateTime AssessmentDate { get; set; } = default(DateTime);

        [XmlElement(ElementName = "Property-Summary")]
        public virtual PropertySummary PropertySummary { get; set; } = null;

        [XmlElement(ElementName = "Energy-Use")]
        public virtual EnergyUse EnergyUse { get; set; } = null;

        [XmlElement(ElementName = "Suggested-Improvements")]
        public virtual SuggestedImprovements SuggestedImprovements { get; set; } = null;

        [XmlElement(ElementName = "LZC-Energy-Sources")]
        public virtual LowZeroCarbonEnergySources LowZeroCarbonEnergySources { get; set; } = null;

        [XmlElement(ElementName = "Renewable-Heat-Incentive")]
        public virtual RenewableHeatIncentive RenewableHeatIncentive { get; set; } = null;

        //may need to include: Green-Deal-Package, Alternative-Improvements (Type:suggested-improvements), Addendum (Type:Addendum)


    }
}
