using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;
using BH.Engine.Units;
using BH.Engine.Geometry;
using BH.oM.Geometry.SettingOut;
using BH.oM.Geometry;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<ThermalBridges> ThermalBridges(List<Dwelling> dwellings, List<Panel> balconyShades, List<Level> levels, List<Polyline> baseCurves, Vector floorToFloorVector, double tolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            List<ThermalBridges> thermalBridges = new List<ThermalBridges>();
            int nd = 0;
            int pd = dwellings.Count-1;

            for (int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                ThermalBridges thermalBridge = new ThermalBridges();

                thermalBridge.DwellingName = dwelling.Name;
                thermalBridge.Reference = dwelling.Reference;
                thermalBridge.ID = (x + 1);

                // Windows (E2, E3, E4)
                List<Opening> openings = dwelling.Rooms.SelectMany(y => y.Panels.OpeningsFromElements()).ToList();
                double jambs = 0;
                double sill = 0;
                for (int i = 0; i < openings.Count; i++)
                {
                    Opening o = openings[i];

                    jambs += o.Height() * 2;
                    sill += o.Width();
                }

                thermalBridge.E2 = sill;
                thermalBridge.E4 = jambs;
                thermalBridge.E3 = sill;

                List<Polyline> intersectingBaseCurves = baseCurves.Where(y => y.ControlPoints.FirstOrDefault().Z == dwelling.Perimeter.IControlPoints().FirstOrDefault().Z).ToList();
                Polyline baseCurve = intersectingBaseCurves.FirstOrDefault();
                List<Panel> wallPanels = dwelling.Rooms.SelectMany(y => y.Panels.Where(a => a.Type == oM.Environment.Elements.PanelType.WallExternal)).ToList();
                List<Panel> exteriorWalls = wallPanels.Where(y => (y.Bottom() as Polyline).ControlPoints.Where(z => (z.IIsOnCurve(baseCurve))).Count() == (y.Bottom() as Polyline).ControlPoints.Count).ToList();
                List<Polyline> exteriorIntersections = exteriorWalls.Select(y => y.Bottom() as Polyline).ToList();
                double length = exteriorIntersections.Select(y => y.ILength()).Sum();

                List<Panel> balconiesInDwelling = balconyShades.Where(y => (y.Polyline()).LineIntersections(dwelling.Perimeter as Polyline).Count > 1).ToList();
                double balconyWidth = 0;

                for (int i = 0; i < balconiesInDwelling.Count; i++)
                {
                    List<Polyline> shadeParts = balconiesInDwelling[i].Polyline().SplitAtPoints(balconiesInDwelling[i].Polyline().IControlPoints());
                    List<Polyline> width = shadeParts.Where(y => (y.ControlPoints.Where(z => z.IIsOnCurve(baseCurve)).Count() == y.ControlPoints().Count)).ToList();
                    balconyWidth += width.Select(y => y.ILength()).Sum();
                }

                double e7Bottom = length - balconyWidth;
                double maxZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Max() + tolerance;
                double minZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Min() - tolerance;
                Level dwellingLevel = levels.Where(y => y.Elevation >= minZ && y.Elevation <= maxZ).FirstOrDefault();
                Level floorAbove = null;
                double topBalconyWidth = 0;
                double roofConnections = 0;
                double terraceSkyConnections = 0;
                double e7top = 0;
                List<Panel> shadesOnLevelAbove = new List<Panel>();
                
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

                    foreach (Panel shade in balconyShades)
                    {
                        double maZ = shade.Polyline().IControlPoints().Select(y => y.Z).Max() + tolerance;
                        double miZ = shade.Polyline().IControlPoints().Select(y => y.Z).Min() - tolerance;

                        maZ = Math.Round(maZ, 4);
                        miZ = Math.Round(miZ, 4);

                        if (miZ >= Math.Round((floorAbove.Elevation - tolerance), 4) && maZ <= Math.Round((floorAbove.Elevation + tolerance), 4)) 
                            shadesOnLevelAbove.Add(shade);

                    }


                    // Want to find the shade where the polyline intersects one of the exterior walls
                    // This does not work, how to get the shade intersecting the top part of the dwelling?

                    List<Panel> shades = new List<Panel>();
                    if (floorAbove != null)
                    {
                        for (int i = 0; i < exteriorWalls.Count; i++)
                        {
                            Panel shade = shadesOnLevelAbove.Where(y => y.Polyline().ICurveIntersections(exteriorWalls[i].Polyline()).Count > 0).FirstOrDefault();
                            if (shade != null)
                            {
                                shades.Add(shade);
                            }
            
                        }

                        for (int j = 0; j < shades.Count; j++)
                        {
                            List<Polyline> shadeParts = shades[j].Polyline().SplitAtPoints(shades[j].Polyline().IControlPoints()); 
                            List<double> lengths = shadeParts.Select(y => Math.Round(y.Length(), 3)).ToList();
                            lengths = lengths.Distinct().ToList();
                            double width = lengths.Max();
                            topBalconyWidth += width;
                        }

                    }

                    e7top = length - topBalconyWidth;
                    List<Polyline> baseCurvesAbove = new List<Polyline>();

                    foreach (Polyline curve in baseCurves)
                    {
                        double maZ = curve.IControlPoints().Select(y => y.Z).Max() + tolerance;
                        double miZ = curve.IControlPoints().Select(y => y.Z).Min() - tolerance;

                        maZ = Math.Round(maZ, 4);
                        miZ = Math.Round(miZ, 4);

                        if (miZ >= Math.Round((floorAbove.Elevation - tolerance), 4) && maZ <= Math.Round((floorAbove.Elevation + tolerance), 4))
                            baseCurvesAbove.Add(curve);

                    }

                    Polyline baseCurveAbove = baseCurvesAbove.FirstOrDefault(); 
                    List<Panel> topWalls = wallPanels.Where(y => (y.Polyline()).ControlPoints.Where(z => (z.IIsOnCurve(baseCurveAbove))).Count() == y.Bottom().IControlPoints().Count).ToList(); // Breaks here
                    List<Polyline> intersecting = topWalls.Select(y => y.Bottom() as Polyline).ToList();

                    double topLength = 0;
                    if (intersecting.Count != 0)
                    {
                        for (int i = 0; i < intersecting.Count; i++)
                        {
                            topLength += intersecting[i].ILength();
                        }
                    }
                                        
                    terraceSkyConnections = length - topLength;

                }

                else
                {
                    roofConnections = length;
                    e7top = length;
                    
                }

                thermalBridge.E15 = terraceSkyConnections;
                thermalBridge.E10 = roofConnections;
                thermalBridge.E7 = e7top + e7Bottom;
                thermalBridge.E23 = balconyWidth + topBalconyWidth;


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


                List<Panel> intersectingWalls1 = wallPanels.Where(y => (y.Bottom() as Polyline).LineIntersections(nextDwelling.Perimeter as Polyline).Count > 0).ToList();
                List<Panel> exteriorIntersectingWalls1 = intersectingWalls1.Where(y => (y.Bottom() as Polyline).LineIntersections(intersectingBaseCurves.FirstOrDefault() as Polyline).Count > 0).ToList();
                double height1 = 0;
                if (exteriorIntersectingWalls1.Count != 0)
                {
                    height1 = exteriorIntersectingWalls1.FirstOrDefault().Height();
                }
                else
                {
                    height1 = exteriorWalls.FirstOrDefault().Height();
                }


                List<Panel> intersectingWalls2 = wallPanels.Where(y => (y.Bottom() as Polyline).LineIntersections(previousDwelling.Perimeter as Polyline).Count > 0).ToList();
                List<Panel> exteriorIntersectingWalls2 = intersectingWalls2.Where(y => (y.Bottom() as Polyline).LineIntersections(intersectingBaseCurves.FirstOrDefault() as Polyline).Count > 0).ToList();
                double height2 = 0;

                if (exteriorIntersectingWalls2.Count != 0)
                {
                    height2 = exteriorIntersectingWalls2.FirstOrDefault().Height();
                }
                else
                {
                    height2 = exteriorWalls.FirstOrDefault().Height();
                }

                
                List<int> wallOrientations = exteriorWalls.Select(y => System.Convert.ToInt32(y.Orientation(0, true).Value.ToDegree())).ToList(); ;
                dwelling.Rooms = dwelling.Rooms.Select(y => y.FlipPanels()).ToList();
                List<int> uniqueWallOrientations = wallOrientations.Distinct().ToList();
                double cornerInverted = 0;
                double corner = 0;

                if (uniqueWallOrientations.Count > 1)
                {
                    Panel baseCurvePanel = new Panel();
                    baseCurvePanel.ExternalEdges = baseCurve.ToEdges();
                    List<Point> intersections = exteriorWalls.Select(y => (y.Bottom() as Polyline).Centre()).ToList();
                    Polyline checkLine = new Polyline();
                    checkLine.ControlPoints = intersections; 
                    List<Polyline> cornerCheckLines = checkLine.SplitAtPoints(checkLine.ControlPoints);
                    bool onBaseCurve = false;
                    List<Polyline> cornerLines = cornerCheckLines.Where(y => y.Centre().IsOnCurve(baseCurve) == onBaseCurve).ToList();


                    for (int i = 0; i < cornerLines.Count; i++)
                    {
                        if (baseCurvePanel.IsContaining(cornerLines[i].Centre()))
                        {
                            corner = exteriorWalls.FirstOrDefault().Height();
                        }

                        else
                        {
                            cornerInverted = exteriorWalls.FirstOrDefault().Height();
                        }
                    }
                }


                thermalBridge.E16 = corner; 
                thermalBridge.E17 = cornerInverted; // Not correct

                List<Point> staggeredCornerPoints = baseCurve.ControlPoints();
                double staggeredPartyWallHeight1 = 0;
                double staggeredPartyWallHeight2 = 0;

                for (int i = 0; i < staggeredCornerPoints.Count; i++)
                {
                    List<Panel> staggeredPartyWalls1 = exteriorIntersectingWalls1.Where(y => y.Bottom().IIsContaining(staggeredCornerPoints)).ToList();
                    List<Panel> staggeredPartyWalls2 = exteriorIntersectingWalls2.Where(y => y.Bottom().IIsContaining(staggeredCornerPoints)).ToList();
                    if (staggeredPartyWalls1.Count != 0)
                    {
                        staggeredPartyWallHeight1 += staggeredPartyWalls1.FirstOrDefault().Height();
                    }

                    if (staggeredPartyWalls2.Count != 0)
                    {
                        staggeredPartyWallHeight2 += staggeredPartyWalls2.FirstOrDefault().Height();
                    }
                    
                }


                if (staggeredPartyWallHeight1 != 0)
                {
                    height1 = 0;
                }

                if (staggeredPartyWallHeight2 != 0)
                {
                    height2 = 0;
                }


                thermalBridge.E18 = height1 + height2;

                thermalBridge.E25 = staggeredPartyWallHeight1 + staggeredPartyWallHeight2;

                thermalBridges.Add(thermalBridge);
            }

            return thermalBridges;

        }


    }
}