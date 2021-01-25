using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Elements;
using BH.oM.Environment.SAP;
using BH.Engine.Environment;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Dwelling TidyPanels(this Dwelling dwelling)
        {
            List<Panel> allPanels = dwelling.Rooms.SelectMany(x => x.Panels).ToList();
            List<Panel> splitPanels = allPanels.SplitPanelsByOverlap();

            List<List<Panel>> overlappingPanels = splitPanels.Select(x => x.IdentifyOverlaps(splitPanels)).ToList();

            List<Panel> fixedPanels = new List<Panel>();
            for (int x = 0; x < splitPanels.Count; x++)
            {
                if (overlappingPanels[x].Count == 0)
                {
                    fixedPanels.Add(splitPanels[x]);
                    continue;
                }

                Panel p = splitPanels[x];
                for (int y = 0; y < overlappingPanels[x].Count; y++)
                    p = p.MergePanels(overlappingPanels[x][y]);

                fixedPanels.Add(p);
            }

            List<List<Panel>> panelsAsSpaces = fixedPanels.ToSpaces();

            foreach(List<Panel> l in panelsAsSpaces)
            {
                string spaceName = l.ConnectedSpaceName();
                dwelling.Rooms.Where(x => x.Name == spaceName).FirstOrDefault().Panels = l;
            }

            return dwelling;
        }
    }
}
