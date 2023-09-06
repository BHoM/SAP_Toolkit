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
    [XmlRoot(ElementName = "Report-Header", IsNullable = false)]
    [NoAutoConstructor]
    public class ReportHeader : SAPXMLObject
    {
        [Description("Report Reference Number is the unique report Identifier that the report will be publicly known by.")]
        [XmlElement(ElementName = "RRN")]
        public virtual string ReportReferenceNumber { get; set; } = null;

        [Description("The date that the inspection was actually carried out by the Home Inspector. In the form yyyy-mm-dd")]
        [XmlElement(ElementName = "Inspection-Date")]
        public virtual string InspectionDate { get; set; } = null;

        [Description("The type of Home Inspection that was carried out.")]
        [XmlElement(ElementName = "Report-Type")]
        public virtual string ReportType { get; set; } = null;

        [Description("The date that the Home Inspector completed the report. In the form yyyy-mm-dd")]
        [XmlElement(ElementName = "Completion-Date")]
        public virtual string CompletionDate { get; set; } = null;

        [Description("The date that the report was submitted to the HCR Registration Organisation for lodging in the HCR Register. In the form yyyy-mm-dd")]
        [XmlElement(ElementName = "Registration-Date")]
        public virtual string RegistrationDate { get; set; } = null;

        [Description("The Status of the Report.")]
        [XmlElement(ElementName = "Status")]
        public virtual string Status { get; set; } = "entered";

        [Description("The language that the report is written in.")]
        [XmlElement(ElementName = "Language-Code")]
        public virtual string LanguageCode { get; set; } = "1";

        [Description(".")]
        [XmlElement(ElementName = "Tenure")]
        public virtual string Tenure { get; set; } = null;//3

        [Description(".")]
        [XmlElement(ElementName = "Transaction-Type")]
        public virtual string TransactionType { get; set; } = "6";

        [Description(".")]
        [XmlElement(ElementName = "Seller-Commission-Report")]
        public virtual string SellerCommissionReport { get; set; } = null;

        [Description("Describes the type of Property that is being inspected. This should be the same as the Property-Type recorded in the Property-Details section.")]
        [XmlElement(ElementName = "Property-Type")]
        public virtual string PropertyType { get; set; } = null;//2

        [Description(".")]
        [XmlElement(ElementName = "Home-Inspector")]
        public virtual HomeInspector HomeInspector { get; set; } = new HomeInspector();

        [Description(".")]
        [XmlElement(ElementName = "Property")]
        public virtual Property Property { get; set; } = new Property();

        [Description("Regional code.")]
        [XmlElement(ElementName = "Region-Code")]
        public virtual string RegionCode { get; set; } = "15"; 

        [Description(".")]
        [XmlElement(ElementName = "Country-Code")]
        public virtual string CountryCode { get; set; } = "ENG";

        [Description(".")]
        [XmlElement(ElementName = "Related-Party-Disclosure")]
        public virtual RelatedPartyDisclosure RelatedPartyDisclosure { get; set; } = null;
    }
}
