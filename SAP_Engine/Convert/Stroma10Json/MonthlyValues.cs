using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.MonthlyValues ToMonthlyValues(CustomObject monthlyValuesObject)
        {
            if (monthlyValuesObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.MonthlyValues sapMonthlyValues = new BH.oM.Environment.SAP.Stroma10.MonthlyValues();

            sapMonthlyValues.ID = System.Convert.ToInt32(monthlyValuesObject.CustomData["Id"]);

            sapMonthlyValues.Month01 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M01"]);

            sapMonthlyValues.Month02 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M02"]);

            sapMonthlyValues.Month03 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M03"]);

            sapMonthlyValues.Month04 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M04"]);

            sapMonthlyValues.Month05 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M05"]);

            sapMonthlyValues.Month06 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M06"]);

            sapMonthlyValues.Month07 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M07"]);

            sapMonthlyValues.Month08 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M08"]);

            sapMonthlyValues.Month09 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M09"]);

            sapMonthlyValues.Month10 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M10"]);

            sapMonthlyValues.Month11 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M11"]);

            sapMonthlyValues.Month12 = System.Convert.ToDouble(monthlyValuesObject.CustomData["M12"]);

            return sapMonthlyValues;
        }
        public static Dictionary<string, object> FromMonthlyValues(MonthlyValues obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("M01", obj.Month01);
            rtn.Add("M02", obj.Month02);
            rtn.Add("M03", obj.Month03);
            rtn.Add("M04", obj.Month04);
            rtn.Add("M05", obj.Month05);
            rtn.Add("M06", obj.Month06);
            rtn.Add("M07", obj.Month07);
            rtn.Add("M08", obj.Month08);
            rtn.Add("M09", obj.Month09);
            rtn.Add("M10", obj.Month10);
            rtn.Add("M11", obj.Month11);
            rtn.Add("M12", obj.Month12);
            rtn.Add("Id", obj.ID);

            return rtn;
        }
    }
}
