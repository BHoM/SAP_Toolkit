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
    public static class BalconyLines
    {
        public static List<Polyline> ComputeBalconyLines(List<Panel> panels, Polyline baseCurve, Polyline dwellingPerimeter)
        {
            //Work out balcony lines on the dwelling perimeter
            List<Polyline> balconyLines = panels.SelectMany(y => y.Polyline().SplitAtPoints(y.Polyline().ControlPoints)).ToList();
            balconyLines = balconyLines.Where(y => y.ControlPoints.Where(z => z.IsOnCurve(baseCurve)).Count() == y.ControlPoints.Count).ToList(); //Filter out to only the lines on the base curve

            List<Point> dwellingControlPoints = dwellingPerimeter.IControlPoints();
            balconyLines = balconyLines.SelectMany(y => y.SplitAtPoints(dwellingControlPoints)).ToList(); //Split to the dwelling
            List<Polyline> e23Lines = new List<Polyline>();

            foreach (Polyline e23 in balconyLines)
            {
                if (e23.ControlPoints.Where(y => y.IIsOnCurve(dwellingPerimeter)).Count() == e23.ControlPoints.Count)
                    e23Lines.Add(e23);
            }

            return e23Lines;
        }
    }
}
