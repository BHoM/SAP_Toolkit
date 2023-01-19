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
    [XmlRoot(ElementName = "RHI-Existing-Dwelling", IsNullable = false)]
    public class RHIExistingDwelling : IObject
    {
        [Description("Space heating requirement for existing dwelling.")]
        [XmlElement(ElementName = "Space - Heating - Existing - Dwelling")]
        public virtual double SpaceHeatingExistingDwelling { get; set; } = 0;

        [Description("For backwards compatibility only, do not use")]
        [XmlElement(ElementName = "Space-Heating-With-Loft-Insulation")]
        public virtual double SpaceHeatingWithLoftInsulation { get; set; } = 0;

        [Description("For backwards compatibility only, do not use")]
        [XmlElement(ElementName = "Space-Heating-With-Cavity-Insulation")]
        public virtual double SpaceHeatingWithCavityInsulation { get; set; } = 0;

        [Description("For backwards compatibility only, do not use")]
        [XmlElement(ElementName = "Space-Heating-With-Loft-And-Cavity-Insulation")]
        public virtual double SpaceHeatingWithLoftAndCavityInsulation { get; set; } = 0;

        [Description("Water heating requirement.")]
        [XmlElement(ElementName = "Water-Heating")]
        public virtual double WaterHeating { get; set; } = 0;

        [Description("Reduction in space heating requirement with loft insulation")]
        [XmlElement(ElementName = "Impact-Of-Loft-Insulation")]
        public virtual int ImpactOfLoftInsulation { get; set; } = -1;

        [Description("Reduction in space heating requirement with cavity insulation")]
        [XmlElement(ElementName = "Impact-Of-Cavity-Insulation")]
        public virtual int ImpactOfCavityInsulation { get; set; } = -1;

        [Description("Reduction in space heating requirement with solid wall insulation ")]
        [XmlElement(ElementName = "Impact-Of-Solid-Wall-Insulation")]
        public virtual int ImpactOfSolidWallInsulation { get; set; } = -1;
    }
}
