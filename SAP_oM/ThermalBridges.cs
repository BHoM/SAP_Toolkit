using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A ThermalBridges object for SAP analysis")]
    public class ThermalBridges : BHoMObject
    {

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor")]
        public virtual int ID { get; set; } = 0;

        [Description("Window lintels")]
        public virtual double E2 { get; set; }

        [Description("Window jambs")]
        public virtual double E4 { get; set; }

        [Description("Party floor")]
        public virtual double E7 { get; set; }

        [Description("Window sills")]
        public virtual double E3 { get; set; }

        [Description("Balconies")]
        public virtual double E23 { get; set; }

        [Description("Eaves")]
        public virtual double E10 { get; set; }

        [Description("Roof")]
        public virtual double E15 { get; set; }

        [Description("Corner inverted")]
        public virtual double E17 { get; set; }

        [Description("Party wall")]
        public virtual double E18 { get; set; }

        [Description("Corner normal")]
        public virtual double E16 { get; set; }

    }
}
