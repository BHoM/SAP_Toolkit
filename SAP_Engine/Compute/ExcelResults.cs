///*
// * This file is part of the Buildings and Habitats object Model (BHoM)
// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
// *
// * Each contributor holds copyright over their respective contributions.
// * The project versioning (Git) records all such contribution source information.
// *                                           
// *                                                                              
// * The BHoM is free software: you can redistribute it and/or modify         
// * it under the terms of the GNU Lesser General Public License as published by  
// * the Free Software Foundation, either version 3.0 of the License, or          
// * (at your option) any later version.                                          
// *                                                                              
// * The BHoM is distributed in the hope that it will be useful,              
// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
// * GNU Lesser General Public License for more details.                          
// *                                                                            
// * You should have received a copy of the GNU Lesser General Public License     
// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
// */

//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;

//using BH.oM.Base.Attributes;
//using BH.oM.Environment.SAP;
//using BH.oM.Environment.Elements;
//using BH.oM.Geometry;
//using BH.Engine.Geometry;
//using BH.Engine.Units;
//using BH.oM.Spatial.SettingOut;
//using BH.oM.Analytical.Elements;
//using BH.oM.Base;
//using BH.Engine.Base;
//using BH.oM.Environment.SAP.XML;
//using System.Reflection;

//namespace BH.Engine.Environment.SAP
//{
//    public static partial class Compute
//    {
//        /***************************************************/
//        /**** Public Methods                            ****/
//        /***************************************************/

//        [Description("Takes data such as areas of building parts, and results and then pushes to a single object.")]
//        [Input("filenames", "List of all the files names in a study.")]
//        [Input("reportObjs", "The SAPReport to get the data from.")]
//        [Input("jsonFile", "The JSON file prroduced by running a parametric study.")]
//        [Input("dwellingCounts", "The number of each dwelling.")]
//        [MultiOutput(0, "results", "Results pulled from the report.")]
//        [MultiOutput(1, "success", "Has it run.")]
//        public static Output<List<SAPResult>,bool> ExcelResults(List<string> filenames, List<SAPReport> reportObjs, BH.oM.Environment.SAP.JSON.JSONReport jsonFile, List<DwellingCount> dwellingCounts)
//        {
//            if (filenames == null || filenames.Count == 0 || reportObjs == null || reportObjs.Count == 0 || reportObjs.Count != filenames.Count)
//                return null;

//            List<SAPResult> results = new List<SAPResult>();

//            List <(string code, string identifier, string path)> dwellingInformation = jsonFile.Iterations.SelectMany(x => x.Dwellings.Select(y => (x.IterationCode, y.BuildingIdentifier, y.FilePath))).ToList();

//            for (int i = 0;  i < reportObjs.Count; i++)
//            {
//                EnergyUse energyUseResults = reportObjs[i].EnergyAssessment.EnergyUse;

//                var typeInfo = dwellingInformation.Where(x => x.path == filenames[i]).First();

//                SAPResult r = new SAPResult
//                {
//                    Dwelling = typeInfo.identifier,
//                    Iteration = typeInfo.code,
//                    WallArea = reportObjs[i].WallArea(),
//                    WindowArea = reportObjs[i].WindowArea(),
//                    TFA = reportObjs[i].TotalFloorArea(),
//                    DER = double.Parse(energyUseResults.DER),
//                    TER = double.Parse(energyUseResults.TER),
//                    DPER = double.Parse(energyUseResults.DPER),
//                    TPER = double.Parse(energyUseResults.TPER),
//                    DFEE = double.Parse(energyUseResults.DFEE),
//                    TFEE = double.Parse(energyUseResults.TFEE)
//                };

//                var count = dwellingCounts.Where(x => x.Dwelling == r.Dwelling).First().Count;
//                r.DwellingCount = (count > 0 ? count : 1);

//                //Block compliance calcs
//                r.FloorAreaPerType = r.DwellingCount * r.TFA;
//                r.WallToFloorRatio = r.WallArea / r.TFA;
//                r.WindowToFloorRatio = r.WindowArea / r.TFA;
//                r.WindowToWallRatio = r.WindowArea / r.WallArea;

//                double totalOpeningArea = reportObjs[i].SAP10Data.PropertyDetails.BuildingParts.BuildingPart.SelectMany(x => x.Openings.Opening.Select(o => (o.Width * o.Height))).Sum();

//                r.NotionalWindowArea = r.WindowArea.NotionalWindowsArea(totalOpeningArea, r.TFA);
//                r.NotionalWindowToWallRatio = r.WallToFloorRatio / r.WindowArea;

//                r.DERTERImprovement = (r.TER - r.DER) / r.TER;
//                r.DPERTPERImprovement = (r.TPER - r.DPER) / r.TPER;
//                r.DFEETFEEImprovement = (r.TFEE - r.DFEE) / r.TFEE;

//                r.DERXTFA = r.DER * r.FloorAreaPerType;
//                r.TERXTFA = r.TER * r.FloorAreaPerType;
//                r.DPERXTFA = r.DPER * r.FloorAreaPerType;
//                r.TPERXTFA = r.TPER * r.FloorAreaPerType;
//                r.DFEEXTFA = r.DFEE * r.FloorAreaPerType;
//                r.TFEEXTFA = r.TFEE * r.FloorAreaPerType;

//                results.Add(r);
//            }

//            var a = results.GroupBy(x => x.Iteration).ToList();

//            List<SAPResult> blockResults = new List<SAPResult>();

//            foreach (var i in a)
//            {
//                var iteration = i.First().Iteration;

//                List<SAPResult> dwellings = i.ToList();

//                SAPResult r = new SAPResult
//                {
//                    Type = "Block",
//                    Dwelling = dwellings.Count().ToString(),
//                    DwellingCount = dwellings.Select(x => x.DwellingCount).Sum(),
//                    Iteration = iteration,
//                    FloorAreaPerType = dwellings.Select(x => x.FloorAreaPerType).Sum(),
//                    WallArea = dwellings.Select(x => (x.DwellingCount * x.WallArea)).Sum(),
//                    WindowArea = dwellings.Select(x => (x.DwellingCount * x.WindowArea)).Sum(),
//                    WallToFloorRatio = dwellings.Select(x=>x.WallToFloorRatio).Average(),
//                    WindowToFloorRatio = dwellings.Select(x => x.WindowToFloorRatio).Average(),
//                    WindowToWallRatio = dwellings.Select(x => x.WindowToWallRatio).Average(),
//                    NotionalWindowArea = dwellings.Select(x => (x.DwellingCount * x.NotionalWindowArea)).Sum(),
//                    NotionalWindowToWallRatio = dwellings.Select(x=>x.NotionalWindowToWallRatio).Average(),
//                };

//                r.DERXTFA = dwellings.Select(x => x.DERXTFA).Sum() / r.FloorAreaPerType;
//                r.TERXTFA = dwellings.Select(x => x.TERXTFA).Sum() / r.FloorAreaPerType;
//                r.DFEEXTFA = dwellings.Select(x => x.DFEEXTFA).Sum() / r.FloorAreaPerType;
//                r.TFEEXTFA = dwellings.Select(x => x.TFEEXTFA).Sum() / r.FloorAreaPerType;
//                r.DPERXTFA = dwellings.Select(x => x.DPERXTFA).Sum() / r.FloorAreaPerType;
//                r.TPERXTFA = dwellings.Select(x => x.TPERXTFA).Sum() / r.FloorAreaPerType;

//                results.Add(r);
//            }

//            return new Output<List<SAPResult>, bool>
//            {
//                Item1 = results,
//                Item2 = true
//            };    
//        }
//    }
//}