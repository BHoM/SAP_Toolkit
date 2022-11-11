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
        public static List<BH.oM.Environment.SAP.Stroma10.Fabric> ToFabrics(List<CustomObject> fabricsObject)
        {
            if (fabricsObject == null)
                return null;

            List<BH.oM.Environment.SAP.Stroma10.Fabric> rtn = new List<BH.oM.Environment.SAP.Stroma10.Fabric>();
            foreach (var value in fabricsObject)
            {
                rtn.Add(ToFabric(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Fabric ToFabric(CustomObject fabricObject)
        {
            if (fabricObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Fabric sapFabric = new BH.oM.Environment.SAP.Stroma10.Fabric();

            sapFabric.ID = System.Convert.ToInt32(fabricObject.CustomData["Id"]);


            sapFabric.BHoM_Guid = (Guid.Parse(fabricObject.CustomData["Guid"] as string));


            sapFabric.ItemID = System.Convert.ToInt32(fabricObject.CustomData["ItemId"]); 


            sapFabric.ElementType = System.Convert.ToInt32(fabricObject.CustomData["ElementType"]); 


            sapFabric.ElementTypeName = fabricObject.CustomData["ElementTypeName"] as string; 


            sapFabric.Ventilation = ToVentilation(fabricObject.CustomData["Ventilation"] as CustomObject); 


            sapFabric.Renewable = ToRenewable(fabricObject.CustomData["Renewable"] as CustomObject);  


            sapFabric.Overheating = ToOverheating(fabricObject.CustomData["Overheating"] as CustomObject); 


            sapFabric.Doors = ToDoors((fabricObject.CustomData["Doors"] as List<Object>).Cast<CustomObject>().ToList()); 


            sapFabric.Windows = ToWindows((fabricObject.CustomData["Windows"] as List<Object>).Cast<CustomObject>().ToList());

           
            sapFabric.RoofLights = ToRoofLights((fabricObject.CustomData["RoofLights"]as List<object>).Cast<CustomObject>().ToList());


            sapFabric.Floors = ToFloors((fabricObject.CustomData["Floors"] as List<object>).Cast<CustomObject>().ToList()); 


            sapFabric.Walls = ToWalls((fabricObject.CustomData["Walls"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.Roofs = ToRoofs((fabricObject.CustomData["Roofs"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.PartyFloors = ToPartyFloors((fabricObject.CustomData["PFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.PartyWalls = ToPartyWalls((fabricObject.CustomData["PWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.PartyCeilings = ToPartyCeilings((fabricObject.CustomData["PCeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.InteriorFloors = ToInteriorFloors((fabricObject.CustomData["IFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.InteriorWalls = ToInteriorWalls((fabricObject.CustomData["IWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.InteriorCeilings = ToInteriorCeilings((fabricObject.CustomData["ICeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapFabric.Thermal = ToThermal(fabricObject.CustomData["Thermal"] as CustomObject); 


            sapFabric.CoolingSystem = ToCoolingSystem(fabricObject.CustomData["CoolingSystem"] as CustomObject); 


            sapFabric.PrimaryHeating = ToPrimaryHeating(fabricObject.CustomData["PrimaryHeating"] as CustomObject); 


            sapFabric.PrimaryHeating2 = ToPrimaryHeating2(fabricObject.CustomData["PrimaryHeating2"] as CustomObject); 


            sapFabric.SecondaryHeating = ToSecondaryHeating(fabricObject.CustomData["SecondaryHeating"] as CustomObject); 


            sapFabric.WaterHeating = ToWaterHeating(fabricObject.CustomData["WaterHeating"] as CustomObject); 

            return sapFabric;
        }
    }
}
