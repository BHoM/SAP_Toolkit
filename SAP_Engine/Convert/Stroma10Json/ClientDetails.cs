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
        public static BH.oM.Environment.SAP.Stroma10.ClientDetails ToClientDetails(CustomObject clientDetailsObject)
        {
            if (clientDetailsObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.ClientDetails sapClientDetails = new BH.oM.Environment.SAP.Stroma10.ClientDetails();
            sapClientDetails.ID = System.Convert.ToInt32(clientDetailsObject.CustomData["Id"]);
            sapClientDetails.Name = clientDetailsObject.Name;
            sapClientDetails.Address = ToAddress(clientDetailsObject.CustomData["Address"] as CustomObject);
            sapClientDetails.PhoneNumber = clientDetailsObject.CustomData["PhoneNumber"] as string;
            sapClientDetails.FaxNumber = clientDetailsObject.CustomData["FaxNumber"] as string;
            sapClientDetails.Email = clientDetailsObject.CustomData["Email"] as string;
            sapClientDetails.CompanyName = clientDetailsObject.CustomData["CompanyName"] as string;
            return sapClientDetails;
        }

        public static Dictionary<string, object> FromClientDetails(ClientDetails obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Name", obj.Name);
            if (obj.Address == null)
                obj.Address = new BH.oM.Environment.SAP.Stroma10.Address();
            rtn.Add("Address", FromAddress(obj.Address));
            rtn.Add("PhoneNumber", obj.PhoneNumber);
            rtn.Add("FaxNumber", obj.FaxNumber);
            rtn.Add("Email", obj.Email);
            rtn.Add("CompanyName", obj.CompanyName);
            return rtn;
        }
    }
}
