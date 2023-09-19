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
        private List<WallSchedule> ReadWallDefinitions(SAPPullConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<WallSchedule>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<WallSchedule>();
            }

            if (config.WallDefinitionsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Wall Definitions Request stating the worksheet and range to read from Excel for the Wall Definition objects.");
                return new List<WallSchedule>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.WallDefinitionsRequest).OfType<TableRow>().ToList();

            List<WallSchedule> wallDefinitions = new List<WallSchedule>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 5)
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                WallSchedule wallDefinition = new WallSchedule();
                wallDefinition.Dwelling = content[0].Value.ToString();
                wallDefinition.Storey = content[2].Value.ToString();

                var type = Enum.Parse(typeof(TypeOfWall), content[1].Value.ToString());
                if (type != null)
                    wallDefinition.Type = (TypeOfWall)type;

                try
                {
                    wallDefinition.UValue = double.Parse(content[4].Value.ToString());
                }
                catch { }

                try
                {
                    wallDefinition.CurtainWall = bool.Parse(content[3].Value.ToString());
                }
                catch { }

                wallDefinitions.Add(wallDefinition);
            }

            return wallDefinitions;
        }
    }
}
