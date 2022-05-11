/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
    [XmlRoot(ElementName = "SAP-Building-Part", IsNullable = false)]
    public class BuildingPart : IObject
    {
        [XmlElement("Building-Part-Number")]
        public virtual string BuildingPartNumber { get; set; } = "1";

        [XmlElement("Identifier")]
        public virtual string Identifier { get; set; } = "Main dwelling";

        [XmlElement("Construction-Year")]
        public virtual string ConstructionYear { get; set; } = DateTime.Now.Year.ToString();

        [XmlElement("Overshading")]
        public virtual string Overshading { get; set; } = "2";

        [XmlElement("SAP-Openings")]
        public virtual List<Opening> Openings { get; set; }

        [XmlElement("SAP-Floor-Dimensions")]
        public virtual List<FloorDimension> Floors { get; set; }

        [XmlElement("SAP-Roofs")]
        public virtual List<Roof> Roofs { get; set; }

        [XmlElement("SAP-Walls")]
        public virtual List<Wall> Walls { get; set; }

        [XmlElement("SAP-Thermal-Bridges")]
        public virtual List<ThermalBridge> ThermalBridges { get; set; }
    }
}
