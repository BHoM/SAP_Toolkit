using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class UvCalculations : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UvImages { get; set; } = "";


        [XmlElement("UvCalculations")]
        public List<UvCalculations> UvCalculations1 { get; set; } = new List<UvCalculations>();
    }
}