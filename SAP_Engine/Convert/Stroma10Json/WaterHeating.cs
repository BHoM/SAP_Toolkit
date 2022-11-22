using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP;
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


            sapWaterHeating.ShowerUnits =  ToShowerUnits((waterHeatingObject.CustomData["ShowerUnits"] as List<object>).Cast<CustomObject>().ToList());

      
            sapWaterHeating.WaterSource = System.Convert.ToInt32(waterHeatingObject.CustomData["WaterSource"]); 

        
            sapWaterHeating.NumberOfBaths = System.Convert.ToInt32(waterHeatingObject.CustomData["NoBaths"]); 

        
            sapWaterHeating.ControllerManufacturer = waterHeatingObject.CustomData["ControllerManufacturer"] as string; 

        
            sapWaterHeating.Model = waterHeatingObject.CustomData["Model"] as string; 


            return sapWaterHeating;
        }
        public static Dictionary<string, object> FromWaterHeating(BH.oM.Environment.SAP.Stroma10.WaterHeating obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            if (obj.SolarWater == null)
                obj.SolarWater = new BH.oM.Environment.SAP.Stroma10.SolarWater();

            rtn.Add("SolarWater", FromSolarWater(obj.SolarWater));

            rtn.Add("System", obj.System);

            rtn.Add("Fuel", obj.Fuel);

            if (obj.Cylinder == null)
                obj.Cylinder = new BH.oM.Environment.SAP.Stroma10.Cylinder();

            rtn.Add("Cylinder", FromCylinder(obj.Cylinder));


            rtn.Add("CpsuTemp", obj.CombinedPrimaryStorageUnitTemperature);

            if (obj.CommunityWater == null)
                obj.CommunityWater = new BH.oM.Environment.SAP.Stroma10.CommunityWater();

            rtn.Add("CommunityWater", FromCommunityWater(obj.CommunityWater));

            if (obj.Thermal2 == null)
                obj.Thermal2 = new BH.oM.Environment.SAP.Stroma10.Thermal2();

            rtn.Add("Thermal", FromThermal2(obj.Thermal2));

            rtn.Add("CombiType", obj.CombiType);

            if (obj.WasteWaterHeatRecovery == null)
                obj.WasteWaterHeatRecovery = new BH.oM.Environment.SAP.Stroma10.WasteWaterHeatRecovery();

            rtn.Add("Wwhrs", FromWasteWaterHeatRecovery(obj.WasteWaterHeatRecovery));

            if (obj.FlueGasHeatRecovery == null)
                obj.FlueGasHeatRecovery = new BH.oM.Environment.SAP.Stroma10.FlueGasHeatRecovery();

            rtn.Add("FlueGasHeatRecovery", FromFlueGasHeatRecovery(obj.FlueGasHeatRecovery));

            rtn.Add("DhwVessel", obj.DomesticHotWaterVessel);


            if (obj.ShowerUnits != null && obj.ShowerUnits.Any(x => x != null))
                rtn.Add("ShowerUnits", obj.ShowerUnits.Select(x => FromShowerUnit(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("ShowerUnits", temp);
            }


            rtn.Add("WaterSource", obj.WaterSource);

            rtn.Add("NoBaths", obj.NumberOfBaths);

            rtn.Add("ControllerManufacturer", obj.ControllerManufacturer);

            rtn.Add("Model", obj.Model);

            return rtn;
        }
    }
}