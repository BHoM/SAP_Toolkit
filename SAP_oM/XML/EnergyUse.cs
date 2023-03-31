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
    [XmlRoot(ElementName = "Energy-Use", IsNullable = false)]
    public class EnergyUse : IObject
    {
        [Description("The DER of the property.")]
        [XmlElement(ElementName = "DER")]
        public virtual double DER { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "TER")]
        public virtual double TER { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "DPER")]
        public virtual double DPER { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "TPER")]
        public virtual double TPER { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "DFEE")]
        public virtual double DFEE { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "TFEE")]
        public virtual double TFEE { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Rating-Current")]
        public virtual int EnergyRatingCurrent { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Rating-Potential")]
        public virtual int EnergyRatingPotential { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Rating-Average")]
        public virtual int EnergyRatingAverage { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Environmental-Impact-Current")]
        public virtual int EnvironmentalImpactCurrent { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Environmental-Impact-Potential")]
        public virtual int EnvironmentalImpactPotential { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Consumption-Current")]
        public virtual int EnergyConsumptionCurrent { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Consumption-Potential")]
        public virtual int EnergyConsumptionPotential { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "CO2-Emissions-Potential")]
        public virtual string CO2EmissionsPotential { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "CO2-Emissions-Current")]
        public virtual double CO2EmissionsCurrent { get; set; } = 0;

        [Description(".")]
        [XmlElement(ElementName = "CO2-Emissions-Current-Per-Floor-Area")]
        public virtual double CO2EmissionsCurrentPerFloorArea { get; set; } = 0;

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
    }
}

