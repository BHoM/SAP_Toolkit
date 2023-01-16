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
    [XmlRoot(ElementName = "Home-Inspector", IsNullable = false)]
    public class HomeInspector : IObject
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Notify-Lodgement")]
        public string NotifyLodgement { get; set; }

        [XmlElement(ElementName = "Contact-Address")] //check
        public Address ContactAddress { get; set; } //check - changed this from ContactAdress type to this as address encapsulates the original object definition of contactaddress

        [XmlElement(ElementName = "Web-Site")]
        public string WebSite { get; set; }

        [XmlElement(ElementName = "E-Mail")]
        public string EMail { get; set; }

        [XmlElement(ElementName = "Fax")]
        public string Fax { get; set; }

        [XmlElement(ElementName = "Telephone")]
        public string Telephone { get; set; }

        [XmlElement(ElementName = "Company-Name")]
        public string CompanyName { get; set; }

        [XmlElement(ElementName = "Scheme-Name")]
        public string SchemeName { get; set; }

        [XmlElement(ElementName = "Scheme-Web-Site")]
        public string SchemeWebSite { get; set; }

        [XmlElement(ElementName = "Identification-Number")]
        public IdentificationNumber IdentificationNumber { get; set; }

        //several other objects may be added (as seen on schema (It's rlly confusing me and so I'm stopping here - none of them appear on example and not necessary for calc))
    }
}
