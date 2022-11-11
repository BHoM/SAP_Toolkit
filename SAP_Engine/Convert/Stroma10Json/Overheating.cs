using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Overheating> ToOverheatings(List<CustomObject> overheatingsObject)
        {
            if (overheatingsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Overheating> rtn = new List<BH.oM.Environment.SAP.Stroma10.Overheating>();
            foreach (var value in overheatingsObject)
            {
                rtn.Add(ToOverheating(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Overheating ToOverheating(CustomObject overheatingObject)
        {
            if (overheatingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Overheating sapOverheating = new BH.oM.Environment.SAP.Stroma10.Overheating();

            sapOverheating.ID = System.Convert.ToInt32(overheatingObject.CustomData["Id"]);

            sapOverheating.EaCBuildType = System.Convert.ToInt32(overheatingObject.CustomData["EaCBuildType"]);

            sapOverheating.EaCWindow = System.Convert.ToInt32(overheatingObject.CustomData["EaCWindow"]);

            sapOverheating.EaCOveride = System.Convert.ToBoolean(overheatingObject.CustomData["EaCOveride"]);

            sapOverheating.EaCAirChange = System.Convert.ToDouble(overheatingObject.CustomData["EaCAirChange"]);

            sapOverheating.Night = System.Convert.ToBoolean(overheatingObject.CustomData["Night"]);

            sapOverheating.Conservatory = System.Convert.ToInt32(overheatingObject.CustomData["Conservatory"]);

            sapOverheating.Lights = ToLights((overheatingObject.CustomData["Lights"] as List<object>).Cast<CustomObject>().ToList());

            sapOverheating.LowerEnergyLights = System.Convert.ToInt32(overheatingObject.CustomData["LowerEnergyLights"]);

            return sapOverheating;
        }
    }
}
