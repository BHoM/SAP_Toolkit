using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using BH.Adapter.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static Opening ToSAPOpening(SAPMarkup markup, string name)
        {
            Opening o = new Opening();

            o.Height = markup.OpeningHeight;
            o.Width = markup.Length;
            o.Orientation = ((int)(BH.oM.Environment.SAP.OrientationCode)Enum.Parse(typeof(BH.oM.Environment.SAP.OrientationCode), markup.OpeningOrientation)).ToString();
            o.Pitch = ((int)(BH.oM.Environment.SAP.VerticalPitchCode)Enum.Parse(typeof(BH.oM.Environment.SAP.VerticalPitchCode), markup.OpeningPitch)).ToString();
            o.Name = name;
            o.Type = markup.OpeningType;
            o.Location = markup.OpeningLocation;

            return o;
        }

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

            return new Output<List<string>, List<string>>() { Item1 = updatedOpeningTypeNames, Item2 = openings };
        }

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

            return new Output<List<string>, List<string>, List<string>>() { Item1 = updatedWallNames, Item2 = updatedRoofNames, Item3 = openingLocations };
        }
    }
}
