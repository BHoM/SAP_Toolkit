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
            BH.oM.Environment.SAP.Stroma10.ComplianceVent sapComplianceVent = new BH.oM.Environment.SAP.Stroma10.ComplianceVent();

            sapComplianceVent.ID = System.Convert.ToInt32(complianceVentObject.CustomData["ID"]);

            sapComplianceVent.Manufacturer = (complianceVentObject.CustomData["Manufacturer"] as CustomObject);

            sapComplianceVent.Model = (complianceVentObject.CustomData["Model"] as CustomObject);

            sapComplianceVent.CommissioningCertificate = (complianceVentObject.CustomData["CommissioningCertificate"] as CustomObject);

            sapComplianceVent.InstallationEngineer = (complianceVentObject.CustomData["InstallationEngineer"] as CustomObject);

            sapComplianceVent.TestCertificateNumber = (complianceVentObject.CustomData["TestCertificateNumber"] as CustomObject);

            return sapComplianceVent;
        }
    }
}
