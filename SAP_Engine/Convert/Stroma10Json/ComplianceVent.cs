using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.ComplianceVent ToComplianceVent(CustomObject complianceVentObject)
        {
            if (complianceVentObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.ComplianceVent sapComplianceVent = new BH.oM.Environment.SAP.Stroma10.ComplianceVent();

            sapComplianceVent.ID = System.Convert.ToInt32(complianceVentObject.CustomData["Id"]);

            sapComplianceVent.Manufacturer = (complianceVentObject.CustomData["Manufacturer"] as string);

            sapComplianceVent.Model = (complianceVentObject.CustomData["Model"] as string);

            sapComplianceVent.CommissioningCertificate = (complianceVentObject.CustomData["CommissioningCertificate"] as string);

            sapComplianceVent.InstallationEngineer = (complianceVentObject.CustomData["InstallationEngineer"] as string);

            sapComplianceVent.TestCertificateNumber = (complianceVentObject.CustomData["TestCertificateNumber"] as string);

            return sapComplianceVent;
        }
    }
}
