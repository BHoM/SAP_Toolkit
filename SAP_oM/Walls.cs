using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A BHoMObject for SAP analysis. Contains info about wall lengths and heights")]
    public class Walls : BHoMObject
    {

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor")]
        public virtual string ID { get; set; } = "";

        [Description("The height from floor to ceiling for each dwelling")]
        public virtual double CeilingHeight { get; set; } = 0.0;

        [Description("The total external wall height for each dwelling")]
        public virtual double ExtWallHeight { get; set; } = 0.0;

        [Description("The total external wall length for each dwelling")]
        public virtual double ExtWallLength { get; set; } = 0.0;

        [Description("The thickness of external walls")]
        public virtual double ExtWallThickness { get; set; } = 0.0;

    }
}
