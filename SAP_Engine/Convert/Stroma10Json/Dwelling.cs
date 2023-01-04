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
using System.Linq;
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Dwelling> ToDwellings(List<CustomObject> dwellingsObject)
        {
            if (dwellingsObject == null)
                return null;
            List<Dwelling> rtn = new List<Dwelling>();
            foreach (var value in dwellingsObject)
            {
                rtn.Add(ToDwelling(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Dwelling ToDwelling(CustomObject dwellingObject)
        {
            if (dwellingObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Dwelling sapDwelling = new BH.oM.Environment.SAP.Stroma10.Dwelling();
            sapDwelling.ID = System.Convert.ToInt32(dwellingObject.CustomData["Id"]);
            sapDwelling.BHoM_Guid = Guid.Parse(dwellingObject.CustomData["Guid"] as string);
            sapDwelling.Selected = System.Convert.ToBoolean(dwellingObject.CustomData["Selected"]);
            sapDwelling.Name = dwellingObject.Name;
            sapDwelling.Orientation = dwellingObject.CustomData["Orientation"] as string;
            sapDwelling.IsLodged = System.Convert.ToBoolean(dwellingObject.CustomData["IsLodged"]);
            sapDwelling.DwellingVersions = ToDwellingVersions((dwellingObject.CustomData["DwellingVersions"] as List<object>).Cast<CustomObject>().ToList());
            return sapDwelling;
        }

        public static Dictionary<string, object> FromDwelling(Dwelling obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Selected", obj.Selected);
            rtn.Add("Name", obj.Name);
            rtn.Add("Orientation", obj.Orientation);
            rtn.Add("IsLodged", obj.IsLodged);
            if (obj.DwellingVersions != null && obj.DwellingVersions.Any(x => x != null))
                rtn.Add("DwellingVersions", obj.DwellingVersions.Select(x => FromDwellingVersion(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("DwellingVersions", temp);
            }

            return rtn;
        }
    }
}
