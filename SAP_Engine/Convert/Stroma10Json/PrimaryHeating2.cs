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
        public static BH.oM.Environment.SAP.Stroma10.PrimaryHeating2 ToPrimaryHeating2(CustomObject primaryHeating2Object)
        {
            BH.oM.Environment.SAP.Stroma10.PrimaryHeating2 sapPrimaryHeating2 = new BH.oM.Environment.SAP.Stroma10.PrimaryHeating2();

            sapPrimaryHeating2.ID = System.Convert.ToInt32(primaryHeating2Object.CustomData["ID"]);

            
            sapPrimaryHeating2.Include = System.Convert.ToBoolean(primaryHeating2Object.CustomData["Include"]);


            sapPrimaryHeating2.Group = (primaryHeating2Object.CustomData["Group"] as CustomObject); 

            
            sapPrimaryHeating2.HeatingCategory = System.Convert.ToInt32(primaryHeating2Object.CustomData["HeatingCategory"]);


            sapPrimaryHeating2.SubHeatingGroup = (primaryHeating2Object.CustomData["SubHeatingGroup"] as CustomObject); 

            
            sapPrimaryHeating2.SubHeatingCategory = System.Convert.ToInt32(primaryHeating2Object.CustomData["SubHeatingCategory"]); 

            
            sapPrimaryHeating2.Source = System.Convert.ToInt32(primaryHeating2Object.CustomData["Source"]); 

            
            sapPrimaryHeating2.SAPTableCode = System.Convert.ToInt32(primaryHeating2Object.CustomData["SAPTableCode"]); 

            
            sapPrimaryHeating2.SeasonalEfficiencyOfDomesticBoilersUK = primaryHeating2Object.CustomData["SeasonalEfficiencyOfDomesticBoilersUK"] as string; 

            
            sapPrimaryHeating2.Efficiency = System.Convert.ToDouble(primaryHeating2Object.CustomData["Efficiency"]); 

            
            sapPrimaryHeating2.TER = System.Convert.ToBoolean(primaryHeating2Object.CustomData["TER"]); 

            
            sapPrimaryHeating2.WinterEfficiency = System.Convert.ToDouble(primaryHeating2Object.CustomData["WinterEfficiency"]); 

            
            sapPrimaryHeating2.SummerEfficiency = System.Convert.ToDouble(primaryHeating2Object.CustomData["SummerEfficiency"]); 

            
            sapPrimaryHeating2.Emitter = System.Convert.ToInt32(primaryHeating2Object.CustomData["Emitter"]); 

            
            sapPrimaryHeating2.ControlCode = System.Convert.ToInt32(primaryHeating2Object.CustomData["ControlCode"]); 

            
            sapPrimaryHeating2.ControlCodeProductCharacteristicsDatabase = primaryHeating2Object.CustomData["ControlCodeProductCharacteristicsDatabase"] as string; 

            
            sapPrimaryHeating2.Fuel = System.Convert.ToInt32(primaryHeating2Object.CustomData["Fuel"]); 

            
            sapPrimaryHeating2.HeatingEquipmentTestingAndApprovalsScheme = System.Convert.ToBoolean(primaryHeating2Object.CustomData["HeatingEquipmentTestingAndApprovalsScheme"]);

          
            sapPrimaryHeating2.Boiler = ToBoiler(primaryHeating2Object.CustomData["Boiler"] as CustomObject); 

            
            sapPrimaryHeating2.ElectricityTariff = System.Convert.ToInt32(primaryHeating2Object.CustomData["ElectricityTariff"]);


            sapPrimaryHeating2.Range = ToRange(primaryHeating2Object.CustomData["Range"] as CustomObject); 

            
            sapPrimaryHeating2.OilPump = System.Convert.ToBoolean(primaryHeating2Object.CustomData["OilPump"]); 

            
            sapPrimaryHeating2.DelayedStart = System.Convert.ToBoolean(primaryHeating2Object.CustomData["DelayedStart"]); 

            
            sapPrimaryHeating2.FuelBurningType = System.Convert.ToInt32(primaryHeating2Object.CustomData["FuelBurningType"]); 

            
            sapPrimaryHeating2.SeasonalEfficiencyOfDomesticBoilersUK2005 = System.Convert.ToBoolean(primaryHeating2Object.CustomData["SeasonalEfficiencyOfDomesticBoilersUK2005"]); 

            
            sapPrimaryHeating2.SeasonalEfficiencyOfDomesticBoilersUK2009 = System.Convert.ToBoolean(primaryHeating2Object.CustomData["SeasonalEfficiencyOfDomesticBoilersUK2009"]);

            
            sapPrimaryHeating2.WinterSummer = System.Convert.ToBoolean(primaryHeating2Object.CustomData["WinterSummer"]); 

            
            sapPrimaryHeating2.MicroCertificationSchemeHeatPump = System.Convert.ToBoolean(primaryHeating2Object.CustomData["MicroCertificationSchemeHeatPump"]);

            
            sapPrimaryHeating2.CommunityHeating = ToCommunityHeating(primaryHeating2Object.CustomData["CommunityHeating"] as CustomObject); 


            sapPrimaryHeating2.ComplianceHeatingDetails = ToComplianceHeatingDetails(primaryHeating2Object.CustomData["ComplianceHeatingDetails"] as CustomObject);


            sapPrimaryHeating2.HeatPumpOnly = ToHeatPumpOnly(primaryHeating2Object.CustomData["HeatPumpOnly"] as CustomObject);

            
            sapPrimaryHeating2.StorageHeaters = (List<object>)primaryHeating2Object.CustomData["StorageHeaters"];


            return sapPrimaryHeating2;
        }
    }
}
