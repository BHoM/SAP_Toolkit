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
            List<Guid> handledPanels = new List<Guid>();
            for (int x = 0; x < splitPanels.Count; x++)
            {
                if (handledPanels.Contains(splitPanels[x].BHoM_Guid))
                    continue; //This panel has already been handled

                if (overlappingPanels[x].Count == 0)
                {
                    fixedPanels.Add(splitPanels[x]);
                    handledPanels.Add(splitPanels[x].BHoM_Guid);
                    continue;
                }

                Panel p = splitPanels[x];
                for (int y = 0; y < overlappingPanels[x].Count; y++)
                {
                    p = p.MergePanels(overlappingPanels[x][y]);
                    handledPanels.Add(overlappingPanels[x][y].BHoM_Guid);
                }

                fixedPanels.Add(p);
                handledPanels.Add(p.BHoM_Guid);
            }

            fixedPanels = fixedPanels.SetWallPanels();

            List<List<Panel>> panelsAsSpaces = fixedPanels.ToSpaces();

            foreach(List<Panel> l in panelsAsSpaces)
            {
                string spaceName = l.ConnectedSpaceName();
                dwelling.Rooms.Where(x => x.Name == spaceName).FirstOrDefault().Panels = l;
            }

            return dwelling;
        }

        public static List<BH.oM.Environment.SAP.Space> TidyPanels(this List<BH.oM.Environment.SAP.Space> spaces)
        {
            List<BH.oM.Environment.SAP.Space> fixedSpaces = new List<oM.Environment.SAP.Space>();
            List<Panel> allPanels = spaces.SelectMany(x => x.Panels).ToList();

            List<Panel> splitPanels = allPanels.SplitPanelsByOverlap();

            List<List<Panel>> overlappingPanels = splitPanels.Select(x => x.IdentifyOverlaps(splitPanels)).ToList();

            List<Panel> fixedPanels = new List<Panel>();
            List<Guid> handledPanels = new List<Guid>();
            for (int x = 0; x < splitPanels.Count; x++)
            {
                if (handledPanels.Contains(splitPanels[x].BHoM_Guid) && splitPanels[x].ConnectedSpaces.Count > 1) //Massive hack, do not deploy
                    continue; //This panel has already been handled

                if (overlappingPanels[x].Count == 0)
                {
                    fixedPanels.Add(splitPanels[x]);
                    handledPanels.Add(splitPanels[x].BHoM_Guid);
                    continue;
                }

                Panel p = splitPanels[x];
                for (int y = 0; y < overlappingPanels[x].Count; y++)
                {
                    p = p.MergePanels(overlappingPanels[x][y]);
                    handledPanels.Add(overlappingPanels[x][y].BHoM_Guid);
                }

                fixedPanels.Add(p);
                handledPanels.Add(p.BHoM_Guid);
            }

            fixedPanels = fixedPanels.SetWallPanels();

            List<List<Panel>> panelsAsSpaces = fixedPanels.ToSpaces();

            foreach (List<Panel> l in panelsAsSpaces)
            {
                string spaceName = l.ConnectedSpaceName();
                BH.oM.Environment.SAP.Space space = spaces.Where(x => x.BHoM_Guid.ToString() == spaceName).FirstOrDefault();
                if (space != null)
                    space.Panels = l;

                fixedSpaces.Add(space);
            }

            return fixedSpaces;
        }
    }
}
