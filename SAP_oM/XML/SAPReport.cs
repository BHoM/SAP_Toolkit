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
    [XmlRoot(ElementName = "SAP-Report", IsNullable = false)]
    public class SAPReport : IObject
    {
        [XmlElement(ElementName = "Schema-Version-Original")]
        public string SchemaVersionOriginal { get; set; } = "SAP-Schema-19.0.0";

        [XmlElement(ElementName = "Schema-Version-Current")]
        public string SchemaVersionCurrent { get; set; } = "SAP-Schema-19.0.0";

        [XmlElement(ElementName = "SAP-Version")]
        public string SAPVersion { get; set; } = "10.2";

        [XmlElement(ElementName = "SAP-Data-Version")]
        public string SAPDataVersion { get; set; } = "10.2";

        [Description("Revision Number of the PCDF file used for the calculations")]
        [XmlElement(ElementName = "PCDF-Revision-Number")]
        public int PCDFRevisionNumber { get; set; } = 0;

        [XmlElement(ElementName = "Calculation-Software-Name")]
        public string CalculationSoftwareName { get; set; } = null;

        [XmlElement(ElementName = "Calculation-Software-Version")]
        public string CalculationSoftwareVersion { get; set; } = null;

        [XmlElement(ElementName = "User-Interface-Name")] 
        public string UserInterfaceName { get; set; } = null;

        [XmlElement(ElementName = "User-Interface-Version")]
        public string UserInterfaceVersion { get; set; } = null;

        [XmlElement(ElementName = "Report-Header")]
        public ReportHeader ReportHeader { get; set; }

        [XmlElement(ElementName = "Energy-Assessment")]
        public EnergyAssessment EnergyAssessment { get; set; }

        [XmlElement(ElementName = "SAP10-Data")]
        public SAP10Data SAP10Data { get; set; }

        [XmlElement(ElementName = "Insurance-Details")]
        public InsuranceDetails InsuranceDetails { get; set; }

        [XmlElement(ElementName = "ExternalDefinitions-Revision-Number")] //check - null
        public string ExternalDefinitionsRevisionNumber { get; set; }

        //[XmlAttribute(AttributeName = "xmlns")]
        //public string Xmlns { get; set; }

        //[XmlAttribute(AttributeName = "xsi")]
        //public string Xsi { get; set; }

        //[XmlAttribute(AttributeName = "schemaLocation")]
        //public string SchemaLocation { get; set; }

        //[XmlText]
        //public string Text { get; set; }
    }
}
