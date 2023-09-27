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

        public void RunCommand(ProcessResultsCommand command)
        {
            //Check a template file exists
            var templateFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BHoM", "Resources", "SAP", "ResultsTemplate.xlsx");
            if(!File.Exists(templateFile))
            {
                BH.Engine.Base.Compute.RecordError("The Excel Results Template could not be found to input results to. Please ensure you have the results template in the %ProgramData%/BHoM/Resources/SAP folder.");
                return;
            }

            var tempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BHoM", "SAP", $"Results-{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}.xlsx");

            try
            {
                File.Copy(templateFile, tempFile);
            }
            catch(Exception ex)
            {
                BH.Engine.Base.Compute.RecordError(ex, "Error occurred while setting up the results file for processing.");
                return;
            }


        }
    }
}