using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

using BH.oM.Base;

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


            sapCommunityWater.SystemReference = (communityWaterObject.CustomData["SystemRef"] as CustomObject); 


            sapCommunityWater.SubNetworkName = (communityWaterObject.CustomData["SubNetworkName"] as CustomObject); 

            
            sapCommunityWater.HeatNetworkExisting = System.Convert.ToBoolean(communityWaterObject.CustomData["HeatNetworkExisting"]); 

            
            sapCommunityWater.CHPElectricityGeneration = System.Convert.ToInt32(communityWaterObject.CustomData["ChpElectricityGeneration"]);


            sapCommunityWater.HeatSources = ToHeatSources((communityWaterObject.CustomData["HeatSources"] as List<object>).Cast<CustomObject>().ToList());


            sapCommunityWater.CommunityHeatingName = (communityWaterObject.CustomData["CommunityHeatingName"] as string); 



            return sapCommunityWater;
        }
    }
}
