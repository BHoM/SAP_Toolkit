using System;
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurveyCoolingSystem : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DataSource { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Area { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Class { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EnergyEfficiencyRatio { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Control { get; set; } = "";
    }
}