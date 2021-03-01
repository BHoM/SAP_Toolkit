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


namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<ThermalBridgesCurves> ThermalBridgesCurves(List<Dwelling> dwellings, List<Panel> balconyShades, List<Level> levels, List<Polyline> baseCurves, double tolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            List<ThermalBridgesCurves> thermalBridgesCurves = new List<ThermalBridgesCurves>();


            for (int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                ThermalBridgesCurves thermalBridgeCurves = new ThermalBridgesCurves();
                thermalBridgeCurves.DwellingName = dwelling.Name;
                thermalBridgeCurves.Reference = dwelling.Reference;
                thermalBridgeCurves.ID = (x + 1);

                //List<Opening> openings = dwelling.Rooms.SelectMany(y => y.Panels.OpeningsFromElements()).ToList();
                //List<Polyline> jambs = new List<Polyline>();
                //List<Polyline> lintels = new List<Polyline>();
                //List<Polyline> sills = new List<Polyline>();

                //for (int i = 0; i < openings.Count; i++)
                //{
                //    Opening o = openings[i];
                //    List<Polyline> edgesParts = o.Polyline().SplitAtPoints(o.Polyline().ControlPoints);
                //    double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();
                //    for (int j = 0; j < edgesParts.Count; j++)
                //    {
                //        List<Point> controlPoints = edgesParts[j].ControlPoints;
                //        if (controlPoints.Where(y => y.Z == zmax).Count() == 0)
                //            sills.Add(edgesParts[j]);

                //        else if (controlPoints.Where(y => y.Z == zmax).Count() == 1)
                //            jambs.Add(edgesParts[j]);

                //        else
                //            lintels.Add(edgesParts[j]);
                //    }
                //}

                //thermalBridgeCurves.E2 = sills;
                //thermalBridgeCurves.E4 = jambs;
                //thermalBridgeCurves.E3 = lintels;

                Polyline baseCurve = baseCurves.Where(y => y.ICurveIntersections(dwelling.Perimeter).Count > 0).FirstOrDefault();
                List<Panel> wallPanels = dwelling.Rooms.SelectMany(y => y.Panels.Where(a => a.Type == PanelType.WallExternal)).ToList();
                List<Panel> exteriorWalls = wallPanels.Where(y => (y.Bottom() as Polyline).ControlPoints.Where(z => (z.IIsOnCurve(baseCurve))).Count() == (y.Bottom() as Polyline).ControlPoints.Count()).ToList();

                List<Polyline> partyFloor = new List<Polyline>();
                List<Polyline> partyFloorTop = new List<Polyline>();

                for (int i = 0; i < exteriorWalls.Count; i++)
                {
                    List<Polyline> edgesParts = exteriorWalls[i].Polyline().SplitAtPoints(exteriorWalls[i].Polyline().ControlPoints);
                    double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();

                    for (int j = 0; j < edgesParts.Count; j++)
                    {
                        List<Point> controlPoints = edgesParts[j].ControlPoints;
                        if (controlPoints.Where(y => y.Z == zmax).Count() == 0)
                            partyFloor.Add(edgesParts[j]);

                        else if (controlPoints.Where(y => y.Z == zmax).Count() == 2)
                        {
                            partyFloorTop.Add(edgesParts[j]);
                        }

                    }
                }

                List<Panel> balconiesInDwelling = balconyShades.Where(y => (y.Polyline()).LineIntersections(dwelling.Perimeter as Polyline).Count > 0).ToList();
                List<Polyline> balconyIntersections = new List<Polyline>();

                for (int i = 0; i < balconiesInDwelling.Count; i++)
                {
                    List<Polyline> shadeParts = balconiesInDwelling[i].Polyline().SplitAtPoints(balconiesInDwelling[i].Polyline().IControlPoints());
                    for (int j = 0; j < shadeParts.Count; j++)
                    {
                        if (shadeParts[j].ControlPoints.Where(z => z.IIsOnCurve(baseCurve)).Count() == shadeParts[j].ControlPoints().Count())
                        {
                            balconyIntersections.Add(shadeParts[j]);
                        }
                    }
                }

                List<Polyline> e7Curves = new List<Polyline>();
                for (int i = 0; i < partyFloor.Count; i++)
                {
                    List<Point> points = balconyIntersections.SelectMany(y => y.ControlPoints).ToList();
                    List<Point> controlPoints = points.Where(y => (y.IIsOnCurve(partyFloor[i]))).ToList(); // fix this
                    if (controlPoints.Count != 0)
                    {

                        List<Polyline> splitCurves = partyFloor[i].SplitAtPoints(controlPoints);

                        for (int j = 0; j < balconyIntersections.Count; j++)
                        {
                            List<Polyline> curves = splitCurves.Where(y => (y.Centre().IIsOnCurve(balconyIntersections[j]) == false)).ToList();
                            for (int k = 0; k < curves.Count; k++)
                            {
                                e7Curves.Add(curves[k]);
                            }


                        }

                    }

                    else e7Curves.Add(partyFloor[i]);

                }

                double maxZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Max() + tolerance;
                double minZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Min() - tolerance;
                Level dwellingLevel = levels.Where(y => y.Elevation >= minZ && y.Elevation <= maxZ).FirstOrDefault();
                Level floorAbove = null;

                if (!(dwellingLevel.Elevation >= (levels.Select(y => y.Elevation).Max() - tolerance) && dwellingLevel.Elevation <= (levels.Select(y => y.Elevation).Max() + tolerance)))
                {
                    //Dwelling is not on the top level so shading may exist above it
                    List<double> elevations = levels.Select(y => y.Elevation).ToList();
                    elevations.Sort();
                    int index = elevations.IndexOf(dwellingLevel.Elevation);
                    index++;
                    if (index == elevations.Count)
                        index--; //For safety but should not happen
                    floorAbove = levels.Where(y => y.Elevation >= (elevations[index] - tolerance) && y.Elevation <= (elevations[index] + tolerance)).FirstOrDefault();
                }

                List<Polyline> balconyTopIntersections = new List<Polyline>();
                if (floorAbove != null)
                {

                    Polyline dwellingTop = (dwelling.Perimeter as Polyline).Clone();
                    dwellingTop.IControlPoints().ForEach(y => y.Z = floorAbove.Elevation); 
                    List<Panel> shades = balconyShades.Where(y => y.Polyline().ICurveIntersections(dwellingTop).Count > 0).ToList();

                    for (int j = 0; j < shades.Count; j++)
                    {
                        List<Polyline> shadeParts = shades[j].Polyline().SplitAtPoints(shades[j].Polyline().IControlPoints());
                        Polyline width = shadeParts.Where(y => (y.ControlPoints.Where(z => z.IIsOnCurve(dwellingTop)).Count() == y.ControlPoints().Count)).FirstOrDefault();
                        balconyTopIntersections.Add(width);
                    }

                    Polyline baseCurveAbove = baseCurves.Where(y => y.ControlPoints().FirstOrDefault().Z == floorAbove.Elevation).FirstOrDefault();
                    Panel baseCurveAbovePanel = new Panel();
                    baseCurveAbovePanel.ExternalEdges = baseCurveAbove.ToEdges();
                    List<Polyline> wallParts = exteriorWalls.SelectMany(y => y.Polyline().SplitAtPoints(y.Polyline().ControlPoints())).ToList();
                    double zmax = wallParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();
                    List<Polyline> topWallparts = new List<Polyline>();
                    List<Polyline> terraceCurves = new List<Polyline>();
                    for (int i = 0; i < wallParts.Count; i++)
                    {
                        List<Point> controlPoints = wallParts[i].ControlPoints;
                        if (controlPoints.Where(y => y.Z == zmax).Count() == 2)
                            topWallparts.Add(wallParts[i]);

                    }

                    for (int i = 0; i < topWallparts.Count; i++)
                    {
                        List<Point> controlPoints = topWallparts[i].ControlPoints;
                        List<Point> pointsInPanel = new List<Point>();
                        for (int j = 0; j < controlPoints.Count; j++)
                        {
                            if (baseCurveAbovePanel.IsContaining(controlPoints[j]))
                                pointsInPanel.Add(controlPoints[j]);
                        }

                        if (pointsInPanel.Count != controlPoints.Count)
                        {
                            terraceCurves.Add(topWallparts[i]);
                        }


                    }

                    thermalBridgeCurves.E15 = terraceCurves;

                }

                else
                {
                    List<Polyline> wallParts = exteriorWalls.SelectMany(y => y.Polyline().SplitAtPoints(y.Polyline().ControlPoints())).ToList();
                    double zmax = wallParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();
                    List<Polyline> eaves = new List<Polyline>();
                    for (int j = 0; j < wallParts.Count; j++)
                    {
                        List<Point> controlPoints = wallParts[j].ControlPoints;
                        if (controlPoints.Where(y => y.Z == zmax).Count() == 2)
                            eaves.Add(wallParts[j]);

                    }
                    thermalBridgeCurves.E10 = eaves;

                }

                List<Polyline> testCurves = new List<Polyline>();
                for (int i = 0; i < partyFloorTop.Count; i++)
                {
                    List<Point> points = balconyTopIntersections.SelectMany(y => y.ControlPoints).ToList();
                    List<Point> controlPoints = points.Where(y => (y.IIsOnCurve(partyFloorTop[i]))).ToList(); // fix this
                    if (controlPoints.Count != 0)
                    {

                        List<Polyline> splitCurves = partyFloorTop[i].SplitAtPoints(controlPoints);

                        for (int j = 0; j < balconyTopIntersections.Count; j++)
                        {
                            List<Polyline> curves = splitCurves.Where(y => (y.Centre().IIsOnCurve(balconyTopIntersections[j]) == false)).ToList();
                            for (int k = 0; k < curves.Count; k++)
                            {
                                testCurves.Add(curves[k]);
                            }


                        }

                    }

                    else testCurves.Add(partyFloorTop[i]);

                }
                thermalBridgeCurves.E2 = partyFloorTop;
                thermalBridgeCurves.E3 = balconyTopIntersections;
                thermalBridgeCurves.E4 = testCurves;

                thermalBridgeCurves.E23 = balconyIntersections;
                thermalBridgeCurves.E7 = e7Curves;

                int nd = 0;
                int pd = dwellings.Count - 1;
                if (x < (dwellings.Count - 1))
                {
                    nd = x + 1;
                }

                if (x > 0)
                {
                    pd = x - 1;
                }

                Dwelling nextDwelling = dwellings[nd];
                Dwelling previousDwelling = dwellings[pd];

                // Check from here
                List<Panel> intersectingWallsND = wallPanels.Where(y => (y.Bottom() as Polyline).LineIntersections(nextDwelling.Perimeter as Polyline).Count > 0).ToList();
                List<Panel> exteriorIntersectingWallsND = intersectingWallsND.Where(y => (y.Bottom() as Polyline).LineIntersections(baseCurve).Count > 0).ToList();

                List<Panel> intersectingWallsPD = wallPanels.Where(y => (y.Bottom() as Polyline).LineIntersections(previousDwelling.Perimeter as Polyline).Count > 0).ToList();
                List<Panel> exteriorIntersectingWallsPD = intersectingWallsND.Where(y => (y.Bottom() as Polyline).LineIntersections(baseCurve).Count > 0).ToList();

                List<Polyline> partyWalls = new List<Polyline>();

                for (int i = 0; i < exteriorIntersectingWallsND.Count; i++)
                {
                    Panel w = exteriorIntersectingWallsND[i];
                    Polyline edges = w.Polyline();
                    List<Polyline> edgesParts = edges.SplitAtPoints(edges.ControlPoints);
                    double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();

                    for (int j = 0; j < edgesParts.Count; j++)
                    {
                        List<Point> controlPoints = edgesParts[j].ControlPoints();
                        if (controlPoints.Where(y => y.Z == zmax).Count() == 1 && controlPoints.Where(y => y.IIsOnCurve(baseCurve)).Count() == 1)
                            partyWalls.Add(edgesParts[j]);

                    }
                }

                for (int i = 0; i < exteriorIntersectingWallsPD.Count; i++)
                {
                    Panel w = exteriorIntersectingWallsPD[i];
                    Polyline edges = w.Polyline();
                    List<Polyline> edgesParts = edges.SplitAtPoints(edges.ControlPoints);
                    double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();

                    for (int j = 0; j < edgesParts.Count; j++)
                    {
                        List<Point> controlPoints = edgesParts[j].ControlPoints();
                        if (controlPoints.Where(y => y.Z == zmax).Count() == 1 && controlPoints.Where(y => y.IIsOnCurve(baseCurve)).Count() == 1)
                            partyWalls.Add(edgesParts[j]);

                    }
                }

                thermalBridgeCurves.E18 = partyWalls;

                dwelling.Rooms = dwelling.Rooms.Select(y => y.FlipPanels()).ToList();
                List<int> wallOrientations = exteriorWalls.Select(y => System.Convert.ToInt32(y.Orientation(0, true).Value.ToDegree())).ToList(); ;
                List<int> uniqueWallOrientations = wallOrientations.Distinct().ToList();

                if (uniqueWallOrientations.Count > 1)
                {

                    Panel baseCurvePanel = new Panel();
                    baseCurvePanel.ExternalEdges = baseCurve.ToEdges();
                    List<Point> cornerpoints = baseCurve.ControlPoints;
                    List<Point> cornersInDwelling = cornerpoints.Where(y => y.IIsOnCurve(dwelling.Perimeter)).ToList();
                    List<Polyline> corners = new List<Polyline>();
                    List<Polyline> cornersInverted = new List<Polyline>();

                    for (int i = 0; i < cornersInDwelling.Count; i++)
                    {
                        List<Panel> cornerwalls = exteriorWalls.Where(y => y.IsContaining(cornersInDwelling[i])).ToList();
                        if (cornerwalls.Count != 2)
                        {
                            BH.Engine.Reflection.Compute.RecordWarning("This method does not work the way it's intended to");
                        }
                        List<Point> midpoints = cornerwalls.Select(y => (y.Bottom() as Polyline).Centre()).ToList();
                        Polyline cornerline = new Polyline();
                        cornerline.ControlPoints = midpoints;
                        List<Polyline> exteriorWallLines = exteriorWalls.Select(y => y.Polyline()).ToList();
                        double zmax = exteriorWallLines.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();
                        if (baseCurvePanel.IsContaining(cornerline.Centre()))
                        {
                            Point top = cornersInDwelling[i].Clone();
                            top.Z = zmax;// zmax
                            List<Point> controlPoints = new List<Point>();
                            controlPoints.Add(cornersInDwelling[i]);
                            controlPoints.Add(top);
                            Polyline height = new Polyline();
                            height.ControlPoints = controlPoints;
                            corners.Add(height);
                        }

                        else
                        {
                            Point top = cornersInDwelling[i].Clone();
                            top.Z = zmax;// zmax
                            List<Point> controlPoints = new List<Point>();
                            controlPoints.Add(cornersInDwelling[i]);
                            controlPoints.Add(top);
                            Polyline height = new Polyline();
                            height.ControlPoints = controlPoints;
                            cornersInverted.Add(height);
                        }

                        thermalBridgeCurves.E16 = corners;
                        thermalBridgeCurves.E17 = cornersInverted;



                    }

                    List<Point> staggeredCornerPoints = baseCurve.ControlPoints();
                    List<Polyline> staggeredPartyWalls = new List<Polyline>();
                    // Find the corner point, check if it's staggered or not
                    for (int i = 0; i < staggeredCornerPoints.Count; i++)
                    {
                        List<Panel> staggeredPartyWallsND = exteriorIntersectingWallsND.Where(y => y.Bottom().IIsContaining(staggeredCornerPoints)).ToList();
                        List<Panel> staggeredPartyWallsPD = exteriorIntersectingWallsPD.Where(y => y.Bottom().IIsContaining(staggeredCornerPoints)).ToList();
                        if (staggeredPartyWallsND.Count != 0)
                        {
                            Panel w = staggeredPartyWallsND[i];
                            Polyline edges = w.Polyline();
                            List<Polyline> edgesParts = edges.SplitAtPoints(edges.ControlPoints);
                            double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();

                            for (int j = 0; j < edgesParts.Count; j++)
                            {
                                List<Point> controlPoints = edgesParts[j].ControlPoints();
                                if (controlPoints.Where(y => y.Z == zmax).Count() == 1 && controlPoints.Where(y => y.IIsOnCurve(baseCurve)).Count() == 1)
                                    staggeredPartyWalls.Add(edgesParts[j]);

                            }

                        }

                        if (staggeredPartyWallsPD.Count != 0)
                        {
                            Panel w = staggeredPartyWallsPD[i];
                            Polyline edges = w.Polyline();
                            List<Polyline> edgesParts = edges.SplitAtPoints(edges.ControlPoints);
                            double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();

                            for (int j = 0; j < edgesParts.Count; j++)
                            {
                                List<Point> controlPoints = edgesParts[j].ControlPoints();
                                if (controlPoints.Where(y => y.Z == zmax).Count() == 1 && controlPoints.Where(y => y.IIsOnCurve(baseCurve)).Count() == 1)
                                    staggeredPartyWalls.Add(edgesParts[j]);

                            }

                        }

                    }

                    thermalBridgeCurves.E25 = staggeredPartyWalls;
                }

                thermalBridgesCurves.Add(thermalBridgeCurves);

            }

            return thermalBridgesCurves;
        }
    }
}