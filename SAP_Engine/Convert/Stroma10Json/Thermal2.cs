using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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
        public static Dictionary<string, object> FromThermal2(Thermal2 obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("Type", obj.Type);

            rtn.Add("Location", obj.Location);

            rtn.Add("Connection", obj.Connection);

            return rtn;
        }
    }
}
