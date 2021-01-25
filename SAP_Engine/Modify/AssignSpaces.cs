using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BHE = BH.oM.Environment.Elements;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Dwelling AssignSpaces(this Dwelling dwelling, List<Space> spaces)
        {
            List<Space> spacesWithNames = new List<Space>();
            foreach(Space s in spaces)
            {
                string name = dwelling.Name + "_" + s.Type.ToString();
                if(spaces.Where(x => x.Type == s.Type).Count() > 1)
                {
                    int current = spacesWithNames.Where(x => x.Name.StartsWith(name)).Count();
                    name += (current + 1).ToString();
                }

                s.Name = name;
                List<BHE.Panel> p = new List<BHE.Panel>();
                foreach(BHE.Panel panel in s.Panels)
                {
                    panel.ConnectedSpaces = new List<string>();
                    panel.ConnectedSpaces.Add(name);
                    p.Add(panel);
                }
                s.Panels = p;
                spacesWithNames.Add(s);
            }

            dwelling.Rooms = spacesWithNames;
            return dwelling.TidyPanels();
        }
    }
}
