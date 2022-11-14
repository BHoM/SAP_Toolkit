﻿using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Assessor ToAssessor(CustomObject assessorObject)
        {
            BH.oM.Environment.SAP.Stroma10.Assessor sapAssessor = new BH.oM.Environment.SAP.Stroma10.Assessor();

            if (assessorObject == null)
                return null;

            sapAssessor.ID = System.Convert.ToInt32(assessorObject.CustomData["Id"]);

            sapAssessor.FirstName = assessorObject.CustomData["FirstName"] as string;

            sapAssessor.LastName = assessorObject.CustomData["LastName"] as string;

            sapAssessor.Address = ToAddress(assessorObject.CustomData["Address"] as CustomObject);

            sapAssessor.WebSite = assessorObject.CustomData["WebSite"] as string;

            sapAssessor.Email = assessorObject.CustomData["Email"] as string;

            sapAssessor.Telephone = assessorObject.CustomData["Telephone"] as string;

            sapAssessor.Fax = assessorObject.CustomData["Fax"] as string;

            sapAssessor.CompanyName = assessorObject.CustomData["CompanyName"] as string;

            sapAssessor.StromaNumber = assessorObject.CustomData["StromaNumber"] as string;

            sapAssessor.Insurance = ToInsurance(assessorObject.CustomData["Insurance"] as CustomObject);


            return sapAssessor;
        }
        public static Dictionary<string, object> FromAssessor(BH.oM.Environment.SAP.Stroma10.Assessor obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);

            rtn.Add("FirstName", obj.FirstName);

            rtn.Add("LastName", obj.LastName);

            rtn.Add("Address", FromAddress(obj.Address));

            rtn.Add("WebSite", obj.WebSite);

            rtn.Add("Email", obj.Email);

            rtn.Add("Telephone", obj.Telephone);

            rtn.Add("Fax", obj.Fax);

            rtn.Add("CompanyName", obj.CompanyName);

            rtn.Add("StromaNumber", obj.StromaNumber);

            rtn.Add("Insurance", FromInsurance(obj.Insurance));    

            return rtn;
        }
    }
}
