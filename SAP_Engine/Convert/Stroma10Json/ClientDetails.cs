using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.ClientDetails ToClientDetails(CustomObject clientDetailsObject)
        {

            if (clientDetailsObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.ClientDetails sapClientDetails = new BH.oM.Environment.SAP.Stroma10.ClientDetails();

            sapClientDetails.ID = System.Convert.ToInt32(clientDetailsObject.CustomData["Id"]);

            sapClientDetails.Address = ToAddress(clientDetailsObject.CustomData["Address"] as CustomObject);

            sapClientDetails.PhoneNumber = clientDetailsObject.CustomData["PhoneNumber"] as string;

            sapClientDetails.FaxNumber = clientDetailsObject.CustomData["FaxNumber"] as string;

            sapClientDetails.Email = clientDetailsObject.CustomData["Email"] as string;

            sapClientDetails.CompanyName = clientDetailsObject.CustomData["CompanyName"] as string;

            return sapClientDetails;
        }
    }
}
