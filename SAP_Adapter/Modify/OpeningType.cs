using BH.oM.Environment.SAP.Bluebeam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BH.Adapter.SAP
{
    public static partial class Modify
    {
        public static List<SAPMarkup> ModifyOpeningType(this List<SAPMarkup> openingMarkUps) 
        {
            List<SAPMarkup> modifiedMarkUps = new List<SAPMarkup>(openingMarkUps);

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
            for (int x = 0; x < modifiedMarkUps.Count; x++)
            {
                if (!namingConventions.ContainsKey(modifiedMarkUps[x].OpeningType))
                {
                    BH.Engine.Base.Compute.RecordError($"The opening {modifiedMarkUps[x].OpeningType} has not been given a valid type. Please return to the markup and correct this.");
                    continue;
                }

                string type = namingConventions[modifiedMarkUps[x].OpeningType];

                string newName = $"{type} ({openingCount[type]})";
                openingCount[type] += 1;
                modifiedMarkUps[x].OpeningType = newName;
            }

            return modifiedMarkUps;
        }
    }
}
