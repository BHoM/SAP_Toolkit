using BH.oM.Adapters.Excel;
using BH.oM.Environment.SAP.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static PsiValues ToPsiValue(this TableRow tableRow)
        {
            if (tableRow.Content.Count < 3)
                return null;

            PsiValues psiValue = new PsiValues();
            psiValue.Type = tableRow.Content[0].ToString();
            psiValue.ThermalBridgeName = tableRow.Content[1].ToString();

            try
            {
                psiValue.PsiValue = double.Parse(tableRow.Content[2].ToString());
            }
            catch { }

            return psiValue;
        }
    }
}
