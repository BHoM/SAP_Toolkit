using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.FlueGasHeatRecovery ToFlueGasHeatRecovery(CustomObject flueGasHeatRecoveryObject)
        {
            BH.oM.Environment.SAP.Stroma10.FlueGasHeatRecovery sapFlueGasHeatRecovery = new BH.oM.Environment.SAP.Stroma10.FlueGasHeatRecovery();

            sapFlueGasHeatRecovery.ID = System.Convert.ToInt32(flueGasHeatRecoveryObject.CustomData["ID"]);

            sapFlueGasHeatRecovery.Include = System.Convert.ToBoolean(flueGasHeatRecoveryObject.CustomData["Include"]);

            sapFlueGasHeatRecovery.IndexNumber = (flueGasHeatRecoveryObject.CustomData["IndexNumber"] as CustomObject);

            sapFlueGasHeatRecovery.Photovoltaic2 = ToPhotovoltaic2(flueGasHeatRecoveryObject.CustomData["Photovoltaic2"] as CustomObject);

            return sapFlueGasHeatRecovery;
        }
    }
}
