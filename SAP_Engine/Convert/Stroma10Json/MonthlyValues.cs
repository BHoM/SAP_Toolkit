using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

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
    }
}
