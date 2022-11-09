using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.ComplianceHeatingDetails ToComplianceHeatingDetails(CustomObject complianceHeatingDetailsObject)
        {
            BH.oM.Environment.SAP.Stroma10.ComplianceHeatingDetails sapComplianceHeatingDetails = new BH.oM.Environment.SAP.Stroma10.ComplianceHeatingDetails();

            sapComplianceHeatingDetails.ID = System.Convert.ToInt32(complianceHeatingDetailsObject.CustomData["ID"]);

            sapComplianceHeatingDetails.Manufacturer = (complianceHeatingDetailsObject.CustomData["Manufacturer"] as CustomObject);

            sapComplianceHeatingDetails.Model = (complianceHeatingDetailsObject.CustomData["Model"] as CustomObject);

            sapComplianceHeatingDetails.SystemType = (complianceHeatingDetailsObject.CustomData["SystemType"] as CustomObject);

            sapComplianceHeatingDetails.CommissioningCertificate = (complianceHeatingDetailsObject.CustomData["CommissioningCertificate"] as CustomObject);

            sapComplianceHeatingDetails.InstallationEngineer = (complianceHeatingDetailsObject.CustomData["InstallationEngineer"] as CustomObject);

            sapComplianceHeatingDetails.ControllerFunction = (complianceHeatingDetailsObject.CustomData["ControllerFunction"] as CustomObject);

            sapComplianceHeatingDetails.ControllerEcodesignClass = (complianceHeatingDetailsObject.CustomData["ControllerEcodesignClass"] as CustomObject);

            sapComplianceHeatingDetails.ControllerManufacturer = (complianceHeatingDetailsObject.CustomData["ControllerManufacturer"] as CustomObject);

            sapComplianceHeatingDetails.ControllerModel = (complianceHeatingDetailsObject.CustomData["ControllerModel"] as CustomObject);

            return sapComplianceHeatingDetails;
        }
    }
}
