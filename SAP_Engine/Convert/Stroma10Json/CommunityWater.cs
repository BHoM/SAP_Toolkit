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


            sapCommunityWater.SystemReference = (communityWaterObject.CustomData["SystemRef"] as CustomObject);


            sapCommunityWater.SubNetworkName = (communityWaterObject.CustomData["SubNetworkName"] as CustomObject);


            sapCommunityWater.HeatNetworkExisting = System.Convert.ToBoolean(communityWaterObject.CustomData["HeatNetworkExisting"]);


            sapCommunityWater.CHPElectricityGeneration = System.Convert.ToInt32(communityWaterObject.CustomData["ChpElectricityGeneration"]);


            sapCommunityWater.HeatSources = ToHeatSources((communityWaterObject.CustomData["HeatSources"] as List<object>).Cast<CustomObject>().ToList());


            sapCommunityWater.CommunityHeatingName = (communityWaterObject.CustomData["CommunityHeatingName"] as string);



            return sapCommunityWater;
        }
        public static Dictionary<string, object> FromCommunityWater(CommunityWater obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

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
            rtn.Add("HeatSources", obj.HeatSources.Select(x => FromHeatSource(x)).ToList());
            rtn.Add("CommunityHeatingName", obj.CommunityHeatingName);
      

            return rtn;
        }
    }
}
