using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class ImportExportRecord : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Version { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Product { get; set; } = "";

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Surveyor", typeof(ImportExportRecordSurveyorsSurveyor), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordSurveyorsSurveyor>> Surveyors { get; set; } = new List<List<ImportExportRecordSurveyorsSurveyor>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PropertyRec", typeof(ImportExportRecordPropertiesPropertyRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRec>> Properties { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRec>>();

        [XmlElement("UvCalculations")]
        public List<UvCalculations> UvCalculations { get; set; } = new List<UvCalculations>();
    }
}