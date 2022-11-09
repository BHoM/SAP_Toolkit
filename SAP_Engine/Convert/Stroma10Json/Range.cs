using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Range ToRange(CustomObject rangeObject)
        {
            BH.oM.Environment.SAP.Stroma10.Range sapRange = new BH.oM.Environment.SAP.Stroma10.Range();

            sapRange.ID = System.Convert.ToInt32(rangeObject.CustomData["ID"]);

            sapRange.CaseKw = System.Convert.ToDouble(rangeObject.CustomData["CaseKw"]);

            sapRange.WaterKw = System.Convert.ToDouble(rangeObject.CustomData["WaterKw"]);

            return sapRange;
        }
    }
}
