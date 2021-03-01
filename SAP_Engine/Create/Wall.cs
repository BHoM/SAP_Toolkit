using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.Engine.Geometry;
using BH.oM.Geometry;
using BH.oM.Environment.Elements;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<Walls> Wall(List<Dwelling> dwellings, double ceilingHeight, double ceilingVoidHeight, double externalWallThickness, List<Polyline> baseCurves)
        {
            List<Walls> walls = new List<Walls>();

            for(int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                
                Walls wall = new Walls();

                wall.DwellingName = dwelling.Name;
                wall.Reference = dwelling.Reference;
                wall.ID = (x + 1);

                wall.CeilingHeight = ceilingHeight;
                wall.ExternalWallHeight = ceilingHeight + ceilingVoidHeight;
                wall.ExternalWallThickness = externalWallThickness;

                Polyline baseCurve = baseCurves.Where(y => y.ControlPoints.FirstOrDefault().Z == dwelling.Perimeter.IControlPoints().FirstOrDefault().Z).FirstOrDefault();

                List<Panel> wallPanels = dwelling.Rooms.SelectMany(y => y.Panels.Where(a => a.Type == oM.Environment.Elements.PanelType.WallExternal)).ToList();
                List<Point> controlPoints = wallPanels.SelectMany(y => y.Polyline().ControlPoints()).ToList();
                List<Polyline> wallPanelCurves = wallPanels.SelectMany(y => y.Polyline().SplitAtPoints(controlPoints)).ToList();
                List<Polyline> intersecting = wallPanelCurves.Where(y => (y.ICurveIntersections(baseCurve).Count > 0)).ToList();
                
                List<Polyline> exteriorIntersections = intersecting.Where(y => y.ControlPoints.Where(z => (z.IIsOnCurve(baseCurve))).Count() == y.ControlPoints.Count).ToList();

                double length = 0;

                for (int i = 0; i < exteriorIntersections.Count; i++)
                {
                    length += exteriorIntersections[i].ILength();
                }

                wall.ExternalWallLength = length;
                
                walls.Add(wall);
            }          

            return walls;
        }
    }
}
