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
    [XmlRoot(ElementName = "SAP-Roof", IsNullable = false)]
    public class Roof : IObject
    {
        [Description("Unique name which identifies this roof.  Can be just a number, e.g. \"1\".  However, a roof cannot have the same name as a wall.")]
        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Roof";

        [Description("Descriptive notes about the roof.")]
        [XmlElement("Description")]
        public virtual string Description { get; set; } = "A heat loss roof";

        [Description("")]
        [XmlElement("Roof-Type")]
        public virtual string Type { get; set; } = "2";

        [Description("Total roof area in square metres, inclusive of any openings.")]
        [XmlElement("Total-Roof-Area")]
        public virtual double Area { get; set; } = 0;

        [Description("Exposed roof U-value.")]
        [XmlElement("U-Value")]
        public virtual double UValue { get; set; } = 0.13;

        [Description("Heat capacity per unit area in kJ/m²K.")]
        [XmlElement("Kappa-Value")]
        public virtual double KappaValue { get; set; } = 9;

    }
}

