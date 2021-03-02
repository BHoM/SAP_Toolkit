using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Elements;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        public static List<Opening> Openings(this Dwelling dwelling)
        {
            return dwelling.Rooms.SelectMany(x => x.Panels.SelectMany(y => y.Openings)).ToList();
        }
    }
}
