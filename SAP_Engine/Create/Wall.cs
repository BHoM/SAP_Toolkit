using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.Engine.Geometry;
using BH.oM.Geometry;
using BH.oM.Environment.Elements;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<Walls> Wall(List<Dwelling> dwellings, double ceilingHeight, double dumbassCeilingVoidHeight, double externalWallThickness, Polyline baseCurve)
        {
            List<Walls> walls = new List<Walls>();

            for(int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                
                Walls wall = new Walls();

                wall.DwellingName = dwelling.Name;
                wall.Reference = dwelling.Reference;
                wall.ID = (x + 1);

                wall.CeilingHeight = ceilingHeight;
                wall.ExternalWallHeight = ceilingHeight + dumbassCeilingVoidHeight;
                wall.ExternalWallThickness = externalWallThickness;

                List<Panel> wallPanels = dwelling.Rooms.SelectMany(y => y.Panels.Where(a => a.Type == oM.Environment.Elements.PanelType.Wall)).ToList();

                List<Panel> intersecting = wallPanels.Where(y => (y.Bottom() as Polyline).LineIntersections(baseCurve).Count > 0).ToList();

                double length = intersecting.Select(y => y.Bottom().ILength()).Sum();
                wall.ExternalWallLength = length;

                walls.Add(wall);
            }          

            return walls;
        }
    }
}
