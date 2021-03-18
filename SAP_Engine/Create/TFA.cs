using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Geometry;
using BH.oM.Geometry.SettingOut;
using BH.oM.Reflection.Attributes;
using BH.oM.Geometry;



namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create TFA BHoMObjects for SAP analysis")]
        [Input("dwellings", "")] // TODO
        [Output("tfa", "A BHoMObject for SAP analysis. Contains info about dwelling areas")]

        public static List<TFA> TFA(List<Dwelling> dwellings, List<Level> levels, List<Polyline> baseCurves, double tolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle)
        {
            List<TFA> tfas = new List<TFA>();

            double minElevation = levels.Min(x => x.Elevation);
            double maxElevation = levels.Max(x => x.Elevation);

            for (int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                TFA tfa = new TFA();

                tfa.DwellingName = dwelling.Name;
                tfa.Reference = dwelling.Reference;
                tfa.ID = (x + 1);

                double roomArea = dwelling.Rooms.Select(y => y.Perimeter.IArea()).Sum();
                if (roomArea != dwelling.Perimeter.IArea())
                {
                    BH.Engine.Reflection.Compute.RecordError("The sum of internal room areas is not equal to the total dwelling area.");
                }
                tfa.TotalArea = dwelling.Perimeter.IArea();

                double livingFloorArea = 0;
                List<BH.oM.Environment.SAP.Space> rooms = dwelling.Rooms.Where(y => y.Type == SAPSpaceType.LivingRoom).ToList();
                livingFloorArea = rooms.Select(y => y.Perimeter.IArea()).Sum();

                //Add the area of rooms connected to the living areas by air walls
                List<string> spacesToAdd = new List<string>(); //To prevent adding the same space twice
                foreach(BH.oM.Environment.SAP.Space s in rooms)
                {
                    List<Panel> airPanels = s.Panels.Where(y => y.Type == PanelType.Air).ToList();
                    List<string> connectedSpaces = new List<string>();
                    foreach(Panel p in airPanels)
                        connectedSpaces.AddRange(p.ConnectedSpaces.Where(y => y != s.Name));

                    connectedSpaces = connectedSpaces.Distinct().ToList();

                    connectedSpaces = connectedSpaces.Where(y => spacesToAdd.IndexOf(y) == -1).ToList();
                    spacesToAdd.AddRange(connectedSpaces);
                    spacesToAdd = spacesToAdd.Distinct().ToList();
                }

                foreach(string s in spacesToAdd)
                {
                    livingFloorArea += dwelling.Rooms.Where(y => y.Name == s).First().Perimeter.IArea();
                }

                tfa.LivingArea = livingFloorArea;

                tfa.CoolingArea = dwelling.Rooms.Where(y => y.Type == SAPSpaceType.Kitchen || y.Type == SAPSpaceType.LivingRoom || y.Type == SAPSpaceType.Bedroom).Select(y => y.Perimeter.IArea()).Sum();

                double maxZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Max() + tolerance;
                double minZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Min() - tolerance;

                Level dwellingLevel = dwelling.Level(levels);

                if (minElevation >= minZ && minElevation <= maxZ)
                {
                    //Dwelling is on the ground
                    tfa.ExternalFloorArea = dwelling.Perimeter.IArea();
                }
                else
                {
                    Level levelBelow = levels[levels.IndexOf(dwellingLevel) - 1];
                    Polyline baseCurveBelow = baseCurves.Where(y => y.IsOnLevel(levelBelow)).FirstOrDefault();
                    double spaceAreas = 0;
                    foreach (BH.oM.Environment.SAP.Space room in dwelling.Rooms)
                    {

                        Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).Clone();
                        roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelBelow.Elevation }).ToList();
                        List<Point> controlPoints = roomClone.IControlPoints();
                        if (!baseCurveBelow.IIsContaining(controlPoints))
                        {
                            spaceAreas += room.Perimeter.IArea();
                        }
                    }

                    tfa.ExternalFloorArea = spaceAreas;
                }
                
                
                if(maxElevation >= minZ && maxElevation <= maxZ)
                {
                    //Dwelling is on the top floor
                    tfa.ExternalRoofArea = dwelling.Perimeter.IArea();
                }
                else
                {
                    Level levelAbove = levels[levels.IndexOf(dwellingLevel) + 1];
                    Polyline baseCurveAbove = baseCurves.Where(y => y.IsOnLevel(levelAbove)).FirstOrDefault();
                    double spaceAreas = 0;
                    foreach (BH.oM.Environment.SAP.Space room in dwelling.Rooms)
                    {

                        Polyline roomClone = room.Perimeter.ICollapseToPolyline(angleTolerance).Clone();
                        roomClone.ControlPoints = roomClone.IControlPoints().Select(y => new Point { X = y.X, Y = y.Y, Z = levelAbove.Elevation }).ToList();
                        List<Point> controlPoints = roomClone.IControlPoints();
                        if (!baseCurveAbove.IIsContaining(controlPoints))
                        {
                            spaceAreas += room.Perimeter.IArea();
                        }
                    }

                    tfa.ExternalRoofArea = spaceAreas;
                }
                tfas.Add(tfa);
            }

            return tfas;
        }
    }
}
