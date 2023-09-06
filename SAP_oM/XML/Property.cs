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
    [XmlRoot(ElementName = "Property", IsNullable = false)]
    [NoAutoConstructor]
    public class Property : BHoMObject
    {
        [Description("Address for the property.")]
        [XmlElement(ElementName = "Address")]
        public virtual Address Address { get; set; } = new Address();

        [Description("Unique Property Reference Number.")] 
        [XmlElement(ElementName = "UPRN")]
        public virtual string UniquePropertyReferenceNumber { get; set; } = null;

        [Description("A site reference.")]
        [XmlElement(ElementName = "Site-Reference")]
        public virtual string SiteReference { get; set; } = null;

        [Description("A plot reference.")]
        [XmlElement(ElementName = "Plot-Reference")]
        public virtual string PlotReference { get; set; } = null;

    }
}


