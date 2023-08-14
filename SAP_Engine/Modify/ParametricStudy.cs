/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;

using System.ComponentModel;

using BH.Engine.Base;
using System.IO;
using BH.oM.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Adapter.Commands;
using BH.oM.Analytical.Elements;
using static System.Net.WebRequestMethods;
using BH.oM.Environment.SAP.JSON;
using System.Text.Json;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify a SAPReport based on opening type iterators.")]
        [Input("sapObjList", "Input the list of SAPReport object to modify.")]
        [Input("iterations", "Input the iterators.")]
        [Input("directory", "Input the directory for the study.")]
        [Input("psiValues", "Input psiValues.")]
        [MultiOutput(0, "SAPReports", "A list of the SAPReports.")]
        [MultiOutput(1, "saveFiles", "A list of file settings objects corresponding to each iteration")]
        public static Output<List<SAPReport>, List<FileSettings>> ParametricStudy(this List<SAPReport> sapObjList, List<Parameters> iterations, string directory, string study, BH.oM.Environment.SAP.PsiValues psiValues)
        {
            //All un-modified reports are included in the output
            List<SAPReport> reports = sapObjList;


            List<oM.Environment.SAP.JSON.Dwelling> baseDwellings = sapObjList.Select(x => new oM.Environment.SAP.JSON.Dwelling
                                                                            {
                                                                                BuildingIdentifier = x.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier,
                                                                                FilePath = $"0000_{x.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier}.xml"
                                                                            }).ToList();
            Iteration baseIteration = new Iteration {  IterationName = "Base Study", IterationCode = "0000", Dwellings = baseDwellings };



            List<FileSettings> files = sapObjList.Select(x => new FileSettings { Directory = directory, FileName = $"0000_{x.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier}.xml" }).ToList();

            //Checking to make sure iterations have unique names
            List<string> iterationName = iterations.Select(x => x.IterationName).ToList();
            if (iterationName.Count > iterationName.Distinct().Count())
            {
                BH.Engine.Base.Compute.RecordError("Please make sure your iterations have unique names.");
                return null;
            }

            //Checking to make sure dwellings have unique names
            List<string> dwellings = files.Select(x => x.FileName).ToList();
            if (dwellings.Count > dwellings.Distinct().Count())
            {
                BH.Engine.Base.Compute.RecordError("Please make sure your dwellings have unique names.");
                return null;
            }

            JSONReport report = new JSONReport();
            List<Iteration> iterationList = new List<Iteration> { baseIteration };  


            int count = 1;
            foreach (var i in iterations)
            {
                string countFormat = $"{string.Format("{0:0000}", count)}";

                //QA file - setting up the Iteration 
                BH.oM.Environment.SAP.JSON.Iteration iterationJson = new Iteration
                {
                    IterationCode = countFormat,
                    IterationName = (i.IterationName == null ? countFormat : i.IterationName)
                };

                var studyResult = sapObjList.Select(x => x.RunParametricStudy(i, directory, psiValues, count));

                reports = reports.Concat(studyResult.Select(x => x.Item1)).ToList();
                files = files.Concat(studyResult.Select(x => x.Item2)).ToList();

                iterationJson.Dwellings = studyResult.Select(x => x.Item3).ToList();

                iterationList.Add(iterationJson);

                count++;
            }

            report.Iterations = iterationList;

            string jsonPath = $"{directory}\\QA.json";

            string JSONFile = BH.Engine.Serialiser.Convert.ToJson(report);
            System.IO.File.WriteAllText(jsonPath, JSONFile);

            return new Output<List<SAPReport>, List<FileSettings>>()
            {
                Item1 = reports,
                Item2 = files
            };
        }

        [Description("Modify a SAPReport based on opening type iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("iteration", "Input titeration object.")]
        [Input("directory", "Input the directory for the study.")]
        [Input("psiValues", "Input psiValues.")]
        [Input("count", "Count of iteration.")]
        [MultiOutput(0, "SAPReports", "A list of the SAPReports.")]
        [MultiOutput(1, "saveFiles", "A list of file settings objects corresponding to each iteration.")]
        public static Output<SAPReport, FileSettings, BH.oM.Environment.SAP.JSON.Dwelling> RunParametricStudy(this SAPReport sapObj, Parameters iteration, string directory, BH.oM.Environment.SAP.PsiValues psiValues, int count)
        {
            SAPReport reportObj = sapObj.DeepClone();

            string countFormat = $"{string.Format("{0:0000}", count)}";

            //QA file - setting up the dwelling
            BH.oM.Environment.SAP.JSON.Dwelling dwellingJSON = new BH.oM.Environment.SAP.JSON.Dwelling
            {
                BuildingIdentifier = sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier
            };

            //Modify the SAPReport in the ways specified in the iteration set up

            //Opening type modifications
            var openingType = reportObj.ParametricsOpeningType(iteration.OpeningTypes, countFormat);

            reportObj = openingType.Item1;
            dwellingJSON.OpeningTypes = openingType.Item2;

            //Opening modifications
            var opening = reportObj.ParametricsOpening(iteration.Openings, countFormat);

            reportObj = opening.Item1;
            dwellingJSON.Openings = opening.Item2;

            //Orientation
            var orientation = reportObj.ParametricsOrientation(iteration.Orientation, countFormat);

            reportObj = orientation.Item1;
            dwellingJSON.Orientation = orientation.Item2;
            dwellingJSON.Openings = dwellingJSON.Openings.MergeJsonOpening(orientation.Item3);

            //Wall modifications
            var wall = reportObj.ParametricsWall(iteration.Walls, countFormat);

            reportObj = wall.Item1;
            dwellingJSON.Walls = wall.Item2;

            //Roof modifications
            var roof = reportObj.ParametricsRoof(iteration.Roofs, countFormat);

            reportObj = roof.Item1;
            dwellingJSON.Roofs = roof.Item2;

            //Floor modifications
            var floor = reportObj.ParametricsFloor(iteration.Floors, countFormat);

            reportObj = floor.Item1;
            dwellingJSON.Floors = floor.Item2;

            //Create thermal bridges from opening
            reportObj = reportObj.ThermalBridgesFromOpening(psiValues);

            //Thermal bridge modifications
            var thermalBridge = reportObj.ParametricsThermalBridge(iteration.ThermalBridges, countFormat);

            reportObj = thermalBridge.Item1;
            dwellingJSON.ThermalBridges = thermalBridge.Item2;


            //File settings
            FileSettings iterationFile = new FileSettings
            {
                FileName = $"{string.Format("{0:0000}",count)}_{sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier}.xml",
                Directory = directory
            };

            dwellingJSON.FilePath = iterationFile.FileName;

            return new Output<SAPReport, FileSettings, BH.oM.Environment.SAP.JSON.Dwelling>()
            {
                Item1 = reportObj,
                Item2 = iterationFile,
                Item3 = dwellingJSON
            };
        }

        [Description("Modify a SAPReport based on opening type iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("openingTypeObj", "Input the opening type iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOpeningTypes", "Tracking the changes made to the uvalues and gvalue to the opening types.")]
        public static Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>> ParametricsOpeningType (this SAPReport sapObj, List<OpeningTypeIterator> openingTypeObj, string iterationName)
        {
            if (openingTypeObj == null)
            {
                return new Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>>() { Item1 = sapObj, Item2 = null };
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingTypeObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has opening types that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List<BH.oM.Environment.SAP.JSON.OpeningType> typeChanges = new List<oM.Environment.SAP.JSON.OpeningType>();

            foreach (var i in openingTypeObj)
            {
                var openingTypeMods = sapObj.ModifyOpeningTypes(i.Include, i.UValue, i.GValue);

                sapObj = openingTypeMods.Item1;
                typeChanges = typeChanges.Concat(openingTypeMods.Item2).ToList();
                //TODO
                //typeChanges.AddRange(openingTypeMods.Item2);
            }

            return new Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>>() { Item1 = sapObj, Item2 = typeChanges };
        }

        [Description("Modify a SAPReport based on opening iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("openingsObj", "Input the opening iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOpenings", "Tracking the changes made to the height, width, and pitch to the openings.")]
        public static Output<SAPReport, List<oM.Environment.SAP.JSON.Opening>> ParametricsOpening(this SAPReport sapObj, List<OpeningIterator> openingsObj, string iterationName)
        {
            if (openingsObj == null)
            {
                return new Output<SAPReport, List<oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = null };
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has openings that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List<BH.oM.Environment.SAP.JSON.Opening> openingChanges = new List<oM.Environment.SAP.JSON.Opening>();

            foreach (var i in openingsObj)
            {
                var openingMods = sapObj.ModifyOpenings(i.Include, i.Height, i.Width, i.Pitch);

                sapObj = openingMods.Item1;
                openingChanges = openingChanges.Concat(openingMods.Item2).ToList();
                //TODO
                //openingChanges.AddRange(openingMods.Item2);
            }

            return new Output<SAPReport, List<oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = openingChanges };
        }

        [Description("WARNING : check order of rotation and mirror, the rotation is performed first. Modify a SAPReport based on orientation iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("orientationsObj", "Input the orientation iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOrientation", "Tracking the changes made to the orientation of the dwelling and the Photovoltaic arrays.")]
        [MultiOutput(2, "changesToOpenings", "Tracking the changes made to the orientation of the openings.")]
        public static Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>> ParametricsOrientation(this SAPReport sapObj, OrientationIterator orientationsObj, string iterationName)
        {
            if (orientationsObj == null)
            {
                return new Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = null, Item3 = null};
            }

            BH.Engine.Base.Compute.RecordNote("Check order of rotation and mirror, the rotation is performed first.");

            var orientationMods = sapObj.ModifyOrientations(orientationsObj.Rotation, orientationsObj.Mirror);

            sapObj = orientationMods.Item1;

            return new Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = orientationMods.Item2, Item3 = orientationMods.Item3 };
        }

        [Description("Modify a SAPReport based on wall iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("wallsObj", "Input the wall iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToWalls", "Tracking the changes made to the uvalue, and the curtain wall status of the floors.")]
        public static Output<SAPReport, List<oM.Environment.SAP.JSON.Wall>> ParametricsWall(this SAPReport sapObj, List<WallIterator> wallsObj, string iterationName)
        {
            if (wallsObj == null)
            {
                return new Output<SAPReport, List<oM.Environment.SAP.JSON.Wall>>() { Item1 = sapObj, Item2 = null };
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = wallsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has walls that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List<oM.Environment.SAP.JSON.Wall> wallChanges = new List<oM.Environment.SAP.JSON.Wall> ();

            foreach (var w in wallsObj)
            {
                var wallMods = sapObj.ModifyWalls(w.Include, w.UValue, w.CurtainWall);

                sapObj = wallMods.Item1;
                wallChanges = wallChanges.Concat(wallMods.Item2).ToList();
            }

            return new Output<SAPReport, List<oM.Environment.SAP.JSON.Wall>>() { Item1 = sapObj, Item2 = wallChanges };
        }

        [Description("Modify a SAPReport based on roof iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("roofsObj", "Input the roof iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToRoofs", "Tracking the changes made to the uvalue of the roofs.")]
        public static Output<SAPReport, List<UValue>> ParametricsRoof(this SAPReport sapObj, List<RoofIterator> roofsObj, string iterationName)
        {
            if (roofsObj == null)
            {
                return new Output<SAPReport, List<UValue>>() { Item1 = sapObj, Item2 = null };
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = roofsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has roofs that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List<UValue> roofChanges = new List<UValue>();

            foreach (var w in roofsObj)
            {
                var roofMods = sapObj.ModifyRoofs(w.Include, w.UValue);

                sapObj = roofMods.Item1;
                roofChanges = roofChanges.Concat(roofMods.Item2).ToList();
            }

            return new Output<SAPReport, List<UValue>>() { Item1 = sapObj, Item2 = roofChanges };
        }

        [Description("Modify a SAPReport based on floor iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("floorsObj", "Input the floor iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToFloors", "Tracking the changes made to the uvalue of the floors.")]
        public static Output<SAPReport, List<UValue>> ParametricsFloor(this SAPReport sapObj, List<FloorIterator> floorsObj, string iterationName)
        {
            if (floorsObj == null)
            {
                return new Output<SAPReport, List<UValue>>() { Item1 = sapObj, Item2 = null };
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = floorsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has floors that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List<UValue> floorChanges = new List<UValue>();

            foreach (var f in floorsObj)
            {
                var floorMods = sapObj.ModifyRoofs(f.Include, f.UValue);

                sapObj = floorMods.Item1;
                floorChanges = floorChanges.Concat(floorMods.Item2).ToList();
            }

            return new Output<SAPReport, List<UValue>>() { Item1 = sapObj, Item2 = floorChanges };
        }

        [Description("Modify a SAPReport based on thermal bridge iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("thermalBridgeObj", "Input the thermal bridge iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToThermalBridges", "Tracking the changes made to the psiValues of the thermal bridges.")]
        public static Output<SAPReport, List<oM.Environment.SAP.JSON.ThermalBridge>> ParametricsThermalBridge(this SAPReport sapObj, List<ThermalBridgeIterator> thermalBridgeObj, string iterationName)
        {
            if (thermalBridgeObj == null)
            {
                return new Output<SAPReport, List<oM.Environment.SAP.JSON.ThermalBridge>> { Item1 = sapObj, Item2 = null };
            }

            var thermalBridges = thermalBridgeObj.Select(x => x.Include).ToList();
            //Checks if TB are not assigned multiple times selected to include are not overlapping.
            
            var psiValues = thermalBridgeObj.Select(x => x.PsiValue).ToList();

            if (thermalBridges.Count != thermalBridges.Distinct().Count())
            {
                string e = $"Iteration \"{iterationName}\" has thermal bridges that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }
            
            if (thermalBridges.Count() != psiValues.Count)
            {
                string e = $"Iteration \"{iterationName}\" not all thermal bridges are assigned a psi value. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List < oM.Environment.SAP.JSON.ThermalBridge > tbChanges = new List<oM.Environment.SAP.JSON.ThermalBridge> ();

            foreach (var tb in thermalBridgeObj)
            {
                var tbMods = sapObj.ModifyThermalBridges(tb.Include, tb.PsiValue);

                sapObj = tbMods.Item1;
                tbChanges = tbChanges.Concat(tbMods.Item2).ToList();
            }

            return new Output<SAPReport, List<oM.Environment.SAP.JSON.ThermalBridge>> { Item1 = sapObj, Item2 = tbChanges };
        }
    }
}

