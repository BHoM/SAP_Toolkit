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
        [Description("Modify a SAPReport based on opening type iterators.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("openingTypeObj", "Input the opening type iterators.")]
        [Input("iterationName", "Input the name of the iteration.")]
        [MultiOutput(0, "sapReport", "The modified SAP Report object.")]
        [MultiOutput(1, "changesToOpeningTypes", "Tracking the changes made to the uvalues and gvalue to the opening types.")]
        public static Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>> ParametricsOpeningType (this SAPReport sapObj, List<OpeningTypeIterator> openingTypeObj, string iterationName)
        {
            if (openingTypeObj == null)
            {
                return new Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>>() { Item1 = sapObj, Item2 = null };
            }

            //Checks if opening types selected to include are not overlapping.
            bool valid = openingTypeObj.Select(x => x.Include).ToList().CheckInclude();

            if (!valid)
            {
                string e = $"Iteration \"{iterationName}\" has opening types that are modified multiple times within the iteration. Please correct this before moving on.";
                BH.Engine.Base.Compute.RecordError(e);
                return null;
            }

            List<BH.oM.Environment.SAP.JSON.OpeningType> typeChanges = new List<oM.Environment.SAP.JSON.OpeningType>();

            foreach (var i in openingTypeObj)
            {
                var openingTypeMods = sapObj.ModifyOpeningTypes(i.Include, i.UValue, i.GValue);

                sapObj = openingTypeMods.Item1;
                typeChanges = ( openingTypeMods.Item2 != null ? typeChanges.Concat(openingTypeMods.Item2).ToList() : typeChanges);
            }

            return new Output<SAPReport, List<BH.oM.Environment.SAP.JSON.OpeningType>>() { Item1 = sapObj, Item2 = typeChanges };
        }
    }
}