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
        public static Window Window(Dwelling dwelling, double frameFactor, List<Panel> balconyShades, List<Level> levels, double tolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            Window window = new Window();

            double maxZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Max() + tolerance;
            double minZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Min() - tolerance;
            Level dwellingLevel = levels.Where(x => x.Elevation >= minZ && x.Elevation <= maxZ).FirstOrDefault();
            Level floorAbove = null;

            List<Panel> shadesOnLevelAbove = new List<Panel>();
            if(!(dwellingLevel.Elevation >= (levels.Select(x => x.Elevation).Max() - tolerance) && dwellingLevel.Elevation <= (levels.Select(x => x.Elevation).Max() + tolerance)))
            {
                //Dwelling is not on the top level so shading may exist above it
                List<double> elevations = levels.Select(x => x.Elevation).ToList();
                elevations.Sort();

                int index = elevations.IndexOf(dwellingLevel.Elevation);
                index++;
                if (index == elevations.Count)
                    index--; //For safety but should not happen

                floorAbove = levels.Where(x => x.Elevation >= (elevations[index] - tolerance) && x.Elevation <= (elevations[index] + tolerance)).FirstOrDefault();

                foreach(Panel shade in balconyShades)
                {
                    double maZ = shade.Polyline().IControlPoints().Select(y => y.Z).Max() + tolerance;
                    double miZ = shade.Polyline().IControlPoints().Select(y => y.Z).Min() - tolerance;

                    maZ = Math.Round(maZ, 4);
                    miZ = Math.Round(miZ, 4);

                    if (miZ >= Math.Round((floorAbove.Elevation - tolerance), 4) && maZ <= Math.Round((floorAbove.Elevation + tolerance), 4))
                        shadesOnLevelAbove.Add(shade);
                }
            }

            List<Opening> openings = dwelling.Rooms.SelectMany(x => x.Panels.OpeningsFromElements()).ToList();

            window.DwellingName = dwelling.Name;
            window.Reference = dwelling.Reference;

            for(int x = 0; x < openings.Count; x++)
            {
                Opening o = openings[x];

                window.WideOverhang.Add(false);
                window.OverhangRatio.Add(0);

                double width = o.Width();
                double height = o.Height();

                Point centre = o.Polyline().Centroid();
                if (floorAbove != null)
                {
                    centre.Z = floorAbove.Elevation;
                    //Find a shade which intersects this opening
                    Panel shade = shadesOnLevelAbove.Where(y => y.IsContaining(centre, true)).FirstOrDefault();

                    if(shade != null)
                    {
                        List<Polyline> shadeParts = shade.Polyline().SplitAtPoints(shade.Polyline().IControlPoints());
                        List<double> lengths = shadeParts.Select(y => Math.Round(y.Length(), 3)).ToList();
                        lengths = lengths.Distinct().ToList();

                        double shadeWidth = lengths.Max();
                        if (shadeWidth > width)
                            window.WideOverhang[window.WideOverhang.Count - 1] = true;

                        double shadeDepth = lengths.Min();
                        window.OverhangRatio[window.OverhangRatio.Count - 1] = (shadeDepth / height);
                    }
                }

                window.WindowID.Add(o.Name);
                window.Width.Add(width.ToMillimetre());
                window.Height.Add(height.ToMillimetre());
                window.Area.Add(o.Polyline().IArea());

                double orientation = o.Orientation(0, true).Value.ToDegree();
                window.Orientation.Add(ToOrientationText(orientation));
                window.OrientationDegrees.Add(orientation);

                window.FrameFactor.Add(frameFactor);

                window.Number.Add((x + 1));
            }

            return window;
        }

        private static string ToOrientationText(double orientation)
        {
            if (orientation <= 45 || orientation > 315)
                return "North";

            if (orientation <= 135 || orientation > 45)
                return "East";

            if (orientation <= 225 || orientation > 135)
                return "South";

            if (orientation <= 225 || orientation > 315)
                return "West";

            return "";
        }
    }
}
