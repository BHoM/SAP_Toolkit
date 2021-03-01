using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using System.ComponentModel;



namespace BH.oM.BuroHappoldMachineLearning
{
    [Description("An export object for Machine Learning analysis")]
    public class MachineLearningExport : BHoMObject
    {
        [Description("Room ID")]
        public virtual string ID { get; set; } = "";

        [Description("Room type")]
        public virtual string RoomType { get; set; } = "";

        [Description("Window apsect Does it have windows in different orientations?")]
        public virtual string SingleDualAspect { get; set; } = "";

        [Description("Standard balcony or Juliette balcony")]
        public virtual string BalconyType { get; set; } = "";

        [Description("G-value for windows")]
        public virtual double GValue { get; set; } = 0.0;

        [Description("Number of bedrooms per dwelling")]
        public virtual int DwellingBeds { get; set; } = 0;

        [Description("Total radiation per room [kW/m2]")]
        public virtual double TotalRadiation { get; set; } = 0.0;

        [Description("Average Daylight Factor per room [-]")]
        public virtual double ADF { get; set; } = 0.0;

        [Description("Window to floor ratio per room [-]")]
        public virtual double GlazingRatioWinFl { get; set; } = 0.0;

        [Description("Total glazing area per room [m2]")]
        public virtual double GlazedArea { get; set; } = 0.0;

        [Description("Window to external wall ratio per room [-]")]
        public virtual double GlazRatio { get; set; } = 0.0;

        [Description("Floor Area per room [m2]")]
        public virtual double FloorArea { get; set; } = 0.0;

        [Description("External wall area per room")]
        public virtual double ExtWallArea { get; set; } = 0.0;

        [Description("Glazing area for window no 1 per room")]
        public virtual double GlazingAreaA { get; set; } = 0.0;

        [Description("Glazing area for window mo 2 per room")]
        public virtual double GlazingAreaB { get; set; } = 0.0;

        [Description("Glazing area for window no 3 per room")]
        public virtual double GlazingAreaC { get; set; } = 0.0;

        [Description("Orientation in degrees for window no 1 per room")]
        public virtual double OrientationA { get; set; } = 0.0;

        [Description("Orientation in degrees for window no 2 per room")]
        public virtual double OrientationB { get; set; } = 0.0;

        [Description("Orientation in degrees for window no 3 per room")]
        public virtual double OrientationC { get; set; } = 0.0;

    }
}
