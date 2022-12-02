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
        public static BH.oM.Environment.SAP.Stroma10.Elements ToElements(CustomObject elementsObject)
        {
            if (elementsObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Elements sapElements = new BH.oM.Environment.SAP.Stroma10.Elements();
            sapElements.ID = System.Convert.ToInt32(elementsObject.CustomData["Id"]);
            sapElements.Fabrics = ToFabrics((elementsObject.CustomData["Fabric"] as List<object>).Cast<CustomObject>().ToList());
            sapElements.Heatings = ToHeatings((elementsObject.CustomData["Heating"] as List<object>).Cast<CustomObject>().ToList());
            sapElements.Waters = ToWaters((elementsObject.CustomData["Water"] as List<object>).Cast<CustomObject>().ToList());
            sapElements.Ventilations = ToVentilations((elementsObject.CustomData["Ventilation"] as List<object>).Cast<CustomObject>().ToList());
            sapElements.Renewables = ToRenewables((elementsObject.CustomData["Renewable"] as List<object>).Cast<CustomObject>().ToList());
            sapElements.Overheatings = ToOverheatings((elementsObject.CustomData["Overheating"] as List<object>).Cast<CustomObject>().ToList());
            return sapElements;
        }

        public static Dictionary<string, object> FromElements(Elements obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            if (obj.Fabrics != null && obj.Fabrics.Any(x => x != null))
                rtn.Add("Fabric", obj.Fabrics.Select(x => FromFabric(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Fabric", temp);
            }

            if (obj.Heatings != null && obj.Heatings.Any(x => x != null))
                rtn.Add("Heating", obj.Heatings.Select(x => FromHeating(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Heating", temp);
            }

            if (obj.Waters != null && obj.Waters.Any(x => x != null))
                rtn.Add("Water", obj.Waters.Select(x => FromWater(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Water", temp);
            }

            if (obj.Ventilations != null && obj.Ventilations.Any(x => x != null))
                rtn.Add("Ventilation", obj.Ventilations.Select(x => FromVentilation(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Ventilation", temp);
            }

            if (obj.Renewables != null && obj.Renewables.Any(x => x != null))
                rtn.Add("Renewable", obj.Renewables.Select(x => FromRenewable(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Renewable", temp);
            }

            if (obj.Overheatings != null && obj.Overheatings.Any(x => x != null))
                rtn.Add("Overheating", obj.Overheatings.Select(x => FromOverheating(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Overheating", temp);
            }

            return rtn;
        }
    }
}