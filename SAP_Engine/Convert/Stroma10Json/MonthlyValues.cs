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
            BH.oM.Environment.SAP.Stroma10.MonthlyValues sapMonthlyValues = new BH.oM.Environment.SAP.Stroma10.MonthlyValues();

            sapMonthlyValues.ID = System.Convert.ToInt32(monthlyValuesObject.CustomData["ID"]);

            sapMonthlyValues.Month01 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month01"]);

            sapMonthlyValues.Month02 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month02"]);

            sapMonthlyValues.Month03 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month03"]);

            sapMonthlyValues.Month04 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month04"]);

            sapMonthlyValues.Month05 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month05"]);

            sapMonthlyValues.Month06 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month06"]);

            sapMonthlyValues.Month07 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month07"]);

            sapMonthlyValues.Month08 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month08"]);

            sapMonthlyValues.Month09 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month09"]);

            sapMonthlyValues.Month10 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month10"]);

            sapMonthlyValues.Month11 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month11"]);

            sapMonthlyValues.Month12 = System.Convert.ToDouble(monthlyValuesObject.CustomData["Month12"]);

            return sapMonthlyValues;
        }
    }
}
