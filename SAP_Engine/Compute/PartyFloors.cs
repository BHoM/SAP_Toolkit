using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.oM.Environment.Elements;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        public static List<Polyline> CalculatePartyFloors(List<Panel> panels, List<Polyline> existingPartyFloors)
        {
            List<Polyline> balconiesOnDwellingLines = panels.SelectMany(y => y.Polyline().SplitAtPoints(y.Polyline().ControlPoints)).ToList();
            List<Point> controlPoints = balconiesOnDwellingLines.SelectMany(x => x.ControlPoints).ToList();

            List<Polyline> fixedPartyFloors = new List<Polyline>();

            foreach (Polyline p in existingPartyFloors)
            {
                //Remove any overlap with a balcony
                List<Point> cuttingPoints = controlPoints.Where(x => x.IsOnCurve(p)).ToList();

                List<Polyline> split = p.SplitAtPoints(cuttingPoints);

                foreach (Polyline s in split)
                {
                    if (balconiesOnDwellingLines.Where(y => s.Centre().IsOnCurve(y)).Count() == 0)
                        fixedPartyFloors.Add(s);
                }
            }

            return fixedPartyFloors;
        }
    }
}
