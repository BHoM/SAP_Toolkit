using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BHE = BH.oM.Environment.Elements;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static Dwelling AssignSpaces(this Dwelling dwelling, List<Space> spaces)
        {
            Dwelling newDwelling = dwelling.DeepClone();
            List<Space> newSpaces = spaces.Select(x => x.DeepClone()).ToList();

            List<Space> spacesWithNames = new List<Space>();
            foreach(Space s in newSpaces)
            {
                string name = newDwelling.Name + "_" + s.Type.ToString();
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

            newDwelling.Rooms = spacesWithNames;
            return newDwelling;
            //return newDwelling.TidyPanels();
        }
    }
}
