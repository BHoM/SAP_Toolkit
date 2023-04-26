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
        public static BH.oM.Environment.SAP.Stroma10.Range ToRange(CustomObject rangeObject)
        {
            if (rangeObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Range sapRange = new BH.oM.Environment.SAP.Stroma10.Range();
            sapRange.ID = System.Convert.ToInt32(rangeObject.CustomData["Id"]);
            sapRange.CaseKw = System.Convert.ToDouble(rangeObject.CustomData["CaseKw"]);
            sapRange.WaterKw = System.Convert.ToDouble(rangeObject.CustomData["WaterKw"]);
            return sapRange;
        }

        public static Dictionary<string, object> FromRange(Range obj)
        {
            if (obj == null)
                return null;
            
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            rtn.Add("Id", obj.ID);
            rtn.Add("CaseKw", obj.CaseKw);
            rtn.Add("WaterKw", obj.WaterKw);

            return rtn;
        }
    }
}
