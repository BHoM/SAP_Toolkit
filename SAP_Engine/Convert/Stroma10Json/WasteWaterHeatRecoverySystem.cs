using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem> ToWasteWaterHeatRecoverySystems(CustomObject wasteWaterHeatRecoverySystemsObject)
        {
            List<WasteWaterHeatRecoverySystem> rtn = new List<WasteWaterHeatRecoverySystem>();
            foreach (var value in wasteWaterHeatRecoverySystemsObject.CustomData["WasteWaterHeatRecoverySystems"] as List<CustomObject>)
            {
                rtn.Add(ToWasteWaterHeatRecoverySystem(value));
            }
            return rtn;
        }



        public static BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem ToWasteWaterHeatRecoverySystem(CustomObject wasteWaterHeatRecoverySystemObject)
        {
            BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem sapWasteWaterHeatRecoverySystem = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecoverySystem();

            sapWasteWaterHeatRecoverySystem.ID = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["ID"]);

            sapWasteWaterHeatRecoverySystem.SystemReference = (wasteWaterHeatRecoverySystemObject.CustomData["SystemReference"] as CustomObject);

            sapWasteWaterHeatRecoverySystem.DedicatedStorage = System.Convert.ToDouble(wasteWaterHeatRecoverySystemObject.CustomData["DedicatedStorage"]);

            sapWasteWaterHeatRecoverySystem.WithBath = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["WithBath"]);
            
            sapWasteWaterHeatRecoverySystem.WithNoBath = System.Convert.ToInt32(wasteWaterHeatRecoverySystemObject.CustomData["WithNoBath"]);

            return sapWasteWaterHeatRecoverySystem;
        }
        
    }
}
