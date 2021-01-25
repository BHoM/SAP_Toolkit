using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.Engine.Geometry;
using BH.oM.Geometry;
using BH.Engine.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static List<Space> AssignSpaceType(this List<Space> spaces, List<Point> searchPoints, string type, bool ignoreCase = true)
        {
            List<Space> updateSpaces = new List<Space>();
            foreach (Space s in spaces)
                updateSpaces.Add(s.DeepClone());

            SAPSpaceType spaceType = SAPSpaceType.Undefined;
            object value = Enum.Parse(typeof(SAPSpaceType), type, ignoreCase);
            if (value != null)
                spaceType = ((SAPSpaceType)value);

            List<Space> returnSpaces = new List<Space>();
            for(int x = 0; x < searchPoints.Count; x++)
            {
                Space update = updateSpaces.Where(a => a.Perimeter.IIsContaining(new List<Point> { searchPoints[x] })).FirstOrDefault();
                if (update == null)
                    continue;

                update.Type = spaceType;

                returnSpaces.Add(update);
            }

            return returnSpaces;
        }
    }
}
