using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Environment.SAP
{ 
    public static class OrientationText
    {
        public static string ToOrientationText(double orientation)
        {
            if (orientation <= 45 || orientation > 315)
                return "North";

            if (orientation <= 135 && orientation > 45)
                return "East";

            if (orientation <= 225 && orientation > 135)
                return "South";

            if (orientation >= 225 && orientation < 315)
                return "West";

            return "";
        }
    }
}
