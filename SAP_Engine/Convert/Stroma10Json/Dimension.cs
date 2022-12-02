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
using System.Reflection;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Dimension> ToDimensions(List<CustomObject> dimensionsObject)
        {
            
            if (dimensionsObject == null)
                return null;

            List<Dimension> rtn = new List<Dimension>();
            foreach (var value in dimensionsObject)
            {
                rtn.Add(ToDimension(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Dimension ToDimension(CustomObject dimensionObject)
        {
            if (dimensionObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Dimension sapDimension = new BH.oM.Environment.SAP.Stroma10.Dimension();

            sapDimension.ID = System.Convert.ToInt32(dimensionObject.CustomData["Id"]);

            sapDimension.BHoM_Guid = (Guid.Parse(dimensionObject.CustomData["Guid"] as string));

            sapDimension.Basement = System.Convert.ToBoolean(dimensionObject.CustomData["Basement"]);

            sapDimension.Area = System.Convert.ToDouble(dimensionObject.CustomData["Area"]);

            sapDimension.Perimeter = System.Convert.ToDouble(dimensionObject.CustomData["Perimeter"]);

            sapDimension.Height = System.Convert.ToDouble(dimensionObject.CustomData["Height"]);

            sapDimension.Dims = ToDims((dimensionObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapDimension.Type = dimensionObject.CustomData["Type"] as string;

            sapDimension.Name = dimensionObject.Name;

            sapDimension.Floor = System.Convert.ToInt32(dimensionObject.CustomData["Floor"]);

            sapDimension.Volume = System.Convert.ToDouble(dimensionObject.CustomData["Volume"]);

            return sapDimension;
        }
        public static Dictionary<string, object> FromDimension(Dimension obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Guid", obj.BHoM_Guid.ToString());

            rtn.Add("Basement", obj. Basement);

            rtn.Add("Area", obj.Area);

            rtn.Add("Perimeter", obj.Perimeter);

            rtn.Add("Height", obj.Height);

            if (obj.Dims != null && obj.Dims.Any(x => x != null))
                rtn.Add("Dims", obj.Dims.Select(x => FromDim(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Dims", temp);
            }


            rtn.Add("Type", obj.Type);

            rtn.Add("Name", obj.Name);

            rtn.Add("Floor", obj.Floor); 
            
            rtn.Add("Volume", obj.Volume);

            return rtn;
        }
    }
}

