using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Special ToSpecial(CustomObject specialObject)
        {
            BH.oM.Environment.SAP.Stroma10.Special sapSpecial = new BH.oM.Environment.SAP.Stroma10.Special();

            sapSpecial.ID = System.Convert.ToInt32(specialObject.CustomData["ID"]);

            sapSpecial.Include = System.Convert.ToBoolean(specialObject.CustomData["Include"]);

            sapSpecial.SpecialFeatures = (List<object>)specialObject.CustomData["SpecialFeatures"];

            return sapSpecial;
        }
    }
}
