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
using BH.oM.Environment.Elements;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-Building-Part", IsNullable = false)]
    public class BuildingPart : IObject
    {
        [Description("An integer value which uniquely identifies the building part in the property.  The value \"1\" must be assigned to the main dwelling.")]
        [XmlElement("Building-Part-Number")]
        public virtual string BuildingPartNumber { get; set; } = "1";

        [Description("Identifier for the Building part - generally only required if there are more that one Building Parts of the same type")]
        [XmlElement("Identifier")]
        public virtual string Identifier { get; set; } = "0";

        [Description("The year when this building part was constructed.  Not used if 'Construction-Age-Band' is used.")]
        [XmlElement("Construction-Year")]
        public virtual string ConstructionYear { get; set; } = "0"; //check - as seen in schema

        [Description("The age band when this building part was constructed.  Not used if 'Construction-Year' is used.")]
        [XmlElement("Construction-Age-Band")]
        public virtual string ConstructionAgeBand { get; set; } = "0"; //check - null value 

        [Description("Exposed openings that make up a particular Building-Part.")]
        [XmlElement("SAP-Openings")]
        public virtual Openings Openings { get; set; }

        [Description("Exposed roofs that make up a particular Building - Part.")]
        [XmlElement("SAP-Roofs")]
        public virtual Roofs Roofs { get; set; }

        [Description("Storeys that make up a particular Building-Part.")]
        [XmlElement(ElementName = "SAP-Floor-Dimensions")]
        public virtual FloorDimensions FloorDimensions { get; set; }

        [Description("Thermal bridges that make up a particular Building-Part.")]
        [XmlElement("SAP-Thermal-Bridges")]
        public virtual ThermalBridges ThermalBridges { get; set; }

        [Description("Exposed walls that make up a particular Storey.")]
        [XmlElement("SAP-Walls")]
        public virtual Walls Walls { get; set; }
    }
}

