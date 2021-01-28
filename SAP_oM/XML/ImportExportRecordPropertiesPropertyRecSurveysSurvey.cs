using System;
using System.Xml.Serialization;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportRecordPropertiesPropertyRecSurveysSurvey : IObject
    {
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Status { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SurveyID { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SurveyorID { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Guid { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LastModif { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IsPrimary { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Surveyor { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UserReference { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DwellingOrientation { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CalculationType { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SimpleComplianceScotland { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Created { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AmendmentDate { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ReportIssueDate { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EpcLodgementDate { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LastMassUpdateChange { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Notes { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PropertyType1 { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PropertyType2 { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PositionOfFlat { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FlatWhichFloor { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FlatFloorsAbove { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NumberOfStoreys { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DateBuilt { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ShelteredSides { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SunlightShade { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LivingArea { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermalMass { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermalMassSimple { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermalMassValue { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermalBridgesCalculation { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermalBridgesYvalue { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermalBridgesDescription { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CalculateOverheating { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WindowsInHotWeather { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CrossVentilation { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NightVentilation { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AirChangeRate { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ChimneysMHS { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ChimneysSHS { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ChimneysOther { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OpenFluesMHS { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OpenFluesSHS { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OpenFluesOther { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IntermittentFans { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PassiveVents { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FluelessGasFires { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LightFittings { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LELFittings { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExternalLightsFitted { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExternalLELsFitted { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ElectricityTariff { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SolarPanelPresent { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PressureTest { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DesignedQ50 { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AsBuiltQ50 { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PropertyTested { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SmokeControlArea { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ThermallySeparated { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DraughtProofing { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DraughtLobby { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TerrainType { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Floor1AreaCalculated { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PhotovoltaicUnitApportionedEnergy { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PhotovoltaicUnitType { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MechanicalVentilationDecentralised { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string HeatingsInteraction { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TotalRooms { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Recomm_E { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Recomm_N { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Recomm_U { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Recomm_V2 { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PrintEnergyChartScotland { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PrintEnergyReportScotland { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IATSReference { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IATSDataExists { get; set; } = "";

        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IATSTestDate { get; set; } = "";

        [XmlElement("Tenure", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyTenure> Tenure { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyTenure>();

        [XmlElement("TransactionType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyTransactionType> TransactionType { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyTransactionType>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("BuildingPart", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart>> BuildingParts { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("OpeningTypeRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningTypesOpeningTypeRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningTypesOpeningTypeRec>> OpeningTypes { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningTypesOpeningTypeRec>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("OpeningRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec>> Openings { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StandardWidthRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardWidthsStandardWidthRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardWidthsStandardWidthRec>> StandardWidths { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardWidthsStandardWidthRec>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StandardHeightRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardHeightsStandardHeightRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardHeightsStandardHeightRec>> StandardHeights { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyStandardHeightsStandardHeightRec>>();

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ThermalBridgeRec", typeof(ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec>> ThermalBridges { get; set; } = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec>>();

        [XmlElement("MechanicalVentilation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyMechanicalVentilation> MechanicalVentilation { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyMechanicalVentilation>();

        [XmlElement("CoolingSystem", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyCoolingSystem> CoolingSystem { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyCoolingSystem>();

        [XmlElement("CommunityHeating", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyCommunityHeating> CommunityHeating { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyCommunityHeating>();

        [XmlElement("WaterHeatingSystem", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyWaterHeatingSystem> WaterHeatingSystem { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyWaterHeatingSystem>();

        [XmlElement("RelatedPartyDisclosure", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<ImportExportRecordPropertiesPropertyRecSurveysSurveyRelatedPartyDisclosure> RelatedPartyDisclosure { get; set; } = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyRelatedPartyDisclosure>();
    }
}