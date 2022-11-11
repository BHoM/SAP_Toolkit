using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Thermal2 ToThermal2(CustomObject thermal2Object)
        {
            if (thermal2Object == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Thermal2 sapThermal2 = new BH.oM.Environment.SAP.Stroma10.Thermal2();

            sapThermal2.ID = System.Convert.ToInt32(thermal2Object.CustomData["Id"]);

            sapThermal2.Include = System.Convert.ToBoolean(thermal2Object.CustomData["Include"]);

            sapThermal2.Type = System.Convert.ToInt32(thermal2Object.CustomData["Type"]);

            sapThermal2.Location = System.Convert.ToInt32(thermal2Object.CustomData["Location"]);

            sapThermal2.Connection = System.Convert.ToInt32(thermal2Object.CustomData["Connection"]);

            return sapThermal2;
        }
    }
}
