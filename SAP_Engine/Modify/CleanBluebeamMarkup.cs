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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;

using System.ComponentModel;

using BH.Engine.Base;
using System.IO;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Cleaning Bluebeam XML export.")]
        [Input("fileSettings", "Full directory to the file.")]
        [Input("fileSettingsOutput", "Full directory for the output file.")]
        [Input("run", "Toggle to activate the component.")]
        [Output("outputDirectory", "Directory to the new file.")]
        public static string CleanBluebeamMarkup(BH.oM.Adapter.FileSettings fileSettings = null, BH.oM.Adapter.FileSettings fileSettingsOutput = null, bool run = false)
        {
            if (!run)
                return null;

            if (fileSettings == null || fileSettingsOutput == null)
            {
                BH.Engine.Base.Compute.RecordError("Please set the File Settings correctly to enable the component to read the correct file.");
                return null;
            }

            if (!Path.HasExtension(fileSettings.FileName) || (Path.GetExtension(fileSettings.FileName) != ".xml") || !Path.HasExtension(fileSettingsOutput.FileName) || (Path.GetExtension(fileSettingsOutput.FileName) != ".xml"))
            {
                BH.Engine.Base.Compute.RecordError("File name must contain a file extension.");
                return null;
            }

            string id = @"" + fileSettings.Directory + "\\" + fileSettings.FileName;

            if (!File.Exists(id))
            {
                BH.Engine.Base.Compute.RecordError("Input directory contains a null value or does not exist. Please check your inputs.");
                return null;
            }

            string outputDirectory = fileSettingsOutput.Directory + "\\" + fileSettingsOutput.FileName;
            File.WriteAllLines(outputDirectory, File.ReadAllLines(id).Where(line => !(line.Trim().StartsWith("<") && line.Trim().Contains("/>"))));
            return outputDirectory;
        }
    }
}


