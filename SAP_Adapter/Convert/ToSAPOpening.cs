using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static Opening ToSAPOpening(SAPMarkup markup, string name)
        {
            Opening o = new Opening();

            o.Height = markup.OpeningHeight;
            o.Width = markup.Length;
            o.Orientation = ((int)(BH.oM.Environment.SAP.OrientationCode)Enum.Parse(typeof(BH.oM.Environment.SAP.OrientationCode), markup.OpeningOrientation)).ToString();
            o.Pitch = ((int)(BH.oM.Environment.SAP.VerticalPitchCode)Enum.Parse(typeof(BH.oM.Environment.SAP.VerticalPitchCode), markup.OpeningPitch)).ToString();
            o.Name = name;

            return o;
        }
    }
}
