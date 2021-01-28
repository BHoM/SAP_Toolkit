using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart : IObject
    {

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RoomInRoofFloor { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PropertyAgeBand { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Basement { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TimberFloorSealed { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PartyWalls { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InternalWalls { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExternalRoofs { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InternalCeilings { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string HeatlossFloors { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InternalFloors { get; set; } = "";

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StoreyMeasurementRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec>> StoreyMeasurements { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("WallRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec>> ExternalWalls { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("RoofRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec>> PartyRoofs { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec>>();


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FloorRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec>> PartyFloors { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec>>();
    }
}