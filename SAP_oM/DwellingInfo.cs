using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("A BHoMObject for SAP analysis. Contains general info about each dwelling")]
    public class DwellingInfo : BHoMObject
    {

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor")]
        public virtual string ID { get; set; } = "";

        [Description("Orientation of each dwelling")]
        public virtual double OrientationDegrees { get; set; } = 0.0;

        [Description("Number of rooms in each dwelling")]
        public virtual int TotalRooms { get; set; } = 0;

        [Description("Number of bathrooms in each dwelling")]
        public virtual int WetRooms { get; set; } = 0;

        [Description("Number of sheltered sides for each dwelling")]
        public virtual int ShelteredSides { get; set; } = 0;

        [Description("States whether crossventilation is available or not for each dwelling")]
        public virtual string CrossVentilation { get; set; } = "";

    }
}
