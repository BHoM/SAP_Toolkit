using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using SXML = BH.oM.Environment.SAP.XML;
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
        public static SXML.ThermalBridge ToThermalBridge(SAPMarkup markup, PsiValues psiValue)
        {
            SXML.ThermalBridge t = new SXML.ThermalBridge();

            t.CalculationReference = markup.Subject;
            t.Type = markup.ThermalBridgeType;

            if (markup.Length <= 0.00001)
            {
                double multiplyFactor = 0;
                double thermalBridgeLength = 0;
                try
                {
                    multiplyFactor = double.Parse(markup.Comments);
                }
                catch { }

                try
                {
                    thermalBridgeLength = double.Parse(markup.ThermalBridgeLength);
                }
                catch { }

                t.Length = thermalBridgeLength * multiplyFactor;
            }
            else
                t.Length = markup.Length;

            t.PsiSource = "4";
            t.PsiValue = psiValue.PsiValue;

            return t;
        }
    }
}
