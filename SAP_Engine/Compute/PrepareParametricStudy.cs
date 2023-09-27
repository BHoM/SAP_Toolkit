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

using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        [Description("Prepare a parametric study for a given set of SAP Reports, and a given collection of iteration types (wall iterations, floor iterations, opening iterations, etc.). Iterations will be blended to create multiple iteration objects.\n\n" +
            "For example, for a given initial SAP Report (A), and provided Wall Iteration (W), Roof Iteration (R), and Opening Iteration (O), we will get the following outputs:\n\n" +
            "A (the initial report)\n" +
            "AW (initial + wall)\n" +
            "AR (initial + roof)\n" +
            "AWR (initial + wall + roof)\n" +
            "AO (initial + opening)\n" +
            "AWO (initial + wall + opening)\n" +
            "ARO (initial + roof + opeinng)\n" +
            "AWRO (initial + wall + roof + opening)\n\n" +
            "If you want a parmetric study WITHOUT this full blending, use the PrepareParametricStudy component which takes the specific type of iteration in as an input.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iterations", "The collection of iteration objects to produce multiple SAP Reports from.")]
        [Input("includeOriginalReports", "Decide whether to include the initial SAP Reports in the output of creating the parametric studies. Defaults to false, indicating that the original reports will NOT be returned from this method. If set to true, then they will be included in the output as well.")]
        [Output("sapReports", "The SAP Reports modified in line with the iteration objects.")]
        public static List<SAPReport> PrepareParametricStudy(this List<SAPReport> initialSAPReports, List<IIteration> iterations, bool includeOriginalReports = false)
        {
            List<SAPReport> allReports = new List<SAPReport>(initialSAPReports);
            List<SAPReport> rtnReports = new List<SAPReport>();

            var iterationTypes = iterations.Select(x => x.GetType()).Distinct();

            foreach(var type in iterationTypes)
            {
                var iterationsOfType = iterations.Where(x => x.GetType() == type).ToList();
                List<SAPReport> reportsForType = new List<SAPReport>();
                foreach (var iteration in iterationsOfType)
                {
                    var study = PrepareParametricStudy(allReports, iteration as dynamic);
                    if(study != null)
                        reportsForType.AddRange(study);
                }

                allReports.AddRange(reportsForType);
                rtnReports.AddRange(reportsForType);
            }

            if (includeOriginalReports)
                return allReports;
            else
                return rtnReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Floors of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Floor Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified floors according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, FloorIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            //To be thread safe on the parallel for loops below, convert the List<string> to ConcurrentBag<string>
            ConcurrentBag<string> includedItems = new ConcurrentBag<string>();
            if (iteration.Include != null)
                includedItems = new ConcurrentBag<string>(iteration.Include);

            Parallel.ForEach(newReports, report =>
            {
                foreach(var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                {
                    for(int x = 0; x < part.FloorDimensions.FloorDimension.Count; x++)
                    {
                        if (includedItems.Count == 0 || includedItems.Contains(part.FloorDimensions.FloorDimension[x].Description) && !double.IsNaN(iteration.UValue))
                            part.FloorDimensions.FloorDimension[x].UValue = iteration.UValue.ToString();
                    }

                    part.Identifier = $"{part.Identifier}{iteration.Prefix}{iteration.Name}";
                }
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Walls of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Wall Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified walls according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, WallIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            //To be thread safe on the parallel for loops below, convert the List<string> to ConcurrentBag<string>
            ConcurrentBag<string> includedItems = new ConcurrentBag<string>();
            if (iteration.Include != null)
                includedItems = new ConcurrentBag<string>(iteration.Include);

            Parallel.ForEach(newReports, report =>
            {
                foreach (var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                {
                    for (int x = 0; x < part.Walls.Wall.Count; x++)
                    {
                        if (includedItems.Count == 0 || includedItems.Contains(part.Walls.Wall[x].Description))
                        {
                            if(!double.IsNaN(iteration.UValue))
                                part.Walls.Wall[x].UValue = iteration.UValue.ToString();

                            if (iteration.IsCurtainWall.HasValue)
                                part.Walls.Wall[x].CurtainWall = iteration.IsCurtainWall.Value;
                        }
                    }

                    part.Identifier = $"{part.Identifier}{iteration.Prefix}{iteration.Name}";
                }
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Openings of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Opening Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified openings according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, OpeningIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            //To be thread safe on the parallel for loops below, convert the List<string> to ConcurrentBag<string>
            ConcurrentBag<string> includedItems = new ConcurrentBag<string>();
            if (iteration.Include != null)
                includedItems = new ConcurrentBag<string>(iteration.Include);

            Parallel.ForEach(newReports, report =>
            {
                //Dictionary for the conversion between the name of the type given by the user and the name of the opening that matches the schema.
                Dictionary<string, string> typeMap = new Dictionary<string, string>();
                foreach (var type in report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType)
                {
                    if (!typeMap.ContainsKey(type.Name))
                        typeMap.Add(type.Name, type.Description);
                }

                foreach (var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                {
                    for (int x = 0; x < part.Openings.Opening.Count; x++)
                    {
                        if (includedItems.Count == 0 || includedItems.Contains(typeMap[part.Openings.Opening[x].Type]))
                        {
                            if (!double.IsNaN(iteration.Height))
                                part.Openings.Opening[x].Height = iteration.Height;

                            if (!double.IsNaN(iteration.Width))
                                part.Openings.Opening[x].Width = iteration.Width;

                            if(!string.IsNullOrEmpty(iteration.Pitch))
                                part.Openings.Opening[x].Pitch = iteration.Pitch;
                        }
                    }

                    part.Identifier = $"{part.Identifier}{iteration.Prefix}{iteration.Name}";
                }
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Roofs of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Roof Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified roofs according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, RoofIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            //To be thread safe on the parallel for loops below, convert the List<string> to ConcurrentBag<string>
            ConcurrentBag<string> includedItems = new ConcurrentBag<string>();
            if (iteration.Include != null)
                includedItems = new ConcurrentBag<string>(iteration.Include);

            Parallel.ForEach(newReports, report =>
            {
                foreach (var part in report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
                {
                    for (int x = 0; x < part.Roofs.Roof.Count; x++)
                    {
                        if (includedItems.Count == 0 || includedItems.Contains(part.Roofs.Roof[x].Description) && !double.IsNaN(iteration.UValue))
                            part.Roofs.Roof[x].UValue = iteration.UValue.ToString();
                    }

                    part.Identifier = $"{part.Identifier}{iteration.Prefix}{iteration.Name}";
                }
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Thermal Bridges of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Thermal Bridge Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified thermal bridges according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, ThermalBridgeIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            if (iteration.Values == null || iteration.Values.Count == 0)
                return null; //Nothing to be done

            foreach(var value in iteration.Values)
                newReports = PrepareParametricStudy(newReports, value); //Can't be parallel because we want each value to run on all reports for a single iteration

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Opening Types of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Opening Type Iterations for U Values to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified opening types according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, OpeningTypeUValueIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            //To be thread safe on the parallel for loops below, convert the List<string> to ConcurrentBag<string>
            ConcurrentBag<string> includedItems = new ConcurrentBag<string>();
            if (iteration.Include != null)
                includedItems = new ConcurrentBag<string>(iteration.Include);

            Parallel.ForEach(newReports, report =>
            {
                for (int x = 0; x < report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType.Count; x++)
                {
                    if (includedItems.Count == 0 || includedItems.Contains(report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType[x].Description))
                    {
                        if (!double.IsNaN(iteration.UValue))
                            report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType[x].UValue = iteration.UValue.ToString();
                    }
                }

                string identifier = report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier;
                report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier = $"{identifier}{iteration.Prefix}{iteration.Name}";
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Opening Types of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Opening Type Iterations for G Values to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified opening types according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, OpeningTypeGValueIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            //To be thread safe on the parallel for loops below, convert the List<string> to ConcurrentBag<string>
            ConcurrentBag<string> includedItems = new ConcurrentBag<string>();
            if (iteration.Include != null)
                includedItems = new ConcurrentBag<string>(iteration.Include);

            Parallel.ForEach(newReports, report =>
            {
                for (int x = 0; x < report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType.Count; x++)
                {
                    if (includedItems.Count == 0 || includedItems.Contains(report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType[x].Description))
                    {
                        if (!double.IsNaN(iteration.GValue))
                            report.SAP10Data.PropertyDetails.OpeningTypes.OpeningType[x].GValue = iteration.GValue.ToString();
                    }
                }

                string identifier = report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier;
                report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier = $"{identifier}{iteration.Prefix}{iteration.Name}";
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Orientation of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Orientation Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified orientations according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, OrientationIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            if (iteration.Mirror == Mirror.None && (iteration.Rotation == Rotation.Zero || iteration.Rotation == Rotation.ThreeHundredSixty))
                return newReports; //No further changes to make, no mirror and rotation would match existing

            ConcurrentBag<string> excludedOrientations = new ConcurrentBag<string>();
            excludedOrientations.Add("0");
            excludedOrientations.Add("9");
            excludedOrientations.Add("ND");
            excludedOrientations.Add("NR");

            Parallel.ForEach(newReports, report =>
            {
                if (!excludedOrientations.Contains(report.SAP10Data.PropertyDetails.Orientation))
                {
                    //Current orientation can be mirrored
                    List<int> compassPoints = new List<int> { (int)iteration.Mirror, (int)iteration.Mirror + 4 };

                    int orientationValue = -1;
                    try
                    {
                        orientationValue = int.Parse(report.SAP10Data.PropertyDetails.Orientation);
                    }
                    catch { }

                    if (orientationValue != -1)
                    {
                        int distance = compassPoints.Select(x => x - orientationValue).Min();
                        int compassDirection = (orientationValue + 2 * distance) % 8;
                        if (compassDirection <= 0)
                            compassDirection += 8;

                        report.SAP10Data.PropertyDetails.Orientation = compassDirection.ToString();

                        compassDirection = (compassDirection + (int)iteration.Rotation) % 8;
                        if (compassDirection <= 0)
                            compassDirection += 8;

                        report.SAP10Data.PropertyDetails.Orientation = compassDirection.ToString();
                    }
                }

                string identifier = report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier;
                report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier = $"{identifier}{iteration.Prefix}{iteration.Name}";
            });

            return newReports;
        }

        [Description("Prepare a parametric study for a given set of SAP Reports, but only making changes to the Air Permeability of the Reports. Iterations will not be blended with this component. The original reports will NOT be included in the returned objects.")]
        [Input("initialSAPReports", "The SAP Report objects to create iterations of.")]
        [Input("iteration", "Air Permeability Iterations to produce iterations of.")]
        [Output("sapReports", "The SAP Reports with modified air permeabilities according to the iterations provided.")]
        public static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, AirPermeabilityIteration iteration)
        {
            List<SAPReport> newReports = initialSAPReports.Select(x => x.DeepClone()).ToList();

            if (double.IsNaN(iteration.AirPermeability))
                return null; //Nothing to change

            Parallel.ForEach(newReports, report =>
            {
                report.SAP10Data.PropertyDetails.Ventilation.AirPermeability = iteration.AirPermeability.ToString();

                string identifier = report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier;
                report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.FirstOrDefault().Identifier = $"{identifier}{iteration.Prefix}{iteration.Name}";
            });

            return newReports;
        }

        /***************************************************/
        /**** Private Fallback Methods                  ****/
        /***************************************************/

        private static List<SAPReport> PrepareParametricStudy(List<SAPReport> initialSAPReports, object iteration)
        {
            BH.Engine.Base.Compute.RecordError($"Parametric iteration for {iteration.GetType().Name} has not been implemented. Please speak to the development team.");
            return initialSAPReports;
        }
    }
}
