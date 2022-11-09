using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Dimension> ToDimensions(CustomObject dimensionsObject)
        {
            List<Dimension> rtn = new List<Dimension>();
            foreach (var value in dimensionsObject.CustomData["Dimensions"] as List<CustomObject>)
            {
                rtn.Add(ToDimension(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Dimension ToDimension(CustomObject dimensionObject)
        {
            BH.oM.Environment.SAP.Stroma10.Dimension sapDimension = new BH.oM.Environment.SAP.Stroma10.Dimension();

            sapDimension.ID = System.Convert.ToInt32(dimensionObject.CustomData["ID"]);

            sapDimension.BHoM_Guid = (Guid)dimensionObject.CustomData["GUID"];

            sapDimension.Basement = System.Convert.ToBoolean(dimensionObject.CustomData["Basement"]);

            sapDimension.Area = System.Convert.ToDouble(dimensionObject.CustomData["Area"]);

            sapDimension.Perimeter = System.Convert.ToDouble(dimensionObject.CustomData["Perimeter"]);

            sapDimension.Height = System.Convert.ToDouble(dimensionObject.CustomData["Height"]);

            sapDimension.Dims = (List<object>)dimensionObject.CustomData["Dims"];

            sapDimension.Type = dimensionObject.CustomData["Type"];

            sapDimension.Floor = System.Convert.ToInt32(dimensionObject.CustomData["Floor"]);

            sapDimension.Volume = System.Convert.ToDouble(dimensionObject.CustomData["Volume"]);

            return sapDimension;
        }
    }
}
