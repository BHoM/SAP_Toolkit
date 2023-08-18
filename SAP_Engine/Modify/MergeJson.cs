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
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.ComponentModel;
using BH.oM.Adapter;
using BH.Engine.Diffing;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using BH.Engine.Base;
using System.Runtime.InteropServices.ComTypes;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Mirror all orientations listed in a dwelling.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("mirrorLine", "The line to mirror across.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static List<BH.oM.Environment.SAP.JSON.Opening> MergeJsonOpening(this List<BH.oM.Environment.SAP.JSON.Opening> openings1, List<BH.oM.Environment.SAP.JSON.Opening> openings2)
        {
            if(openings1 == null)
            {
                return openings2;
            }

            if (openings2 == null)
            {
                return openings1;
            }
            
            List<string> names = openings1.Select(x => x.Name).ToList();
            List<BH.oM.Environment.SAP.JSON.Opening> openings = new List<BH.oM.Environment.SAP.JSON.Opening>();
            
            foreach (var o in openings2)
            {
                if (names.Contains(o.Name))
                {
                    var test = openings1.Where(x=> x.Name == o.Name).First();
                    
                    if (test.Orientation == null)
                        test.Orientation = o.Orientation;
                    else
                        test.Orientation.Final = o.Orientation.Final;
                    openings.Add(test);
                }
                else
                {
                    openings.Add(o);
                }
            }

            names = openings.Select(x => x.Name).ToList();

            foreach (var o in openings1)
            {
                if (!names.Contains(o.Name))
                {
                    openings.Add(o);
                }
            }
            return openings;
        }
    }
}

