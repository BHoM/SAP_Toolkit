﻿/*
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

using BH.Adapter.XML;
using BH.oM.Adapter;
using BH.oM.Adapters.XML;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BH.oM.Environment.SAP;

namespace BH.Adapter.SAP.Argyle
{
    public partial class ArgyleAdapter : BHoMAdapter
    {
        public static bool CreateArgyle(BH.oM.Environment.SAP.XML.SAPReport data, ArgyleConfig config)
        {
            FileSettings fs = new FileSettings()
            {
                Directory = config.OutputDirectory,
                FileName = $"{data?.SAP10Data?.PropertyDetails?.BuildingParts?.BuildingPart?.FirstOrDefault()?.Identifier}.xml",
            };

            XMLConfig xmlConfig = new XMLConfig() { RemoveNils = true };
            XMLAdapter xmlAdapter = new XMLAdapter(fs);
            xmlAdapter.Push(new List<IBHoMObject>() { data }, actionConfig: xmlConfig);
            return true;
        }
    }
}