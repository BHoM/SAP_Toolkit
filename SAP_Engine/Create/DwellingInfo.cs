using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;
using BH.Engine.Geometry;
using BH.oM.Geometry;
using BH.Engine.Base;
using BH.Engine.Units;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<DwellingInfo> DwellingInfo(List<Dwelling> dwellings)
        {
            List<DwellingInfo> rtn = new List<DwellingInfo>();

            foreach (Dwelling dwelling in dwellings)
            {

                DwellingInfo dInfo = new DwellingInfo();

                dInfo.DwellingName = dwelling.Name;
                dInfo.TotalRooms = dwelling.Rooms.Count;
                dInfo.Reference = dwelling.Reference;
                dInfo.ID = dwellings.IndexOf(dwelling) + 1;
                dInfo.WetRooms = dwelling.Rooms.Where(x => x.Type == SAPSpaceType.Bathroom).Count();

                dwelling.Rooms = dwelling.Rooms.Select(x => x.FlipPanels()).ToList();

                List<Panel> allRoomPanels = dwelling.Rooms.SelectMany(x => x.Panels).ToList();
                List<List<Panel>> overlappedPanels = allRoomPanels.Select(x => x.IdentifyOverlaps(allRoomPanels)).ToList();
                List<Panel> allWallPanels = new List<Panel>();
                for(int x = 0; x < overlappedPanels.Count; x++)
                {
                    if (overlappedPanels[x].Count == 0)
                        allWallPanels.Add(allRoomPanels[x]);
                }

                List<Opening> openings = dwelling.Rooms.SelectMany(x => x.Panels.OpeningsFromElements()).ToList();
                openings = openings.Where(x => x != null).ToList();

                List<int> orientation = openings.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).ToList();
                List<int> uniqueOrientations = orientation.Distinct().ToList();
                dInfo.OrientationDegrees = uniqueOrientations.Sum() / uniqueOrientations.Count;

                //Wall panels which intersect
                List<Panel> wallsOnly = allWallPanels.Where(x => x.Type == PanelType.WallExternal).ToList();

                List<int> wallOrientations = wallsOnly.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).ToList();
                List<int> uniqueWallOrientations = wallOrientations.Distinct().ToList();
                dInfo.ShelteredSides = uniqueWallOrientations.Count - uniqueOrientations.Count;

                string crossvent = "False";
                if (uniqueOrientations.Count > 1)
                    crossvent = "True";

                dInfo.CrossVentilation = crossvent;
                rtn.Add(dInfo);
            }

            return rtn;
        }
    }
}
