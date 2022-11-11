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
        public static List<BH.oM.Environment.SAP.Stroma10.Heating> ToHeatings(List<CustomObject> heatingsObject)
        {
            if (heatingsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Heating> rtn = new List<BH.oM.Environment.SAP.Stroma10.Heating>();
            foreach (var value in heatingsObject)
            {
                rtn.Add(ToHeating(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Heating ToHeating(CustomObject heatingObject)
        {
            if (heatingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Heating sapHeating = new BH.oM.Environment.SAP.Stroma10.Heating();

            sapHeating.ID = System.Convert.ToInt32(heatingObject.CustomData["Id"]);


            sapHeating.BHoM_Guid = (Guid.Parse(heatingObject.CustomData["Guid"] as string));


            sapHeating.ItemID = System.Convert.ToInt32(heatingObject.CustomData["ItemId"]); 


            sapHeating.ElementType = System.Convert.ToInt32(heatingObject.CustomData["ElementType"]); 


            sapHeating.ElementTypeName = heatingObject.CustomData["ElementTypeName"] as string; 


            sapHeating.Ventilation = ToVentilation(heatingObject.CustomData["Ventilation"] as CustomObject); 


            sapHeating.Renewable = ToRenewable(heatingObject.CustomData["Renewable"] as CustomObject);  


            sapHeating.Overheating = ToOverheating(heatingObject.CustomData["Overheating"] as CustomObject); 


            sapHeating.Doors = ToDoors((heatingObject.CustomData["Doors"] as List<Object>).Cast<CustomObject>().ToList()); 


            sapHeating.Windows = ToWindows((heatingObject.CustomData["Windows"] as List<Object>).Cast<CustomObject>().ToList());

           
            sapHeating.RoofLights = ToRoofLights((heatingObject.CustomData["RoofLights"]as List<object>).Cast<CustomObject>().ToList());


            sapHeating.Floors = ToFloors((heatingObject.CustomData["Floors"] as List<object>).Cast<CustomObject>().ToList()); 


            sapHeating.Walls = ToWalls((heatingObject.CustomData["Walls"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.Roofs = ToRoofs((heatingObject.CustomData["Roofs"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.PartyFloors = ToPartyFloors((heatingObject.CustomData["PFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.PartyWalls = ToPartyWalls((heatingObject.CustomData["PWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.PartyCeilings = ToPartyCeilings((heatingObject.CustomData["PCeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.InteriorFloors = ToInteriorFloors((heatingObject.CustomData["IFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.InteriorWalls = ToInteriorWalls((heatingObject.CustomData["IWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.InteriorCeilings = ToInteriorCeilings((heatingObject.CustomData["ICeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapHeating.Thermal = ToThermal(heatingObject.CustomData["Thermal"] as CustomObject); 


            sapHeating.CoolingSystem = ToCoolingSystem(heatingObject.CustomData["CoolingSystem"] as CustomObject); 


            sapHeating.PrimaryHeating = ToPrimaryHeating(heatingObject.CustomData["PrimaryHeating"] as CustomObject); 


            sapHeating.PrimaryHeating2 = ToPrimaryHeating2(heatingObject.CustomData["PrimaryHeating2"] as CustomObject); 


            sapHeating.SecondaryHeating = ToSecondaryHeating(heatingObject.CustomData["SecondaryHeating"] as CustomObject); 


            sapHeating.WaterHeating = ToWaterHeating(heatingObject.CustomData["WaterHeating"] as CustomObject); 

            return sapHeating;
        }
    }
}
