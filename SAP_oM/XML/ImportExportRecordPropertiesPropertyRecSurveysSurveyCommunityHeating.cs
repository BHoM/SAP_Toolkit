using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurveyCommunityHeating : IObject
    {

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DistributionLossSpace { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ctrl { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DistributionLossWater { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ChargingLinked { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DistributionLossSpaceValue { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DistributionLossWaterValue { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SpacePCDFIndex { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WaterPCDFIndex { get; set; } = "";

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CommunityHeatSourceRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyCommunityHeatingHeatSourceCommunityHeatSourceRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyCommunityHeatingHeatSourceCommunityHeatSourceRec>> HeatSource { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyCommunityHeatingHeatSourceCommunityHeatSourceRec>>();
    }
}