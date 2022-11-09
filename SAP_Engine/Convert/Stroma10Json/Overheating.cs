using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Overheating ToOverheating(CustomObject overheatingObject)
        {
            BH.oM.Environment.SAP.Stroma10.Overheating sapOverheating = new BH.oM.Environment.SAP.Stroma10.Overheating();

            sapOverheating.ID = System.Convert.ToInt32(overheatingObject.CustomData["ID"]);

            sapOverheating.EaCBuildType = System.Convert.ToInt32(overheatingObject.CustomData["EaCBuildType"]);

            sapOverheating.EaCWindow = System.Convert.ToInt32(overheatingObject.CustomData["EaCWindow"]);

            sapOverheating.EaCOveride = System.Convert.ToBoolean(overheatingObject.CustomData["EaCOveride"]);

            sapOverheating.EaCAirChange = System.Convert.ToDouble(overheatingObject.CustomData["EaCAirChange"]);

            sapOverheating.Night = System.Convert.ToBoolean(overheatingObject.CustomData["Night"]);

            sapOverheating.Conservatory = System.Convert.ToInt32(overheatingObject.CustomData["Conservatory"]);

            sapOverheating.Lights = ToLights(overheatingObject.CustomData["Lights"] as CustomObject);

            sapOverheating.LowerEnergyLights = System.Convert.ToInt32(overheatingObject.CustomData["LowerEnergyLights"]);

            return sapOverheating;
        }
    }
}
