using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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
        public static Dictionary<string, object> FromFlueGasHeatRecovery(FlueGasHeatRecovery obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);
            rtn.Add("Include", obj.Include);
            rtn.Add("IndexNo", obj.IndexNumber);
            rtn.Add("Photovoltaics", FromPhotovoltaic2(obj.Photovoltaic2));

            return rtn;
        }
    }
}
