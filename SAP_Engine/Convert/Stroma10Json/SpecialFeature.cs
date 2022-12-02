/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
        public static List<BH.oM.Environment.SAP.Stroma10.SpecialFeature> ToSpecialFeatures(List<CustomObject> specialFeaturesObject)
        {
            if (specialFeaturesObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.SpecialFeature> rtn = new List<BH.oM.Environment.SAP.Stroma10.SpecialFeature>();
            foreach (var value in specialFeaturesObject)
            {
                rtn.Add(ToSpecialFeature(value));
            }
            return rtn;
        }


        public static BH.oM.Environment.SAP.Stroma10.SpecialFeature ToSpecialFeature(CustomObject specialFeatureObject)
        {
            if (specialFeatureObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.SpecialFeature sapSpecialFeature = new BH.oM.Environment.SAP.Stroma10.SpecialFeature();

            sapSpecialFeature.ID = System.Convert.ToInt32(specialFeatureObject.CustomData["Id"]);

            sapSpecialFeature.Description = specialFeatureObject.CustomData["Description"] as string;

            sapSpecialFeature.EnergySaved = System.Convert.ToDouble(specialFeatureObject.CustomData["EnergySaved"]);

            sapSpecialFeature.ID = System.Convert.ToInt32(specialFeatureObject.CustomData["Id"]);

            sapSpecialFeature.EnergyUsed = System.Convert.ToDouble(specialFeatureObject.CustomData["EnergyUsed"]);

            sapSpecialFeature.ID = System.Convert.ToInt32(specialFeatureObject.CustomData["Id"]);

            sapSpecialFeature.IncludeMonthly = System.Convert.ToBoolean(specialFeatureObject.CustomData["IncludeMonthly"]);

            sapSpecialFeature.MakeEmissionsOnly = System.Convert.ToBoolean(specialFeatureObject.CustomData["MakeEmissionsOnly"]);

            sapSpecialFeature.EmissionsAmount = System.Convert.ToDouble(specialFeatureObject.CustomData["EmissionsAmount"]);

            sapSpecialFeature.EmissionsAmountCreated = System.Convert.ToDouble(specialFeatureObject.CustomData["EmissionsAmountCreated"]);

            sapSpecialFeature.Month01 = System.Convert.ToDouble(specialFeatureObject.CustomData["M1"]);

            sapSpecialFeature.Month02 = System.Convert.ToDouble(specialFeatureObject.CustomData["M2"]);

            sapSpecialFeature.Month03 = System.Convert.ToDouble(specialFeatureObject.CustomData["M3"]);

            sapSpecialFeature.Month04 = System.Convert.ToDouble(specialFeatureObject.CustomData["M4"]);

            sapSpecialFeature.Month05 = System.Convert.ToDouble(specialFeatureObject.CustomData["M5"]);

            sapSpecialFeature.Month06 = System.Convert.ToDouble(specialFeatureObject.CustomData["M6"]);

            sapSpecialFeature.Month07 = System.Convert.ToDouble(specialFeatureObject.CustomData["M7"]);

            sapSpecialFeature.Month08 = System.Convert.ToDouble(specialFeatureObject.CustomData["M8"]);

            sapSpecialFeature.Month09 = System.Convert.ToDouble(specialFeatureObject.CustomData["M9"]);

            sapSpecialFeature.Month10 = System.Convert.ToDouble(specialFeatureObject.CustomData["M10"]);

            sapSpecialFeature.Month11 = System.Convert.ToDouble(specialFeatureObject.CustomData["M11"]);

            sapSpecialFeature.Month12 = System.Convert.ToDouble(specialFeatureObject.CustomData["M12"]);

            return sapSpecialFeature;
        }
        public static Dictionary<string, object> FromSpecialFeature(SpecialFeature obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Description", obj.Description);

            rtn.Add("EnergySaved", obj.EnergySaved);

            rtn.Add("FuelSaved", obj.FuelSaved);

            rtn.Add("EnergyUsed", obj.EnergyUsed);

            rtn.Add("FuelUsed", obj.FuelUsed);

            rtn.Add("IncludeMonthly", obj.IncludeMonthly);

            rtn.Add("MakeEmissionsOnly", obj.MakeEmissionsOnly);

            rtn.Add("EmissionsAmount", obj.EmissionsAmount);

            rtn.Add("EmissionsAmountCreated", obj.EmissionsAmountCreated);

            rtn.Add("M1", obj.Month01);

            rtn.Add("M2", obj.Month02);

            rtn.Add("M3", obj.Month03);

            rtn.Add("M4", obj.Month04);

            rtn.Add("M5", obj.Month05);

            rtn.Add("M6", obj.Month06);

            rtn.Add("M7", obj.Month07);

            rtn.Add("M8", obj.Month08);

            rtn.Add("M9", obj.Month09);

            rtn.Add("M10", obj.Month10);

            rtn.Add("M11", obj.Month11);

            rtn.Add("M12", obj.Month12);

            return rtn;
        }
    }
}
