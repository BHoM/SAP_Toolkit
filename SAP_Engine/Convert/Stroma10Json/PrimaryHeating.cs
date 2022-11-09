using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.PrimaryHeating ToPrimaryHeating(CustomObject primaryHeatingObject)
        {
            BH.oM.Environment.SAP.Stroma10.PrimaryHeating sapPrimaryHeating = new BH.oM.Environment.SAP.Stroma10.PrimaryHeating();

            sapPrimaryHeating.ID = System.Convert.ToInt32(primaryHeatingObject.CustomData["ID"]);

           
            sapPrimaryHeating.Include = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Include"]);


            sapPrimaryHeating.Group = (primaryHeatingObject.CustomData["Group"] as CustomObject); 

            
            sapPrimaryHeating.HeatingCategory = System.Convert.ToInt32(primaryHeatingObject.CustomData["HeatingCategory"]);


            sapPrimaryHeating.SubHeatingGroup = (primaryHeatingObject.CustomData["SubHeatingGroup"] as CustomObject); 

            
            sapPrimaryHeating.SubHeatingCategory = System.Convert.ToInt32(primaryHeatingObject.CustomData["SubHeatingCategory"]); 

            
            sapPrimaryHeating.Source = System.Convert.ToInt32(primaryHeatingObject.CustomData["Source"]); 

            
            sapPrimaryHeating.SAPTableCode = System.Convert.ToInt32(primaryHeatingObject.CustomData["SAPTableCode"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK = primaryHeatingObject.CustomData["SeasonalEfficiencyOfDomesticBoilersUK"] as string; 

            
            sapPrimaryHeating.Efficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["Efficiency"]); 

            
            sapPrimaryHeating.TER = System.Convert.ToBoolean(primaryHeatingObject.CustomData["TER"]); 

            
            sapPrimaryHeating.WinterEfficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["WinterEfficiency"]); 

            
            sapPrimaryHeating.SummerEfficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["SummerEfficiency"]); 

            
            sapPrimaryHeating.Emitter = System.Convert.ToInt32(primaryHeatingObject.CustomData["Emitter"]); 

            
            sapPrimaryHeating.ControlCode = System.Convert.ToInt32(primaryHeatingObject.CustomData["ControlCode"]); 

            
            sapPrimaryHeating.ControlCodeProductCharacteristicsDatabase = primaryHeatingObject.CustomData["ControlCodeProductCharacteristicsDatabase"] as string; 

            
            sapPrimaryHeating.Fuel = System.Convert.ToInt32(primaryHeatingObject.CustomData["Fuel"]); 

            
            sapPrimaryHeating.HeatingEquipmentTestingAndApprovalsScheme = System.Convert.ToBoolean(primaryHeatingObject.CustomData["HeatingEquipmentTestingAndApprovalsScheme"]);

          
            sapPrimaryHeating.Boiler = ToBoiler(primaryHeatingObject.CustomData["Boiler"] as CustomObject); 

            
            sapPrimaryHeating.ElectricityTariff = System.Convert.ToInt32(primaryHeatingObject.CustomData["ElectricityTariff"]);


            sapPrimaryHeating.Range = ToRange(primaryHeatingObject.CustomData["Range"] as CustomObject); 

            
            sapPrimaryHeating.OilPump = System.Convert.ToBoolean(primaryHeatingObject.CustomData["OilPump"]); 

            
            sapPrimaryHeating.DelayedStart = System.Convert.ToBoolean(primaryHeatingObject.CustomData["DelayedStart"]); 

            
            sapPrimaryHeating.FuelBurningType = System.Convert.ToInt32(primaryHeatingObject.CustomData["FuelBurningType"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK2005 = System.Convert.ToBoolean(primaryHeatingObject.CustomData["SeasonalEfficiencyOfDomesticBoilersUK2005"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK2009 = System.Convert.ToBoolean(primaryHeatingObject.CustomData["SeasonalEfficiencyOfDomesticBoilersUK2009"]);

            
            sapPrimaryHeating.WinterSummer = System.Convert.ToBoolean(primaryHeatingObject.CustomData["WinterSummer"]); 

            
            sapPrimaryHeating.MicroCertificationSchemeHeatPump = System.Convert.ToBoolean(primaryHeatingObject.CustomData["MicroCertificationSchemeHeatPump"]);

            
            sapPrimaryHeating.CommunityHeating = ToCommunityHeating(primaryHeatingObject.CustomData["CommunityHeating"] as CustomObject); 


            sapPrimaryHeating.ComplianceHeatingDetails = ToComplianceHeatingDetails(primaryHeatingObject.CustomData["ComplianceHeatingDetails"] as CustomObject);


            sapPrimaryHeating.HeatPumpOnly = ToHeatPumpOnly(primaryHeatingObject.CustomData["HeatPumpOnly"] as CustomObject);

            
            sapPrimaryHeating.StorageHeaters = (List<object>)primaryHeatingObject.CustomData["StorageHeaters"];


            return sapPrimaryHeating;
        }
    }
}
