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
        public static BH.oM.Environment.SAP.Stroma10.SolarWater ToSolarWater(CustomObject solarWaterObject)
        {
            if (solarWaterObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.SolarWater sapSolarWater = new BH.oM.Environment.SAP.Stroma10.SolarWater();

            sapSolarWater.ID = System.Convert.ToInt32(solarWaterObject.CustomData["Id"]);


            sapSolarWater.Include = System.Convert.ToBoolean(solarWaterObject.CustomData["Include"]); 

            
            sapSolarWater.SolarWaterCollectorType = System.Convert.ToInt32(solarWaterObject.CustomData["SolarWaterCollectorType"]); 

            
            sapSolarWater.OverRide = System.Convert.ToBoolean(solarWaterObject.CustomData["OverRide"]); 

            
            sapSolarWater.SolarZero = System.Convert.ToDouble(solarWaterObject.CustomData["SolarZero"]); 

            
            sapSolarWater.SolarHeatLoss = System.Convert.ToDouble(solarWaterObject.CustomData["SolarHLoss"]); 

            
            sapSolarWater.SolarHeatLoss2 = System.Convert.ToDouble(solarWaterObject.CustomData["SolarHLoss2"]); 

            
            sapSolarWater.SolarArea = System.Convert.ToDouble(solarWaterObject.CustomData["SolarArea"]); 

            
            sapSolarWater.Gross = System.Convert.ToBoolean(solarWaterObject.CustomData["Gross"]); 

            
            sapSolarWater.SolarTilt = System.Convert.ToInt32(solarWaterObject.CustomData["SolarTilt"]); 

            
            sapSolarWater.SolarPitch = System.Convert.ToDouble(solarWaterObject.CustomData["SolarPitch"]); 

            
            sapSolarWater.SolarOrientation = System.Convert.ToInt32(solarWaterObject.CustomData["SolarOrientation"]); 

            
            sapSolarWater.SolarOverShading = System.Convert.ToInt32(solarWaterObject.CustomData["SolarOverShading"]); 

            
            sapSolarWater.SolarVolume = System.Convert.ToDouble(solarWaterObject.CustomData["SolarVolume"]); 

            
            sapSolarWater.SolarSeparate = System.Convert.ToBoolean(solarWaterObject.CustomData["SolarSeparate"]); 

            
            sapSolarWater.Pumped = System.Convert.ToBoolean(solarWaterObject.CustomData["Pumped"]); 

            
            sapSolarWater.ShowerType = System.Convert.ToInt32(solarWaterObject.CustomData["ShowerType"]); 

            
            sapSolarWater.LoopEfficiencyDeclared = System.Convert.ToDouble(solarWaterObject.CustomData["NloopDeclared"]); 

            
            sapSolarWater.Nloop = System.Convert.ToDouble(solarWaterObject.CustomData["Nloop"]); 

            
            sapSolarWater.IncidenceAngleModifier = System.Convert.ToDouble(solarWaterObject.CustomData["Khem"]); 

            
            sapSolarWater.SystemHeatLoss = System.Convert.ToDouble(solarWaterObject.CustomData["HlSystem"]); 

            
            sapSolarWater.ServiceProvision = System.Convert.ToInt32(solarWaterObject.CustomData["ServiceProvision"]); 

            
            sapSolarWater.Manufacturer = (solarWaterObject.CustomData["Manufacturer"] as string);


            sapSolarWater.Certificate = (solarWaterObject.CustomData["Certificate"] as CustomObject); 


            return sapSolarWater;
        }
        public static Dictionary<string, object> FromSolarWater(SolarWater obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);
            rtn.Add("SolarWaterCollectorType", obj.SolarWaterCollectorType);
            rtn.Add("OverRide", obj.OverRide);
            rtn.Add("SolarZero", obj.SolarZero);
            rtn.Add("SolarHLoss", obj.SolarHeatLoss);
            rtn.Add("SolarHLoss2", obj.SolarHeatLoss2);
            rtn.Add("SolarArea", obj.SolarArea);
            rtn.Add("Gross", obj.Gross);
            rtn.Add("SolarTilt", obj.SolarTilt);
            rtn.Add("SolarPitch", obj.SolarPitch);
            rtn.Add("SolarOrientation", obj.SolarOrientation);
            rtn.Add("SolarOverShading", obj.SolarOverShading);
            rtn.Add("SolarVolume", obj.SolarVolume);
            rtn.Add("SolarSeparate", obj.SolarSeparate);
            rtn.Add("Pumped", obj.Pumped);
            rtn.Add("ShowerType", obj.ShowerType);
            rtn.Add("NloopDeclared", obj.LoopEfficiencyDeclared);
            rtn.Add("Nloop", obj.Nloop);
            rtn.Add("Khem", obj.IncidenceAngleModifier);
            rtn.Add("HlSystem", obj.SystemHeatLoss);
            rtn.Add("ServiceProvision", obj.ServiceProvision);
            rtn.Add("Manufacturer", obj.Manufacturer);
            rtn.Add("Certificate", obj.Certificate);



            return rtn;
        }
    }
}
