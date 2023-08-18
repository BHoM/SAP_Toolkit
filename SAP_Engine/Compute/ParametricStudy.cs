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
    public static partial class Compute
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

                sapObjList = sapObjList.Concat(studyResult.Select(x => x.Item1)).ToList();
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
                Item1 = sapObjList,
                Item2 = files
            };
        }
    }
}