using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Elements;
using BH.oM.Environment.SAP;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static BH.oM.Environment.SAP.Space AssignPanels(this BH.oM.Environment.SAP.Space space, List<Panel> panels)
        {
            List<Panel> p = panels.Select(x => x.DeepClone()).ToList(); 
            p.ForEach(x =>
            {
                x.ConnectedSpaces = new List<string>();
                x.ConnectedSpaces.Add(space.BHoM_Guid.ToString());
            }); //Temporary grouping name
            space.Panels = p;
            return space;
        }
    }
}
