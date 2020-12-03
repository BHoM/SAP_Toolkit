using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A BHoMObject for SAP analysis. Contains info about window properties and overhang")]
    public class Window : BHoMObject
    {

        [Description("Window layer name")]
        public virtual List <string> WindowID { get; set; }

        [Description("Dwelling name")]
        public virtual List <string> DwellingName { get; set; } 

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual List<string> Reference { get; set; }

        [Description("Window width in mm")]
        public virtual List<double> Width { get; set; }

        [Description("Window height in mm")]
        public virtual List<double> Height { get; set; }

        [Description("Window area in square meters")]
        public virtual List<double> Area { get; set; }

        [Description("Window orientation in text")]
        public virtual List<string> Orientation { get; set; }

        [Description("Window orientation in degrees")]
        public virtual List<double> OrientationDegrees { get; set; }

        [Description("Frame percentage of window area")]
        public virtual List<double> FrameFactor { get; set; }

        [Description("If the window has an overhang wider than the window itself")]
        public virtual List<string> WideOverhang { get; set; }

        [Description("Overhang ratio")]
        public virtual List<double> OverhangRatio { get; set; }

        [Description("Window Number, resets with each dwelling")]
        public virtual List<int> Number { get; set; }

    }
}