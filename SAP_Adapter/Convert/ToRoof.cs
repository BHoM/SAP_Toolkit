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
        public static Roof ToRoof(SAPMarkup markup, EXL.RoofSchedule importedDimensionData)
        {
            Roof r = new Roof();

            r.Name = markup.Subject;
            r.Description = markup.Subject;
            r.Type = ((int)(BH.oM.Environment.SAP.TypeOfRoof)Enum.Parse(typeof(BH.oM.Environment.SAP.TypeOfRoof), markup.RoofType)).ToString();
            r.KappaValue = "";
            r.UValue = (importedDimensionData != null ? importedDimensionData.UValue.ToString() : "0.0");
            r.Area = markup.Area.ToString();

            return r;
        }
    }
}
