using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {

        public static List<BH.oM.Environment.SAP.Stroma10.Dim> ToDims(CustomObject dimsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Dim> rtn = new List<BH.oM.Environment.SAP.Stroma10.Dim>();

            foreach (var value in dimsObject.CustomData["Dims"] as List<CustomObject>)
            {
                rtn.Add(ToDim(value));
            }
            return rtn; 
        }

        public static BH.oM.Environment.SAP.Stroma10.Dim ToDim(CustomObject dimObject)
        {
            BH.oM.Environment.SAP.Stroma10.Dim sapDim = new BH.oM.Environment.SAP.Stroma10.Dim();

            sapDim.ID = System.Convert.ToInt32(dimObject.CustomData["ID"]);

            sapDim.BHoM_Guid = (Guid)dimObject.CustomData["GUID"];

            sapDim.Width = System.Convert.ToDouble(dimObject.CustomData["Width"]);

            sapDim.Length = System.Convert.ToDouble(dimObject.CustomData["Length"]);

            sapDim.Area = System.Convert.ToDouble(dimObject.CustomData["Area"]);

            return sapDim;
        }
    }
}
