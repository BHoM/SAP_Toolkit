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
    [XmlRoot(ElementName = "Report-Header", IsNullable = false)]
    public class ReportHeader : IObject
    {
        [XmlElement(ElementName = "RRN")]
        public string ReportReferenceNumber { get; set; }

        [XmlElement(ElementName = "Inspection-Date")]
        public DateTime InspectionDate { get; set; }

        [XmlElement(ElementName = "Report-Type")] //check - null, enum?
        public int ReportType { get; set; }

        [XmlElement(ElementName = "Completion-Date")]
        public DateTime CompletionDate { get; set; }

        [XmlElement(ElementName = "Registration-Date")]
        public DateTime RegistrationDate { get; set; }

        [XmlElement(ElementName = "Status")] //check - null, enum?
        public string Status { get; set; }

        [XmlElement(ElementName = "Language-Code")] //check - null, ennum?
        public int LanguageCode { get; set; }

        [XmlElement(ElementName = "Tenure")] //check - null, ennum?
        public string Tenure { get; set; }

        [XmlElement(ElementName = "Transaction-Type")] //check - null, ennum?
        public int TransactionType { get; set; }

        [XmlElement(ElementName = "Seller-Commission-Report")] //check - null, ennum?
        public string SellerCommissionReport { get; set; }

        [XmlElement(ElementName = "Property-Type")] //check - null, ennum?
        public int PropertyType { get; set; }

        [XmlElement(ElementName = "Home-Inspector")]
        public HomeInspector HomeInspector { get; set; }

        [XmlElement(ElementName = "Property")]
        public Property Property { get; set; }

        [XmlElement(ElementName = "Region-Code")]
        public int RegionCode { get; set; }

        [XmlElement(ElementName = "Country-Code")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "Related-Party-Disclosure")]
        public RelatedPartyDisclosure RelatedPartyDisclosure { get; set; }
    }
}
