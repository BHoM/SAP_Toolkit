using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Photovoltaic ToPhotovoltaic(CustomObject photovoltaicObject)
        {
            BH.oM.Environment.SAP.Stroma10.Photovoltaic sapPhotovoltaic = new BH.oM.Environment.SAP.Stroma10.Photovoltaic();

            sapPhotovoltaic.ID = System.Convert.ToInt32(photovoltaicObject.CustomData["ID"]);

            sapPhotovoltaic.Include = System.Convert.ToBoolean(photovoltaicObject.CustomData["Include"]);

            sapPhotovoltaic.Diverter = System.Convert.ToBoolean(photovoltaicObject.CustomData["Diverter"]);

            sapPhotovoltaic.BatteryCapacity = System.Convert.ToDouble(photovoltaicObject.CustomData["BatteryCapacity"]);
            
            sapPhotovoltaic.Photovoltaic2s = ToPhotovoltaic2s(photovoltaicObject.CustomData["Photovoltaic2s"] as CustomObject);

            return sapPhotovoltaic;
        }
    }
}
