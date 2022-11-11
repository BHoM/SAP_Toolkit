using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Water> ToWaters(List<CustomObject> watersObject)
        {
            if (watersObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Water> rtn = new List<BH.oM.Environment.SAP.Stroma10.Water>();
            foreach (var value in watersObject)
            {
                rtn.Add(ToWater(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Water ToWater(CustomObject waterObject)
        {
            if (waterObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Water sapWater = new BH.oM.Environment.SAP.Stroma10.Water();

            sapWater.ID = System.Convert.ToInt32(waterObject.CustomData["Id"]);


            sapWater.BHoM_Guid = (Guid.Parse(waterObject.CustomData["Guid"] as string));


            sapWater.ItemID = System.Convert.ToInt32(waterObject.CustomData["ItemId"]); 


            sapWater.ElementType = System.Convert.ToInt32(waterObject.CustomData["ElementType"]); 


            sapWater.ElementTypeName = waterObject.CustomData["ElementTypeName"] as string; 


            sapWater.Ventilation = ToVentilation(waterObject.CustomData["Ventilation"] as CustomObject); 


            sapWater.Renewable = ToRenewable(waterObject.CustomData["Renewable"] as CustomObject);  


            sapWater.Overheating = ToOverheating(waterObject.CustomData["Overwater"] as CustomObject); 


            sapWater.Doors = ToDoors((waterObject.CustomData["Doors"] as List<Object>).Cast<CustomObject>().ToList()); 


            sapWater.Windows = ToWindows((waterObject.CustomData["Windows"] as List<Object>).Cast<CustomObject>().ToList());

           
            sapWater.RoofLights = ToRoofLights((waterObject.CustomData["RoofLights"]as List<object>).Cast<CustomObject>().ToList());


            sapWater.Floors = ToFloors((waterObject.CustomData["Floors"] as List<object>).Cast<CustomObject>().ToList()); 


            sapWater.Walls = ToWalls((waterObject.CustomData["Walls"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.Roofs = ToRoofs((waterObject.CustomData["Roofs"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.PartyFloors = ToPartyFloors((waterObject.CustomData["PFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.PartyWalls = ToPartyWalls((waterObject.CustomData["PWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.PartyCeilings = ToPartyCeilings((waterObject.CustomData["PCeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.InteriorFloors = ToInteriorFloors((waterObject.CustomData["IFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.InteriorWalls = ToInteriorWalls((waterObject.CustomData["IWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.InteriorCeilings = ToInteriorCeilings((waterObject.CustomData["ICeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapWater.Thermal = ToThermal(waterObject.CustomData["Thermal"] as CustomObject); 


            sapWater.CoolingSystem = ToCoolingSystem(waterObject.CustomData["CoolingSystem"] as CustomObject); 


            sapWater.PrimaryHeating = ToPrimaryHeating(waterObject.CustomData["PrimaryHeating"] as CustomObject); 


            sapWater.PrimaryHeating2 = ToPrimaryHeating2(waterObject.CustomData["PrimaryHeating2"] as CustomObject); 


            sapWater.SecondaryHeating = ToSecondaryHeating(waterObject.CustomData["SecondaryHeating"] as CustomObject); 


            sapWater.WaterHeating = ToWaterHeating(waterObject.CustomData["WaterHeating"] as CustomObject); 

            return sapWater;
        }
    }
}
