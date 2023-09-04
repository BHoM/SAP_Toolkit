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
        public static Output<List<SAPMarkup>, List<SAPMarkup>> ModifyRoofNames(this List<SAPMarkup> roofMarkUps, List<SAPMarkup> openingMarkUps)
        {
            List<SAPMarkup> modifiedMarkUps = new List<SAPMarkup>(roofMarkUps);

            Dictionary<string, int> roofs = new Dictionary<string, int>
            {
                {"ExposedRoof", 1 },
                {"PartyCeiling", 1 }
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
                if (!roofs.ContainsKey(modifiedMarkUps[x].RoofType))
                {
                    BH.Engine.Base.Compute.RecordError($"The roof {modifiedMarkUps[x].RoofType} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string newName = $"{namingConventions[modifiedMarkUps[x].RoofType]} ({roofs[modifiedMarkUps[x].RoofType]})";
                roofs[modifiedMarkUps[x].RoofType] += 1;

                for (int y = 0; y < openingMarkUps.Count; y++)
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
