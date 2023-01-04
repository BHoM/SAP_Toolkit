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
using System.Linq;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.ShowerUnit> ToShowerUnits(List<CustomObject> showerUnitsObject)
        {
            if (showerUnitsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.ShowerUnit> rtn = new List<BH.oM.Environment.SAP.Stroma10.ShowerUnit>();
            foreach (var value in showerUnitsObject)
            {
                rtn.Add(ToShowerUnit(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.ShowerUnit ToShowerUnit(CustomObject showerUnitObject)
        {
            BH.oM.Environment.SAP.Stroma10.ShowerUnit sapShowerUnit = new BH.oM.Environment.SAP.Stroma10.ShowerUnit();
            if (showerUnitObject == null)
                return null;
            sapShowerUnit.ID = System.Convert.ToInt32(showerUnitObject.CustomData["Id"]);
            sapShowerUnit.BHoM_Guid = (Guid.Parse(showerUnitObject.CustomData["Guid"] as string));
            sapShowerUnit.Name = showerUnitObject.Name;
            sapShowerUnit.Type = System.Convert.ToInt32(showerUnitObject.CustomData["Type"]);
            sapShowerUnit.ShowerWasteWaterHeatRecoverySystem = System.Convert.ToInt32(showerUnitObject.CustomData["ShowerWwhrs"]);
            sapShowerUnit.OverRide = System.Convert.ToBoolean(showerUnitObject.CustomData["OverRide"]);
            sapShowerUnit.Flow = System.Convert.ToDouble(showerUnitObject.CustomData["Flow"]);
            sapShowerUnit.Power = System.Convert.ToDouble(showerUnitObject.CustomData["Power"]);
            return sapShowerUnit;
        }

        public static Dictionary<string, object> FromShowerUnit(ShowerUnit obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Type", obj.Type);
            rtn.Add("ShowerWwhrs", obj.ShowerWasteWaterHeatRecoverySystem);
            rtn.Add("OverRide", obj.OverRide);
            rtn.Add("Flow", obj.Flow);
            rtn.Add("Power", obj.Power);
            return rtn;
        }
    }
}
