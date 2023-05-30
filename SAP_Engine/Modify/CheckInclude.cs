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

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Mirror a sap dwelling.")]
        [Input("sapReport", "Input the SAPReport object to modify.")]
        [Input("mirror", "Line to mirror over.")]
        [Output("sapReport", "The mirrored report.")]
        public static bool CheckInclude(this List<List<string>> toInclude)
        {
            List<string> test = toInclude.Select(x => x.Distinct().ToList()).ToList().SelectMany(x=> x).ToList();

            if (test.Count() != test.Distinct().Count())
            {
                BH.Engine.Base.Compute.RecordError("Some items have been changed within this iteration multiple times. Please make sure this is not the case.");
                return false;
            }

            return true;

        }
    }
}

