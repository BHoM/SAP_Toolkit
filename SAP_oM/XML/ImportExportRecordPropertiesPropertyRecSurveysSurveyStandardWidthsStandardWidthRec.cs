using System;
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardWidthsStandardWidthRec : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OpeningType { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WidthInMilimeters { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SaveNewRecord { get; set; } = "";
    }
}