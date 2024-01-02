/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using System.Text;

using BH.oM.Base;
using BH.oM.Adapter;
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.XML;
using BH.Engine.Environment.SAP;

using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

using ClosedXML.Excel;
using BH.Engine.Adapter;
using System.Collections.Concurrent;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter : BHoMAdapter
    {
        public override Output<List<object>, bool> Execute(IExecuteCommand command, ActionConfig actionConfig = null)
        {
            var output = new Output<List<object>, bool>() { Item1 = null, Item2 = false };

            List<object> temp = new List<object>() { RunCommand(command as dynamic) };
            output.Item1 = temp;
            output.Item2 = true;

            return output;
        }

        public List<SAPResult> RunCommand(ProcessResultsCommand command)
        {
            //Check a template file exists
            var iterationTemplateFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BHoM", "Resources", "SAP", "IterationResultsTemplate.xlsx");
            if(!File.Exists(iterationTemplateFile))
            {
                BH.Engine.Base.Compute.RecordError("The Excel Iteration Results Template could not be found to input results to. Please ensure you have the iteration results template in the %ProgramData%/BHoM/Resources/SAP folder.");
                return new List<SAPResult>();
            }

            var allResultsTemplateFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BHoM", "Resources", "SAP", "AllResultsTemplate.xlsx");
            if(!File.Exists(allResultsTemplateFile))
            {
                BH.Engine.Base.Compute.RecordError("The Excel Results Template coule not be found to input results to. Please ensure you have the full results template in the %ProgramData%/BHoM/Resources/SAP folder.");
                return new List<SAPResult>();
            }

            var tempDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BHoM", "SAP");
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            //Prepare the results from the reports
            ConcurrentBag<SAPResult> allResults = new ConcurrentBag<SAPResult>();
            Parallel.ForEach(command.ResultFiles, result =>
            //foreach (var result in command.ResultFiles)
            {
                //Get the SAPReport from the file
                SAPReportPullConfig config = new SAPReportPullConfig() { SAPReportFile = result };
                var reports = ReadSAPReport(config);
                Parallel.ForEach(reports, report =>
                {
                    if (report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart.Count > 0)
                    {
                        var part = report.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0];
                        var schedule = command.DwellingSchedules.Where(x => result.FileName.StartsWith(x.DwellingTypeName)).FirstOrDefault();
                        if (schedule == null)
                            BH.Engine.Base.Compute.RecordError($"Could not find a suitable dwelling schedule for {part.Identifier}. Please ensure a suitable schedule is provided. Results not calculated for this dwelling.");

                        allResults.Add(Convert.ToResult(report, schedule, result.FileName));
                    }
                });
            });

            //Output each iteration
            var iterations = allResults.Select(x => x.Iteration).Distinct();
            //foreach(var iteration in iterations)
            Parallel.ForEach(iterations, iteration =>
            {
                var iterationResults = allResults.Where(x => x.Iteration == iteration).ToList();
                OutputResults(iterationResults, tempDir, iteration, iterationTemplateFile, command, true);
            });

            //Output all results
            OutputResults(allResults.ToList(), tempDir, "AllResults", allResultsTemplateFile, command, false);

            return allResults.ToList();
        }

        private void OutputResults(List<SAPResult> iterationResults, string tempDir, string iteration, string templateFile, ProcessResultsCommand command, bool outputWeightedAverage)
        {
            var tempFile = Path.Combine(tempDir, $"Results-{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}-{iteration}.xlsx");
            
            try
            {
                File.Copy(templateFile, tempFile);
            }
            catch (Exception ex)
            {
                BH.Engine.Base.Compute.RecordError(ex, $"Error occurred while setting up the results file for processing iteration {iteration}.");
                return;
            }

            XLWorkbook workbook = null;
            try
            {
                workbook = new XLWorkbook(tempFile);
            }
            catch (Exception ex)
            {
                BH.Engine.Base.Compute.RecordError(ex, $"Error while trying to load Excel template from {tempFile}.");
                return;
            }

            if (workbook == null)
            {
                BH.Engine.Base.Compute.RecordError($"Error while loading Excel template from {tempFile}. Workbook was null.");
                return;
            }

            IXLWorksheet worksheet = workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                BH.Engine.Base.Compute.RecordError($"Error in obtaining first worksheet from workbook to store results.");
                return;
            }

            //Result iterations
            int row = 11;
            for (int x = 0; x < iterationResults.Count; x++)
            {
                var result = iterationResults[x];
                worksheet.Cell(row, 1).SetValue((x + 1).ToString());
                worksheet = OutputRow(result, row, worksheet);
                row++;
            }

            worksheet = OutputHeader(iterationResults, worksheet, outputWeightedAverage);

            //Targets
            worksheet.Cell(3, 2).SetValue(command.TargetDERTERImprovement / 100);
            worksheet.Cell(3, 3).SetValue(command.TargetDPERTPERImprovement / 100);
            worksheet.Cell(3, 4).SetValue(command.TargetDFEETFEEImprovement / 100);

            var savePath = Path.Combine(command.SaveFileDirectory, $"{iteration}.xlsx");
            try
            {
                workbook.SaveAs(savePath);
            }
            catch (Exception ex)
            {
                BH.Engine.Base.Compute.RecordError(ex, $"Error in saving Excel results file to location {savePath}.");
            }
        }

        private IXLWorksheet OutputRow(SAPResult result, int row, IXLWorksheet worksheet)
        {
            worksheet.Cell(row, 2).SetValue(result.DwellingName);
            worksheet.Cell(row, 3).SetValue(result.DwellingCount);
            worksheet.Cell(row, 4).SetValue(result.Iteration);

            worksheet.Cell(row, 5).SetValue(result.TotalFloorArea);
            worksheet.Cell(row, 6).SetValue(result.FloorAreaByBlock);
            worksheet.Cell(row, 7).SetValue(result.WallArea);
            worksheet.Cell(row, 8).SetValue(result.WindowArea);
            worksheet.Cell(row, 9).SetValue(result.WallToFloorRatio);
            worksheet.Cell(row, 10).SetValue(result.WindowToFloorRatio);
            worksheet.Cell(row, 11).SetValue(result.WindowToWallRatio);

            worksheet.Cell(row, 13).SetValue(result.NotionalWindowArea);
            worksheet.Cell(row, 14).SetValue(result.NotionalWindowToWallRatio);

            worksheet.Cell(row, 16).SetValue(result.DER);
            worksheet.Cell(row, 17).SetValue(result.TER);
            worksheet.Cell(row, 18).SetValue(result.DERTERImprovement);

            worksheet.Cell(row, 19).SetValue(result.DPER);
            worksheet.Cell(row, 20).SetValue(result.TPER);
            worksheet.Cell(row, 21).SetValue(result.DPERTPERImprovement);

            worksheet.Cell(row, 22).SetValue(result.DFEE);
            worksheet.Cell(row, 23).SetValue(result.TFEE);
            worksheet.Cell(row, 24).SetValue(result.DFEETFEEImprovement);

            worksheet.Cell(row, 25).SetValue(result.BlockDER);
            worksheet.Cell(row, 26).SetValue(result.BlockTER);
            worksheet.Cell(row, 27).SetValue(result.BlockDPER);
            worksheet.Cell(row, 28).SetValue(result.BlockTPER);
            worksheet.Cell(row, 29).SetValue(result.BlockDFEE);
            worksheet.Cell(row, 30).SetValue(result.BlockTFEE);

            return worksheet;
        }

        private IXLWorksheet OutputHeader(List<SAPResult> iterationResults, IXLWorksheet worksheet, bool outputWeightedAverage)
        {
            //Header information
            var uniqueDwellingTypes = iterationResults.Select(x => x.DwellingName).Distinct().Count();
            var totalNumberOfDwellings = iterationResults.Select(x => x.DwellingCount).Sum();
            var totalBlockFloorArea = iterationResults.Select(x => x.FloorAreaByBlock).Sum();
            var totalBlockWallArea = iterationResults.Select(x => x.WallArea).Sum();
            var totalBlockWindowArea = iterationResults.Select(x => x.WindowArea).Sum();
            var averageBlockWallToFloorRatio = iterationResults.Select(x => x.WallToFloorRatio).Average();
            var averageBlockWindowToFloorRatio = iterationResults.Select(x => x.WindowToFloorRatio).Average();
            var averageBlockWindowToWallRatio = iterationResults.Select(x => x.WindowToWallRatio).Average();
            var totalBlockNotionalWindowArea = iterationResults.Select(x => x.NotionalWindowArea).Sum();
            var averageBlockNotionalWindowToWallRatio = iterationResults.Select(x => x.NotionalWindowToWallRatio).Average();

            worksheet.Cell(6, 2).SetValue(uniqueDwellingTypes);
            worksheet.Cell(6, 3).SetValue(totalNumberOfDwellings);

            worksheet.Cell(6, 6).SetValue(totalBlockFloorArea);
            worksheet.Cell(6, 7).SetValue(totalBlockWallArea);
            worksheet.Cell(6, 8).SetValue(totalBlockWindowArea);
            worksheet.Cell(6, 9).SetValue(averageBlockWallToFloorRatio);
            worksheet.Cell(6, 10).SetValue(averageBlockWindowToFloorRatio);
            worksheet.Cell(6, 11).SetValue(averageBlockWindowToWallRatio);

            worksheet.Cell(6, 13).SetValue(totalBlockNotionalWindowArea);
            worksheet.Cell(6, 14).SetValue(averageBlockNotionalWindowToWallRatio);

            if (outputWeightedAverage)
            {
                var averageDER = iterationResults.Select(x => x.BlockDER).Sum() / totalBlockFloorArea;
                var averageTER = iterationResults.Select(x => x.BlockTER).Sum() / totalBlockFloorArea;
                var averageDPER = iterationResults.Select(x => x.BlockDPER).Sum() / totalBlockFloorArea;
                var averageTPER = iterationResults.Select(x => x.BlockTPER).Sum() / totalBlockFloorArea;
                var averageDFEE = iterationResults.Select(x => x.BlockDFEE).Sum() / totalBlockFloorArea;
                var averageTFEE = iterationResults.Select(x => x.BlockTFEE).Sum() / totalBlockFloorArea;

                var averageDERTER = (averageTER - averageDER) / averageTER;
                var averageDPERTPER = (averageTPER - averageDPER) / averageTPER;
                var averageDFEETFEE = (averageTFEE - averageDFEE) / averageTFEE;
                worksheet.Cell(5, 25).SetValue(averageDER);
                worksheet.Cell(5, 26).SetValue(averageTER);
                worksheet.Cell(5, 27).SetValue(averageDPER);
                worksheet.Cell(5, 28).SetValue(averageTPER);
                worksheet.Cell(5, 29).SetValue(averageDFEE);
                worksheet.Cell(5, 30).SetValue(averageTFEE);

                worksheet.Cell(6, 25).SetValue(averageDERTER);
                worksheet.Cell(6, 27).SetValue(averageDPERTPER);
                worksheet.Cell(6, 29).SetValue(averageDFEETFEE);
            }

            return worksheet;
        }
    }
}
