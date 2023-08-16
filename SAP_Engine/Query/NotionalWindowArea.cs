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
using System.Net;
using System.IO;

using BH.oM.Environment.MaterialFragments;

using BH.oM.Base.Attributes;
using System.ComponentModel;
using BH.oM.Environment.SAP.XML;
using System.Xml.Serialization;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        [Description("From openingTypes SAPReport, returns the total window area of the dwelling.")]
        [Input("report", "The report to get the opening data from.")]
        [Output("Area", "The total window area of the dwelling.")]
        public static double NotionalWindowsArea(this double windowArea, double openingArea, double TFA)
        {
            if (openingArea > (TFA / 4))
            {
                double doorArea = openingArea - windowArea;

                double factor = ((TFA / 4) - doorArea) / windowArea;

                windowArea = windowArea * factor;
            }

            return windowArea;
        }
    }
}

