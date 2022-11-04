using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Address ToAddress(CustomObject addressObject)
        {
            BH.oM.Environment.SAP.Stroma10.Address sapAddress = new BH.oM.Environment.SAP.Stroma10.Address();

            sapAddress.Postcode = addressObject.CustomData["Postcode"] as string;

            return sapAddress;
        }
    }
}
