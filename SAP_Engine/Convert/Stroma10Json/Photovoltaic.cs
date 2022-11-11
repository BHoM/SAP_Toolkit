using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Photovoltaic ToPhotovoltaic(CustomObject photovoltaicObject)
        {
            if (photovoltaicObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Photovoltaic sapPhotovoltaic = new BH.oM.Environment.SAP.Stroma10.Photovoltaic();

            sapPhotovoltaic.ID = System.Convert.ToInt32(photovoltaicObject.CustomData["Id"]);

            sapPhotovoltaic.Include = System.Convert.ToBoolean(photovoltaicObject.CustomData["Include"]);

            sapPhotovoltaic.Diverter = System.Convert.ToBoolean(photovoltaicObject.CustomData["Diverter"]);

            sapPhotovoltaic.BatteryCapacity = System.Convert.ToDouble(photovoltaicObject.CustomData["BatterCapacity"]);

            sapPhotovoltaic.Photovoltaic2s = ToPhotovoltaic2s((photovoltaicObject.CustomData["Photovoltaics"] as List<object>).Cast<CustomObject>().ToList());

            return sapPhotovoltaic;
        }
    }
}
