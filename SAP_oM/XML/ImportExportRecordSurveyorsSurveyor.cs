using System;
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordSurveyorsSurveyor : IObject
    {

        public string Name { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Title { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FirstName { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SurnameUnaccredited { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Company { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string House { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Street { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Locality { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Town { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string County { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Postcode { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Telephone { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Mobile { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Fax { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Email { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SurveyorID { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Password { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Surname { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LastModif { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Guid { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RegsRegion { get; set; } = "";
    }
}