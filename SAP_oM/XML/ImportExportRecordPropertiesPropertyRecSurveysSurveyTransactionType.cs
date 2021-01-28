using System;
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurveyTransactionType : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Code { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Text { get; set; } = "";
    }
}