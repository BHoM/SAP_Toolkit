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
        //[Description("The DER of the property")]
        //[XmlElement(ElementName ="DER")]

        //[Description("")]
        //[XmlElement(ElementName = "TER")]

        //[Description("")]
        //[XmlElement(ElementName = "DPER")]

        //[Description("")]
        //[XmlElement(ElementName = "TPER")]

        //[Description("")]
        //[XmlElement(ElementName = "DFEE")]

        //[Description("")]
        //[XmlElement(ElementName = "TFEE")]


        [XmlElement(ElementName = "Energy-Rating-Current")]
        public int EnergyRatingCurrent { get; set; }

        [XmlElement(ElementName = "Energy-Rating-Potential")]
        public int EnergyRatingPotential { get; set; }

        [XmlElement(ElementName = "Energy-Rating-Average")]
        public int EnergyRatingAverage { get; set; }

        [XmlElement(ElementName = "Environmental-Impact-Current")]
        public int EnvironmentalImpactCurrent { get; set; }

        [XmlElement(ElementName = "Environmental-Impact-Potential")]
        public int EnvironmentalImpactPotential { get; set; }

        [XmlElement(ElementName = "Energy-Consumption-Current")]
        public int EnergyConsumptionCurrent { get; set; }

        [XmlElement(ElementName = "Energy-Consumption-Potential")]
        public int EnergyConsumptionPotential { get; set; }

        [XmlElement(ElementName = "CO2-Emissions-Current")]
        public double CO2EmissionsCurrent { get; set; }

        [XmlElement(ElementName = "CO2-Emissions-Current-Per-Floor-Area")]
        public double CO2EmissionsCurrentPerFloorArea { get; set; }


        [XmlElement(ElementName = "Lighting-Cost-Current")] //check - type! Type was "money" have replaced this with double ( same as all the following )
        public double LightingCostCurrent { get; set; }

        [XmlElement(ElementName = "Lighting-Cost-Potential")]
        public double LightingCostPotential { get; set; }

        [XmlElement(ElementName = "Heating-Cost-Current")]
        public double HeatingCostCurrent { get; set; }

        [XmlElement(ElementName = "Heating-Cost-Potential")]
        public double HeatingCostPotential { get; set; }

        [XmlElement(ElementName = "Hot-Water-Cost-Current")]
        public double HotWaterCostCurrent { get; set; }

        [XmlElement(ElementName = "Hot-Water-Cost-Potential")]
        public double HotWaterCostPotential { get; set; }
    }
}

