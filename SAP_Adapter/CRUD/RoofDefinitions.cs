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
        private List<RoofSchedule> ReadRoofDefinitions(SAPMarkUpPullConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<RoofSchedule>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<RoofSchedule>();
            }

            if (config.RoofDefinitionsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Roof Definitions Request stating the worksheet and range to read from Excel for the Roof Definition objects.");
                return new List<RoofSchedule>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.RoofDefinitionsRequest).OfType<TableRow>().ToList();

            List<RoofSchedule> roofDefinitions = new List<RoofSchedule>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 4 || !TableRowHasContent(tableRow))
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                RoofSchedule roofDefinition = new RoofSchedule();
                roofDefinition.Dwelling = content[0].Value.ToString();
                roofDefinition.Storey = content[2].Value.ToString();

                var type = Enum.Parse(typeof(TypeOfRoof), content[1].Value.ToString());
                if (type != null)
                    roofDefinition.Type = (TypeOfRoof)type;

                try
                {
                    roofDefinition.UValue = double.Parse(content[3].Value.ToString());
                }
                catch
                {

                }

                roofDefinitions.Add(roofDefinition);
            }

            return roofDefinitions;
        }
    }
}
