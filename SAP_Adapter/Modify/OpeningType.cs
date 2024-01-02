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

using BH.oM.Environment.SAP.Bluebeam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using SXML = BH.oM.Environment.SAP.XML;
using BH.oM.Base;

namespace BH.Adapter.SAP
{
    public static partial class Modify
    {
        public static Output<List<SAPMarkup>, List<SXML.OpeningType>> ModifyOpeningType(this List<SAPMarkup> openingMarkUps, List<SXML.OpeningType> xmlOpeningTypes)
        {
            List<SAPMarkup> modifiedMarkUps = new List<SAPMarkup>(openingMarkUps);
            List<SXML.OpeningType> modifiedOpeningTypes = new List<SXML.OpeningType>(xmlOpeningTypes);

            /*var allOpeningNames = openingMarkUps.Select(x => x.Subject).ToList();
            var allOpeningTypes = openingMarkUps.Where(x => allOpeningNames.Contains(x.Subject)).Select(x => x.OpeningType).Distinct().ToList();
            var allOpeningLocations = openingMarkUps.Select(x => x.OpeningLocation).ToList();
            var openingNamesMatchingSchema = Convert.RenameToSchemaOpenings(allOpeningTypes, allOpeningNames.Distinct().ToList(), allOpeningNames);*/

            Dictionary<string, string> namingConventions = new Dictionary<string, string>
            {
                {"SolidDoor", "Doors"},
                {"SemiGlazedDoor", "Doors"},
                {"DoorToCorridor", "Doors"},
                {"Window", "Windows"},
                {"RoofWindow", "Roof windows"},
                {"Rooflight", "Roof windows"}
            };

            Dictionary<string, int> openingCount = new Dictionary<string, int>
            {
                {"Doors", 1},
                {"Windows", 1 },
                {"Roof windows", 1}
            };

            //For each opening type
            for (int x = 0; x < modifiedOpeningTypes.Count; x++)
            {
                if (!namingConventions.ContainsKey(modifiedOpeningTypes[x].Name))
                {
                    BH.Engine.Base.Compute.RecordError($"The opening {modifiedOpeningTypes[x].Name} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string type = namingConventions[modifiedOpeningTypes[x].Name];

                string newName = $"{type} ({openingCount[type]})";
                openingCount[type] += 1;

                for (int y = 0; y < modifiedMarkUps.Count; y++)
                {
                    if (modifiedOpeningTypes[x].Name == modifiedMarkUps[y].OpeningType && modifiedOpeningTypes[x].Description == modifiedMarkUps[y].Subject)
                        modifiedMarkUps[y].OpeningType = newName;
                }

                modifiedOpeningTypes[x].Name = newName;
            }

            return new Output<List<SAPMarkup>, List<SXML.OpeningType>>()
            {
                Item1 = modifiedMarkUps,
                Item2 = modifiedOpeningTypes,
            };
        }
    }
}
