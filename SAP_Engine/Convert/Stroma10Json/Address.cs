using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Address ToAddress(CustomObject addressObject)
        {
            if (addressObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Address sapAddress = new BH.oM.Environment.SAP.Stroma10.Address();

            sapAddress.ID = System.Convert.ToInt32(addressObject.CustomData["Id"]);

            sapAddress.AddressLine1 = addressObject.CustomData["AddressLine1"] as string;

            sapAddress.AddressLine2 = addressObject.CustomData["AddressLine2"] as string;

            sapAddress.AddressLine3 = addressObject.CustomData["AddressLine3"] as string;

            sapAddress.City = addressObject.CustomData["City"] as string;

            sapAddress.Postcode = addressObject.CustomData["Postcode"] as string;

            sapAddress.UniquePropertyReferenceNumber = addressObject.CustomData["Uprn"] as string;

            sapAddress.Country = addressObject.CustomData["Country"] as string;

            sapAddress.DisplayAddress = addressObject.CustomData["DisplayAddress"] as string;

            return sapAddress;
        }

        public static Dictionary<string, object> FromAddress(BH.oM.Environment.SAP.Stroma10.Address obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("AddressLine1", obj.AddressLine1);

            rtn.Add("AddressLine2", obj.AddressLine2);

            rtn.Add("AddressLine3", obj.AddressLine3);

            rtn.Add("City", obj.City);

            rtn.Add("Postcode", obj.Postcode);

            rtn.Add("Uprn", obj.UniquePropertyReferenceNumber);

            rtn.Add("Country", obj.Country);

            rtn.Add("DisplayAddress", obj.DisplayAddress);

            return rtn;
        }
    }
}
