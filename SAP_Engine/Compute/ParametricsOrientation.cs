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


namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        [Description("WARNING : check order of rotation and mirror, the rotation is performed first. Modify a SAPReport based on orientation iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("orientationsObj", "Input the orientation iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOrientation", "Tracking the changes made to the orientation of the dwelling and the Photovoltaic arrays.")]
        [MultiOutput(2, "changesToOpenings", "Tracking the changes made to the orientation of the openings.")]
        public static Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>> ParametricsOrientation(this SAPReport sapObj, OrientationIterator orientationsObj, string iterationName)
        {
            if (orientationsObj == null)
            {
                return new Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = null, Item3 = null};
            }

            BH.Engine.Base.Compute.RecordNote("Check order of rotation and mirror, the rotation is performed first.");

            var orientationMods = sapObj.ModifyOrientations(orientationsObj.Rotation, orientationsObj.Mirror);

            sapObj = orientationMods.Item1;

            return new Output<SAPReport, Orientation, List<BH.oM.Environment.SAP.JSON.Opening>>() { Item1 = sapObj, Item2 = orientationMods.Item2, Item3 = orientationMods.Item3 };
        }
    }
}