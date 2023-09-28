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

using BH.oM.Adapter;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Environment.SAP.Excel;

namespace BH.oM.Environment.SAP
{
    public class ProcessResultsCommand : IExecuteCommand, IObject
    {
        [Description("Paths to the XML results files that will be calculated.")]
        public virtual List<FileSettings> ResultFiles { get; set; }

        [Description("Directory to save the results file(s) to.")]
        public virtual string SaveFileDirectory { get; set; }

        [Description("List of dwelling schedules containing information about each individual dwelling in the report.")]
        public virtual List<DwellingSchedule> DwellingSchedules { get; set; }

        [Description("Provide the target DER/TER improvement as a % between 0 and 100.")]
        public virtual double TargetDERTERImprovement { get; set; }

        [Description("Provide the target DPER/TPER improvement as a % between 0 and 100.")]
        public virtual double TargetDPERTPERImprovement { get; set; }

        [Description("Provide the target DFEE/TFEE improvement as a % between 0 and 100.")]
        public virtual double TargetDFEETFEEImprovement { get; set; }
    }
}