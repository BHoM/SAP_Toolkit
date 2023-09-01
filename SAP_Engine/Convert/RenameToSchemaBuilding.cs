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

        [Description("Renames the roofs and walls to match the schema")]
        [Input("roofTypes", "List of types of roofs.")]
        [Input("roofNames", "List of names of roofs.")]
        [Input("wallTypes", "List of types of walls.")]
        [Input("wallNames", "List of names of walls.")]
        [Input("openingLocations", "The list of opening locations.")]
        [MultiOutput(0, "wallNames", "Wall names changed to match the schema.")]
        [MultiOutput(1, "roofNames", "Roof names changed to match the schema.")]
        [MultiOutput(2, "OpeningLocations", "Opening locations changed to match the schema.")]
        public static Output<List<string>, List<string>, List<string>> RenameToSchemaBuilding(this List<string> roofTypes, List<string> roofNames, List<string> wallTypes, List<string> wallNames, List<string> openingLocations)
        {
            //Check for mismatched inputs
            if (roofTypes.Count != roofNames.Count)
            {
                BH.Engine.Base.Compute.RecordError("The number of roof types and roof names do not match. Please fix this.");
            }
            if (wallTypes.Count != wallNames.Count)
            {
                BH.Engine.Base.Compute.RecordError("The number of wall types and wall names do not match. Please fix this.");
            }

            //Check for missing building parts
            if (!wallTypes.Any()) 
            {
                BH.Engine.Base.Compute.RecordError("..There doesn't seem to be any walls in this dwelling. Please make sure there are walls in this dwelling.");
            };
            if (!roofTypes.Any())
            {
                BH.Engine.Base.Compute.RecordError("This workflow needs there to be at least one roof in the dwelling so please add one.");
            };

            //Check for repeating names of building parts
            if (roofNames.Distinct().Count() != roofNames.Count())
            {
                BH.Engine.Base.Compute.RecordError("Roofs in the same dwelling must have unique names.");
            }
            if (wallNames.Distinct().Count() != wallNames.Count())
            {
                BH.Engine.Base.Compute.RecordError("Walls in the same dwelling must have unique names.");
            }

            Dictionary<string, int> roofs = new Dictionary<string, int>
            {
                {"ExposedRoof", 1 },
                {"PartyCeiling", 1 }
            };

            Dictionary<string, int> walls = new Dictionary<string, int>
            {
                {"Undefined", 1},
                {"BasementWall", 1 },
                {"ExposedWall", 1},
                {"ShelteredWall", 1},
                {"PartyWall", 1},
                {"InternalWall", 1}
            };

            //TODO: theres an enum for this but I think that's for someone else to update now - Ellie
            Dictionary<string, string> namingConventions = new Dictionary<string, string>
            {
                {"ExposedRoof", "Roof" },
                {"PartyCeiling", "Party ceiling" },
                {"Undefined", "Undefined"},
                {"BasementWall", "Basement wall" },
                {"ExposedWall", "Walls"},
                {"ShelteredWall", "Sheltered wall"},
                {"PartyWall", "Party wall"},
                {"InternalWall", "Internal wall"}
            };

            List<string> updatedRoofNames = new List<string>();

            //Rename roof and all openings in roof
            for (int r = 0; r < roofTypes.Count; r++)
            {
                if (!roofs.ContainsKey(roofTypes[r]))
                {
                    BH.Engine.Base.Compute.RecordError($"The roof {roofNames[r]} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string newName = $"{namingConventions[roofTypes[r]]} ({roofs[roofTypes[r]]})";

                updatedRoofNames.Add(newName);

                roofs[roofTypes[r]] += 1;

                List<string> updatedOpenings = new List<string>();

                foreach (var o in openingLocations)
                {
                    if (o == roofNames[r])
                    {
                        updatedOpenings.Add(newName);
                    }
                    else
                    {
                        updatedOpenings.Add(o);
                    }
                }
                openingLocations = updatedOpenings;
            }

            List<string> updatedWallNames = new List<string>();

            //Rename roof and all openings in roof
            for (int w = 0; w < wallTypes.Count; w++)
            {
                if (!walls.ContainsKey(wallTypes[w]))
                {
                    BH.Engine.Base.Compute.RecordError($"The roof {wallNames[w]} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string newName = $"{namingConventions[wallTypes[w]]} ({walls[wallTypes[w]]})";

                updatedWallNames.Add(newName);

                walls[wallTypes[w]] += 1;

                List<string> updatedOpenings = new List<string>();

                foreach (var o in openingLocations)
                {
                    if (o == wallNames[w])
                    {
                        updatedOpenings.Add(newName);
                    }
                    else
                    {
                        updatedOpenings.Add(o);
                    }
                }
                openingLocations = updatedOpenings;
            }

            return new Output<List<string>,List<string>, List<string>>() { Item1 = updatedWallNames, Item2 = updatedRoofNames, Item3 = openingLocations };
        }
    }
}