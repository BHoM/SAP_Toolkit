using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Insurance ToInsurance(CustomObject insuranceObject)
        {
            if (insuranceObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Insurance sapInsurance = new BH.oM.Environment.SAP.Stroma10.Insurance();

            sapInsurance.ID = System.Convert.ToInt32(insuranceObject.CustomData["Id"]);

            sapInsurance.Insurer = insuranceObject.CustomData["Insurer"] as string;

            sapInsurance.PolicyNumber = insuranceObject.CustomData["PolicyNo"] as string;

            sapInsurance.PublicLiabilityInsuranceLimit = System.Convert.ToInt32(insuranceObject.CustomData["PLLimit"]);

            sapInsurance.StartDate = System.Convert.ToDateTime(insuranceObject.CustomData["StartDate"]);

            sapInsurance.EndDate = System.Convert.ToDateTime(insuranceObject.CustomData["Enddate"]);

            return sapInsurance;
        }
        public static Dictionary<string, object> FromInsurance(Insurance obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Insurer", obj.Insurer);

            rtn.Add("PolicyNo", obj.PolicyNumber);

            rtn.Add("PLLimit", obj.PublicLiabilityInsuranceLimit);

            rtn.Add("StartDate", obj.StartDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            rtn.Add("Enddate", obj.EndDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            return rtn;
        }
    }
}
