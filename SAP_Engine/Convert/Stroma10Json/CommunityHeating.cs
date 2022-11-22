using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    static partial class Convert
    {
        static BH.oM.Environment.SAP.Stroma10.CommunityHeating ToCommunityHeating(CustomObject communityHeatingObject)
        {
            if (communityHeatingObject == null)
                return null;


            BH.oM.Environment.SAP.Stroma10.CommunityHeating sapCommunityHeating = new BH.oM.Environment.SAP.Stroma10.CommunityHeating();

            sapCommunityHeating.ID = System.Convert.ToInt32(communityHeatingObject.CustomData["Id"]);

            
            sapCommunityHeating.Boiler1Efficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["Boiler1Efficiency"]); 

            
            sapCommunityHeating.Boiler1HeatFraction = System.Convert.ToDouble(communityHeatingObject.CustomData["Boiler1HeatFraction"]); 

            
            sapCommunityHeating.HeatDistributionSystem = System.Convert.ToInt32(communityHeatingObject.CustomData["HeatDistributionSystem"]); 

            
            sapCommunityHeating.HeatToPowerRatio = System.Convert.ToDouble(communityHeatingObject.CustomData["HeatToPowerRatio"]);


            sapCommunityHeating.HeatSources = ToHeatSources((communityHeatingObject.CustomData["HeatSources"] as List<object>).Cast<CustomObject>().ToList());


            sapCommunityHeating.NumberOfAdditionalHeatSources = System.Convert.ToInt32(communityHeatingObject.CustomData["NoOfAdditionalHeatSources"]); 

            
            sapCommunityHeating.Boiler2CHP = System.Convert.ToBoolean(communityHeatingObject.CustomData["Boiler2Chp"]); 

            
            sapCommunityHeating.Boiler2CHPEfficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["Boiler2ChpEfficiency"]); 

            
            sapCommunityHeating.CHPHeatFraction = System.Convert.ToDouble(communityHeatingObject.CustomData["ChpHeatFraction"]); 

            
            sapCommunityHeating.CHPHeatEfficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["ChpHeatEfficiency"]); 

            
            sapCommunityHeating.CHPElectricalEfficiency = System.Convert.ToDouble(communityHeatingObject.CustomData["ChpElectricalEfficiency"]); 

            
            sapCommunityHeating.FromDatabase = System.Convert.ToBoolean(communityHeatingObject.CustomData["FromDatabase"]); 

            
            sapCommunityHeating.Boiler2CHPFuel = System.Convert.ToInt32(communityHeatingObject.CustomData["Boiler2ChpFuel"]); 

            
            sapCommunityHeating.KnownLoss = System.Convert.ToBoolean(communityHeatingObject.CustomData["KnownLoss"]); 
            

            sapCommunityHeating.KnownLossValue = System.Convert.ToDouble(communityHeatingObject.CustomData["KnownLossValue"]); 

            
            sapCommunityHeating.HeatNetworkExisting = System.Convert.ToBoolean(communityHeatingObject.CustomData["HeatNetworkExisting"]); 

            
            sapCommunityHeating.CHPElectricityGeneration = System.Convert.ToInt32(communityHeatingObject.CustomData["ChpElectricityGeneration"]); 

            
            sapCommunityHeating.CommunityHeatingName = communityHeatingObject.CustomData["CommunityHeatingName"] as string; 


            sapCommunityHeating.SubNetworkName = (communityHeatingObject.CustomData["SubNetworkName"] as string);


            return sapCommunityHeating;
        }
        public static Dictionary<string, object> FromCommunityHeating(CommunityHeating obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Boiler1Efficiency", obj.Boiler1Efficiency);

            rtn.Add("Boiler1HeatFraction", obj.Boiler1HeatFraction);

            rtn.Add("HeatDistributionSystem", obj.HeatDistributionSystem); 
            
            rtn.Add("HeatToPowerRatio", obj.HeatToPowerRatio);

            if (obj.HeatSources != null && obj.HeatSources.Any(x => x != null))
                rtn.Add("HeatSources", obj.HeatSources.Select(x => FromHeatSource(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("HeatSources", temp);
            }

            rtn.Add("NoOfAdditionalHeatSources", obj.NumberOfAdditionalHeatSources);

            rtn.Add("Boiler2Chp", obj.Boiler2CHP);

            rtn.Add("Boiler2ChpEfficiency", obj.Boiler2CHPEfficiency);

            rtn.Add("ChpHeatFraction", obj.CHPHeatEfficiency);

            rtn.Add("ChpHeatEfficiency", obj.CHPHeatEfficiency);

            rtn.Add("ChpElectricalEfficiency", obj.CHPElectricalEfficiency);

            rtn.Add("FromDatabase", obj.FromDatabase);

            rtn.Add("Boiler2ChpFuel", obj.Boiler2CHPFuel);

            rtn.Add("KnownLoss", obj.KnownLoss);

            rtn.Add("KnownLossValue", obj.KnownLossValue);

            rtn.Add("HeatNetworkExisting", obj.HeatNetworkExisting);

            rtn.Add("ChpElectricityGeneration", obj.CHPElectricityGeneration);

            rtn.Add("CommunityHeatingName", obj.CommunityHeatingName);

            rtn.Add("SubNetworkName", obj.SubNetworkName);

            return rtn;
        }

    }
}
