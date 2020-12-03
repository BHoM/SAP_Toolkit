using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A BHoMObject for SAP analysis. Contains info about dwelling areas")]
    public class TFA : BHoMObject
    {

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor")]
        public virtual string ID { get; set; } = "";

        [Description("The toal area of each dwelling")]
        public virtual double TotalArea { get; set; } = 0.0;

        [Description("The total living area of each dwelling")]
        public virtual double LivingArea { get; set; } = 0.0;

        [Description("The total cooling area area of each dwelling")]
        public virtual double CoolingArea { get; set; } = 0.0;

        [Description("The total external floor area connected to each dwelling")]
        public virtual double ExtFloorArea { get; set; } = 0.0;

        [Description("The total external roof area connected to each dwelling")]
        public virtual double ExtRoofArea { get; set; } = 0.0;

    }
}
