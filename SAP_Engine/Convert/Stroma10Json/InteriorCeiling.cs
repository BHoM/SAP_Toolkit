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
        public static List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling> ToInteriorCeilings(List<CustomObject> interiorCeilingsObject)
        {
            if (interiorCeilingsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling> rtn = new List<BH.oM.Environment.SAP.Stroma10.InteriorCeiling>();
            foreach (var value in interiorCeilingsObject)
            {
                rtn.Add(ToInteriorCeiling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.InteriorCeiling ToInteriorCeiling(CustomObject interiorCeilingObject)
        {
            if (interiorCeilingObject == null)
                return null;
            
            BH.oM.Environment.SAP.Stroma10.InteriorCeiling sapInteriorCeiling = new BH.oM.Environment.SAP.Stroma10.InteriorCeiling();

            sapInteriorCeiling.ID = System.Convert.ToInt32(interiorCeilingObject.CustomData["Id"]);

            sapInteriorCeiling.BHoM_Guid = (Guid.Parse(interiorCeilingObject.CustomData["Guid"] as string));

            sapInteriorCeiling.Name = interiorCeilingObject.Name;

            sapInteriorCeiling.Type = System.Convert.ToInt32(interiorCeilingObject.CustomData["Type"]);

            sapInteriorCeiling.Construction = System.Convert.ToInt32(interiorCeilingObject.CustomData["Construction"]);

            sapInteriorCeiling.Area = System.Convert.ToDouble(interiorCeilingObject.CustomData["Area"]);

            sapInteriorCeiling.UValueStart = System.Convert.ToDouble(interiorCeilingObject.CustomData["UValueStart"]);

            sapInteriorCeiling.UValue = System.Convert.ToDouble(interiorCeilingObject.CustomData["UValue"]);

            sapInteriorCeiling.ResultantUValue = System.Convert.ToDouble(interiorCeilingObject.CustomData["Ru"]);

            sapInteriorCeiling.Curtain = System.Convert.ToBoolean(interiorCeilingObject.CustomData["Curtain"]);

            sapInteriorCeiling.ManualInputKappa = System.Convert.ToBoolean(interiorCeilingObject.CustomData["OverRideK"]);

            sapInteriorCeiling.Kappa = System.Convert.ToDouble(interiorCeilingObject.CustomData["K"]);

            sapInteriorCeiling.Dims = ToDims((interiorCeilingObject.CustomData["Dims"] as List<object>).Cast<CustomObject>().ToList()); ;


            sapInteriorCeiling.UValueSelectionID = System.Convert.ToInt32(interiorCeilingObject.CustomData["UValueSelectionId"]);

            sapInteriorCeiling.UValueSelected = System.Convert.ToBoolean(interiorCeilingObject.CustomData["UValueSelected"]);

            sapInteriorCeiling.EnergyPerformanceCertificateDescription = interiorCeilingObject.CustomData["EpcDescription"] as string;

            sapInteriorCeiling.LoftInsulation = interiorCeilingObject.CustomData["LoftInsulation"] as string;

            return sapInteriorCeiling;
        }
        public static Dictionary<string, object> FromInteriorCeiling(InteriorCeiling obj)
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

