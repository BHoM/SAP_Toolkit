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
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Floor> ToFloors(List<CustomObject> floorsObject)
        {
            if (floorsObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Floor> rtn = new List<BH.oM.Environment.SAP.Stroma10.Floor>();
            foreach (var value in floorsObject)
            {
                rtn.Add(ToFloor(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Floor ToFloor(CustomObject floorObject)
        {
            if (floorObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Floor sapFloor = new BH.oM.Environment.SAP.Stroma10.Floor();
            sapFloor.ID = System.Convert.ToInt32(floorObject.CustomData["Id"]);
            sapFloor.BHoM_Guid = (Guid.Parse(floorObject.CustomData["Guid"] as string));
            sapFloor.Name = floorObject.Name;
            sapFloor.Type = System.Convert.ToInt32(floorObject.CustomData["Type"]);
            sapFloor.Construction = System.Convert.ToInt32(floorObject.CustomData["Construction"]);
            sapFloor.Area = System.Convert.ToDouble(floorObject.CustomData["Area"]);
            sapFloor.UValueStart = System.Convert.ToDouble(floorObject.CustomData["UValueStart"]);
            sapFloor.UValue = System.Convert.ToDouble(floorObject.CustomData["UValue"]);
            sapFloor.ResultantUValue = System.Convert.ToDouble(floorObject.CustomData["Ru"]);
            sapFloor.Curtain = System.Convert.ToBoolean(floorObject.CustomData["Curtain"]);
            sapFloor.ManualInputKappa = System.Convert.ToBoolean(floorObject.CustomData["OverRideK"]);
            sapFloor.Kappa = System.Convert.ToDouble(floorObject.CustomData["K"]);
            sapFloor.Dims = ToDims((floorObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());
            sapFloor.UValueSelectionID = System.Convert.ToInt32(floorObject.CustomData["UValueSelectionId"]);
            sapFloor.UValueSelected = System.Convert.ToBoolean(floorObject.CustomData["UValueSelected"]);
            sapFloor.EnergyPerformanceCertificateDescription = floorObject.CustomData["EpcDescription"] as string;
            sapFloor.LoftInsulation = floorObject.CustomData["LoftInsulation"] as string;
            return sapFloor;
        }

        public static Dictionary<string, object> FromFloor(BH.oM.Environment.SAP.Stroma10.Floor obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("Type", obj.Type);
            rtn.Add("Construction", obj.Construction);
            rtn.Add("Area", obj.Area);
            rtn.Add("UValueStart", obj.UValueStart);
            rtn.Add("UValue", obj.UValue);
            rtn.Add("Ru", obj.ResultantUValue);
            rtn.Add("Curtain", obj.Curtain);
            rtn.Add("OverRideK", obj.ManualInputKappa);
            rtn.Add("K", obj.Kappa);
            if (obj.Dims != null && obj.Dims.Any(x => x != null))
                rtn.Add("Dims", obj.Dims.Select(x => FromDim(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Dims", temp);
            }

            rtn.Add("UValueSelectionId", obj.UValueSelectionID);
            rtn.Add("UValueSelected", obj.UValueSelected);
            rtn.Add("EpcDescription", obj.EnergyPerformanceCertificateDescription);
            rtn.Add("LoftInsulation", obj.LoftInsulation);
            return rtn;
        }
    }
}
