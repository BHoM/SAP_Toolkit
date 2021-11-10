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


using System.Collections.ObjectModel;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;
using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.Engine.Units;
using BH.oM.Geometry.SettingOut;
using BH.oM.Analytical.Elements;
using BH.oM.Reflection;
using BH.Engine.Base;
using BH.oM.Base;
using BH.oM.XML.Bluebeam;

using Opening = BH.oM.Environment.SAP.Opening;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Output<Wall, List<Wall>> AddOpenings(this List<Markup> markups, List<Opening> openings)
        {
            List<double> areas = new List<double>();
            foreach (Markup markup in markups)
            {
                areas.Add(markup.Length * markup.Depth); 
            }

            
            int indexAtMax = areas.IndexOf(areas.Max());
            List<Wall> wallsWithoutOpenings = new List<Wall>();

            for (int i = 0; i < markups.Count; i++)
            {
                if (i != indexAtMax)
                {
                    Wall temp = new Wall();
                    temp.Area = markups[i].Length * markups[i].Depth;
                    temp.DwellingName = "dwelling";
                    temp.Name = markups[i].Label;
                    wallsWithoutOpenings.Add(temp);

                }
            }
            Markup x = markups[indexAtMax];

            Wall y = new Wall();
            y.Openings = openings;
            y.Area = areas.Max();
            y.DwellingName = "dwelling";
            y.Name = x.Label;


            return new Output<Wall, List<Wall>>
            {
                Item1 = y,
                Item2 = wallsWithoutOpenings,
            };
        }
        
    }
}

//var listA = walls;
//var listB = wallAreas;


//var items = new List<Tuple<List<CustomObject>, List<double>>>();
//for (var i = 0; i < listA.Count; ++i)
//    items.Add(Tuple.Create(listA[i], listB[i]));

//var sorted = items.OrderBy(x => x.Item1);

//listA = sorted.Select(x => x.Item1).ToList();
//listB = sorted.Select(x => x.Item2).ToList();


// <Custom additional code> 


/*foreach (Polyline baseCurve in baseCurves)
            {
                double minBaseLevel = baseCurve.MinimumLevel();
                List<Space> spacesOnLevel = spaces.Where(x => x.Perimeter.ICollapseToPolyline(angleTolerance).MinimumLevel() == minBaseLevel).ToList(); // Spaces on the same level as the basecurve
                if (spacesOnLevel.Count == 0)
                    continue;

                List<Space> newSpaces = resnappedSpaces.Where(x => x.Perimeter.ICollapseToPolyline(angleTolerance).MinimumLevel() == minBaseLevel).ToList(); // Spaces on the same level as the basecurve

                List<Point> corners = baseCurve.ControlPoints();
                List<Polyline> basecurveSegments = baseCurve.SplitAtPoints(corners);
                List<Point> invertedPoints = new List<Point>();
                foreach (Point pt in corners)
                {
                    List<Polyline> cornerLines = basecurveSegments.Where(x => pt.IIsOnCurve(x)).ToList();
                    if (cornerLines.Count() > 1)
                    {
                        Point centre1 = cornerLines[0].Centre();
                        Point centre2 = cornerLines[1].Centre();
                        Line joined = new Line() { Start = centre1, End = centre2 };

                        if (!(baseCurve.IIsContaining(new List<Point>() { joined.Centroid() })))
                            invertedPoints.Add(pt);
                    }
                }

                Space prioritySpace = new Space();
                foreach (Point pt in invertedPoints)
                {
                    List<Space> connectedSpaces = spacesOnLevel.Where(x => pt.IIsOnCurve(x.Perimeter)).ToList();
                    foreach (Space space in connectedSpaces)
                    {
                        List<Polyline> spaceParts = space.Perimeter.ICollapseToPolyline(BH.oM.Geometry.Tolerance.Distance).SplitAtPoints(space.Perimeter.IControlPoints()).ToList();
                        List<Polyline> parts = spaceParts.Where(x => pt.IIsOnCurve(x)).ToList();
                        if (parts.Count > 1)
                        {
                            Point centre1 = parts[0].Centre();
                            Point centre2 = parts[1].Centre();
                            Line joined = new Line() { Start = centre1, End = centre2 };
                            if (!((joined.Centroid().IIsOnCurve(parts[0]) || joined.Centroid().IIsOnCurve(parts[1]))))
                                prioritySpace = space;
                        }
                    }

                    List<Space> priorityResnapped = newSpaces.Where(x => x.Name == prioritySpace.Name).ToList();
                    int nr = connectedSpaces.IndexOf(prioritySpace);
                    connectedSpaces.RemoveAt(nr);
                    List<Space> resnappedConnectedspaces = new List<Space>();
                    foreach (Space space in connectedSpaces)
                        resnappedConnectedspaces.Add(newSpaces.Where(x => x.Name == space.Name).FirstOrDefault());

                    List<Polyline> resnappedPerimeters = priorityResnapped.Select(x => x.Perimeter.ICollapseToPolyline(BH.oM.Geometry.Tolerance.Angle)).ToList();

                    foreach (Space space in resnappedConnectedspaces)
                    {
                        Polyline perimeter = space.Perimeter.ICollapseToPolyline(BH.oM.Geometry.Tolerance.Angle);
                        Polyline newPerimeter = perimeter.BooleanDifference(resnappedPerimeters).FirstOrDefault();
                        space.Perimeter = newPerimeter;
                        Space matchingSpace = newSpaces.Where(x => x.Name == space.Name).FirstOrDefault();
                        int number = resnappedSpaces.IndexOf(matchingSpace);
                        resnappedSpaces[number] = space;

                        List<Panel> panels1 = panels.ToSpace(space.Name);
                        double spaceLevel = space.Perimeter.ICollapseToPolyline(angleTolerance).MinimumLevel();
                        Panel floor = panels1.Where(x => x.MinimumLevel() == spaceLevel).FirstOrDefault();
                        Panel ceiling = panels1.Where(x => x.MinimumLevel() != spaceLevel).FirstOrDefault();

                        if (floor != null)
                        {
                            int floorIndex = panels.IndexOf(floor);
                            floor.ExternalEdges = space.Perimeter.ToEdges();

                            if (floorIndex != -1)
                                panels[floorIndex] = floor;
                        }

                        if (ceiling != null)
                        {
                            int ceilingIndex = panels.IndexOf(ceiling);
                            double z = ceiling.MinimumLevel();
                            Polyline spaceClone = space.Perimeter.ICollapseToPolyline(angleTolerance).DeepClone();
                            spaceClone.ControlPoints = spaceClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = z }).ToList();
                            ceiling.ExternalEdges = space.Perimeter.ToEdges();

                            if (ceilingIndex != -1)
                                panels[ceilingIndex] = ceiling;
                        }
                    }
                }
            }
*/