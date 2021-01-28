using System;
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Description { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string StoreyIndex { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Construction { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UValue { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UValueCalculationID { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UValueCalculated { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string KappaCalculated { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ShelterFactor { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ShelterCode { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Kappa { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AreaCalculationType { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Area { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OpeningsArea { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NettArea { get; set; } = "";
    }
}