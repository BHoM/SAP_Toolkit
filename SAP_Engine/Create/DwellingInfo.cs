using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;
using BH.Engine.Geometry;
using BH.oM.Geometry;
using BH.Engine.Base;
using BH.Engine.Units;
using BH.oM.Reflection.Attributes;
using BH.oM.Geometry.SettingOut;

using BH.oM.Reflection;
using BH.oM.Environment;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create DwellingInfo BHoMObjects for SAP analysis")]
        [Input("dwellings", "")] // TODO
        [Output("dwellingInfo", "A BHoMObject for SAP analysis. Contains general info about each dwelling")]

        public static List<DwellingInfo> DwellingInfo(List<Dwelling> dwellings, List<Opening> frontDoors, List<Polyline> baseCurves, int crossVentTolerance = 45)
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
                dInfo.DwellingBeds = dwelling.Rooms.Where(x => x.Type == SAPSpaceType.Bedroom).Count();
                dwelling.Rooms = dwelling.Rooms.Select(x => x.FlipPanels()).ToList();
                List<Panel> allRoomPanels = dwelling.Rooms.SelectMany(x => x.Panels).ToList();
                List<List<Panel>> overlappedPanels = allRoomPanels.Select(x => x.IdentifyOverlaps(allRoomPanels)).ToList();
                List<Panel> allWallPanels = new List<Panel>();
                for(int x = 0; x < overlappedPanels.Count; x++)
                {
                    if (overlappedPanels[x].Count == 0)
                        allWallPanels.Add(allRoomPanels[x]);
                }

                List<Opening> doorInDwelling = frontDoors.Where(x => x.Bottom().IControlPoints().FirstOrDefault().IIsOnCurve(dwelling.Perimeter)).ToList();

                BH.oM.Environment.SAP.Space space = dwelling.Rooms.Where(x => x.Perimeter.IIsContaining(doorInDwelling.FirstOrDefault().Bottom().IControlPoints())).FirstOrDefault();

                    if (!doorInDwelling.FirstOrDefault().Polyline().NormalAwayFromSpace(space.Panels))
                    doorInDwelling.FirstOrDefault().Edges = doorInDwelling.FirstOrDefault().Polyline().Flip().ToEdges();


                int orientation = System.Convert.ToInt32(doorInDwelling.Select(x => x.Orientation(0, true).Value.ToDegree()).FirstOrDefault());
                dInfo.OrientationDegrees = orientation;

                Polyline baseCurve = baseCurves.Where(y => y.ICurveIntersections(dwelling.Perimeter).Count>0).FirstOrDefault();

                List<Panel> wallPanels = allWallPanels.Where(x => x.Type == PanelType.WallExternal).ToList();
                List<Panel> exteriorWalls = wallPanels.Where(y => y.Bottom().IControlPoints().Where(z => (z.IIsOnCurve(baseCurve))).Count() == y.Bottom().IControlPoints().Count()).ToList();

                List<int> orientations = wallPanels.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).ToList();
                List<int> uniqueOrientations = orientations.Distinct().ToList();
                List<int> wallOrientations = exteriorWalls.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).ToList();
                List<int> uniqueWallOrientations = wallOrientations.Distinct().ToList();
                dInfo.ShelteredSides = uniqueOrientations.Count - uniqueWallOrientations.Count;

                List<Opening> openings = dwelling.Rooms.SelectMany(x => x.Panels.OpeningsFromElements()).ToList();

                List<int> openingOrientations = openings.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).ToList();
                List<int> uniqueOpeningOrientations = openingOrientations.Distinct().ToList();

                string crossvent = "False";
                if (uniqueOpeningOrientations.Count > 1)
                {
                    for (int i = 0; i <uniqueOpeningOrientations.Count ; i++)
                    {
                        for (int j = 0; j < uniqueOpeningOrientations.Count; j++)
                        {
                            if (i == j) continue;
                            
                            if (uniqueOpeningOrientations[j] <= 180 && uniqueOpeningOrientations[i] == 360)                               uniqueOpeningOrientations[i] = 0;
                            
                            if (uniqueOpeningOrientations[j] == 360 && uniqueOpeningOrientations[i] <= 180)
                                uniqueOpeningOrientations[j] = 0;

                            int dif = uniqueOpeningOrientations[i] - uniqueOpeningOrientations[j];
                            if (dif < 0) dif = -dif;

                            if (dif <= 180 + crossVentTolerance && dif >= 180 - crossVentTolerance)
                            {
                                crossvent = "True";
                            }

                        }
                    }
                    
                }

                dInfo.CrossVentilation = crossvent;
                rtn.Add(dInfo);
            }

            return rtn;
        }
    }
}
