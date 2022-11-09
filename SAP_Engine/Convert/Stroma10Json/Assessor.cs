using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Assessor ToAssessor(CustomObject assessorObject)
        {
            BH.oM.Environment.SAP.Stroma10.Assessor sapAssessor = new BH.oM.Environment.SAP.Stroma10.Assessor();

            sapAssessor.ID = System.Convert.ToInt32(assessorObject.CustomData["ID"]);

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
    }
}
