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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.Engine.Units;
using BH.oM.Spatial.SettingOut;
using BH.oM.Analytical.Elements;
using BH.oM.Base;
using BH.Engine.Base;
using BH.oM.Environment.SAP.XML;
using System.Reflection;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/
        
        [Description("Renames the openings to match the schema.")]
        [Input("openingTypes", "List of the opening types in the dwelling.")]
        [Input("openingNames", "List of the names of the opening types in the dwelling.")]
        [Input("openings", "List of the openings in the dwelling.")]
        [MultiOutput(0, "openingTypeNames", "Opening type names changed to match the schema.")]
        [MultiOutput(1, "openingTypes", "Opening Types updated to match the change to the names of opening types.")]
        public static Output<List<string>, List<string>> RenameToSchemaOpenings(this List<string> openingTypes, List<string> openingNames, List<string> openings)
        {
            //Check for mismatched inputs
            if (openingTypes.Count != openingNames.Count)
            {
                BH.Engine.Base.Compute.RecordError("The number of roof types and roof names do not match. Please fix this.");
            }
            
            //Check for missing building parts
            if (!openings.Any()) 
            {
                BH.Engine.Base.Compute.RecordWarning("There doesn't seem to be any openings in this dwelling.");
            };

            Dictionary<string, string> namingConventions = new Dictionary<string, string>
            {
                {"SolidDoor","Doors"},
                {"SemiGlazedDoor","Doors"},
                {"DoorToCorridor","Doors"},
                {"Window","Windows"},
                {"RoofWindow","Roof windows"},
                {"Rooflight","Roof windows"}
            };

            Dictionary<string, int> openingCount = new Dictionary<string, int>
            {
                {"Doors", 1},
                {"Windows", 1 },
                {"Roof windows", 1}
            };

            List<string> updatedOpeningTypeNames = new List<string>();

            //For each opening type
            for (int r = 0; r < openingNames.Count; r++)
            {
                if (!namingConventions.ContainsKey(openingTypes[r]))
                {
                    BH.Engine.Base.Compute.RecordError($"The opening {openingNames[r]} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string type = namingConventions[openingTypes[r]];

                string newName = $"{type} ({openingCount[type]})";

                updatedOpeningTypeNames.Add(newName);

                openingCount[type] += 1;

                List<string> updatedOpenings = new List<string>();

                //For each opening
                foreach (var o in openings)
                {
                    if (o == openingNames[r])
                    {
                        updatedOpenings.Add(newName);
                    }
                    else
                    {
                        updatedOpenings.Add(o);
                    }
                }
                openings = updatedOpenings;
            }
           
            return new Output<List<string>,List<string>>() { Item1 = updatedOpeningTypeNames, Item2 = openings };
        }
    }
}