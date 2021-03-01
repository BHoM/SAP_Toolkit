using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BHE = BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.Engine.Environment;
using BH.oM.Reflection.Attributes;


namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Dwelling AddOpenings(this Dwelling dwelling, List<BHE.Opening> openings)
        {

            List<Space> spaces = dwelling.Rooms;
            List<Space> modifiedSpaces = new List<Space>();
            for (int i = 0; i < spaces.Count; i++)
            {
                Space space = spaces[i];
                List<BHE.Panel> panels = space.ExtrudeToVolume();
                List<BHE.Panel> panelOpenings = panels.AddOpenings(openings);

                space.Panels = panelOpenings;

                modifiedSpaces.Add(space);
            }

            dwelling.Rooms = modifiedSpaces;
            return dwelling;
        }
    }
}
