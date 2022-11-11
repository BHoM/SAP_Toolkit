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
        public static BH.oM.Environment.SAP.Stroma10.PrimaryHeating ToPrimaryHeating(CustomObject primaryHeatingObject)
        {
            if (primaryHeatingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PrimaryHeating sapPrimaryHeating = new BH.oM.Environment.SAP.Stroma10.PrimaryHeating();

            sapPrimaryHeating.ID = System.Convert.ToInt32(primaryHeatingObject.CustomData["Id"]);

           
            sapPrimaryHeating.Include = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Include"]);


            sapPrimaryHeating.Group = (primaryHeatingObject.CustomData["Group"] as CustomObject); 

            
            sapPrimaryHeating.HeatingCategory = System.Convert.ToInt32(primaryHeatingObject.CustomData["HeatingCategory"]);


            sapPrimaryHeating.SubHeatingGroup = (primaryHeatingObject.CustomData["SGroup"] as CustomObject); 

            
            sapPrimaryHeating.SubHeatingCategory = System.Convert.ToInt32(primaryHeatingObject.CustomData["SubHeatingCategory"]); 

            
            sapPrimaryHeating.Source = System.Convert.ToInt32(primaryHeatingObject.CustomData["Source"]); 

            
            sapPrimaryHeating.SAPTableCode = System.Convert.ToInt32(primaryHeatingObject.CustomData["SapTableCode"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK = primaryHeatingObject.CustomData["Sedbuk"] as string; 

            
            sapPrimaryHeating.Efficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["Efficiency"]); 

            
            sapPrimaryHeating.TER = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Ter"]); 

            
            sapPrimaryHeating.WinterEfficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["WinterEfficiency"]); 

            
            sapPrimaryHeating.SummerEfficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["WinterEfficiency"]); 

            
            sapPrimaryHeating.Emitter = System.Convert.ToInt32(primaryHeatingObject.CustomData["Emitter"]); 

            
            sapPrimaryHeating.ControlCode = System.Convert.ToInt32(primaryHeatingObject.CustomData["ControlCode"]); 

            
            sapPrimaryHeating.ControlCodeProductCharacteristicsDatabase = primaryHeatingObject.CustomData["ControlCodePcdf"] as string; 

            
            sapPrimaryHeating.Fuel = System.Convert.ToInt32(primaryHeatingObject.CustomData["Fuel"]); 

            
            sapPrimaryHeating.HeatingEquipmentTestingAndApprovalsScheme = System.Convert.ToBoolean(primaryHeatingObject.CustomData["IsHetas"]);

          
            sapPrimaryHeating.Boiler = ToBoiler(primaryHeatingObject.CustomData["Boiler"] as CustomObject); 

            
            sapPrimaryHeating.ElectricityTariff = System.Convert.ToInt32(primaryHeatingObject.CustomData["ElectricityTariff"]);


            sapPrimaryHeating.Range = ToRange(primaryHeatingObject.CustomData["Range"] as CustomObject); 

            
            sapPrimaryHeating.OilPump = System.Convert.ToBoolean(primaryHeatingObject.CustomData["OilPump"]); 

            
            sapPrimaryHeating.DelayedStart = System.Convert.ToBoolean(primaryHeatingObject.CustomData["DelayedStart"]); 

            
            sapPrimaryHeating.FuelBurningType = System.Convert.ToInt32(primaryHeatingObject.CustomData["FuelBurningType"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK2005 = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Sedbuk2005"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK2009 = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Sedbuk2009"]);

            
            sapPrimaryHeating.WinterSummer = System.Convert.ToBoolean(primaryHeatingObject.CustomData["WinterSummer"]); 

            
            sapPrimaryHeating.MicroCertificationSchemeHeatPump = System.Convert.ToBoolean(primaryHeatingObject.CustomData["McsHeatPump"]);

            
            sapPrimaryHeating.CommunityHeating = ToCommunityHeating(primaryHeatingObject.CustomData["CommunityHeating"] as CustomObject); 


            sapPrimaryHeating.ComplianceHeatingDetails = ToComplianceHeatingDetails(primaryHeatingObject.CustomData["ComplianceHeatingDetails"] as CustomObject);


            sapPrimaryHeating.HeatPumpOnly = ToHeatPumpOnly(primaryHeatingObject.CustomData["HpOnly"] as CustomObject);


            sapPrimaryHeating.StorageHeaters = ToStorageHeaters((primaryHeatingObject.CustomData["StorageHeaters"] as List<object>).Cast<CustomObject>().ToList());


            return sapPrimaryHeating;
        }
    }
}
