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
        [Description("Iterate through sap openings.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("iteration", "Input the iteration settings.")]
        [Input("saveFile", "Input the file settings, the file name will be changed based on the iteration.")]
        [MultiOutput(0, "sapObjects", "Mulitple iterations of the sapObject.")]
        [MultiOutput(1, "fileSettings", "Multiple sets of filesettings.")]
        public static Output<List<SAPReport>, List<FileSettings>> ParametricStudy(this SAPReport sapObj, List<Parameters> iteration, FileSettings saveFile)
        {
            List<SAPReport> reports = new List<SAPReport>
            {
                sapObj 
            };

            List<FileSettings> files = new List<FileSettings>
            {
                saveFile
            };

            foreach (var i in iteration)
            {
                SAPReport reportObj = sapObj.DeepClone();

                if (i.IterationName == null)
                {
                    BH.Engine.Base.Compute.RecordError("Please give all your iterations a name.");
                    return null;
                }

                reportObj = reportObj.ParametricsOpeningType(i.OpeningTypes, i.IterationName);
                reportObj = reportObj.ParametricsOpening(i.Openings, i.IterationName);
                reportObj = reportObj.ParametricsOrientation(i.Orientation, i.IterationName);
                reportObj = reportObj.ParametricsWall(i.Walls, i.IterationName);
                reportObj = reportObj.ParametricsRoof(i.Roofs, i.IterationName);
                reportObj = reportObj.ParametricsFloor(i.Floors, i.IterationName);
                reportObj = reportObj.ParametricsThermalBridge(i.ThermalBridges, i.IterationName);

                reports.Add(reportObj);

                FileSettings iterationFile = new FileSettings
                {
                    FileName = i.IterationName, 
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

        [Description("")]
        public static SAPReport ParametricsOpeningType (this SAPReport sapObj, List<OpeningTypeIterator> openingTypeIObj, string iterationName)
        {
            if (openingTypeIObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingTypeIObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"TestIteration {iterationName} has opening types that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var i in openingTypeIObj)
            {
                sapObj = sapObj.ModifyOpeningTypes(i.TypeName, i.Include, i.UValue, i.GValue);
            }

            return sapObj;

        }

        [Description("")]
        public static SAPReport ParametricsOpening(this SAPReport sapObj, List<OpeningIterator> openingsIObj, string iterationName)
        {
            if (openingsIObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingsIObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"TestIteration {iterationName} has openings that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var i in openingsIObj)
            {
                sapObj = sapObj.ModifyOpenings(i.Include, i.Height, i.Width, i.Pitch);
            }

            return sapObj;

        }

        [Description("WARNING : check order of rotation and mirror, the rotation is performed first.")]
        public static SAPReport ParametricsOrientation(this SAPReport sapObj, OrientationIterator orientationsIObj, string iterationName)
        {
            if (orientationsIObj == null)
            {
                return sapObj;
            }

            if (orientationsIObj.Rotation != null)
            {
                sapObj = sapObj.RotateDwelling(orientationsIObj.Rotation);
            }
            
            if (orientationsIObj.Mirror != Mirror.None)
            {
                sapObj = sapObj.MirrorDwelling(orientationsIObj.Mirror);
            }
            
            return sapObj;

        }

        [Description("")]
        public static SAPReport ParametricsWall(this SAPReport sapObj, List<WallIterator> wallsIObj, string iterationName)
        {
            if (wallsIObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = wallsIObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"TestIteration {iterationName} has walls that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var w in wallsIObj)
            {
                sapObj = sapObj.ModifyWalls(w.Include, w.Description, w.UValue, w.CurtainWall);
            }

            return sapObj;

        }

        [Description("")]
        public static SAPReport ParametricsRoof(this SAPReport sapObj, List<RoofIterator> roofsIObj, string iterationName)
        {
            if (roofsIObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = roofsIObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"TestIteration {iterationName} has walls that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var w in roofsIObj)
            {
                sapObj = sapObj.ModifyRoofs(w.Include, w.Description, w.UValue.ToString());
            }

            return sapObj;

        }

        [Description("")]
        public static SAPReport ParametricsFloor(this SAPReport sapObj, List<FloorIterator> floorsIObj, string iterationName)
        {
            if (floorsIObj == null)
            {
                return sapObj;
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = floorsIObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"TestIteration {iterationName} has floors that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            foreach (var f in floorsIObj)
            {
                sapObj = sapObj.ModifyFloors(f.Include, f.Description, f.UValue);
            }

            return sapObj;

        }

        [Description("")]
        public static SAPReport ParametricsThermalBridge(this SAPReport sapObj, List<ThermalBridgeIterator> tbIObj, string iterationName)
        {
            if (tbIObj == null)
            {
                return sapObj;
            }

            var thermalBridges = tbIObj.Select(x => x.ThermalBridge).ToList();
            //Checks if TB are not assigned multiple times selected to include are not overlapping.
            
            var psiValues = tbIObj.Select(x => x.PsiValue).ToList();

            if (thermalBridges.Count != thermalBridges.Distinct().Count())
            {
                string e = $"TestIteration {iterationName} has thermal bridges that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }
            
            if (thermalBridges.Count != psiValues.Count)
            {
                string e = $"TestIteration {iterationName}: not all thermal bridges are assigned a psi value. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }
            sapObj = sapObj.ModifyThermalBridge(thermalBridges, psiValues);

            return sapObj;
        }
    }
}

