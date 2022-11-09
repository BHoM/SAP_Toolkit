using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    static partial class Convert
    {
        static BH.oM.Environment.SAP.Stroma10.CommunityHeating ToCommunityHeating(CustomObject communityHeatingObject)
        {
            BH.oM.Environment.SAP.Stroma10.CommunityHeating sapCommunityHeating = new BH.oM.Environment.SAP.Stroma10.CommunityHeating();

            sapCommunityHeating.ID = System.Convert.ToInt32(communityHeatingObject.CustomData["ID"]);

            
            sapCommunityHeating.Boiler1Efficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["Boiler1Efficiency"]); 

            
            sapCommunityHeating.Boiler1HeatFraction = System.Convert.ToDouble(communityHeatingObject.CustomData["Boiler1HeatFraction"]); 

            
            sapCommunityHeating.HeatDistributionSystem = System.Convert.ToInt32(communityHeatingObject.CustomData["HeatDistributionSystem"]); 

            
            sapCommunityHeating.HeatToPowerRatio = System.Convert.ToDouble(communityHeatingObject.CustomData["HeatToPowerRatio"]); 

            
            sapCommunityHeating.HeatSources = (List<object>)communityHeatingObject.CustomData["HeatSources"];
            
            sapCommunityHeating.NumberOfAdditionalHeatSources = System.Convert.ToInt32(communityHeatingObject.CustomData["NumberOfAdditionalHeatSources"]); 

            
            sapCommunityHeating.Boiler2CHP = System.Convert.ToBoolean(communityHeatingObject.CustomData["Boiler2CHP"]); 

            
            sapCommunityHeating.Boiler2CHPEfficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["Boiler2CHPEfficiency"]); 

            
            sapCommunityHeating.CHPHeatFraction = System.Convert.ToDouble(communityHeatingObject.CustomData["CHPHeatFraction"]); 

            
            sapCommunityHeating.CHPHeatEfficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["CHPHeatEfficiency"]); 

            
            sapCommunityHeating.CHPElectricalEfficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["CHPElectricalEfficiency"]); 

            
            sapCommunityHeating.FromDatabase = System.Convert.ToBoolean(communityHeatingObject.CustomData["FromDatabase"]); 

            
            sapCommunityHeating.Boiler2CHPFuel = System.Convert.ToInt32(communityHeatingObject.CustomData["Boiler2CHPFuel"]); 

            
            sapCommunityHeating.KnownLoss = System.Convert.ToBoolean(communityHeatingObject.CustomData["KnownLoss"]); 
            
            sapCommunityHeating.KnownLossValue = System.Convert.ToDouble(communityHeatingObject.CustomData["KnownLossValue"]); 

            
            sapCommunityHeating.HeatNetworkExisting = System.Convert.ToBoolean(communityHeatingObject.CustomData["HeatNetworkExisting"]); 

            
            sapCommunityHeating.CHPElectricityGeneration = System.Convert.ToInt32(communityHeatingObject.CustomData["CHPElectricityGeneration"]); 

            
            sapCommunityHeating.CommunityHeatingName = communityHeatingObject.CustomData["CommunityHeatingName"] as string; 


            sapCommunityHeating.SubNetworkName = (communityHeatingObject.CustomData["SubNetworkName"] as CustomObject);


            return sapCommunityHeating;
        }
    }
}
