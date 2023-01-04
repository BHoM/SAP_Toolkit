/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */
using System;
using System.Collections.Generic;
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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

        public static Dictionary<string, object> FromComplianceHeatingDetails(ComplianceHeatingDetails obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Manufacturer", obj.Manufacturer);
            rtn.Add("Model", obj.Model);
            rtn.Add("SystemType", obj.SystemType);
            rtn.Add("CommissioningCertificate", obj.CommissioningCertificate);
            rtn.Add("InstallationEngineer", obj.InstallationEngineer);
            rtn.Add("ControllerFunction", obj.ControllerFunction);
            rtn.Add("ControllerEcodesignClass", obj.ControllerEcodesignClass);
            rtn.Add("ControllerManufacturer", obj.ControllerManufacturer);
            rtn.Add("ControllerModel", obj.ControllerModel);
            return rtn;
        }
    }
}
