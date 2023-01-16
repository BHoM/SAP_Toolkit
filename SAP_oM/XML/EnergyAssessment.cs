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
        public DateTime AssessmentDate { get; set; }

        [XmlElement(ElementName = "Property-Summary")]
        public PropertySummary PropertySummary { get; set; }

        [XmlElement(ElementName = "Energy-Use")]
        public EnergyUse EnergyUse { get; set; }

        [XmlElement(ElementName = "Suggested-Improvements")]
        public SuggestedImprovements SuggestedImprovements { get; set; }

        [XmlElement(ElementName = "LZC-Energy-Sources")]
        public LowZeroCarbonEnergySources LowZeroCarbonEnergySources { get; set; }

        [XmlElement(ElementName = "Renewable-Heat-Incentive")]
        public RenewableHeatIncentive RenewableHeatIncentive { get; set; }

        //may need to include: Green-Deal-Package, Alternative-Improvements (Type:suggested-improvements), Addendum (Type:Addendum)

        
    }
}
