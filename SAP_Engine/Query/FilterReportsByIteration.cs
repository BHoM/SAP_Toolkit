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

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        [Description("Filter a set of SAP Reports based on the iteration name. The Dwelling Identifier needs to end with the iteration name to be returned.")]
        [Input("reports", "A collection of SAP Reports.")]
        [Input("iterationName", "The iteration name which the reports identifier should end with to be filtered.")]
        [Output("reports", "Filtered reports based on the iteration name.")]
        public static List<SAPReport> FilterReportsByIteration(this List<SAPReport> reports, string iterationName)
        {
            return reports.Where(x => x.SAP10Data.PropertyDetails.BuildingParts.BuildingPart[0].Identifier.EndsWith(iterationName)).ToList();
        }
    }
}

