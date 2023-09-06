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
    [XmlRoot(ElementName = "Addendum", IsNullable = false)]
    [NoAutoConstructor]
    public class Addendum : BHoMObject
    {
        [Description("Cavity fill is recommended.")]
        [XmlElement(ElementName = "Cavity-Fill-Recommended")]
        public virtual bool? CavityFillRecommended { get; set; } = null;

        [Description("Stone walls present, not insulated.")]
        [XmlElement(ElementName = "Stone-Walls")]
        public virtual bool? StoneWalls { get; set; } = null;

        [Description("System build present.")]
        [XmlElement(ElementName = "System-Build")]
        public virtual bool? SystemBuild { get; set; } = null;

        [Description("Dwelling has access issues for cavity wall insulation. Include only when at least one of Cavity-Fill-Recommended, Stone-Walls, System-Build is also present.")]
        [XmlElement(ElementName = "Access-Issues")]
        public virtual bool? AccessIssues { get; set; } = null;

        [Description("Dwelling may be exposed to wind-driven rain. Include only when at least one of Cavity-Fill-Recommended, Stone-Walls, System-Build is also present.")]
        [XmlElement(ElementName = "High-Exposure")]
        public virtual bool? HighExposure { get; set; } = null;

        [Description("Dwelling may have narrow cavities. Include only when Cavity-Fill-Recommended is also present.")]
        [XmlElement(ElementName = "Narrow-Cavities")]
        public virtual bool? NarrowCavities { get; set; } = null;

    }
}
