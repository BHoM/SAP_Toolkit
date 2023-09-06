using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using EXL = BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static Wall ToWall(SAPMarkup markup, EXL.Walls importedDimensionData)
        {
            Wall w = new Wall();

            w.Name = markup.Subject;
            w.Description = markup.Subject;
            w.Type = ((int)(BH.oM.Environment.SAP.TypeOfWall)Enum.Parse(typeof(BH.oM.Environment.SAP.TypeOfWall), markup.WallType)).ToString();
            w.KappaValue = "";
            w.UValue = (importedDimensionData != null ? importedDimensionData.UValue.ToString() : "0.0");
            w.Area = (markup.WallHeight * markup.Length);
            w.CurtainWall = markup.IsCurtainWall;

            return w;
        }
    }
}
