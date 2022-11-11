using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

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
    }
}
