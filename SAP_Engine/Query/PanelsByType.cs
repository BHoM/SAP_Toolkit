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
        public static List<Panel> PanelsByType(this Dwelling dwelling, PanelType type)
        {
            return dwelling.Rooms.SelectMany(y => y.Panels.Where(a => a.Type == type)).ToList();
        }
    }
}
