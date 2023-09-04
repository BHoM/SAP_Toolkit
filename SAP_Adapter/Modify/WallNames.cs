using BH.oM.Environment.SAP.Bluebeam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BH.oM.Base;

namespace BH.Adapter.SAP
{
    public static partial class Modify
    {
        public static Output<List<SAPMarkup>, List<SAPMarkup>> ModifyWallNames(this List<SAPMarkup> wallMarkUps, List<SAPMarkup> openingMarkUps)
        {
            List<SAPMarkup> modifiedMarkUps = new List<SAPMarkup>(wallMarkUps);

            Dictionary<string, int> walls = new Dictionary<string, int>
            {
                {"Undefined", 1},
                {"BasementWall", 1 },
                {"ExposedWall", 1},
                {"ShelteredWall", 1},
                {"PartyWall", 1},
                {"InternalWall", 1}
            };

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

            for (int x = 0; x < modifiedMarkUps.Count; x++)
            {
                if (!walls.ContainsKey(modifiedMarkUps[x].WallType))
                {
                    BH.Engine.Base.Compute.RecordError($"The roof {modifiedMarkUps[x].WallType} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string newName = $"{namingConventions[modifiedMarkUps[x].WallType]} ({walls[modifiedMarkUps[x].WallType]})";
                walls[modifiedMarkUps[x].WallType] += 1;
                
                for(int y = 0; y < openingMarkUps.Count; y++)
                {
                    if (openingMarkUps[y].OpeningLocation == modifiedMarkUps[x].WallType)
                        openingMarkUps[y].OpeningLocation = newName;
                }

                modifiedMarkUps[x].Subject = newName;
            }

            return new Output<List<SAPMarkup>, List<SAPMarkup>>()
            {
                Item1 = modifiedMarkUps,
                Item2 = openingMarkUps,
            };
        }
    }
}
