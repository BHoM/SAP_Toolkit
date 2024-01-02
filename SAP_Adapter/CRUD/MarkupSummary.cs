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
using BH.Adapter.XML;
using BH.oM.XML;
using BH.oM.Adapters.XML;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Data.Requests;
using System.Linq;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<SAPMarkupSummary> ReadSAPMarkupSummary(SAPMarkUpPullConfig config)
        {
            if(config.SAPMarkupFile == null)
            {
                BH.Engine.Base.Compute.RecordError("Please provide a valid SAP Markup File Location.");
                return new List<SAPMarkupSummary>();
            }

            string fullFileName = config.SAPMarkupFile.GetFullFileName();
            if(string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<SAPMarkupSummary>();
            }

            XMLConfig xmlConfig = new XMLConfig() { Schema = oM.Adapters.XML.Enums.Schema.Undefined, File = config.SAPMarkupFile };
            XMLAdapter xmlAdapter = new XMLAdapter();
            FilterRequest xmlRequest = BH.Engine.Data.Create.FilterRequest(typeof(SAPMarkupSummary), "");

            return xmlAdapter.Pull(xmlRequest, actionConfig: xmlConfig).OfType<SAPMarkupSummary>().ToList();
        }
    }
}

