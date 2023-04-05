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
using BH.oM.Analytical.Results;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-Report", IsNullable = false, Namespace = "https://epbr.digital.communities.gov.uk/xsd/sap")]
    public class SAPReport : IObject, IResultObject
    {

        [Description("The schema version that the data conformed to when it was lodged.")]
        [XmlElement(ElementName = "Schema-Version-Original")]
        public virtual string SchemaVersionOriginal { get; set; } = "SAP-Schema-19.0.0";

        [Description("The schema version that the data conformed to when it was lodged.")]
        [XmlElement(ElementName = "Schema-Version-Current")]
        public virtual string SchemaVersionCurrent { get; set; } = null;

        [Description("SAP version that was used for the calculation.")]
        [XmlElement(ElementName = "SAP-Version")]
        public virtual string SAPVersion { get; set; } = "10.2";

        [Description("Version of SAP that was used to define the input data for the calculation.")]
        [XmlElement(ElementName = "SAP-Data-Version")]
        public virtual string SAPDataVersion { get; set; } = "10.2";

        [Description("Revision Number of the PCDF file used for the calculations.")]
        [XmlElement(ElementName = "PCDF-Revision-Number")]
        public virtual string PCDFRevisionNumber { get; set; } = null;

        [Description("Name of the software used to perform the SAP calculation.")]
        [XmlElement(ElementName = "Calculation-Software-Name")]
        public virtual string CalculationSoftwareName { get; set; } = "BRE SAP 10.2";

        [Description("Version of the software used to perform the SAP calculation.")]
        [XmlElement(ElementName = "Calculation-Software-Version")]
        public virtual string CalculationSoftwareVersion { get; set; } = "1.0.1-alpha";

        [Description(".")]
        [XmlElement(ElementName = "User-Interface-Name")]
        public virtual string UserInterfaceName { get; set; } = "BRE SAP interface 10.2";

        [Description(".")]
        [XmlElement(ElementName = "User-Interface-Version")]
        public virtual string UserInterfaceVersion { get; set; } = "1.0.1-alpha";

        [Description(".")]
        [XmlElement(ElementName = "Report-Header")]
        public virtual ReportHeader ReportHeader { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Energy-Assessment")]
        public virtual EnergyAssessment EnergyAssessment { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "SAP10-Data")]
        public virtual SAP10Data SAP10Data { get; set; } = new SAP10Data();

        [Description("Details of the Professional Indemnity Insurance policy used to provide cover against a compensation claim against any particular Home Condition Report.")]
        [XmlElement(ElementName = "Insurance-Details")]
        public virtual InsuranceDetails InsuranceDetails { get; set; } =null;

        [Description("A number indicating the version of related ExternalDefinitions.")]
        [XmlElement(ElementName = "ExternalDefinitions-Revision-Number")]
        public virtual string ExternalDefinitionsRevisionNumber { get; set; } = null;

        //[XmlAttribute(AttributeName = "xmlns")]
        //public virtual string Xmlns { get; set; }

        //[XmlAttribute(AttributeName = "xsi")]
        //public virtual string Xsi { get; set; }

        //[XmlAttribute(AttributeName = "schemaLocation")]
        //public virtual string SchemaLocation { get; set; }

    }
}
