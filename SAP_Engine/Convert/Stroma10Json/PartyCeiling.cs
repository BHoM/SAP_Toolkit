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
        public static List<BH.oM.Environment.SAP.Stroma10.PartyCeiling> ToPartyCeilings(List<CustomObject> partyCeilingsObject)
        {
            if (partyCeilingsObject == null)
                return null;

            List<PartyCeiling> rtn = new List<PartyCeiling>();
            foreach (var value in partyCeilingsObject)
            {
                rtn.Add(ToPartyCeiling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.PartyCeiling ToPartyCeiling(CustomObject partyCeilingObject)
        {
            if (partyCeilingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PartyCeiling sapPartyCeiling = new BH.oM.Environment.SAP.Stroma10.PartyCeiling();

            sapPartyCeiling.ID = System.Convert.ToInt32(partyCeilingObject.CustomData["Id"]);

            sapPartyCeiling.BHoM_Guid = (Guid.Parse(partyCeilingObject.CustomData["Guid"] as string));

            sapPartyCeiling.Name = partyCeilingObject.Name;

            sapPartyCeiling.Type = System.Convert.ToInt32(partyCeilingObject.CustomData["Type"]);

            sapPartyCeiling.Construction = System.Convert.ToInt32(partyCeilingObject.CustomData["Construction"]);

            sapPartyCeiling.Area = System.Convert.ToDouble(partyCeilingObject.CustomData["Area"]);

            sapPartyCeiling.UValueStart = System.Convert.ToDouble(partyCeilingObject.CustomData["UValueStart"]);

            sapPartyCeiling.UValue = System.Convert.ToDouble(partyCeilingObject.CustomData["UValue"]);

            sapPartyCeiling.ResultantUValue = System.Convert.ToDouble(partyCeilingObject.CustomData["Ru"]);

            sapPartyCeiling.Curtain = System.Convert.ToBoolean(partyCeilingObject.CustomData["Curtain"]);

            sapPartyCeiling.ManualInputKappa = System.Convert.ToBoolean(partyCeilingObject.CustomData["OverRideK"]);

            sapPartyCeiling.Kappa = System.Convert.ToDouble(partyCeilingObject.CustomData["K"]);

            sapPartyCeiling.Dims = ToDims((partyCeilingObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList());

            sapPartyCeiling.UValueSelectionID = System.Convert.ToInt32(partyCeilingObject.CustomData["UValueSelectionId"]);

            sapPartyCeiling.UValueSelected = System.Convert.ToBoolean(partyCeilingObject.CustomData["UValueSelected"]);

            sapPartyCeiling.EnergyPerformanceCertificateDescription = partyCeilingObject.CustomData["EpcDescription"] as string;

            sapPartyCeiling.LoftInsulation = partyCeilingObject.CustomData["LoftInsulation"] as string;

            return sapPartyCeiling;
        }
        public static Dictionary<string, object> FromPartyCeiling(PartyCeiling obj)
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

