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

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Run iterations set up through the Parameters object.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("iteration", "Input the iteration settings.")]
        [Input("saveFile", "Input the file settings, the file name will be changed based on the iteration.")]
        [Input("psiValues", "Psi Values of all the thermal bridge objects.")]
        [MultiOutput(0, "sapObjects", "Multiple iterations of the sapObject.")]
        [MultiOutput(1, "fileSettings", "Multiple sets of filesettings.")]
        public static Output<List<SAPReport>, List<FileSettings>> ParametricStudy(this SAPReport sapObj, List<Parameters> iteration, FileSettings saveFile, BH.oM.Environment.SAP.PsiValues psiValues)
        {
            //Output the original file
            List<SAPReport> reports = new List<SAPReport>
            {
                sapObj 
            };

            //Output the original file settings
            List<FileSettings> files = new List<FileSettings>
            {
                saveFile
            };

            //Checking to make sure iterations have unique names
            List<string> iterations = iteration.Select(x => x.IterationName).ToList();

            if (iterations.Count > iterations.Distinct().Count())
            {
                BH.Engine.Base.Compute.RecordError("Please make sure your iterations have unique names.");
                return null;
            }
            
            //For each parametric study set up
            foreach (var i in iteration)
            {
                SAPReport reportObj = sapObj.DeepClone();

                if (i.IterationName == null)
                {
                    BH.Engine.Base.Compute.RecordError("Please name all of your iterations.");
                    return null;
                }

                //Modify the SAPReport in the ways specified in the iteration set up
                reportObj = reportObj.ParametricsOpeningType(i.OpeningTypes, i.IterationName);
                reportObj = reportObj.ParametricsOpening(i.Openings, i.IterationName);
                reportObj = reportObj.ParametricsOrientation(i.Orientation, i.IterationName);
                reportObj = reportObj.ParametricsWall(i.Walls, i.IterationName);
                reportObj = reportObj.ParametricsRoof(i.Roofs, i.IterationName);
                reportObj = reportObj.ParametricsFloor(i.Floors, i.IterationName);
                reportObj = reportObj.ThermalBridgesFromOpening(psiValues);
                reportObj = reportObj.ParametricsThermalBridge(i.ThermalBridges, i.IterationName);

                reports.Add(reportObj);

                FileSettings iterationFile = new FileSettings
                {
                    FileName = $"{i.IterationName}_{saveFile.FileName}", 
                    Directory = saveFile.Directory
                };

                files.Add(iterationFile);
            }

            return new Output<List<SAPReport>, List<FileSettings>>()
            {
                Item1 = reports, 
                Item2 = files
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
                sapObj = sapObj.ModifyOpeningTypes(i.TypeName, i.Include, i.UValue, i.GValue);
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
                sapObj = sapObj.ModifyWalls(w.Include, w.Description, w.UValue, w.CurtainWall);
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
                sapObj = sapObj.ModifyRoofs(w.Include, w.Description, w.UValue.ToString());
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
                sapObj = sapObj.ModifyFloors(f.Include, f.Description, f.UValue);
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

            var thermalBridges = thermalBridgeObj.Select(x => x.ThermalBridge).ToList();
            //Checks if TB are not assigned multiple times selected to include are not overlapping.
            
            var psiValues = thermalBridgeObj.Select(x => x.PsiValue).ToList();

            if (thermalBridges.Count != thermalBridges.Distinct().Count())
            {
                string e = $"Iteration \"{iterationName}\" has thermal bridges that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }
            
            if (thermalBridges.Count != psiValues.Count)
            {
                string e = $"Iteration \"{iterationName}\" not all thermal bridges are assigned a psi value. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }
            sapObj = sapObj.ModifyThermalBridge(thermalBridges, psiValues);

            return sapObj;
        }
    }
}

