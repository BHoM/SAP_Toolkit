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
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Photovoltaic ToPhotovoltaic(CustomObject photovoltaicObject)
        {
            if (photovoltaicObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Photovoltaic sapPhotovoltaic = new BH.oM.Environment.SAP.Stroma10.Photovoltaic();

            sapPhotovoltaic.ID = System.Convert.ToInt32(photovoltaicObject.CustomData["Id"]);

            sapPhotovoltaic.Include = System.Convert.ToBoolean(photovoltaicObject.CustomData["Include"]);

            sapPhotovoltaic.Diverter = System.Convert.ToBoolean(photovoltaicObject.CustomData["Diverter"]);

            sapPhotovoltaic.BatteryCapacity = System.Convert.ToDouble(photovoltaicObject.CustomData["BatterCapacity"]);

            sapPhotovoltaic.Photovoltaic2s = ToPhotovoltaic2s((photovoltaicObject.CustomData["Photovoltaics"] as List<object>).Cast<CustomObject>().ToList());

            return sapPhotovoltaic;
        }
        public static Dictionary<string, object> FromPhotovoltaic(Photovoltaic obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("Diverter", obj.Diverter);

            rtn.Add("BatterCapacity", obj.BatteryCapacity);

            if (obj.Photovoltaic2s != null && obj.Photovoltaic2s.Any(x => x != null))
                rtn.Add("Photovoltaics", obj.Photovoltaic2s.Select(x => FromPhotovoltaic2(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Photovoltaics", temp);
            }

            return rtn;
        }
    }
}

