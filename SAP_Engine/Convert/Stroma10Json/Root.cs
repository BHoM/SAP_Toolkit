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

using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Base;
using System.Linq;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static Root ToRoot(CustomObject rootObject)
        {
            if (rootObject == null)
                return null;

            Root sapRoot = new Root();

            sapRoot.ID = System.Convert.ToInt32(rootObject.CustomData["Id"]);

            sapRoot.BHoM_Guid = Guid.Parse(rootObject.CustomData["Guid"] as string);

            sapRoot.DateTimeCreated = System.Convert.ToDateTime(rootObject.CustomData["DateTimeCreated"]);

            sapRoot.DateTimeSaved = System.Convert.ToDateTime(rootObject.CustomData["DateTimeSaved"]);

            sapRoot.UserID = System.Convert.ToInt32(rootObject.CustomData["UserId"]);

            sapRoot.Name = rootObject.Name;

            sapRoot.Reference = rootObject.CustomData["Reference"] as string;

            sapRoot.Dwellings = ToDwellings((rootObject.CustomData["Dwellings"] as List<object>).Cast<CustomObject>().ToList());

            sapRoot.Address = ToAddress(rootObject.CustomData["Address"] as CustomObject);

            sapRoot.ClientDetails = ToClientDetails(rootObject.CustomData["ClientDetails"] as CustomObject);

            sapRoot.Elements = ToElements(rootObject.CustomData["Elements"] as CustomObject);

            sapRoot.Assessor = ToAssessor(rootObject.CustomData["Assessor"] as CustomObject);

            sapRoot.DwellingCount = System.Convert.ToInt32(rootObject.CustomData["DwellingCount"]);

            return sapRoot;
        }

        public static Dictionary<string, object> FromRoot(Root obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Guid", obj.BHoM_Guid.ToString());

            rtn.Add("DateTimeCreated", obj.DateTimeCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            rtn.Add("DateTimeSaved", obj.DateTimeSaved.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            rtn.Add("UserId", obj.UserID);

            rtn.Add("Name", obj.Name);

            rtn.Add("Reference", obj.Reference);


            if (obj.Dwellings != null && obj.Dwellings.Any(x => x != null))
                rtn.Add("Dwellings", obj.Dwellings.Select(x => FromDwelling(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Dwellings", temp);
            }


            if (obj.Address == null)
                obj.Address = new BH.oM.Environment.SAP.Stroma10.Address();
            
            rtn.Add("Address", FromAddress(obj.Address));


            if (obj.ClientDetails == null)
                obj.ClientDetails = new BH.oM.Environment.SAP.Stroma10.ClientDetails();

            rtn.Add("ClientDetails", FromClientDetails(obj.ClientDetails));


            if (obj.Elements == null)
                obj.Elements = new BH.oM.Environment.SAP.Stroma10.Elements();

            rtn.Add("Elements", FromElements(obj.Elements));


            if (obj.Assessor == null)
                obj.Assessor = new BH.oM.Environment.SAP.Stroma10.Assessor();

            rtn.Add("Assessor", FromAssessor(obj.Assessor));


            rtn.Add("DwellingCount", obj.DwellingCount);


            return rtn;
        }
    }
}

