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
        public static BH.oM.Environment.SAP.Stroma10.HydroGeneration ToHydroGeneration(CustomObject hydroGenerationObject)
        {
            if (hydroGenerationObject == null)
                return null;
            
            BH.oM.Environment.SAP.Stroma10.HydroGeneration sapHydroGeneration = new BH.oM.Environment.SAP.Stroma10.HydroGeneration();

            sapHydroGeneration.ID = System.Convert.ToInt32(hydroGenerationObject.CustomData["Id"]);

            sapHydroGeneration.Yearly = System.Convert.ToBoolean(hydroGenerationObject.CustomData["Yearly"]);

            sapHydroGeneration.Include = System.Convert.ToBoolean(hydroGenerationObject.CustomData["Include"]);

            sapHydroGeneration.HydroGenerated = System.Convert.ToDouble(hydroGenerationObject.CustomData["HydroGenerated"]);
            
            sapHydroGeneration.ConnectedToMeter = System.Convert.ToBoolean(hydroGenerationObject.CustomData["ConnectedToMeter"]);
            
            sapHydroGeneration.TotalArea = System.Convert.ToDouble(hydroGenerationObject.CustomData["TotalArea"]);

            sapHydroGeneration.MonthlyValues = ToMonthlyValues(hydroGenerationObject.CustomData["MonthlyValues"] as CustomObject);

            sapHydroGeneration.Certificate = (hydroGenerationObject.CustomData["Certificate"] as string);

            return sapHydroGeneration;
        }
        public static Dictionary<string, object> FromHydroGeneration(HydroGeneration obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Yearly", obj.Yearly);

            rtn.Add("Include", obj.Include);

            rtn.Add("HydroGenerated", obj.HydroGenerated);

            rtn.Add("ConnectedToMeter", obj.ConnectedToMeter);

            rtn.Add("TotalArea", obj.TotalArea);

            if (obj.MonthlyValues == null)
                obj.MonthlyValues = new BH.oM.Environment.SAP.Stroma10.MonthlyValues();

            rtn.Add("MonthlyValues", FromMonthlyValues(obj.MonthlyValues));

            rtn.Add("Certificate", obj.Certificate);

            return rtn;
        }
    }
}
