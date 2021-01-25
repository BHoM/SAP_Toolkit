using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.oM.Environment.SAP;
using BH.Engine.Environment;
using BH.Engine.Geometry;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static Opening Opening(this Point location, OpeningOption designOption, List<Panel> panels)
        {
            Point bottomPoint = location.Clone();
            bottomPoint.Z += designOption.SillHeight;

            Panel hostPanel = panels.Where(x => x.IsContaining(bottomPoint)).FirstOrDefault();
            if (hostPanel == null)
                return null; //Error

            ICurve bottomEdge = hostPanel.Bottom();
            Vector direction = bottomEdge.IEndPoint() - bottomEdge.IStartPoint();

            direction = direction.Normalise();
            direction *= (designOption.Width / 2);

            Point bottomCorner1 = bottomPoint.Clone().Translate(direction);
            Point bottomCorner2 = bottomPoint.Clone().Translate(-direction);

            Point topCorner1 = bottomCorner1.Clone();
            topCorner1.Z += designOption.Height;

            Point topCorner2 = bottomCorner2.Clone();
            topCorner2.Z += designOption.Height;

            List<Point> controlPoints = new List<Point>()
            {
                topCorner1,
                topCorner2,
                bottomCorner2,
                bottomCorner1,
                topCorner1,
            };

            Polyline curve = new Polyline()
            {
                ControlPoints = controlPoints,
            };

            return new Opening()
            {
                Edges = curve.ToEdges(),
                Name = designOption.Name,
            };
        }
    }
}
