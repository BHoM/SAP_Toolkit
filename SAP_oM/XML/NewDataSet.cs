using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class NewDataSet : IObject
    {
        [XmlElement("ImportExportRecord", typeof(ImportExportRecord))]
        [XmlElement("UvCalculations", typeof(UvCalculations))]
        public List<object> Items = new List<object>();
    }
}