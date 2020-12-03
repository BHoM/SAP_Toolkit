using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A plane curve. A circular Arc, a curve, with a constant distance from a point, its centre, defined with start and end polarpoints.")]
    public class Export : BHoMObject
    {
        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Number of bathrooms in each dwelling")]
        public virtual int WetRooms { get; set; } = 0;

        [Description("Number of sheltered sides for each dwelling")]
        public virtual int ShelteredSides { get; set; } = 0;

        [Description("Orientation of each dwelling")]
        public virtual string Orientation { get; set; } = "";

        [Description("States whether crossventilation is available or not for each dwelling")]
        public virtual string CrossVentilation { get; set; } = "";

        [Description("The toal floor area of each dwelling")]
        public virtual double TotalArea { get; set; } = 0.0;

        [Description("The total living area of each dwelling")]
        public virtual double LivingArea { get; set; } = 0.0;

        [Description("The total cooling area area of each dwelling")]
        public virtual double CoolingArea { get; set; } = 0.0;

        [Description("The total outside floor area connected to each dwelling")]
        public virtual double ExtFloorArea { get; set; } = 0.0;

        [Description("The total outside roof area connected to each dwelling")]
        public virtual double ExtRoofArea { get; set; } = 0.0;

        [Description("")]
        public virtual double PartyFloor { get; set; } = 0.0;

        [Description("")]
        public virtual double PartyRoof { get; set; } = 0.0;

        [Description("The height from floor to ceiling for each dwelling")]
        public virtual double CeilingHeight { get; set; } = 0.0;

        [Description("The total external wall height for each dwelling")]
        public virtual double ExtWallHeight { get; set; } = 0.0;

        [Description("The total external wall length for each dwelling")]
        public virtual double ExtWallLength { get; set; } = 0.0;

        [Description("Window width in mm")]
        public virtual List<double> WindowLength { get; set; }

        [Description("Window height in mm")]
        public virtual List<double> WindowHeight { get; set; }

        [Description("Window orientation in text")]
        public virtual List<string> WindowOrientation { get; set; }

        [Description("If the window has an overhang wider than the window itself")]
        public virtual List<string> WideOverhang { get; set; }

        [Description("Overhang ratio")]
        public virtual List<double> OverhangRatio { get; set; }

    }
}