using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Range ToRange(CustomObject rangeObject)
        {
            if (rangeObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Range sapRange = new BH.oM.Environment.SAP.Stroma10.Range();

            sapRange.ID = System.Convert.ToInt32(rangeObject.CustomData["Id"]);

            sapRange.CaseKw = System.Convert.ToDouble(rangeObject.CustomData["CaseKw"]);

            sapRange.WaterKw = System.Convert.ToDouble(rangeObject.CustomData["WaterKw"]);

            return sapRange;
        }
        public static Dictionary<string, object> FromRange(Range obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);

            rtn.Add("CaseKw", obj.CaseKw);
            rtn.Add("WaterKw", obj.WaterKw);

            return rtn;
        }
    }
}
