using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;
using BH.Engine.Geometry;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static BH.oM.Environment.SAP.Space FlipPanels(this BH.oM.Environment.SAP.Space space)
        {
            List<Panel> panels = new List<Panel>();
            foreach(Panel p in space.Panels)
            {
                Panel p2 = p.DeepClone();
                if(!p2.NormalAwayFromSpace(space.Panels))
                    p2.ExternalEdges = p2.Polyline().Flip().ToEdges();

                List<Opening> openings = p2.Openings.Select(x => x.DeepClone()).ToList();
                for(int x = 0; x < openings.Count; x++)
                {
                    if (!openings[x].Polyline().NormalAwayFromSpace(space.Panels))
                        openings[x].Edges = openings[x].Polyline().Flip().ToEdges();
                }

                p2.Openings = openings;
                panels.Add(p2);
            }

            space.Panels = panels;

            return space;
        }
    }
}
