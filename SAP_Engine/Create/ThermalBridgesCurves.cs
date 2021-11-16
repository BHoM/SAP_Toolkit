/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

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
using BH.oM.Analytical.Elements;

using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<ThermalBridgesCurves> ThermalBridgesCurves(List<Zone> dwellings, List<Space> spaces, List<Panel> allPanels, List<Panel> balconyShades, List<Level> levels, List<Polyline> baseCurves, double distanceTolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle, double numericalTolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            List<ThermalBridgesCurves> thermalBridgesCurves = new List<ThermalBridgesCurves>();
            levels = levels.OrderBy(x => x.Elevation).ToList();
            for (int x = 0; x < dwellings.Count; x++)
            {
                ThermalBridgesCurves thermalBridgeCurves = new ThermalBridgesCurves();
                Zone dwelling = dwellings[x];
                Polyline dwellingPerimeter = dwelling.Perimeter.ICollapseToPolyline(angleTolerance);
            
                thermalBridgeCurves.DwellingName = dwelling.Name;
                thermalBridgeCurves.Reference = dwelling.Reference;

                Level dwellingLevel = dwelling.RegionLevel(levels, distanceTolerance, angleTolerance);

                Polyline baseCurve = baseCurves.Where(y => y.IsOnLevel(dwellingLevel)).FirstOrDefault();
                if (baseCurve == null)
                    BH.Engine.Reflection.Compute.RecordError("Please make sure there is a basecurve on the same elevation as the dwellings");

                Output<List<List<IRegion>>, List<List<double>>, List<IRegion>, List<IRegion>> mappedRegions = BH.Engine.Environment.Compute.MapRegions(spaces.Select(y => y as IRegion).ToList(), new List<IRegion> { dwelling }, distanceTolerance, angleTolerance);
                List<Space> spacesInDwelling = mappedRegions.Item1[0].Cast<Space>().ToList();

                List<Panel> panelsInDwelling = new List<Panel>();
                foreach (Space s in spacesInDwelling)
                    panelsInDwelling.AddRange(allPanels.Where(y => y.ConnectedSpaces.Contains(s.Name)).ToList());

                List<Opening> openings = panelsInDwelling.OpeningsFromElements();
                Output<List<Polyline>, List<Polyline>, List<Polyline>> openingParts = new Output<List<Polyline>, List<Polyline>, List<Polyline>>();
                foreach (Opening o in openings)
                {
                    Output<List<ICurve>, List<ICurve>, List<ICurve>> outputFromExplode = o.ExplodeToParts(distanceTolerance, angleTolerance, numericalTolerance);
                    thermalBridgeCurves.E2.AddRange(outputFromExplode.Item3.Select(y => y.ICollapseToPolyline(angleTolerance)));
                    thermalBridgeCurves.E4.AddRange(outputFromExplode.Item2.Select(y => y.ICollapseToPolyline(angleTolerance)));

                    if (!(o.Bottom().ICollapseToPolyline(angleTolerance).Centre().IIsOnCurve(dwellingPerimeter)))
                        thermalBridgeCurves.E3.AddRange(outputFromExplode.Item1.Select(y => y.ICollapseToPolyline(angleTolerance)));
                }

                //Sort out party floors - curves that go along the perimeter of the building
                List<Panel> wallPanels = panelsInDwelling.Where(y => y.Type == PanelType.Wall || y.Type == PanelType.WallExternal || y.Type == PanelType.WallInternal).ToList();
                List<Panel> exteriorWalls = wallPanels.Where(y => y.Bottom().IControlPoints().Where(z => (z.IIsOnCurve(baseCurve))).Count() == y.Bottom().IControlPoints().Count()).ToList();
                Output<List<Polyline>, List<Polyline>, List<Polyline>> exteriorWallParts = new Output<List<Polyline>, List<Polyline>, List<Polyline>>();
                exteriorWallParts.Item1 = new List<Polyline>();
                exteriorWallParts.Item2 = new List<Polyline>();
                exteriorWallParts.Item3 = new List<Polyline>();

                foreach (Panel p in exteriorWalls)
                {
                    Output<List<ICurve>, List<ICurve>, List<ICurve>> outputFromExplode = p.ExplodeToParts();
                    exteriorWallParts.Item1.AddRange(outputFromExplode.Item1.Select(y => y.ICollapseToPolyline(angleTolerance)));
                    exteriorWallParts.Item2.AddRange(outputFromExplode.Item2.Select(y => y.ICollapseToPolyline(angleTolerance)));
                    exteriorWallParts.Item3.AddRange(outputFromExplode.Item3.Select(y => y.ICollapseToPolyline(angleTolerance)));
                }

                List<Polyline> partyFloorBottom = exteriorWallParts.Item1;
                List<Polyline> partyFloorTop = new List<Polyline>();

                List<Panel> balconiesOnDwelling = balconyShades.Where(y => (y.Polyline()).LineIntersections(dwellingPerimeter).Count > 0).ToList();

                partyFloorBottom = PartyFloors.CalculatePartyFloors(balconiesOnDwelling, partyFloorBottom);

                thermalBridgeCurves.E23 = BalconyLines.ComputeBalconyLines(balconiesOnDwelling, baseCurve, dwelling.Perimeter.ICollapseToPolyline(angleTolerance));

                if (dwellingLevel != levels.Last())
                {
                    partyFloorTop = exteriorWallParts.Item3;
                    //There may be a balcony above us, find out
                    Level levelAbove = levels[levels.IndexOf(dwellingLevel) + 1];

                    Polyline dwellingCurveAbove = dwellingPerimeter.DeepClone();
                    dwellingCurveAbove.ControlPoints = dwellingCurveAbove.ControlPoints.Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList();

                    Polyline baseCurveAbove = baseCurves.Where(y => y.IsOnLevel(levelAbove)).FirstOrDefault();
                    List<Polyline> baseCurvesAbove = new List<Polyline>();
                    baseCurvesAbove.Add(baseCurveAbove);

                    List<Panel> balconiesAttached = balconyShades.Where(y => (y.Polyline()).LineIntersections(dwellingCurveAbove).Count > 0).ToList();

                    partyFloorTop = PartyFloors.CalculatePartyFloors(balconiesAttached, partyFloorTop);

                    //Work out balcony lines on the upper perimeter
                    thermalBridgeCurves.E23.AddRange(BalconyLines.ComputeBalconyLines(balconiesAttached, baseCurveAbove, dwellingCurveAbove));


                    foreach (Space room in spacesInDwelling)
                    {
                        Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).DeepClone();
                        roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList(); //Pull the space down to the level below
                        List<Polyline> externalCurves = roomClone.BooleanDifference(baseCurvesAbove);
                        List<Polyline> externalParts = externalCurves.SelectMany(y => y.SplitAtPoints(y.ControlPoints())).ToList();
                        Polyline baseCurveClone = baseCurve.DeepClone();
                        baseCurveClone.ControlPoints = baseCurveClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList();

                        List<Polyline> topLines = externalParts.Where(y => y.ControlPoints.Where(z => z.IsOnCurve(baseCurveClone)).Count() == y.ControlPoints().Count()).ToList();

                        thermalBridgeCurves.E15.AddRange(topLines);
                    }
                }
                else //This is the top level
                    thermalBridgeCurves.E15 = exteriorWallParts.Item3;

                thermalBridgeCurves.E7 = partyFloorBottom;
                if (partyFloorTop != null)
                    thermalBridgeCurves.E7.AddRange(partyFloorTop);

                List<Zone> dwellingsOnLevel = dwellings.Where(y => y.Perimeter.ICollapseToPolyline(angleTolerance).IsOnLevel(dwellingLevel)).Where(y => y != dwelling).ToList(); //Available dwellings not including the one being thermal bridged
                List<Zone> connectedDwellings = dwellingsOnLevel.Where(y =>
                {
                    List<ICurve> curves = new List<ICurve>() { y.Perimeter, dwellingPerimeter };
                    List<PolyCurve> union = curves.BooleanUnion();
                    return union.Count == 1;
                }).ToList(); //Only the dwellings which are connected to the current dwelling

                List<Point> connectionPointsToNeighbours = connectedDwellings.SelectMany(y => y.Perimeter.ICurveIntersections(dwelling.Perimeter).Where(z => z.IsOnCurve(baseCurve))).ToList();

                foreach (Point p in connectionPointsToNeighbours)
                {
                    List<Point> ctrlPoints = new List<Point>() { p };
                    ctrlPoints.Add(new Point() { X = p.X, Y = p.Y, Z = p.Z + exteriorWalls[0].Height() }); ;
                    Polyline line = new Polyline() { ControlPoints = ctrlPoints };
                    if (baseCurve.IControlPoints().Contains(p))
                        thermalBridgeCurves.E25.Add(line);
                    else
                        thermalBridgeCurves.E18.Add(line);
                }

                List<Point> baseCurveCornerPoints = baseCurve.CleanPolyline().ControlPoints();
                baseCurveCornerPoints.RemoveAt(baseCurveCornerPoints.Count - 1);
                List<Point> cornerInDwelling = baseCurveCornerPoints.Where(y => y.IIsOnCurve(dwelling.Perimeter)).ToList();

                List<Point> e16Pts = new List<Point>();
                List<Point> e17Pts = new List<Point>();

                foreach (Point pt in cornerInDwelling)
                {
                    List<Polyline> cornerLines = exteriorWallParts.Item1.Where(y => pt.IsOnCurve(y)).ToList();
                    if (cornerLines.Count < 2)
                        e17Pts.Add(pt);
                    else
                    {
                        Point centre1 = cornerLines[0].Centre();
                        Point centre2 = cornerLines[1].Centre();
                        Line joined = new Line() { Start = centre1, End = centre2 };

                        if (baseCurve.IIsContaining(new List<Point>() { joined.Centroid() }))
                            e16Pts.Add(pt);
                        else
                            e17Pts.Add(pt);
                    }
                }

                List<Polyline> e16Lines = new List<Polyline>();
                foreach (Point p in e16Pts)
                {
                    List<Point> ctrlPts = new List<Point>() { p };
                    ctrlPts.Add(new Point() { X = p.X, Y = p.Y, Z = p.Z + exteriorWalls[0].Height() });
                    Polyline pl = new Polyline() { ControlPoints = ctrlPts };
                    thermalBridgeCurves.E16.Add(pl);
                }

                List<Polyline> e17Lines = new List<Polyline>();
                foreach (Point p in e17Pts)
                {
                    List<Point> ctrlPts = new List<Point>() { p };
                    ctrlPts.Add(new Point() { X = p.X, Y = p.Y, Z = p.Z + exteriorWalls[0].Height() });
                    Polyline pl = new Polyline() { ControlPoints = ctrlPts };
                    thermalBridgeCurves.E17.Add(pl);
                }

                thermalBridgesCurves.Add(thermalBridgeCurves);
            }

            return thermalBridgesCurves;
        }
    }
}
