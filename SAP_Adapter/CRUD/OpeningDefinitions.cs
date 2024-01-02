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

using BH.Engine.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BH.oM.Adapters.Excel;
using BH.Adapter.Excel;
using System.Linq;
using BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<OpeningSchedule> ReadOpeningDefinitions(SAPMarkUpPullConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<OpeningSchedule>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<OpeningSchedule>();
            }

            if (config.OpeningDefinitionsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Opening Definitions Request stating the worksheet and range to read from Excel for the Opening Definition objects.");
                return new List<OpeningSchedule>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.OpeningDefinitionsRequest).OfType<TableRow>().ToList();

            List<OpeningSchedule> openingDefinitions = new List<OpeningSchedule>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 11 || !TableRowHasContent(tableRow))
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                OpeningSchedule openingDefinition = new OpeningSchedule();
                openingDefinition.OpeningType = content[0].Value.ToString();

                try
                {
                    openingDefinition.UValue = double.Parse(content[1].Value.ToString());
                }
                catch { }

                try
                {
                    openingDefinition.GValue = double.Parse(content[2].Value.ToString());
                }
                catch { }

                var glazingType = Enum.Parse(typeof(TypeOfGlazing), content[3].Value.ToString());
                if (glazingType != null)
                    openingDefinition.TypeOfGlazing = (TypeOfGlazing)glazingType;

                var glazingGap = Enum.Parse(typeof(GlazingGap), content[4].Value.ToString());
                if(glazingGap != null)
                    openingDefinition.GlazingGap = (GlazingGap)glazingGap;

                try
                {
                    openingDefinition.FrameFactor = double.Parse(content[5].Value.ToString());
                }
                catch { }

                var frameType = Enum.Parse(typeof(TypeOfFrame), content[6].Value.ToString());
                if (frameType != null)
                    openingDefinition.FrameType = (TypeOfFrame)frameType;

                try
                {
                    openingDefinition.ArgonFilled = bool.Parse(content[7].Value.ToString());
                }
                catch { }

                try
                {
                    openingDefinition.KryptonFilled = bool.Parse(content[8].Value.ToString());
                }
                catch { }

                var dataSource = Enum.Parse(typeof(OpeningDataSource), content[9].Value.ToString());
                if (dataSource != null)
                    openingDefinition.DataSource = (OpeningDataSource)dataSource;

                try
                {
                    openingDefinition.FloorIntersection = bool.Parse(content[10].Value.ToString());
                }
                catch { }

                openingDefinitions.Add(openingDefinition);
            }

            return openingDefinitions;
        }
    }
}

