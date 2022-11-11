using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Special ToSpecial(CustomObject specialObject)
        {
            if (specialObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Special sapSpecial = new BH.oM.Environment.SAP.Stroma10.Special();

            sapSpecial.ID = System.Convert.ToInt32(specialObject.CustomData["Id"]);

            sapSpecial.Include = System.Convert.ToBoolean(specialObject.CustomData["Include"]);

            sapSpecial.SpecialFeatures = ToSpecialFeatures((specialObject.CustomData["SpecialFeatures"] as List<object>).Cast<CustomObject>().ToList());

            return sapSpecial;
        }
    }
}
