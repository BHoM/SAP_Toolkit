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
        [Description("Convert SAP Floor to XML floor.")]
        [Input("floor", "SAP floor to convert.")]
        [Output("floor", "XML floor.")]
        public static BH.oM.Environment.SAP.XML.Floor xmlFloor(this BH.oM.Environment.SAP.Floor sapFloor)
        {
            BH.oM.Environment.SAP.XML.Floor xmlFloor = new BH.oM.Environment.SAP.XML.Floor();
            xmlFloor.Storey = "0";
            xmlFloor.Description = ""; //Descriptive notes about the floor
            xmlFloor.Type = "2"; //2 meaning ground floor
            xmlFloor.Area = sapFloor.Area;
            xmlFloor.StoreyHeight = 0;
            xmlFloor.HeatLossArea = 0;
            xmlFloor.uValue = 0.13;
            xmlFloor.KappaValue = 80;


            return xmlFloor;
        } 
    }
}
