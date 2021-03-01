using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.BuroHappoldMachineLearning;
using BH.oM.Environment.SAP;
using BH.oM.Geometry;
using BH.oM.Environment.Elements;
using BH.Engine.Units;
using BH.Engine.Geometry;
using BH.Engine.Environment.SAP;
using BH.Engine.Environment;



namespace BH.Engine.BuroHappoldMachineLearning
{
    public static partial class Create
    {
        public static List<MachineLearningExport> MachineLearningExport(List<Dwelling> dwellings, List<Panel> balconies, double gValue, double totalRadiation, double adf)
        {
            List<MachineLearningExport> machineLearningExports = new List<MachineLearningExport>();
            for (int x = 0; x < dwellings.Count; x++)
            {
                MachineLearningExport machineLearningExport = new MachineLearningExport();
                Dwelling dwelling = dwellings[x];
                int dwellingBedRooms = dwelling.Rooms.Where(y => y.Type == SAPSpaceType.Bedroom).Count();

                // Balconies
                List<Panel> balconiesInDwelling = balconies.Where(y => (y.Polyline()).LineIntersections(dwelling.Perimeter as Polyline).Count > 1).ToList();
                double balconyDepth= 0;
                string balconyType = "";

                for (int i = 0; i < balconiesInDwelling.Count; i++)
                {
                    List<Polyline> shadeParts = balconiesInDwelling[i].Polyline().SplitAtPoints(balconiesInDwelling[i].Polyline().IControlPoints());
                    List<Polyline> balconyIntersections = shadeParts.Where(y => (y.ControlPoints.Where(z => z.IIsOnCurve(dwelling.Perimeter as Polyline)).Count()) == 1).ToList();
                    balconyDepth = balconyIntersections.Select(y => y.ILength()).Max();
                    if (balconyDepth > 0.5)
                    {
                        balconyType = "Standard Balcony";
                    }
                    else balconyType = "Juliette Balcony";
                }
                for (int i = 0; i < dwelling.Rooms.Count; i++)
                {
                    oM.Environment.SAP.Space room = dwelling.Rooms[i];
                    if (room.Type == SAPSpaceType.Bedroom || room.Type== SAPSpaceType.Kitchen || room.Type == SAPSpaceType.LivingRoom)
                    {
                        machineLearningExport.ID = dwelling.Name;
                        machineLearningExport.RoomType = room.Type.ToString();

                        List<Opening> openings = room.Panels.OpeningsFromElements().ToList();
                        if (openings.Count > 3)
                        {
                            BH.Engine.Reflection.Compute.RecordWarning("This room has more than three windows. Only the first three will be taken into account");
                        }

                        Opening openingA = openings[0];
                        Opening openingB = openings[1];
                        Opening openingC = openings[2];

                        machineLearningExport.GlazingAreaA = openingA.Polyline().IArea();
                        machineLearningExport.GlazingAreaB = openingB.Polyline().IArea();
                        machineLearningExport.GlazingAreaC = openingC.Polyline().IArea();

                        dwelling.Rooms = dwelling.Rooms.Select(y => y.FlipPanels()).ToList();
                        machineLearningExport.OrientationA = openingA.Orientation(0, true).Value.ToDegree();
                        machineLearningExport.OrientationB = openingB.Orientation(0, true).Value.ToDegree();
                        machineLearningExport.OrientationC = openingC.Orientation(0, true).Value.ToDegree();

                        // Need to use flippanels method somewhere

                        List<double> openingOrientations = openings.Select(y =>
                        {
                            double? orient = y.Orientation(0, true);
                            if (orient != null)
                                return orient.Value.ToDegree();
                            
                            return -1; //Something went wrong, orientation returned null
                        }).ToList();

                        List<double> uniqueOpeningOrientations = openingOrientations.Where(y => y != -1).Distinct().ToList();
                        if (uniqueOpeningOrientations.Count != 0)
                        {
                            if (uniqueOpeningOrientations.Count == 1)
                                machineLearningExport.SingleDualAspect = "Single";
                            else
                                machineLearningExport.SingleDualAspect = "Dual";
                        }
                        else
                            machineLearningExport.SingleDualAspect = "0";




                        //List<Panel> balconyInRoom = balconies.Where();
                        // Find balcony that intersects the room perimeter
                        // Measure the depth of the balcony
                        // If balcony depth < 0.5 = Juliette balcony

                        double windowArea = openings.Select(y => y.Polyline().IArea()).Sum();
                        machineLearningExport.GValue = gValue;

                        machineLearningExport.DwellingBeds = dwellingBedRooms;
                        machineLearningExport.BalconyType = balconyType;
                        machineLearningExport.TotalRadiation = totalRadiation;
                        machineLearningExport.ADF = adf;

                        double floorArea = (room.Perimeter as Polyline).Area();
                        machineLearningExport.GlazingRatioWinFl = windowArea / floorArea;
                        machineLearningExport.GlazedArea = windowArea;

                        List<Panel> wallPanels = room.Panels.Where(a => a.Type == oM.Environment.Elements.PanelType.WallExternal).ToList();
                        List<Point> controlPoints = wallPanels.SelectMany(y => y.Polyline().ControlPoints()).ToList();
                        List<Panel> exteriorwalls = wallPanels.Where(y => (y.Polyline().ICurveIntersections(room.Perimeter).Count > 0)).ToList();

                        List<Panel> exteriorIntersections = exteriorwalls.Where(y => y.Polyline().ControlPoints().Where(z => (z.IIsOnCurve(room.Perimeter))).Count() == y.Bottom().IControlPoints().Count).ToList();
                        double externalWallArea = exteriorIntersections.Select(y => y.Polyline().Area()).Sum();
                        machineLearningExport.ExtWallArea = externalWallArea;
                        machineLearningExport.GlazRatio = windowArea / externalWallArea;

                    }

                }

            }

            return machineLearningExports;
        }


    }



}

