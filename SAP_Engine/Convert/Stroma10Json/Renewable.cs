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

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Renewable> ToRenewables(List<CustomObject> renewablesObject)
        {
            if (renewablesObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Renewable> rtn = new List<BH.oM.Environment.SAP.Stroma10.Renewable>();
            foreach (var value in renewablesObject)
            {
                rtn.Add(ToRenewable(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Renewable ToRenewable(CustomObject renewableObject)
        {
            if (renewableObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Renewable sapRenewable = new BH.oM.Environment.SAP.Stroma10.Renewable();

            sapRenewable.ID = System.Convert.ToInt32(renewableObject.CustomData["Id"]);

            sapRenewable.WindTurbine = ToWindTurbine(renewableObject.CustomData["WindTurbine"] as CustomObject);
            
            sapRenewable.Photovoltaic = ToPhotovoltaic(renewableObject.CustomData["Photovoltaic"] as CustomObject);

            sapRenewable.Special = ToSpecial(renewableObject.CustomData["Special"] as CustomObject);

            sapRenewable.AdditionalGeneration = ToAdditionalGeneration(renewableObject.CustomData["AAEGeneration"] as CustomObject);

            sapRenewable.HydroGeneration = ToHydroGeneration(renewableObject.CustomData["HydroGeneration"] as CustomObject);

            return sapRenewable;
        }
        public static Dictionary<string, object> FromRenewable(Renewable obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            if (obj.WindTurbine == null)
                obj.WindTurbine = new BH.oM.Environment.SAP.Stroma10.WindTurbine();

            rtn.Add("WindTurbine", FromWindTurbine(obj.WindTurbine));

            if (obj.Photovoltaic == null)
                obj.Photovoltaic = new BH.oM.Environment.SAP.Stroma10.Photovoltaic();

            rtn.Add("Photovoltaic", FromPhotovoltaic(obj.Photovoltaic));

            if (obj.Special == null)
                obj.Special = new BH.oM.Environment.SAP.Stroma10.Special();

            rtn.Add("Special", FromSpecial(obj.Special));

            if (obj.AdditionalGeneration == null)
                obj.AdditionalGeneration = new BH.oM.Environment.SAP.Stroma10.AdditionalGeneration();

            rtn.Add("AAEGeneration", FromAdditionalGeneration(obj.AdditionalGeneration));

            if (obj.HydroGeneration == null)
                obj.HydroGeneration = new BH.oM.Environment.SAP.Stroma10.HydroGeneration();

            rtn.Add("HydroGeneration", FromHydroGeneration(obj.HydroGeneration));

            return rtn;
        }
    }
}

