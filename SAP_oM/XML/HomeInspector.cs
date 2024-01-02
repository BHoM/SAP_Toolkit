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
    [XmlRoot(ElementName = "Home-Inspector", IsNullable = false)]
    [NoAutoConstructor]
    public class HomeInspector : BHoMObject
    {
        [Description(".")]
        [XmlElement(ElementName = "Name")]
        public virtual string Name { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Notify-Lodgement")]
        public virtual string NotifyLodgement { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Contact-Address")]
        public virtual Address ContactAddress { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Web-Site")]
        public virtual string WebSite { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "E-Mail")]
        public virtual string EMail { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Fax")]
        public virtual string Fax { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Telephone")]
        public virtual string Telephone { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Company-Name")]
        public virtual string CompanyName { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Scheme-Name")]
        public virtual string SchemeName { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Scheme-Web-Site")]
        public virtual string SchemeWebSite { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Identification-Number")]
        public virtual IdentificationNumber IdentificationNumber { get; set; } = null;

    }
}

