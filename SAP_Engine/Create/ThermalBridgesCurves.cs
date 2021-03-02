using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Geometry;
using BH.oM.Geometry.SettingOut;
using BH.oM.Geometry;
using BH.Engine.Units;

using BH.oM.Reflection;
using BH.oM.Environment;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<ThermalBridgesCurves> ThermalBridgesCurves(List<Dwelling> dwellings, List<Panel> balconyShades, List<Level> levels, List<Polyline> baseCurves, double tolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle)
        {
            List<ThermalBridgesCurves> thermalBridgesCurves = new List<ThermalBridgesCurves>();

            levels = levels.OrderBy(x => x.Elevation).ToList();

            for (int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                ThermalBridgesCurves thermalBridgeCurves = new ThermalBridgesCurves();
                thermalBridgeCurves.DwellingName = dwelling.Name;
                thermalBridgeCurves.Reference = dwelling.Reference;
                thermalBridgeCurves.ID = (x + 1);

                Level dwellingLevel = dwelling.Level(levels);

                Polyline baseCurve = baseCurves.Where(y => y.IsOnLevel(dwellingLevel)).FirstOrDefault();
                if(baseCurve == null)
                {
                    BH.Engine.Reflection.Compute.RecordError("Well now you're fucked aren't you.");
                }

                //Sort out window curves
                Output<List<Polyline>, List<Polyline>, List<Polyline>> openingParts = dwelling.Openings().Parts();
                thermalBridgeCurves.E3 = openingParts.Item1; //Sills/bottom
                thermalBridgeCurves.E4 = openingParts.Item2; //Jambs/sides
                thermalBridgeCurves.E2 = openingParts.Item3; //Lintels/top

                //Sort out party floors - curves that go along the perimeter of the building
                List<Panel> wallPanels = dwelling.PanelsByType(PanelType.WallExternal);
                List<Panel> exteriorWalls = wallPanels.Where(y => y.Bottom().IControlPoints().Where(z => (z.IIsOnCurve(baseCurve))).Count() == y.Bottom().IControlPoints().Count()).ToList();
                Output<List<Polyline>, List<Polyline>, List<Polyline>> exteriorWallParts = exteriorWalls.Parts();

                List<Polyline> partyFloorBottom = exteriorWallParts.Item1;
                List<Polyline> partyFloorTop = exteriorWallParts.Item3;

                List<Panel> balconiesOnLevel = balconyShades.Where(y => y.Polyline().IsOnLevel(dwellingLevel)).ToList();
                List<Panel> balconiesOnDwelling = balconiesOnLevel.Where(y => (y.Polyline()).LineIntersections(dwelling.Perimeter.ICollapseToPolyline(angleTolerance)).Count > 0).ToList();

                partyFloorBottom = Compute.CalculatePartyFloors(balconiesOnDwelling, partyFloorBottom);

                List<Polyline> e23Lines = Compute.BalconyLines(balconiesOnDwelling, baseCurve, dwelling.Perimeter.ICollapseToPolyline(angleTolerance));                

                if (dwellingLevel != levels.Last())
                {
                    //There may be a balcony above us, find out
                    Level levelAbove = levels[levels.IndexOf(dwellingLevel) + 1];

                    Polyline dwellingCurveAbove = dwellings[x].Perimeter.ICollapseToPolyline(angleTolerance).Clone();
                    dwellingCurveAbove.ControlPoints = dwellingCurveAbove.ControlPoints.Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList();

                    Polyline baseCurveAbove = baseCurves.Where(y => y.IsOnLevel(levelAbove)).FirstOrDefault();

                    List<Panel> balconiesAbove = balconyShades.Where(y => y.Polyline().IsOnLevel(levelAbove)).ToList();
                    List<Panel> balconiesAttached = balconiesAbove.Where(y => (y.Polyline()).LineIntersections(dwellingCurveAbove).Count > 0).ToList();

                    partyFloorTop = Compute.CalculatePartyFloors(balconiesAttached, partyFloorTop);

                    //Work out balcony lines on the upper perimeter
                    e23Lines.AddRange(Compute.BalconyLines(balconiesAttached, baseCurveAbove, dwellingCurveAbove));

                    //Work out terrace lines
                    List<Polyline> topLines = exteriorWallParts.Item3;
                    topLines = topLines.Where(y => y.ControlPoints.Where(z => baseCurveAbove.IsContaining(new List<Point> { z }, true)).Count() != y.ControlPoints.Count).ToList(); //All the top lines that are not wholly contained by the floor above, what's remaining are terrace curves
                    thermalBridgeCurves.E15 = topLines;
                }
                else
                {
                    //This is the top level
                    thermalBridgeCurves.E10 = exteriorWallParts.Item3;
                }

                thermalBridgeCurves.E7 = partyFloorBottom;
                thermalBridgeCurves.E7.AddRange(partyFloorTop);

                thermalBridgeCurves.E23 = e23Lines;

                List<Dwelling> dwellingsOnLevel = dwellings.Where(y => y.Perimeter.ICollapseToPolyline(angleTolerance).IsOnLevel(dwellingLevel)).Where(y => y != dwelling).ToList(); //Available dwellings not including the one being thermal bridged
                List<Dwelling> connectedDwellings = dwellingsOnLevel.Where(y =>
                {
                    List<ICurve> curves = new List<ICurve>() { y.Perimeter, dwelling.Perimeter };
                    List<PolyCurve> union = curves.BooleanUnion();
                    return union.Count == 1;
                }).ToList(); //Only the dwellings which are connected to the current dwelling

                List<Point> connectionPointsToNeighbours = connectedDwellings.SelectMany(y => y.Perimeter.ICurveIntersections(dwelling.Perimeter).Where(z => z.IsOnCurve(baseCurve))).ToList();
                List<Polyline> e18Lines = new List<Polyline>();
                List<Polyline> e25Lines = new List<Polyline>();

                foreach(Point p in connectionPointsToNeighbours)
                {
                    List<Point> ctrlPoints = new List<Point>() { p };
                    ctrlPoints.Add(new Point() { X = p.X, Y = p.Y, Z = p.Z + dwelling.Rooms[0].Height });
                    Polyline line = new Polyline() { ControlPoints = ctrlPoints };
                    if (baseCurve.IControlPoints().Contains(p))
                        e25Lines.Add(line);
                    else
                        e18Lines.Add(line);
                }

                thermalBridgeCurves.E18 = e18Lines;
                thermalBridgeCurves.E25 = e25Lines;

                List<Point> baseCurveCornerPoints = baseCurve.CleanPolyline().ControlPoints();
                List<Point> cornerInDwelling = baseCurveCornerPoints.Where(y => y.IIsOnCurve(dwelling.Perimeter)).ToList();

                List<Point> e16Pts = new List<Point>();
                List<Point> e17Pts = new List<Point>();

                foreach(Point pt in cornerInDwelling)
                {
                    List<Polyline> cornerLines = exteriorWallParts.Item1.Where(y => pt.IsOnCurve(y)).ToList();
                    if (cornerLines.Count < 2)
                        continue; //This corner point is not a proper corner

                    Point centre1 = cornerLines[0].Centre();
                    Point centre2 = cornerLines[1].Centre();
                    Line joined = new Line() { Start = centre1, End = centre2 };

                    if (baseCurve.IIsContaining(new List<Point>() { joined.Centroid() }))
                        e16Pts.Add(pt);
                    else
                        e17Pts.Add(pt);
                }

                List<Polyline> e16Lines = new List<Polyline>();
                foreach (Point p in e16Pts)
                {
                    List<Point> ctrlPts = new List<Point>() { p };
                    ctrlPts.Add(new Point() { X = p.X, Y = p.Y, Z = p.Z + dwelling.Rooms[0].Height });
                    Polyline pl = new Polyline() { ControlPoints = ctrlPts };
                    e16Lines.Add(pl);
                }

                List<Polyline> e17Lines = new List<Polyline>();
                foreach (Point p in e17Pts)
                {
                    List<Point> ctrlPts = new List<Point>() { p };
                    ctrlPts.Add(new Point() { X = p.X, Y = p.Y, Z = p.Z + dwelling.Rooms[0].Height });
                    Polyline pl = new Polyline() { ControlPoints = ctrlPts };
                    e17Lines.Add(pl);
                }

                thermalBridgeCurves.E16 = e16Lines;
                thermalBridgeCurves.E17 = e17Lines;

                thermalBridgesCurves.Add(thermalBridgeCurves);

            }

            return thermalBridgesCurves;
        }
    }
}