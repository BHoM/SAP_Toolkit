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
    [XmlRoot(ElementName = "SAP-Opening-Type", IsNullable = false)]
    public class OpeningType : IObject
    {
        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Window type 1";

        [XmlElement("Description")]
        public virtual string Description { get; set; } = "Double-glazed windows with aluminimum frame";

        [XmlElement("Data-Source")]
        public virtual string DataSource { get; set; } = "2";

        [XmlElement("Type")]
        public virtual string Type { get; set; } = "4";

        [XmlElement("Glazing-Type")]
        public virtual string GlazingType { get; set; } = "7";

        [XmlElement("Solar-Transmittance")]
        public virtual double gValue { get; set; } = 0.4;

        [XmlElement("Frame-Factor")]
        public virtual double FrameFactor { get; set; } = 0.8;

        [XmlElement("U-Value")]
        public virtual double uValue { get; set; } = 1.4;

    }
}

