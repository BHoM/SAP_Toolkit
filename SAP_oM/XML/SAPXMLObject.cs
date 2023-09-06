using BH.oM.Base;
using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [NoAutoConstructor]
    public class SAPXMLObject : BHoMObject
    {
        [XmlIgnore]
        public override Guid BHoM_Guid { get; set; } = Guid.NewGuid();
        [XmlIgnore]
        public override Dictionary<string, object> CustomData { get; set; }
        [XmlIgnore]
        public override string Name { get; set; }
        [XmlIgnore]
        public override FragmentSet Fragments { get; set; }
        [XmlIgnore]
        public override HashSet<string> Tags { get; set; }
    }
}
