using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery ToWasteWaterHeatRecovery(CustomObject wasteWaterHeatRecoveryObject)
        {
            BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery sapWasteWaterHeatRecovery = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery();

            sapWasteWaterHeatRecovery.ID = System.Convert.ToInt32(wasteWaterHeatRecoveryObject.CustomData["ID"]);

            sapWasteWaterHeatRecovery.Include = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["Include"]);

            sapWasteWaterHeatRecovery.IsTER = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsTER"]);

            sapWasteWaterHeatRecovery.ID = System.Convert.ToInt32(wasteWaterHeatRecoveryObject.CustomData["ID"]);

            sapWasteWaterHeatRecovery.Manufacturer = (wasteWaterHeatRecoveryObject.CustomData["Manufacturer"] as CustomObject);

            sapWasteWaterHeatRecovery.Model = (wasteWaterHeatRecoveryObject.CustomData["Model"] as CustomObject);

            sapWasteWaterHeatRecovery.Efficiency = System.Convert.ToDouble(wasteWaterHeatRecoveryObject.CustomData["Efficiency"]);

            sapWasteWaterHeatRecovery.IsStorage = System.Convert.ToBoolean(wasteWaterHeatRecoveryObject.CustomData["IsStorage"]);

            sapWasteWaterHeatRecovery.WasteWaterHeatRecoverySystems = ToWasteWaterHeatRecoverySystems(wasteWaterHeatRecoveryObject.CustomData["WasteWaterHeatRecoverySystems"] as CustomObject);

            return sapWasteWaterHeatRecovery;
        }
    }
}
