using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry.SettingOut;
using BH.oM.Environment.SAP;

using BH.Engine.Geometry;
using BH.Engine.Environment;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        public static Level Level(this Dwelling dwelling, List<Level> searchLevels, double distanceTolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle)
        {
            double elevation = dwelling.Perimeter.ICollapseToPolyline(angleTolerance).MinimumLevel();

            return searchLevels.Where(x => x.Elevation >= (elevation - distanceTolerance) && x.Elevation <= (elevation + distanceTolerance)).FirstOrDefault();
        }
    }
}
