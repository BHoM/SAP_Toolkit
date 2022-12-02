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

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("FirstName", obj.FirstName);

            rtn.Add("LastName", obj.LastName);
            

            if (obj.Address == null)
                obj.Address = new BH.oM.Environment.SAP.Stroma10.Address();

            rtn.Add("Address", FromAddress(obj.Address));


            rtn.Add("WebSite", obj.WebSite);

            rtn.Add("Email", obj.Email);

            rtn.Add("Telephone", obj.Telephone);

            rtn.Add("Fax", obj.Fax);

            rtn.Add("CompanyName", obj.CompanyName);

            rtn.Add("StromaNumber", obj.StromaNumber);


            if (obj.Insurance == null)
                obj.Insurance = new BH.oM.Environment.SAP.Stroma10.Insurance();

            rtn.Add("Insurance", FromInsurance(obj.Insurance));    

            return rtn;
        }
    }
}

