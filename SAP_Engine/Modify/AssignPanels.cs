using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Elements;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static BH.oM.Environment.SAP.Space AssignPanels(this BH.oM.Environment.SAP.Space space, List<Panel> panels)
        {
            space.Panels = panels;
            return space;
        }
    }
}
