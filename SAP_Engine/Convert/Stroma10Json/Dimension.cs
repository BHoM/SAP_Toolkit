using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Dimension> ToDimensions(List<CustomObject> dimensionsObject)
        {
            
            if (dimensionsObject == null)
                return null;

            List<Dimension> rtn = new List<Dimension>();
            foreach (var value in dimensionsObject)
            {
                rtn.Add(ToDimension(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Dimension ToDimension(CustomObject dimensionObject)
        {
            if (dimensionObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Dimension sapDimension = new BH.oM.Environment.SAP.Stroma10.Dimension();

            sapDimension.ID = System.Convert.ToInt32(dimensionObject.CustomData["Id"]);

            sapDimension.BHoM_Guid = (Guid.Parse(dimensionObject.CustomData["Guid"] as string));

            sapDimension.Basement = System.Convert.ToBoolean(dimensionObject.CustomData["Basement"]);

            sapDimension.Area = System.Convert.ToDouble(dimensionObject.CustomData["Area"]);

            sapDimension.Perimeter = System.Convert.ToDouble(dimensionObject.CustomData["Perimeter"]);

            sapDimension.Height = System.Convert.ToDouble(dimensionObject.CustomData["Height"]);

            sapDimension.Dims = ToDims((dimensionObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapDimension.Type = dimensionObject.CustomData["Type"];

            sapDimension.Floor = System.Convert.ToInt32(dimensionObject.CustomData["Floor"]);

            sapDimension.Volume = System.Convert.ToDouble(dimensionObject.CustomData["Volume"]);

            return sapDimension;
        }
    }
}
