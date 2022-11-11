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
        public static BH.oM.Environment.SAP.Stroma10.SecondaryHeating ToSecondaryHeating(CustomObject secondaryHeatingObject)
        {
            if (secondaryHeatingObject == null)
                return null;
            
            BH.oM.Environment.SAP.Stroma10.SecondaryHeating sapSecondaryHeating = new BH.oM.Environment.SAP.Stroma10.SecondaryHeating();


            sapSecondaryHeating.ID = System.Convert.ToInt32(secondaryHeatingObject.CustomData["Id"]);

            
            sapSecondaryHeating.Include = System.Convert.ToBoolean(secondaryHeatingObject.CustomData["Include"]); 

        
            sapSecondaryHeating.IsManufacturer = System.Convert.ToBoolean(secondaryHeatingObject.CustomData["IsManufacturer"]); 

        
            sapSecondaryHeating.SubHeatingGroup = secondaryHeatingObject.CustomData["SGroup"] as string; 

        
            sapSecondaryHeating.SubHeatingCategory  = System.Convert.ToInt32(secondaryHeatingObject.CustomData["SubHeatingCategory"]);


            sapSecondaryHeating.ComplianceHeatingDetails = ToComplianceHeatingDetails(secondaryHeatingObject.CustomData["ComplianceHeatingDetails"] as CustomObject);

        
            sapSecondaryHeating.Fuel  = System.Convert.ToInt32(secondaryHeatingObject.CustomData["Fuel"]); 

        
            sapSecondaryHeating.HeatingEquipmentTestingAndApprovalsScheme = System.Convert.ToBoolean(secondaryHeatingObject.CustomData["IsHetas"]); 


            sapSecondaryHeating.Efficiency  = System.Convert.ToDouble(secondaryHeatingObject.CustomData["Efficiency"]);

        
            sapSecondaryHeating.SAPTableCode  = System.Convert.ToInt32(secondaryHeatingObject.CustomData["SapTableCode"]); 

        
            sapSecondaryHeating.ManufacturerDescription = secondaryHeatingObject.CustomData["MDescription"] as string; 

        
            sapSecondaryHeating.TestMethod = secondaryHeatingObject.CustomData["TestMethod"] as string; 

        
            sapSecondaryHeating.FlueType = System.Convert.ToInt32(secondaryHeatingObject.CustomData["FlueType"]); 
            

            return sapSecondaryHeating;
        }
    }
}
