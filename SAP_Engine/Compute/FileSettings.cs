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

using BH.oM.Adapter;
using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        [Description("Produce file settings objects for every file in a given directory.")]
        [Input("dir", "The directory to generate file settings objects for.")]
        [Output("fileSettings", "File Settings objects for every file in the given directory.")]
        public static List<FileSettings> FileSettings(string dir)
        {
            var allFiles = Directory.EnumerateFiles(dir);
            List<FileSettings> fs = new List<FileSettings>();

            foreach(var file in allFiles)
            {
                fs.Add(new FileSettings()
                {
                    Directory = dir,
                    FileName = Path.GetFileName(file),
                });
            }

            return fs;
        }
    }
}

