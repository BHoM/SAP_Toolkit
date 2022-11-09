using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Light> ToLights(CustomObject lightsObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Light> rtn = new List<BH.oM.Environment.SAP.Stroma10.Light>();
            foreach (var value in lightsObject.CustomData["Lights"] as List<CustomObject>)
            {
                rtn.Add(ToLight(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Light ToLight(CustomObject lightObject)
        {
            BH.oM.Environment.SAP.Stroma10.Light sapLight = new BH.oM.Environment.SAP.Stroma10.Light();

            sapLight.ID = System.Convert.ToInt32(lightObject.CustomData["ID"]);

            sapLight.BHoM_Guid = (Guid)lightObject.CustomData["GUID"];

            sapLight.Power = System.Convert.ToDouble(lightObject.CustomData["Power"]);

            sapLight.Efficacy = System.Convert.ToDouble(lightObject.CustomData["Efficacy"]);

            sapLight.Capacity = System.Convert.ToDouble(lightObject.CustomData["Capacity"]);

            sapLight.Count = System.Convert.ToInt32(lightObject.CustomData["Count"]);

            return sapLight;
        }
    }
}
