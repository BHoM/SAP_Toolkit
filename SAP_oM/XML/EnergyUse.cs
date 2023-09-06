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
    [XmlRoot(ElementName = "Energy-Use", IsNullable = false)]
    [NoAutoConstructor]
    public class EnergyUse : BHoMObject
    {
        [Description(".")]
        [XmlElement(ElementName = "Energy-Rating-Average")]
        public virtual string EnergyRatingAverage { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Rating-Current")]
        public virtual string EnergyRatingCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Rating-Potential")]
        public virtual string EnergyRatingPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Environmental-Impact-Current")]
        public virtual string EnvironmentalImpactCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Environmental-Impact-Potential")]
        public virtual string EnvironmentalImpactPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Consumption-Current")]
        public virtual string EnergyConsumptionCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Consumption-Potential")]
        public virtual string EnergyConsumptionPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "CO2-Emissions-Current")]
        public virtual string CO2EmissionsCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "CO2-Emissions-Potential")]
        public virtual string CO2EmissionsPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "CO2-Emissions-Current-Per-Floor-Area")]
        public virtual string CO2EmissionsCurrentPerFloorArea { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Lighting-Cost-Current")]
        public virtual Money LightingCostCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Lighting-Cost-Potential")]
        public virtual Money LightingCostPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Heating-Cost-Current")]
        public virtual Money HeatingCostCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Heating-Cost-Potential")]
        public virtual Money HeatingCostPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Hot-Water-Cost-Current")]
        public virtual Money HotWaterCostCurrent { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Hot-Water-Cost-Potential")]
        public virtual Money HotWaterCostPotential { get; set; } = null;

        [Description("The DER of the property.")]
        [XmlElement(ElementName = "DER")]
        public virtual string DER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "TER")]
        public virtual string TER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "DPER")]
        public virtual string DPER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "TPER")]
        public virtual string TPER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "DFEE")]
        public virtual string DFEE { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "TFEE")]
        public virtual string TFEE { get; set; } = null;
    }
}

