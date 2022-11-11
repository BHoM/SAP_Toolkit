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
        public static BH.oM.Environment.SAP.Stroma10.WaterHeating ToWaterHeating(CustomObject waterHeatingObject)
        {
            if (waterHeatingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.WaterHeating sapWaterHeating = new BH.oM.Environment.SAP.Stroma10.WaterHeating();

            sapWaterHeating.ID = System.Convert.ToInt32(waterHeatingObject.CustomData["Id"]);


            sapWaterHeating.SolarWater = ToSolarWater(waterHeatingObject.CustomData["SolarWater"] as CustomObject);

       
            sapWaterHeating.System = System.Convert.ToInt32(waterHeatingObject.CustomData["System"]); 

        
            sapWaterHeating.Fuel = System.Convert.ToInt32(waterHeatingObject.CustomData["Fuel"]); 


            sapWaterHeating.Cylinder = ToCylinder(waterHeatingObject.CustomData["Cylinder"] as CustomObject);


            sapWaterHeating.CombinedPrimaryStorageUnitTemperature = System.Convert.ToDouble(waterHeatingObject.CustomData["CpsuTemp"]); 


            sapWaterHeating.CommunityWater = ToCommunityWater(waterHeatingObject.CustomData["CommunityWater"] as CustomObject);
            

            sapWaterHeating.Thermal2 = ToThermal2(waterHeatingObject.CustomData["Thermal"] as CustomObject);
      

            sapWaterHeating.CombiType = System.Convert.ToInt32(waterHeatingObject.CustomData["CombiType"]); 


            sapWaterHeating.WasteWaterHeatRecovery = ToWasteWaterHeatRecovery(waterHeatingObject.CustomData["Wwhrs"] as CustomObject);


            sapWaterHeating.FlueGasHeatRecovery = ToFlueGasHeatRecovery(waterHeatingObject.CustomData["FlueGasHeatRecovery"] as CustomObject);
        

            sapWaterHeating.DomesticHotWaterVessel = System.Convert.ToBoolean(waterHeatingObject.CustomData["DhwVessel"]); 


            sapWaterHeating.ShowerUnits =  ToShowerUnits(waterHeatingObject.CustomData["ShowerUnits"] as CustomObject);

      
            sapWaterHeating.WaterSource = System.Convert.ToInt32(waterHeatingObject.CustomData["WaterSource"]); 

        
            sapWaterHeating.NumberOfBaths = System.Convert.ToInt32(waterHeatingObject.CustomData["NoBaths"]); 

        
            sapWaterHeating.ControllerManufacturer = waterHeatingObject.CustomData["ControllerManufacturer"] as string; 

        
            sapWaterHeating.Model = waterHeatingObject.CustomData["Model"] as string; 


            return sapWaterHeating;
        }
    }
}
