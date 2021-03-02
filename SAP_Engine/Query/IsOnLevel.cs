using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Geometry.SettingOut;

using BH.Engine.Environment;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        public static bool IsOnLevel(this Polyline polyline, Level level, double tolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            double minLevel = polyline.MinimumLevel();
            double maxLevel = polyline.MaximumLevel();

            return ((minLevel >= (level.Elevation - tolerance)) && (maxLevel <= (level.Elevation + tolerance)));
        }
    }
}
