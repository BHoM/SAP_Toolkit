/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.Engine.Units;
using BH.oM.Spatial.SettingOut;
using BH.oM.Analytical.Elements;
using BH.oM.Base;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Create a SAP export object from BHoM geometry.")]
        [Input("dwelling", "A self-contained unit of accommodation, that could contain smaller spaces.")]
        [Input("spaces", "A collection of spaces within the dwelling.")]
        [Input("panels", "A collection of Environment Panels within the dwelling, with connected space names matching the space names.")]
        [Input("balconies", "A collection of Environment Panels representing any balconies adjacent to the dwelling.")]
        [Input("baseCurves", "A collection of curves representing the outline of the building, one for each modelled floor.")]
        [Input("levels", "A collection of levels containing the elevations of the floors.")]
        [Input("frontDoors", "A collection of opening representing the dwelling entraces. Used to get the orientation of the dwelling.")]
        [Input("ceilingHeight", "The internal height of the dwelling, from floor top to ceiling bottom.")]
        [Input("ceilingVoidHeight", "The ceiling thickness of the dwelling.")]
        [Input("externalWallHeight", "The total floor to floor height of the dwelling.")]
        [Input("distanceTolerance", "Distance tolerance for calculating discontinuity points, default is set to the value defined by BH.oM.Geometry.Tolerance.Distance.")]
        [Input("angleTolerance", "Angle tolerance for calculating discontinuity points, default is set to the value defined by BH.oM.Geometry.Tolerance.Angle.")]
        [Output("SAPExport", "A SAP export object.")]
        public static SAPExport SAPExport(Zone dwelling, List<Space> spaces, List<Panel> panels, List<Panel> balconies, List<Polyline> baseCurves, List<Level> levels, List<BH.oM.Environment.Elements.Opening> frontDoors, double ceilingHeight, double ceilingVoidHeight, double externalWallHeight, double distanceTolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle, int crossVentTolerance = 45)
        {
            SAPExport sapExport = new SAPExport();

            levels = levels.OrderBy(x => x.Elevation).ToList(); // need to reorder the levels
            Polyline dwellingPerimeter = dwelling.Perimeter.ICollapseToPolyline(angleTolerance);

            #region General Dwelling Information
            sapExport.Name = dwelling.Name;
            sapExport.Reference = dwelling.Reference;

            Output<List<List<IRegion>>, List<List<double>>, List<IRegion>, List<IRegion>> mappedRegions = BH.Engine.Environment.Compute.MapRegions(spaces.Select(x => x as IRegion).ToList(), new List<IRegion> { dwelling }, distanceTolerance, angleTolerance);
            List<Space> spacesInDwelling = mappedRegions.Item1[0].Cast<Space>().ToList();

            sapExport.WetRooms = spacesInDwelling.Where(x => x.SpaceType == SpaceType.Bathroom).Count();
            sapExport.DwellingBeds = spacesInDwelling.Where(x => x.SpaceType == SpaceType.Bedroom).Count();

            BH.oM.Environment.Elements.Opening doorInDwelling = frontDoors.Where(x => dwellingPerimeter.IIsContaining(x.Bottom(distanceTolerance, angleTolerance))).FirstOrDefault();
            Space space = spaces.Where(x => x.Perimeter.IIsContaining(doorInDwelling.Bottom(distanceTolerance, angleTolerance).IControlPoints())).FirstOrDefault();
            List<Panel> panelsInSpace = panels.Where(x => x.ConnectedSpaces.Contains(space.Name)).ToList();
            if (!doorInDwelling.Polyline().NormalAwayFromSpace(panelsInSpace))
                doorInDwelling.Edges = doorInDwelling.Polyline().Flip().ToEdges(); //Make sure the normal of the door is pointing away from its containing space

            int orientation = System.Convert.ToInt32(doorInDwelling.Orientation(0, true).Value.ToDegree());
            sapExport.OrientationDegrees = orientation;
            sapExport.Orientation = OrientationText.ToOrientationText(orientation);

            Polyline baseCurve = baseCurves.Where(y => y.ICurveIntersections(dwellingPerimeter).Count > 0).FirstOrDefault();
            List<Panel> panelsInDwelling = new List<Panel>();
            foreach (Space s in spacesInDwelling)
                panelsInDwelling.AddRange(panels.Where(x => x.ConnectedSpaces.Contains(s.Name)).ToList());

            List<Panel> wallPanels = panelsInDwelling.Where(x => (x.Type == PanelType.Wall || x.Type == PanelType.WallExternal || x.Type == PanelType.WallInternal) && x.Bottom().IControlPoints().Where(y => (y.IIsOnCurve(dwellingPerimeter))).Count() == x.Bottom().IControlPoints().Count()).ToList();
            wallPanels.FlipPanels();

            List<Panel> exteriorWalls = wallPanels.Where(y => y.Bottom().IControlPoints().Where(z => (z.IIsOnCurve(baseCurve))).Count() == y.Bottom().IControlPoints().Count()).ToList();

            List<int> orientations = wallPanels.Select(x =>
            {
                int orientationX = System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree());
                if (orientationX == 360)
                    orientationX = 0;
                return orientationX;
            }).Distinct().ToList();

            List<int> wallOrientations = exteriorWalls.Select(x =>
            {
            int wallOrientation = System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree());
                if (wallOrientation == 360)
                    wallOrientation = 0;
                return wallOrientation;
            }).Distinct().ToList();

            sapExport.ShelteredSides = orientations.Count - wallOrientations.Count;

            List<BH.oM.Environment.Elements.Opening> openings = panelsInDwelling.SelectMany(x => x.Openings).ToList();
            List<int> openingOrientations = openings.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).Distinct().ToList();

            string crossVent = "False"; //Default position is that there is no cross ventilation
            if (openingOrientations.Count > 1)
            {
                for (int i = 0; i < openingOrientations.Count; i++)
                {
                    for (int j = i + 1; j < openingOrientations.Count; j++)
                    {
                        if (openingOrientations[j] <= 180 && openingOrientations[i] == 360)
                            openingOrientations[i] = 0;

                        if (openingOrientations[j] == 360 && openingOrientations[i] <= 180)
                            openingOrientations[j] = 0;

                        int dif = Math.Abs(openingOrientations[i] - openingOrientations[j]);
                        if (dif <= 180 + crossVentTolerance && dif >= 180 - crossVentTolerance)
                        {
                            crossVent = "True";
                            break;
                        }
                    }
                }
            }

            sapExport.CrossVentilation = crossVent;
            #endregion

            double roomArea = spacesInDwelling.Select(y => y.Perimeter.IArea()).Sum();
            //Check if the sum of the space areas is equal to the dwelling area
            if (roomArea > dwellingPerimeter.IArea() + distanceTolerance || roomArea < dwellingPerimeter.IArea() - distanceTolerance)
                BH.Engine.Base.Compute.RecordError($"The sum of internal space areas is not equal to the total dwelling area for dwelling {dwelling.Name}.");

            sapExport.TotalArea = dwellingPerimeter.IArea();
            List<string> spacesToAdd = new List<string>(); //To prevent adding the same space twice
            List<Space> spacesToInvestigate = spacesInDwelling.Where(x => x.SpaceType == SpaceType.Lounge).ToList();

            while(spacesToInvestigate.Count > 0)
            {
                Space current = spacesToInvestigate[0];
                spacesToInvestigate.RemoveAt(0);
                spacesToAdd.Add(current.Name);

                List<string> spacesConnectedByAir = panels.Where(x => x.ConnectedSpaces.Contains(current.Name) && x.Type == PanelType.Air).SelectMany(x => x.ConnectedSpaces).Where(x => x != current.Name && !spacesToAdd.Contains(x)).Distinct().ToList();
                spacesToInvestigate.AddRange(spacesInDwelling.Where(x => spacesConnectedByAir.Contains(x.Name)));
            }

            spacesToAdd = spacesToAdd.Distinct().ToList();
            spacesToAdd.ForEach(x => sapExport.LivingArea += spacesInDwelling.Where(a => a.Name == x).First().Perimeter.IArea());
            sapExport.CoolingArea = spacesInDwelling.Where(y => y.SpaceType == SpaceType.Kitchen || y.SpaceType == SpaceType.Lounge || y.SpaceType == SpaceType.Bedroom).Select(y => y.Perimeter.IArea()).Sum();

            #region Calculate the external floor and roof area

            Level dwellingLevel = dwelling.RegionLevel(levels, distanceTolerance, angleTolerance);

            if (dwellingPerimeter.IsOnLevel(levels.First(), distanceTolerance))
            {
                foreach (Space s in spacesInDwelling)
                {
                    sapExport.ExternalFloorArea.Add(s.Perimeter.IArea());
                    sapExport.PartyFloor.Add(0);
                } 
            }
            else
            {
                //Pull the space down to the level below, if the base curve of the level below does not contain the space then it is an overhang and counts towards external floor area
                Level levelBelow = levels[levels.IndexOf(dwellingLevel) - 1];
                List<Polyline> baseCurvesBelow = baseCurves.Where(y => y.IsOnLevel(levelBelow)).ToList();

                foreach (Space room in spacesInDwelling)
                {
                    Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).DeepClone();
                    roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelBelow.Elevation }).ToList(); //Pull the space down to the level below
                    List<Polyline> externalCurves = roomClone.BooleanDifference(baseCurvesBelow);
                    foreach (Polyline ln in externalCurves)
                    {
                        double value = 0;
                        if(ln != null)
                        {
                            double area = ln.Area();
                            if (area > 0)
                                value = area;
                        }

                        sapExport.ExternalFloorArea.Add(value);
                        sapExport.PartyFloor.Add(roomClone.Area() - value);
                    }
                    
                    if(externalCurves.Count == 0)
                    {
                        sapExport.ExternalFloorArea.Add(0);
                        sapExport.PartyFloor.Add(roomClone.Area());
                    }
                }
            }

            Level levelAbove = null; 
            List<Panel> shadesOnLevelAbove = new List<Panel>();
            if (dwellingPerimeter.IsOnLevel(levels.Last(), distanceTolerance))
            {
                foreach (Space s in spacesInDwelling)
                {
                    sapExport.ExternalRoofArea.Add(s.Perimeter.IArea());
                    sapExport.PartyRoof.Add(0);
                }
            }
            else
            {
                //Do the same as above, but for the roof
                levelAbove = levels[levels.IndexOf(dwellingLevel) + 1];
                List<Polyline> baseCurvesAbove = baseCurves.Where(y => y.IsOnLevel(levelAbove)).ToList();

                foreach (Space room in spacesInDwelling)
                {
                    Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).DeepClone();
                    roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList(); //Pull the space down to the level below
                    List<Polyline> externalCurves = roomClone.BooleanDifference(baseCurvesAbove);
                    foreach (Polyline ln in externalCurves)
                    {
                        double value = 0;
                        if (ln != null)
                        {
                            double area = ln.Area();
                            if (area > 0)
                                value = area;
                        }

                        sapExport.ExternalRoofArea.Add(value);
                        sapExport.PartyRoof.Add(roomClone.Area() - value);
                    }

                    if (externalCurves.Count == 0)
                    {
                        sapExport.ExternalRoofArea.Add(0);
                        sapExport.PartyRoof.Add(roomClone.Area());
                    }
                }

                shadesOnLevelAbove = balconies.Where(x => x.Polyline().IsOnLevel(levelAbove, distanceTolerance)).ToList();

            }
            #endregion

            if (ceilingHeight + ceilingVoidHeight != externalWallHeight)
                BH.Engine.Base.Compute.RecordError("The sum of ceilingHeight and ceilingVoidHeight is not equal to the external wall height");

            sapExport.CeilingHeight = ceilingHeight;
            sapExport.CeilingVoidHeight = ceilingVoidHeight;
            sapExport.ExternalWallHeight = externalWallHeight;
            sapExport.ExternalWallLength = exteriorWalls.Select(x => x.Bottom().ILength()).Sum();

            List<bool> wideOverhang = new List<bool>();
            List<double> overhangRatio = new List<double>();
            List<double> width = new List<double>();
            List<double> height = new List<double>();
            List<string> orientationTexts = new List<string>();

            for (int x = 0; x < openings.Count; x++)
            {
                BH.oM.Environment.Elements.Opening o = openings[x];

                wideOverhang.Add(false);
                overhangRatio.Add(0);
                width.Add(o.Width().ToMillimetre());
                height.Add(o.Height().ToMillimetre());
                orientationTexts.Add(OrientationText.ToOrientationText(o.Orientation(0, true).Value.ToDegree()));
                
                if (levelAbove != null)
                {
                    Point centre = o.Polyline().Centroid();
                    centre.Z = levelAbove.Elevation;
                    //Find a shade which intersects this opening
                    Panel shade = shadesOnLevelAbove.Where(y => y.IsContaining(centre, true)).FirstOrDefault();

                    if (shade != null)
                    {
                        List<Polyline> shadeParts = shade.Polyline().SplitAtPoints(shade.Polyline().IControlPoints());
                        List<double> lengths = shadeParts.Select(y => Math.Round(y.Length(), 3)).Distinct().ToList();

                        if (lengths.Max() > o.Width())
                            wideOverhang[wideOverhang.Count - 1] = true;

                        overhangRatio[overhangRatio.Count - 1] = (lengths.Min() / o.Height());
                    }
                }
            }

            sapExport.WindowLength = width;
            sapExport.WindowHeight = height;
            sapExport.WindowOrientation = orientationTexts;
            sapExport.WideOverhang = wideOverhang;
            sapExport.OverhangRatio = overhangRatio;

            return sapExport;
        }
    }
}


