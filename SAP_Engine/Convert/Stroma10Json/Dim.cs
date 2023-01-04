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
        public static List<BH.oM.Environment.SAP.Stroma10.Dim> ToDims(List<CustomObject> dimsObject)
        {
            if (dimsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Dim> rtn = new List<BH.oM.Environment.SAP.Stroma10.Dim>();
            foreach (var value in dimsObject)
            {
                rtn.Add(ToDim(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Dim ToDim(CustomObject dimObject)
        {
            if (dimObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Dim sapDim = new BH.oM.Environment.SAP.Stroma10.Dim();
            sapDim.ID = System.Convert.ToInt32(dimObject.CustomData["Id"]);
            sapDim.BHoM_Guid = (Guid.Parse(dimObject.CustomData["Guid"] as string));
            sapDim.Width = System.Convert.ToDouble(dimObject.CustomData["Width"]);
            sapDim.Length = System.Convert.ToDouble(dimObject.CustomData["Length"]);
            sapDim.Area = System.Convert.ToDouble(dimObject.CustomData["Area"]);
            return sapDim;
        }

        public static Dictionary<string, object> FromDim(Dim obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Width", obj.Width);
            rtn.Add("Length", obj.Length);
            rtn.Add("Area", obj.Area);
            return rtn;
        }
    }
}
