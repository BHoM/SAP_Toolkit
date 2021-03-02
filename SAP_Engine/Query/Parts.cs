using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Reflection;
using BH.oM.Reflection.Attributes;
using BH.oM.Geometry;
using BH.oM.Environment;
using BH.oM.Environment.Elements;

using BH.Engine.Environment;
using BH.Engine.Geometry;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        [MultiOutput(0, "bottom", "The polylines representing the bottom of the objects geometry. For openings this is also referred to as a 'sill'.")]
        [MultiOutput(1, "sides", "The polylines representing the sides of the objects geometry. For openings this is also referred to as a 'jamb'.")]
        [MultiOutput(2, "top", "The polylines representing the top of the objects geometry. For openings this is also referred to as a 'lintel'.")]
        public static Output<List<Polyline>, List<Polyline>, List<Polyline>> IParts(this IEnvironmentObject obj)
        {
            return obj.Polyline().Parts();
        }

        private static Output<List<Polyline>, List<Polyline>, List<Polyline>> Parts(this Polyline polyline)
        {
            List<Polyline> edgesParts = polyline.SplitAtPoints(polyline.ControlPoints);
            double zmax = edgesParts.SelectMany(y => y.ControlPoints().Select(z => z.Z)).Max();

            List<Polyline> sills = new List<Polyline>();
            List<Polyline> jambs = new List<Polyline>();
            List<Polyline> lintels = new List<Polyline>();

            foreach (Polyline p in edgesParts)
            {
                if (p.ControlPoints.Where(y => y.Z == zmax).Count() == 0)
                    sills.Add(p);
                else if (p.ControlPoints.Where(y => y.Z == zmax).Count() == 1)
                    jambs.Add(p);
                else
                    lintels.Add(p);
            }

            return new Output<List<Polyline>, List<Polyline>, List<Polyline>>()
            {
                Item1 = sills,
                Item2 = jambs,
                Item3 = lintels,
            };
        }

        public static Output<List<Polyline>, List<Polyline>, List<Polyline>> Parts(this List<Opening> openings)
        {
            return openings.Select(x => x as IEnvironmentObject).IParts();
        }

        public static Output<List<Polyline>, List<Polyline>, List<Polyline>> Parts(this List<Panel> panels)
        {
            return panels.Select(x => x as IEnvironmentObject).IParts();
        }

        private static Output<List<Polyline>, List<Polyline>, List<Polyline>> IParts(this IEnumerable<IEnvironmentObject> envObjs)
        {
            Output<List<Polyline>, List<Polyline>, List<Polyline>> finalParts = new Output<List<Polyline>, List<Polyline>, List<Polyline>>()
            {
                Item1 = new List<Polyline>(),
                Item2 = new List<Polyline>(),
                Item3 = new List<Polyline>(),
            };
            foreach (IEnvironmentObject o in envObjs)
            {
                Output<List<Polyline>, List<Polyline>, List<Polyline>> parts = o.IParts();
                finalParts.Item1.AddRange(parts.Item1);
                finalParts.Item2.AddRange(parts.Item2);
                finalParts.Item3.AddRange(parts.Item3);
            }

            return finalParts;
        }
    }
}
