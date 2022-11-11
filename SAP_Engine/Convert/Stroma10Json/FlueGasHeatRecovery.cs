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
            if (flueGasHeatRecoveryObject == null)
                return null;

            
            BH.oM.Environment.SAP.Stroma10.FlueGasHeatRecovery sapFlueGasHeatRecovery = new BH.oM.Environment.SAP.Stroma10.FlueGasHeatRecovery();

            sapFlueGasHeatRecovery.ID = System.Convert.ToInt32(flueGasHeatRecoveryObject.CustomData["Id"]);

            sapFlueGasHeatRecovery.Include = System.Convert.ToBoolean(flueGasHeatRecoveryObject.CustomData["Include"]);

            sapFlueGasHeatRecovery.IndexNumber = (flueGasHeatRecoveryObject.CustomData["IndexNo"] as string);

            sapFlueGasHeatRecovery.Photovoltaic2 = ToPhotovoltaic2(flueGasHeatRecoveryObject.CustomData["Photovoltaics"] as CustomObject); 

            return sapFlueGasHeatRecovery;
        }
    }
}
