using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem> ToWasteWaterHeatRecoverySystems(List<CustomObject> wasteWaterHeatRecoverySystemsObject)
        {
            if (wasteWaterHeatRecoverySystemsObject == null)
                return null;

            List<WasteWaterHeatRecoverySystem> rtn = new List<WasteWaterHeatRecoverySystem>();
            foreach (var value in wasteWaterHeatRecoverySystemsObject)
            {
                rtn.Add(ToWasteWaterHeatRecoverySystem(value));
            }
            return rtn;
        }



        public static BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem ToWasteWaterHeatRecoverySystem(CustomObject wasteWaterHeatRecoverySystemObject)
        {

            if (wasteWaterHeatRecoverySystemObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem sapWasteWaterHeatRecoverySystem = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem();

            sapWasteWaterHeatRecoverySystem.ID = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["Id"]);

            sapWasteWaterHeatRecoverySystem.SystemReference = (wasteWaterHeatRecoverySystemObject.CustomData["SystemRef"] as string);

            sapWasteWaterHeatRecoverySystem.DedicatedStorage = System.Convert.ToDouble(wasteWaterHeatRecoverySystemObject.CustomData["DedicatedStorage"]);

            sapWasteWaterHeatRecoverySystem.WithBath = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["WithBath"]);
            
            sapWasteWaterHeatRecoverySystem.WithNoBath = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["WithNoBath"]);

            return sapWasteWaterHeatRecoverySystem;
        }
        public static Dictionary<string, object> FromWasteWaterHeatRecoverySystem(WasteWaterHeatRecoverySystem obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);

            rtn.Add("SystemRef", obj.SystemReference);
            rtn.Add("DedicatedStorage", obj.DedicatedStorage);
            rtn.Add("WithBath", obj.WithBath);
            rtn.Add("WithNoBath", obj.WithNoBath);


            return rtn;
        }

    }
}
