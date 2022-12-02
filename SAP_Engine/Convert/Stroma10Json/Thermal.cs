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
using System.Linq;
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Thermal ToThermal(CustomObject thermalObject)
        {
            if (thermalObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Thermal sapThermal = new BH.oM.Environment.SAP.Stroma10.Thermal();
            sapThermal.ID = System.Convert.ToInt32(thermalObject.CustomData["Id"]);
            sapThermal.BHoM_Guid = (Guid.Parse(thermalObject.CustomData["Guid"] as string));
            sapThermal.ManualThermalBridgingCalcuation = System.Convert.ToBoolean(thermalObject.CustomData["ManualHtb"]);
            sapThermal.ThermalBridgingValue = System.Convert.ToDouble(thermalObject.CustomData["HtbValue"]);
            sapThermal.ConstrunctionDetails = (thermalObject.CustomData["ConstDetails"] as string);
            sapThermal.ManualThermalBridgingYValue = System.Convert.ToBoolean(thermalObject.CustomData["ManualY"]);
            sapThermal.YValue = System.Convert.ToDouble(thermalObject.CustomData["YValue"]);
            sapThermal.CustomApproved = System.Convert.ToBoolean(thermalObject.CustomData["CustomApproved"]);
            sapThermal.ExternalJunctions = ToExternalJunctions((thermalObject.CustomData["ExternalJunctions"] as List<object>).Cast<CustomObject>().ToList());
            sapThermal.PartyJunctions = ToPartyJunctions((thermalObject.CustomData["PartyJunctions"] as List<object>).Cast<CustomObject>().ToList());
            sapThermal.RoofJunctions = ToRoofJunctions((thermalObject.CustomData["RoofJunctions"] as List<object>).Cast<CustomObject>().ToList());
            sapThermal.Reference = System.Convert.ToBoolean(thermalObject.CustomData["Reference"]);
            return sapThermal;
        }

        public static Dictionary<string, object> FromThermal(Thermal obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("ManualHtb", obj.ManualThermalBridgingCalcuation);
            rtn.Add("HtbValue", obj.ThermalBridgingValue);
            rtn.Add("ConstDetails", obj.ConstrunctionDetails);
            rtn.Add("ManualY", obj.ManualThermalBridgingYValue);
            rtn.Add("YValue", obj.YValue);
            rtn.Add("CustomApproved", obj.CustomApproved);
            if (obj.ExternalJunctions != null && obj.ExternalJunctions.Any(x => x != null))
                rtn.Add("ExternalJunctions", obj.ExternalJunctions.Select(x => FromExternalJunction(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("ExternalJunctions", temp);
            }

            if (obj.PartyJunctions != null && obj.PartyJunctions.Any(x => x != null))
                rtn.Add("PartyJunctions", obj.PartyJunctions.Select(x => FromPartyJunction(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("PartyJunctions", temp);
            }

            if (obj.RoofJunctions != null && obj.RoofJunctions.Any(x => x != null))
                rtn.Add("RoofJunctions", obj.RoofJunctions.Select(x => FromRoofJunction(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("RoofJunctions", temp);
            }

            rtn.Add("Reference", obj.Reference);
            return rtn;
        }
    }
}