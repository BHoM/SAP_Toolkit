using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.CommunityWater ToCommunityWater(CustomObject communityWaterObject)
        {
            BH.oM.Environment.SAP.Stroma10.CommunityWater sapCommunityWater = new BH.oM.Environment.SAP.Stroma10.CommunityWater();

            sapCommunityWater.ID = System.Convert.ToInt32(communityWaterObject.CustomData["ID"]);


            sapCommunityWater.CylinderInDwelling = System.Convert.ToBoolean(communityWaterObject.CustomData["CylinderInDwelling"]); 

            
            sapCommunityWater.CHPRatio = System.Convert.ToDouble(communityWaterObject.CustomData["CHPRatio"]); 

            
            sapCommunityWater.KnownLossFactor = System.Convert.ToBoolean(communityWaterObject.CustomData["KnownLossFactor"]); 

            
            sapCommunityWater.LossFactor = System.Convert.ToDouble(communityWaterObject.CustomData["LossFactor"]); 

            
            sapCommunityWater.CHPPowerEfficiency = System.Convert.ToDouble(communityWaterObject.CustomData["CHPPowerEfficiency"]); 

            
            sapCommunityWater.HeatDistributionSystem = System.Convert.ToInt32(communityWaterObject.CustomData["HeatDistributionSystem"]); 

            
            sapCommunityWater.HeatSourceType = System.Convert.ToInt32(communityWaterObject.CustomData["HeatSourceType"]); 

            
            sapCommunityWater.Efficiency = System.Convert.ToDouble(communityWaterObject.CustomData["Efficiency"]); 

            
            sapCommunityWater.Boiler1Fraction = System.Convert.ToDouble(communityWaterObject.CustomData["Boiler1Fraction"]); 

            
            sapCommunityWater.ChargingSystem = System.Convert.ToInt32(communityWaterObject.CustomData["ChargingSystem"]); 

            
            sapCommunityWater.ChargingLinkedToHeatUse = System.Convert.ToBoolean(communityWaterObject.CustomData["ChargingLinkedToHeatUse"]); 

            
            sapCommunityWater.NumberOfAdditionalHeatSources = System.Convert.ToInt32(communityWaterObject.CustomData["NumberOfAdditionalHeatSources"]); 

            
            sapCommunityWater.FromDatabase = System.Convert.ToBoolean(communityWaterObject.CustomData["FromDatabase"]);


            sapCommunityWater.SystemReference = (communityWaterObject.CustomData["SystemReference"] as CustomObject); 


            sapCommunityWater.SubNetworkName = (communityWaterObject.CustomData["SubNetworkName"] as CustomObject); 

            
            sapCommunityWater.HeatNetworkExisting = System.Convert.ToBoolean(communityWaterObject.CustomData["HeatNetworkExisting"]); 

            
            sapCommunityWater.CHPElectricityGeneration = System.Convert.ToInt32(communityWaterObject.CustomData["CHPElectricityGeneration"]);


            sapCommunityWater.HeatSources = (List<object>)communityWaterObject.CustomData["HeatSources"]; 


            sapCommunityWater.CommunityHeatingName = (communityWaterObject.CustomData["CommunityHeatingName"] as CustomObject); 



            return sapCommunityWater;
        }
    }
}
