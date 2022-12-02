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
using System.ComponentModel;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.CommunityWater ToCommunityWater(CustomObject communityWaterObject)
        {
            if (communityWaterObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.CommunityWater sapCommunityWater = new BH.oM.Environment.SAP.Stroma10.CommunityWater();

            sapCommunityWater.ID = System.Convert.ToInt32(communityWaterObject.CustomData["Id"]);


            sapCommunityWater.CylinderInDwelling = System.Convert.ToBoolean(communityWaterObject.CustomData["CylinderInDwelling"]);


            sapCommunityWater.CHPRatio = System.Convert.ToDouble(communityWaterObject.CustomData["ChpRatio"]);


            sapCommunityWater.KnownLossFactor = System.Convert.ToBoolean(communityWaterObject.CustomData["KnownLossFactor"]);


            sapCommunityWater.LossFactor = System.Convert.ToDouble(communityWaterObject.CustomData["LossFactor"]);


            sapCommunityWater.CHPPowerEfficiency = System.Convert.ToDouble(communityWaterObject.CustomData["ChpPowerEff"]);


            sapCommunityWater.HeatDistributionSystem = System.Convert.ToInt32(communityWaterObject.CustomData["HeatDistributionSystem"]);


            sapCommunityWater.HeatSourceType = System.Convert.ToInt32(communityWaterObject.CustomData["HeatSourceType"]);


            sapCommunityWater.Efficiency = System.Convert.ToDouble(communityWaterObject.CustomData["Efficiency"]);


            sapCommunityWater.Boiler1Fraction = System.Convert.ToDouble(communityWaterObject.CustomData["Boiler1Fraction"]);


            sapCommunityWater.ChargingSystem = System.Convert.ToInt32(communityWaterObject.CustomData["ChargingSystem"]);


            sapCommunityWater.ChargingLinkedToHeatUse = System.Convert.ToBoolean(communityWaterObject.CustomData["ChargingLinkedToHeatUse"]);


            sapCommunityWater.NumberOfAdditionalHeatSources = System.Convert.ToInt32(communityWaterObject.CustomData["NoOfAdditionalHeatSources"]);


            sapCommunityWater.FromDatabase = System.Convert.ToBoolean(communityWaterObject.CustomData["FromDatabase"]);


            sapCommunityWater.SystemReference = (communityWaterObject.CustomData["SystemRef"] as string);


            sapCommunityWater.SubNetworkName = (communityWaterObject.CustomData["SubNetworkName"] as string);


            sapCommunityWater.HeatNetworkExisting = System.Convert.ToBoolean(communityWaterObject.CustomData["HeatNetworkExisting"]);


            sapCommunityWater.CHPElectricityGeneration = System.Convert.ToInt32(communityWaterObject.CustomData["ChpElectricityGeneration"]);


            sapCommunityWater.HeatSources = ToHeatSources((communityWaterObject.CustomData["HeatSources"] as List<object>).Cast<CustomObject>().ToList());


            sapCommunityWater.CommunityHeatingName = (communityWaterObject.CustomData["CommunityHeatingName"] as string);


            return sapCommunityWater;
        }
        public static Dictionary<string, object> FromCommunityWater(CommunityWater obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("CylinderInDwelling", obj.CylinderInDwelling);

            rtn.Add("ChpRatio", obj.CHPRatio);

            rtn.Add("KnownLossFactor", obj.KnownLossFactor);

            rtn.Add("LossFactor", obj.LossFactor);

            rtn.Add("ChpPowerEff", obj.CHPPowerEfficiency);

            rtn.Add("HeatDistributionSystem", obj.HeatDistributionSystem);

            rtn.Add("HeatSourceType", obj.HeatSourceType);

            rtn.Add("Efficiency", obj.Efficiency);

            rtn.Add("Boiler1Fraction", obj.Boiler1Fraction);

            rtn.Add("ChargingSystem", obj.ChargingSystem);

            rtn.Add("ChargingLinkedToHeatUse", obj.ChargingLinkedToHeatUse);

            rtn.Add("NoOfAdditionalHeatSources", obj.NumberOfAdditionalHeatSources);

            rtn.Add("FromDatabase", obj.FromDatabase);

            rtn.Add("SystemRef", obj.SystemReference);

            rtn.Add("SubNetworkName", obj.SubNetworkName);

            rtn.Add("HeatNetworkExisting", obj.HeatNetworkExisting);

            rtn.Add("ChpElectricityGeneration", obj.CHPElectricityGeneration);

            if (obj.HeatSources != null && obj.HeatSources.Any(x => x != null))
                rtn.Add("HeatSources", obj.HeatSources.Select(x => FromHeatSource(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("HeatSources", temp);
            }

            rtn.Add("CommunityHeatingName", obj.CommunityHeatingName);

            return rtn;
        }
    }
}
