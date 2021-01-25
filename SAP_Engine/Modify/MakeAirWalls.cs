using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Elements;
using BH.oM.Environment.SAP;
using BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Dwelling MakeAirWalls(this Dwelling dwelling, List<Line> airWallLines)
        {
            List<BH.oM.Environment.SAP.Space> spaces = new List<oM.Environment.SAP.Space>();
            foreach(BH.oM.Environment.SAP.Space space in dwelling.Rooms)
            {
                List<Panel> spacePanels = space.Panels;
                foreach (Line l in airWallLines)
                {
                    Panel p = spacePanels.Where(x => x.Type == PanelType.Wall).Where(x => { List<Point> intersections = x.Polyline().LineIntersections(l); return (intersections != null && intersections.Count > 0); }).FirstOrDefault();
                    if (p != null)
                        p.Type = PanelType.Air;
                }
                space.Panels = spacePanels;
                spaces.Add(space);
            }

            dwelling.Rooms = spaces;
            return dwelling;
        }
    }
}
