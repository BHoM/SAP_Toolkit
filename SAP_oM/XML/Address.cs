/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
    [XmlRoot(ElementName = "Address", IsNullable = false)]
    [NoAutoConstructor]
    public class Address : BHoMObject
    {
        [Description(".")]
        [XmlElement(ElementName = "Address-Line-1")]
        public virtual string AddressLine1 { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Address-Line-2")]
        public virtual string AddressLine2 { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Address-Line-3")]
        public virtual string AddressLine3 { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Post-Town")]
        public virtual string PostTown { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Postcode")]
        public virtual string Postcode { get; set; } = "BA2 3DQ";
    }
}

