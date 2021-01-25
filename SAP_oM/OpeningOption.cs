using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Environment.SAP
{
    public class OpeningOption : BHoMObject
    {
        public virtual double Height { get; set; } = 0;
        public virtual double Width { get; set; } = 0;

        [Description("The distance between the floor of the space and the bottom of the Opening.")]
        public virtual double SillHeight { get; set; } = 0;
    }
}
