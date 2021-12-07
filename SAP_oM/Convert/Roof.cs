using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;


namespace BH.oM.Environment.SAP.Convert
{
    public static partial class Convert
    {
        [Description("Convert SAP roof to XML roof.")]
        [Input("roof", "SAP roof to convert.")]
        [Output("roof", "XML roof.")]
        public static BH.oM.Environment.SAP.XML.Roof xmlRoof(this BH.oM.Environment.SAP.Roof sapRoof)
        {
            BH.oM.Environment.SAP.XML.Roof xmlRoof = new BH.oM.Environment.SAP.XML.Roof();
            xmlRoof.Name = sapRoof.Name;
            xmlRoof.Description = "";//Descriptive notes about the roof.
            xmlRoof.Type = "4"; //party ceiling
            xmlRoof.Area = sapRoof.Area;
            xmlRoof.UValue = 0.13;
            xmlRoof.KappaValue = 9;

            return xmlRoof;
        }
    }
}
