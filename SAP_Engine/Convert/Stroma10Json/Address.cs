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

            sapAddress.ID = System.Convert.ToInt32(addressObject.CustomData["ID"]);

            sapAddress.AddressLine1 = addressObject.CustomData["AddressLine1"] as string;

            sapAddress.AddressLine2 = addressObject.CustomData["AddressLine2"] as string;

            sapAddress.AddressLine3 = addressObject.CustomData["AddressLine3"] as string;

            sapAddress.City = addressObject.CustomData["City"] as string;

            sapAddress.Postcode = addressObject.CustomData["Postcode"] as string;

            sapAddress.UniquePropertyReferenceNumber = addressObject.CustomData["UniquePropertyReferenceNumber"] as string;

            sapAddress.Country = addressObject.CustomData["Country"] as string;

            sapAddress.DisplayAddress = addressObject.CustomData["DisplayAddress"] as string;

            return sapAddress;
        }
    }
}
