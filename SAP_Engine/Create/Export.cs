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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create a SAP export object from BHoM geometry. ")]

        [Output("SAPExport", "a SAP export object ready for conversion to XML")]
        public static Export Export(Dwelling dwelling, List<Space> spaces, List<Panel> allPanels, List<Panel> balconies, List<Opening> frontDoors, List<Polyline> baseCurves, List<Level> levels, double ceilingHeight, double ceilingVoidHeight, double externalWallThickness, double tolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle, int crossVentTolerance = 45)
        {
            Export sapExport = new Export();

            levels = levels.OrderBy(x => x.Elevation).ToList(); // need to reorder the levels

            sapExport.Name = dwelling.Name;
            sapExport.Reference = dwelling.Reference;

            Output<List<List<IRegion>>, List<List<double>>, List<IRegion>, List<IRegion>> someStupidOutput = BH.Engine.Environment.Compute.MapRegions(spaces.Select(x => x as IRegion).ToList(), new List<IRegion> { dwelling }, tolerance, angleTolerance);
            List<Space> spacesInDwelling = someStupidOutput.Item1[0].Cast<Space>().ToList();

            sapExport.WetRooms = spacesInDwelling.Where(x => x.SpaceType == SpaceType.Bathroom).Count();
            sapExport.DwellingBeds = spacesInDwelling.Where(x => x.SpaceType == SpaceType.Bedroom).Count();

            Opening doorInDwelling = frontDoors.Where(x => x.Bottom().IControlPoints().FirstOrDefault().IIsOnCurve(dwelling.Perimeter)).FirstOrDefault();
            Space space = spaces.Where(x => x.Perimeter.IIsContaining(doorInDwelling.Bottom().IControlPoints())).FirstOrDefault();
            List<Panel> panelsInSpace = allPanels.Where(x => x.ConnectedSpaces.Contains(space.Name)).ToList();
            if (!doorInDwelling.Polyline().NormalAwayFromSpace(panelsInSpace))
                doorInDwelling.Edges = doorInDwelling.Polyline().Flip().ToEdges(); //Make sure the normal of the door is pointing away from its containing space

            int orientation = System.Convert.ToInt32(doorInDwelling.Orientation(0, true).Value.ToDegree());
            sapExport.OrientationDegrees = orientation;
            sapExport.Orientation = Compute.ToOrientationText(orientation);

            Polyline baseCurve = baseCurves.Where(y => y.ICurveIntersections(dwelling.Perimeter).Count > 0).FirstOrDefault();
            List<Panel> panelsInDwelling = new List<Panel>();
            foreach (Space s in spacesInDwelling)
                panelsInDwelling.AddRange(allPanels.Where(x => x.ConnectedSpaces.Contains(s.Name)).ToList());

            List<Panel> wallPanels = panelsInDwelling.Where(x => x.Type == PanelType.Wall || x.Type == PanelType.WallExternal || x.Type == PanelType.WallInternal).ToList();
            List<Panel> exteriorWalls = wallPanels.Where(y => y.Bottom().IControlPoints().Where(z => (z.IIsOnCurve(baseCurve))).Count() == y.Bottom().IControlPoints().Count()).ToList();

            List<int> orientations = wallPanels.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).Distinct().ToList();
            List<int> wallOrientations = exteriorWalls.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).Distinct().ToList();
            sapExport.ShelteredSides = orientations.Count - wallOrientations.Count;

            List<Opening> openings = panelsInDwelling.SelectMany(x => x.Openings).ToList();
            List<int> openingOrientations = openings.Select(x => System.Convert.ToInt32(x.Orientation(0, true).Value.ToDegree())).Distinct().ToList();

            string crossVent = "False"; //Default position is that there is no fucking cross ventilation
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
                            crossVent = "True";
                    }
                }
            }

            sapExport.CrossVentilation = crossVent;
            // Move opening orientations here?

            
            double roomArea = spacesInDwelling.Select(y => y.Perimeter.IArea()).Sum();

            //Check if the sum of the space areas is equal to the dwelling area
            if (roomArea > dwelling.Perimeter.IArea() + tolerance || roomArea < dwelling.Perimeter.IArea() - tolerance)
                BH.Engine.Reflection.Compute.RecordError($"The sum of internal room areas is not equal to the total dwelling area for dwelling {dwelling.Name}.");

            sapExport.TotalArea = dwelling.Perimeter.IArea();
            List<string> spacesToAdd = new List<string>(); //To prevent adding the same space twice
            List<Space> spacesToInvestigate = spacesInDwelling.Where(x => x.SpaceType == SpaceType.Lounge).ToList();

            while(spacesToInvestigate.Count > 0)
            {
                Space current = spacesToInvestigate[0];
                spacesToInvestigate.RemoveAt(0);
                spacesToAdd.Add(current.Name);

                List<string> spacesConnectedByAir = allPanels.Where(x => x.ConnectedSpaces.Contains(current.Name) && x.Type == PanelType.Air).SelectMany(x => x.ConnectedSpaces).Where(x => x != current.Name && !spacesToAdd.Contains(x)).Distinct().ToList();
                spacesToInvestigate.AddRange(spacesInDwelling.Where(x => spacesConnectedByAir.Contains(x.Name)));
            }

            spacesToAdd.ForEach(x => sapExport.LivingArea += spacesInDwelling.Where(a => a.Name == x).First().Perimeter.IArea());
            sapExport.CoolingArea = spacesInDwelling.Where(y => y.SpaceType == SpaceType.Kitchen || y.SpaceType == SpaceType.Lounge || y.SpaceType == SpaceType.Bedroom).Select(y => y.Perimeter.IArea()).Sum();

            #region Calculate the external floor and roof area
            double maxZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Max() + tolerance;
            double minZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Min() - tolerance;

            Level dwellingLevel = levels.Where(x => x.Elevation >= minZ && x.Elevation <= maxZ).FirstOrDefault();
            double minElevation = levels.Min(x => x.Elevation);
            double maxElevation = levels.Max(x => x.Elevation);

            if (minElevation >= minZ && minElevation <= maxZ)
                sapExport.ExtFloorArea = dwelling.Perimeter.IArea(); //Dwelling is on the ground
            else
            {
                //Pull the space down to the level below, if the base curve of the level below does not contain the space then it is an overhang and counts towards external floor area
                Level levelBelow = levels[levels.IndexOf(dwellingLevel) - 1];
                Polyline baseCurveBelow = baseCurves.Where(y => y.IsOnLevel(levelBelow)).FirstOrDefault();

                foreach (Space room in spacesInDwelling)
                {
                    Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).Clone();
                    roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelBelow.Elevation }).ToList(); //Pull the space down to the level below
                    if (!baseCurveBelow.IIsContaining(roomClone.IControlPoints()))
                        sapExport.ExtFloorArea += roomClone.IArea();

                }
            }

            if (maxElevation >= minZ && maxElevation <= maxZ)
                sapExport.ExtRoofArea = dwelling.Perimeter.IArea(); //Dwelling is on the top floor
            else
            {
                //Do the same as above, but for the roof
                Level levelAbove = levels[levels.IndexOf(dwellingLevel) + 1];
                Polyline baseCurveAbove = baseCurves.Where(y => y.IsOnLevel(levelAbove)).FirstOrDefault();

                foreach (Space room in spacesInDwelling)
                {
                    Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).Clone();
                    roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList(); //Pull the space up to the roof level
                    if (!baseCurveAbove.IIsContaining(roomClone.IControlPoints()))
                        sapExport.ExtRoofArea += roomClone.IArea();

                }
            }
            #endregion

            sapExport.PartyFloor = sapExport.TotalArea - sapExport.ExtFloorArea;
            sapExport.PartyRoof = sapExport.TotalArea - sapExport.ExtRoofArea;
            sapExport.CeilingHeight = ceilingHeight;
            sapExport.ExternalWallHeight = ceilingHeight + ceilingVoidHeight; //  fix this
            //wall.ExternalWallThickness = externalWallThickness; // fix this?
            sapExport.ExternalWallLength = exteriorWalls.Select(x => x.Bottom().ILength()).Sum();

            // Should this be placed with the ExtRoofArea loop
            Level floorAbove = null;
            List<Panel> shadesOnLevelAbove = new List<Panel>();
            if (!(dwellingLevel.Elevation >= minElevation && dwellingLevel.Elevation <= maxElevation))
            {
                //Dwelling is not on the top level so shading may exist above it
                List<double> elevations = levels.Select(x => x.Elevation).ToList();
                elevations.Sort();

                int index = elevations.IndexOf(dwellingLevel.Elevation);
                index++;
                if (index == elevations.Count)
                    index--; //For safety but should not happen

                floorAbove = levels.Where(x => x.Elevation >= (elevations[index] - tolerance) && x.Elevation <= (elevations[index] + tolerance)).FirstOrDefault();
                double minFloorElevation = Math.Round(floorAbove.Elevation - tolerance, 4);
                double maxFloorElevation = Math.Round(floorAbove.Elevation + tolerance, 4);

                foreach (Panel shade in balconies)
                {
                    double maZ = Math.Round(shade.Polyline().IControlPoints().Select(y => y.Z).Max() + tolerance, 4);
                    double miZ = Math.Round(shade.Polyline().IControlPoints().Select(y => y.Z).Min() - tolerance, 4);

                    if (miZ >= minFloorElevation && maZ <= maxFloorElevation)
                        shadesOnLevelAbove.Add(shade);
                }
            }

            List<bool> wideOverhang = new List<bool>();
            List<double> overhangRatio = new List<double>();
            List<double> width = new List<double>();
            List<double> height = new List<double>();
            List<string> orientationTexts = new List<string>();

            for (int x = 0; x < openings.Count; x++)
            {
                Opening o = openings[x];

                wideOverhang.Add(false);
                overhangRatio.Add(0);
                width.Add(o.Width().ToMillimetre());
                height.Add(o.Height().ToMillimetre());
                Point centre = o.Polyline().Centroid();
                if (floorAbove != null)
                {
                    centre.Z = floorAbove.Elevation;
                    //Find a shade which intersects this opening
                    Panel shade = shadesOnLevelAbove.Where(y => y.IsContaining(centre, true)).FirstOrDefault();

                    if (shade != null)
                    {
                        List<Polyline> shadeParts = shade.Polyline().SplitAtPoints(shade.Polyline().IControlPoints());
                        List<double> lengths = shadeParts.Select(y => Math.Round(y.Length(), 3)).Distinct().ToList();

                        double shadeWidth = lengths.Max();
                        if (shadeWidth > o.Width())
                            wideOverhang[wideOverhang.Count - 1] = true;

                        double shadeDepth = lengths.Min();
                        overhangRatio[overhangRatio.Count - 1] = (shadeDepth / o.Height());
                    }
                }

                orientationTexts.Add(Compute.ToOrientationText(o.Orientation(0, true).Value.ToDegree()));
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