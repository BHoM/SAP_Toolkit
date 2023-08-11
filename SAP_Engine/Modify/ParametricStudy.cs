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
        public static Output<List<SAPReport>, List<FileSettings>> ParametricStudy(this List<SAPReport> sapObjList, List<Parameters> iterations, string directory, BH.oM.Environment.SAP.PsiValues psiValues)
        {
            //All un-modified reports are included in the output
            List<SAPReport> reports = sapObjList;

            //For each unmodified dwelling a matching filesettings object is included in the output
            List<FileSettings> files = sapObjList.Select(x => new FileSettings { Directory = directory, FileName = $"0000_{x.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier}" }).ToList();

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

            int count = 1;
            foreach (var i in iterations)
            {
                var studyResult = sapObjList.Select(x => x.RunParametricStudy(i, directory, psiValues, count));

                reports.AddRange(studyResult.Select(x => x.Item1).ToList());
                files.AddRange(studyResult.Select(x => x.Item2).ToList());

                count++;
            }

            return new Output<List<SAPReport>, List<FileSettings>>()
            {
                Item1 = reports,
                Item2 = files
            };
        }

        [Description("Modify a SAPReport based on opening type iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("iteration", "Input titeration object.")]
        [MultiOutput(0, "SAPReports", "A list of the SAPReports.")]
        [MultiOutput(1, "saveFiles", "A list of file settings objects corresponding to each iteration.")]
        public static Output<SAPReport, FileSettings> RunParametricStudy(this SAPReport sapObj, Parameters iteration, string directory, BH.oM.Environment.SAP.PsiValues psiValues, int count)
        {
            SAPReport reportObj = sapObj.DeepClone();

            string countFormat = $"{string.Format("{0:0000}", count)}";
            //Modify the SAPReport in the ways specified in the iteration set up
            reportObj = reportObj.ParametricsOpeningType(iteration.OpeningTypes, countFormat);
            reportObj = reportObj.ParametricsOpening(iteration.Openings, countFormat);
            reportObj = reportObj.ParametricsOrientation(iteration.Orientation, countFormat);
            reportObj = reportObj.ParametricsWall(iteration.Walls, countFormat);
            reportObj = reportObj.ParametricsRoof(iteration.Roofs, countFormat);
            reportObj = reportObj.ParametricsFloor(iteration.Floors, countFormat);
            reportObj = reportObj.ThermalBridgesFromOpening(psiValues);
            reportObj = reportObj.ParametricsThermalBridge(iteration.ThermalBridges, countFormat);

            //reports.Add(reportObj);

            FileSettings iterationFile = new FileSettings
            {
                FileName = $"{string.Format("{0:0000}",count)}_{sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier}",
                Directory = directory
            };

            return new Output<SAPReport, FileSettings>()
            {
                Item1 = reportObj,
                Item2 = iterationFile
            };
        }

        [Description("Modify a SAPReport based on opening type iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("openingTypeObj", "Input the opening type iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on the opening type.")]
        public static SAPReport ParametricsOpeningType (this SAPReport sapObj, List<OpeningTypeIterator> openingTypeObj, string iterationName)
        {
            if (openingTypeObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingTypeObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has opening types that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var i in openingTypeObj)
            {
                sapObj = sapObj.ModifyOpeningTypes(i.Include, i.UValue, i.GValue);
            }

            return sapObj;
        }

        [Description("Modify a SAPReport based on opening iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("openingsObj", "Input the opening iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on the opening.")]
        public static SAPReport ParametricsOpening(this SAPReport sapObj, List<OpeningIterator> openingsObj, string iterationName)
        {
            if (openingsObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has openings that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var i in openingsObj)
            {
                sapObj = sapObj.ModifyOpenings(i.Include, i.Height, i.Width, i.Pitch);
            }

            return sapObj;
        }

        [Description("WARNING : check order of rotation and mirror, the rotation is performed first. Modify a SAPReport based on orientation iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("orientationsObj", "Input the orientation iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on a transformation.")]
        public static SAPReport ParametricsOrientation(this SAPReport sapObj, OrientationIterator orientationsObj, string iterationName)
        {
            if (orientationsObj == null)
            {
                return sapObj;
            }

            BH.Engine.Base.Compute.RecordNote("Check order of rotation and mirror, the rotation is performed first.");

            if (orientationsObj.Rotation != null)
            {
                sapObj = sapObj.RotateDwelling(orientationsObj.Rotation);
            }
            
            if (orientationsObj.Mirror != Mirror.None)
            {
                sapObj = sapObj.MirrorDwelling(orientationsObj.Mirror);
            }
            
            return sapObj;
        }

        [Description("Modify a SAPReport based on wall iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("wallsObj", "Input the wall iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on the walls.")]
        public static SAPReport ParametricsWall(this SAPReport sapObj, List<WallIterator> wallsObj, string iterationName)
        {
            if (wallsObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = wallsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has walls that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var w in wallsObj)
            {
                sapObj = sapObj.ModifyWalls(w.Include, w.UValue, w.CurtainWall);
            }

            return sapObj;
        }

        [Description("Modify a SAPReport based on roof iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("roofsObj", "Input the roof iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on the roofs.")]
        public static SAPReport ParametricsRoof(this SAPReport sapObj, List<RoofIterator> roofsObj, string iterationName)
        {
            if (roofsObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = roofsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has roofs that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var w in roofsObj)
            {
                sapObj = sapObj.ModifyRoofs(w.Include, w.UValue);
            }

            return sapObj;
        }

        [Description("Modify a SAPReport based on floor iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("floorsObj", "Input the floor iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on the floors.")]
        public static SAPReport ParametricsFloor(this SAPReport sapObj, List<FloorIterator> floorsObj, string iterationName)
        {
            if (floorsObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = floorsObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has floors that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var f in floorsObj)
            {
                sapObj = sapObj.ModifyFloors(f.Include, f.UValue);
            }

            return sapObj;
        }

        [Description("Modify a SAPReport based on thermal bridge iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("thermalBridgeObj", "Input the thermal bridge iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [Output("sapReport", "SAPReport object with changes made based on the thermal bridges.")]
        public static SAPReport ParametricsThermalBridge(this SAPReport sapObj, List<ThermalBridgeIterator> thermalBridgeObj, string iterationName)
        {
            if (thermalBridgeObj == null)
            {
                return sapObj;
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

            foreach (var tb in thermalBridgeObj)
            {
                sapObj = sapObj.ModifyThermalBridge(tb.Include, tb.PsiValue);
            }

            return sapObj;
        }
    }
}

