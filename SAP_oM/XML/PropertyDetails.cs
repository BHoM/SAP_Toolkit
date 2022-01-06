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
    [XmlRoot(ElementName = "SAPSAP-Property-Details", IsNullable = false)]
    public class PropertyDetails : IObject
    {
        [XmlElement("Property-Type")]
        public virtual string PropertyType { get; set; }

        [XmlElement("Built-Form")]
        public virtual string BuiltForm { get; set; }

        [XmlElement("Level")]
        public virtual string Level { get; set; }

        [XmlElement("Living-Area")]
        public virtual double LivingArea { get; set; }

        [XmlElement("Orientation")]
        public virtual double Orientation { get; set; }

        [XmlElement("Conservatory-Type")]
        public virtual string ConservatoryType { get; set; }

        [XmlElement("Is-In-Smoke-Control-Area")]
        public virtual double SmokeControlArea { get; set; }
    }
}
