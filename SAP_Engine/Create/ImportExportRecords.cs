using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;
using BH.Engine.Geometry;
using BH.oM.Geometry;
using BH.Engine.Base;
using BH.Engine.Units;
using BH.oM.Reflection.Attributes;
using BH.oM.Environment.SAP.XML;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        
        public static List<ImportExportRecord> ImportExportRecords(List<Export> exports, List<ThermalBridges> thermalBridgesList, Parametrics parametrics, TBInput tBInput)
        {
            
            List<ImportExportRecord> importExportRecords = new List<ImportExportRecord>();
            for (int x = 0; x < exports.Count; x++)
            {
                Export export = exports[x];
                ThermalBridges thermalBridges = thermalBridgesList[x];
                ImportExportRecord importExportRecord = new ImportExportRecord();
                List<List<ImportExportRecordSurveyorsSurveyor>> surveyors = new List<List<ImportExportRecordSurveyorsSurveyor>>();
                importExportRecord.Surveyors = surveyors; // Do we care about any of this?
                List<List<ImportExportRecordPropertiesPropertyRec>> propertiesRec = new List<List<ImportExportRecordPropertiesPropertyRec>>();
                propertiesRec.Add(new List<ImportExportRecordPropertiesPropertyRec>());
                ImportExportRecordPropertiesPropertyRec propRec = new ImportExportRecordPropertiesPropertyRec();

                List<ImportExportRecordPropertiesPropertyRecProperty> properties = new List<ImportExportRecordPropertiesPropertyRecProperty>();

                ImportExportRecordPropertiesPropertyRecProperty property = new ImportExportRecordPropertiesPropertyRecProperty();

                property.UserReference = "Index_" + x.ToString();
                property.HouseName = export.Reference + "G:" + parametrics.GValue.ToString() + "_W-U:" + parametrics.WallUValue.ToString() + "_G-U:" + parametrics.GlazUValue.ToString() + "_Q50:" + parametrics.Q50.ToString();

                property.ProjectID = (3700+x).ToString();
                properties.Add(property);
                propRec.Property = properties;
                
                ImportExportRecordPropertiesPropertyRecSurveysSurvey survey = new ImportExportRecordPropertiesPropertyRecSurveysSurvey();
                List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart>> buildingParts = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart>>();
                buildingParts.Add(new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart>());
                ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart buildingPart = new ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPart();


                List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec>> storyMeasurements = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec>>();
                storyMeasurements.Add(new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec>());
                ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec storyMeasurement = new ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartStoreyMeasurementsStoreyMeasurementRec();
                

                storyMeasurement.InternalFloorArea = export.TotalArea.ToString();
                storyMeasurement.InternalPerimeter = export.ExternalWallLength.ToString();
                storyMeasurement.StoreyHeight = export.CeilingHeight.ToString();

                buildingPart.HeatlossFloors = export.ExtFloorArea.ToString(); // Should have an object
                buildingPart.ExternalRoofs = export.ExtRoofArea.ToString(); // Should have an obejct

                List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec>> partyFloors = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec>>();
                partyFloors.Add(new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec>());

                List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec>> partyRoofs = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec>>();
                partyRoofs.Add(new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec>());

                ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec partyRoof = new ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyRoofsRoofRec();
                ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec partyFloor = new ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartPartyFloorsFloorRec();

                partyFloor.Area = export.PartyFloor.ToString();
                partyRoof.Area = export.PartyRoof.ToString();

                List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec>> externalWalls = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec>>();
                externalWalls.Add(new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec>());


                ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec externalWall = new ImportExportRecordPropertiesPropertyRecSurveysSurveyBuildingPartsBuildingPartExternalWallsWallRec();



                survey.SunlightShade = parametrics.SunlightShade;
                survey.WindowsInHotWeather = parametrics.WindowsOpen;
                survey.AirChangeRate = parametrics.AirChangeRate.ToString();

                List<ImportExportRecordPropertiesPropertyRecSurveysSurveyMechanicalVentilation> mechVents = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyMechanicalVentilation>();
                ImportExportRecordPropertiesPropertyRecSurveysSurveyMechanicalVentilation mechanicalVentilation = new ImportExportRecordPropertiesPropertyRecSurveysSurveyMechanicalVentilation();
                mechanicalVentilation.WetRooms = (export.WetRooms + 1).ToString();
                mechanicalVentilation.SedbukItem = export.WetRooms.ToString();

                //Tuple<string, string, List<double>, string, List<double>> clean = new Tuple<string, string, List<double>, string, List<double>>(", "SFP", 0.20, "EFF", 0);

                if (parametrics.MechVentType == "MEVCentralised")
                {
                    List<Tuple<int, string, double, string, double>> mvhrWetrooms = new List<Tuple<int, string, double, string, double>>();
                    Tuple<int, string, double, string, double> no1 = new Tuple<int, string, double, string, double>(1, "SFP", 0.20, "EFF", 0);
                    mvhrWetrooms.Add(no1);
                    Tuple<int, string, double, string, double> no2 = new Tuple<int, string, double, string, double>(2, "SFP", 0.17, "EFF", 0);
                    mvhrWetrooms.Add(no2);
                    Tuple<int, string, double, string, double> no3 = new Tuple<int, string, double, string, double>(3, "SFP", 0.19, "EFF", 0);
                    mvhrWetrooms.Add(no3);
                    Tuple<int, string, double, string, double> no4 = new Tuple<int, string, double, string, double>(4, "SFP", 0.21, "EFF", 0);
                    mvhrWetrooms.Add(no4);
                    Tuple<int, string, double, string, double> no5 = new Tuple<int, string, double, string, double>(5, "SFP", 0.25, "EFF", 0);
                    mvhrWetrooms.Add(no5);

                    Tuple<int, string, double, string, double> tuple = mvhrWetrooms.Where(y => y.Item1 == export.WetRooms).FirstOrDefault();

                    mechanicalVentilation.ManufacturerSFP = tuple.Item3.ToString();
                    mechanicalVentilation.MVHREfficiency = tuple.Item5.ToString();
                    mechanicalVentilation.Type = parametrics.MechVentType;
                }

                else if (parametrics.MechVentType == "BalancedWithHeatRecovery")
                {

                    List<Tuple<int, string, double, string, double>> mevWetrooms = new List<Tuple<int, string, double, string, double>>();
                    Tuple<int, string, double, string, double> no1 = new Tuple<int, string, double, string, double>(1, "SFP", 0.42, "EFF", 91);
                    mevWetrooms.Add(no1);
                    Tuple<int, string, double, string, double> no2 = new Tuple<int, string, double, string, double>(2, "SFP", 0.44, "EFF", 91);
                    mevWetrooms.Add(no2);
                    Tuple<int, string, double, string, double> no3 = new Tuple<int, string, double, string, double>(3, "SFP", 0.52, "EFF", 90);
                    mevWetrooms.Add(no3);
                    Tuple<int, string, double, string, double> no4 = new Tuple<int, string, double, string, double>(4, "SFP", 0.63, "EFF", 90);
                    mevWetrooms.Add(no4);
                    Tuple<int, string, double, string, double> no5 = new Tuple<int, string, double, string, double>(5, "SFP", 0.76, "EFF", 90);
                    mevWetrooms.Add(no5);

                    Tuple<int, string, double, string, double> tuple = mevWetrooms.Where(y => y.Item1 == export.WetRooms).FirstOrDefault();
                    mechanicalVentilation.ManufacturerSFP = tuple.Item3.ToString();
                    mechanicalVentilation.MVHREfficiency = tuple.Item5.ToString();
                    mechanicalVentilation.Type = parametrics.MechVentType;
                }
                else BH.Engine.Reflection.Compute.RecordError("Error setting Mech vent types");

                mechVents.Add(mechanicalVentilation);
                survey.MechanicalVentilation = mechVents;
                partyFloors[0].Add(partyFloor);
                buildingPart.PartyFloors = partyFloors;
                partyRoofs[0].Add(partyRoof);
                buildingPart.PartyRoofs = partyRoofs;
                buildingPart.StoreyMeasurements = storyMeasurements;



                survey.LivingArea = export.LivingArea.ToString();
                survey.ShelteredSides = export.ShelteredSides.ToString();
                survey.CrossVentilation = export.CrossVentilation.ToString();
                survey.DesignedQ50 = parametrics.Q50.ToString();

                ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningTypesOpeningTypeRec openingRec = new ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningTypesOpeningTypeRec();
                openingRec.SolarTrans = parametrics.GValue.ToString();
                openingRec.UValue = parametrics.GlazUValue.ToString();

                List<ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec> openings = new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec>();
                double totalWindowArea = 0;

                for (int y = 0; y < export.WindowHeight.Count; y++)
                {
                    ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec opening = new ImportExportRecordPropertiesPropertyRecSurveysSurveyOpeningsOpeningRec();
                    opening.Description = "Window_" + y;
                    opening.Area = (export.WindowHeight[y] * export.WindowLength[y]).ToString();
                    opening.OverhangRatio = export.OverhangRatio[y].ToString();
                    opening.WideOverhang = export.WideOverhang[y].ToString();
                    totalWindowArea += export.WindowHeight[y] * export.WindowLength[y];
                    opening.Orientation = export.OrientationDegrees.ToString();
                    opening.CurtainClosed = parametrics.CurtainsClosed.ToString();
                    opening.CurtainType = parametrics.CurtainType;
                    openings.Add(opening);
                }

                externalWall.Area = (export.ExternalWallHeight * export.ExternalWallLength).ToString();
                externalWall.AreaCalculationType = "Gross";
                externalWall.UValue = parametrics.WallUValue.ToString();
                externalWall.NettArea = (export.ExternalWallHeight * export.ExternalWallLength - totalWindowArea).ToString();
                externalWall.OpeningsArea = totalWindowArea.ToString();

                externalWalls[0].Add(externalWall);
                buildingPart.ExternalWalls = externalWalls;
                buildingParts[0].Add(buildingPart);
                survey.BuildingParts = buildingParts; // List handling problem

                // ThermalBridges
                List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec>> bridges = new List<List<ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec>>();
                bridges.Add(new List<ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec>());
                if (parametrics.CalculateThermalBridges)
                {
                    List<Tuple<string, string, double, double>> tuples = new List<Tuple<string, string, double, double>>();
                    Tuple<string, string, double, double> e2 = new Tuple<string, string, double, double>("E2", "Other Lintels", tBInput.E2, thermalBridges.E2); // Acronym, type, Psivalue, Length
                    tuples.Add(e2);
                    Tuple<string, string, double, double> e3 = new Tuple<string, string, double, double>("E3", "Sill", tBInput.E3, thermalBridges.E3); // Acronym, type, Psivalue, Length
                    tuples.Add(e3);
                    Tuple<string, string, double, double> e4 = new Tuple<string, string, double, double>("E4", "Jamb", tBInput.E4, thermalBridges.E4); // Acronym, type, Psivalue, Length
                    tuples.Add(e4);
                    Tuple<string, string, double, double> e7 = new Tuple<string, string, double, double>("E7", "PartyFloor", tBInput.E7, thermalBridges.E7); // Acronym, type, Psivalue, Length
                    tuples.Add(e7);
                    Tuple<string, string, double, double> e10 = new Tuple<string, string, double, double>("E10", "EavesAtCeiling", tBInput.E10, thermalBridges.E10); // Acronym, type, Psivalue, Length
                    tuples.Add(e10);
                    Tuple<string, string, double, double> e15 = new Tuple<string, string, double, double>("E15", "FlatRoofWithParapet", tBInput.E15, thermalBridges.E15); // Acronym, type, Psivalue, Length
                    tuples.Add(e15);
                    Tuple<string, string, double, double> e16 = new Tuple<string, string, double, double>("E16", "CornerNormal", tBInput.E16, thermalBridges.E16); // Acronym, type, Psivalue, Length
                    tuples.Add(e16);
                    Tuple<string, string, double, double> e17 = new Tuple<string, string, double, double>("E17", "CornerInverted", tBInput.E17, thermalBridges.E17); // Acronym, type, Psivalue, Length
                    tuples.Add(e17);
                    Tuple<string, string, double, double> e18 = new Tuple<string, string, double, double>("E18", "PartyWall", tBInput.E18, thermalBridges.E18); // Acronym, type, Psivalue, Length
                    tuples.Add(e18);
                    Tuple<string, string, double, double> e23 = new Tuple<string, string, double, double>("E23", "BalconyBetweenDwellingsPenetrates", tBInput.E23, thermalBridges.E23); // Acronym, type, Psivalue, Length
                    tuples.Add(e23);
                    Tuple<string, string, double, double> e25 = new Tuple<string, string, double, double>("E25", "CornerInverted", tBInput.E25, thermalBridges.E25); // Acronym, type, Psivalue, Length
                    tuples.Add(e25);

                    foreach (var tuple in tuples)
                    {
                        ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec bridge = new ImportExportRecordPropertiesPropertyRecSurveysSurveyThermalBridgesThermalBridgeRec();
                        bridge.Adjusted = tuple.Item3.ToString();
                        bridge.K1Index = tuple.Item2.ToString();
                        bridge.PsiValue = tuple.Item3.ToString();
                        bridge.Length = tuple.Item4.ToString();
                        bridges[0].Add(bridge);

                    }
                }

                survey.ThermalBridges = bridges; 


                importExportRecords.Add(importExportRecord);
            }
                return importExportRecords;
        }
    }
}
