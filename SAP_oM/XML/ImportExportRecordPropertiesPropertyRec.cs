using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRec : IObject
    {
        [XmlElement("Property", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecProperty> Property = new List<ImportExportRecordPropertiesPropertyRecProperty>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Survey", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurvey), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurvey>> Surveys = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurvey>>();
    }
}