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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.Engine.Units;
using BH.oM.Spatial.SettingOut;
using BH.oM.Analytical.Elements;
using BH.oM.Base;
using BH.Engine.Base;
using BH.oM.Environment.SAP.XML;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Takes data such as areas of building parts, and results and then pushes to a single object.")]
        [Input("filename", "Name of the file information is taken from.")]
        [Input("report", "The SAPReport to get the data from.")]
        [Output("results", "Results pulled from the report.")]
        public static SAPExcelResults ExcelResults(string filename, SAPReport report)
        {
            EnergyUse energyUseResults = report.EnergyAssessment.EnergyUse;

            SAPExcelResults results = new SAPExcelResults
            {
                Dwelling = report.ReportHeader.Property.PlotReference,
                Iteration = filename,
                WallArea = report.WallArea(),
                WindowArea = report.WindowArea(),
                TFA = report.TotalFloorArea(),
                DER = energyUseResults.DER,
                TER = energyUseResults.TER,
                DPER = energyUseResults.DPER,
                TPER = energyUseResults.TPER,
                DFEE = energyUseResults.DFEE,
                TFEE = energyUseResults.TFEE
            };

            return results;            
        }
    }
}


