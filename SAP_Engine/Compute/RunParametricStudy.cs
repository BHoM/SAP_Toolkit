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
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("iteration", "Input titeration object.")]
        [Input("directory", "Input the directory for the study.")]
        [Input("psiValues", "Input psiValues.")]
        [Input("count", "Count of iteration.")]
        [MultiOutput(0, "SAPReports", "A list of the SAPReports.")]
        [MultiOutput(1, "saveFiles", "A list of file settings objects corresponding to each iteration.")]
        [MultiOutput(2, "qaFile", "A list of objects corresponding to changes made in each iteration.")]
        public static Output<SAPReport, FileSettings, BH.oM.Environment.SAP.JSON.Dwelling> RunParametricStudy(this SAPReport sapObj, Parameters iteration, string directory, BH.oM.Environment.SAP.PsiValues psiValues, int count)
        {
            SAPReport reportObj = sapObj.DeepClone();

            string countFormat = $"{string.Format("{0:0000}", count)}";

            //QA file - setting up the dwelling
            BH.oM.Environment.SAP.JSON.Dwelling dwellingJSON = new BH.oM.Environment.SAP.JSON.Dwelling
            {
                BuildingIdentifier = sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier
            };

            //Modify the SAPReport in the ways specified in the iteration set up

            //Opening type modifications
            var openingType = reportObj.ParametricsOpeningType(iteration.OpeningTypes, countFormat);

            reportObj = openingType.Item1;
            dwellingJSON.OpeningTypes = openingType.Item2;

            //Opening modifications
            var opening = reportObj.ParametricsOpening(iteration.Openings, countFormat);

            reportObj = opening.Item1;
            dwellingJSON.Openings = opening.Item2;

            //Orientation
            var orientation = reportObj.ParametricsOrientation(iteration.Orientation, countFormat);

            reportObj = orientation.Item1;
            dwellingJSON.Orientation = orientation.Item2;
            dwellingJSON.Openings = dwellingJSON.Openings != null ? dwellingJSON.Openings.MergeJsonOpening(orientation.Item3) : orientation.Item3;

            //Wall modifications
            var wall = reportObj.ParametricsWall(iteration.Walls, countFormat);

            reportObj = wall.Item1;
            dwellingJSON.Walls = wall.Item2;

            //Roof modifications
            var roof = reportObj.ParametricsRoof(iteration.Roofs, countFormat);

            reportObj = roof.Item1;
            dwellingJSON.Roofs = roof.Item2;

            //Floor modifications
            var floor = reportObj.ParametricsFloor(iteration.Floors, countFormat);

            reportObj = floor.Item1;
            dwellingJSON.Floors = floor.Item2;

            //Create thermal bridges from opening
            reportObj = reportObj.ThermalBridgesFromOpening(psiValues);

            //Thermal bridge modifications
            var thermalBridge = reportObj.ParametricsThermalBridge(iteration.ThermalBridges, countFormat);

            reportObj = thermalBridge.Item1;
            dwellingJSON.ThermalBridges = thermalBridge.Item2;


            //File settings
            FileSettings iterationFile = new FileSettings
            {
                FileName = $"{string.Format("{0:0000}",count)}_{sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier}.xml",
                Directory = directory
            };

            dwellingJSON.FilePath = iterationFile.FileName;

            return new Output<SAPReport, FileSettings, BH.oM.Environment.SAP.JSON.Dwelling>()
            {
                Item1 = reportObj,
                Item2 = iterationFile,
                Item3 = dwellingJSON
            };
        }
    }
}