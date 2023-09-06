using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using BH.Adapter.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static FloorDimension ToFloorDimension(SAPMarkup markup, Floors importedDimensionData)
        {
            FloorDimension f = new FloorDimension();

            f.Name = markup.Subject;
            f.Description = markup.Subject;
            f.Type = ((int)(BH.oM.Environment.SAP.TypeOfFloor)Enum.Parse(typeof(BH.oM.Environment.SAP.TypeOfFloor), markup.TFAFloorType)).ToString();
            f.Storey = markup.TFADwellingStorey.ToString();
            f.StoreyHeight = markup.TFAHeight.ToString();
            f.HeatLossArea = "0";
            f.KappaValue = "100";
            f.UValue = (importedDimensionData != null ? importedDimensionData.UValue.ToString() : "0.0");
            f.Area = markup.Area;

            return f;
        }
    }
}
