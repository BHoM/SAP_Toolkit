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
            if (complianceHeatingDetailsObject == null)
                return null;

            
            BH.oM.Environment.SAP.Stroma10.ComplianceHeatingDetails sapComplianceHeatingDetails = new BH.oM.Environment.SAP.Stroma10.ComplianceHeatingDetails();

            sapComplianceHeatingDetails.ID = System.Convert.ToInt32(complianceHeatingDetailsObject.CustomData["Id"]);

            sapComplianceHeatingDetails.Manufacturer = (complianceHeatingDetailsObject.CustomData["Manufacturer"] as string);

            sapComplianceHeatingDetails.Model = (complianceHeatingDetailsObject.CustomData["Model"] as string);

            sapComplianceHeatingDetails.SystemType = (complianceHeatingDetailsObject.CustomData["SystemType"] as string);

            sapComplianceHeatingDetails.CommissioningCertificate = (complianceHeatingDetailsObject.CustomData["CommissioningCertificate"] as string);

            sapComplianceHeatingDetails.InstallationEngineer = (complianceHeatingDetailsObject.CustomData["InstallationEngineer"] as string);

            sapComplianceHeatingDetails.ControllerFunction = (complianceHeatingDetailsObject.CustomData["ControllerFunction"] as string);

            sapComplianceHeatingDetails.ControllerEcodesignClass = (complianceHeatingDetailsObject.CustomData["ControllerEcodesignClass"] as string);

            sapComplianceHeatingDetails.ControllerManufacturer = (complianceHeatingDetailsObject.CustomData["ControllerManufacturer"] as string);

            sapComplianceHeatingDetails.ControllerModel = (complianceHeatingDetailsObject.CustomData["ControllerModel"] as string);

            return sapComplianceHeatingDetails;
        }
    }
}
