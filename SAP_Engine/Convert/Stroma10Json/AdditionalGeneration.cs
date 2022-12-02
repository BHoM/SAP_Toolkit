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
        public static BH.oM.Environment.SAP.Stroma10.AdditionalGeneration ToAdditionalGeneration(CustomObject additionalGenerationObject)
        {
            if (additionalGenerationObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.AdditionalGeneration sapAdditionalGeneration = new BH.oM.Environment.SAP.Stroma10.AdditionalGeneration();

            sapAdditionalGeneration.ID = System.Convert.ToInt32(additionalGenerationObject.CustomData["Id"]);

            sapAdditionalGeneration.Include = System.Convert.ToBoolean(additionalGenerationObject.CustomData["Include"]);

            sapAdditionalGeneration.EnergyGenerated = System.Convert.ToDouble(additionalGenerationObject.CustomData["EGenerated"]);

            sapAdditionalGeneration.TotalArea = System.Convert.ToDouble(additionalGenerationObject.CustomData["TotalArea"]);

            return sapAdditionalGeneration;
        }

        public static Dictionary<string, object> FromAdditionalGeneration(AdditionalGeneration obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("EGenerated", obj.EnergyGenerated);

            rtn.Add("TotalArea", obj.TotalArea);

            return rtn;
        }
    }
}
