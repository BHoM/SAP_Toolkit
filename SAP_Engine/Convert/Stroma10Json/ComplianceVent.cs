/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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

        public static Dictionary<string, object> FromComplianceVent(ComplianceVent obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Manufacturer", obj.Manufacturer);
            rtn.Add("Model", obj.Model);
            rtn.Add("CommissioningCertificate", obj.CommissioningCertificate);
            rtn.Add("InstallationEngineer", obj.InstallationEngineer);
            rtn.Add("TestCertificateNumber", obj.TestCertificateNumber);
            return rtn;
        }
    }
}