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

using BH.oM.Environment.SAP;
using BH.Engine.Geometry;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using System.IO;
using BH.oM.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;
using static System.Net.WebRequestMethods;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Converts lists of thermal bridge curves to lists of lengths of thermal bridges.")]
        [Input("thermalBridgesCurves", "ThermalBridgeLength objects.")]
        [Output("thermalBridgeLengths", "ThermalBridgeLengthObjects.")]
        public static Output<string, string> InputOutputFolder(this string directory)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                BH.Engine.Base.Compute.RecordError($"The directory {directory} does not exist.");
                return null;
            }

            string inputPath = Path.Combine(directory, "Input");

            string outputPath = Path.Combine(directory, "Results");

            if (!System.IO.Directory.Exists(inputPath))
            {
                Directory.CreateDirectory(inputPath);
            }

            if (!System.IO.Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            return new Output<string, string>()
            {
                Item1 = inputPath,
                Item2 = outputPath
            };
        }
    }
}

