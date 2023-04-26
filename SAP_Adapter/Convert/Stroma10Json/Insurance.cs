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
            if (obj == null)
                return null;

            Dictionary<string, object> rtn = new Dictionary<string, object>();
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
