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

            sapFabric.Name = fabricObject.Name;

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
        public static Dictionary<string, object> FromFabric(Fabric obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Name", obj.Name);
            rtn.Add("ItemId", obj.ItemID);
            rtn.Add("ElementType", obj.ElementType);
            rtn.Add("ElementTypeName", obj.ElementTypeName);
            rtn.Add("Ventilation", FromVentilation(obj.Ventilation));
            rtn.Add("Renewable", FromRenewable(obj.Renewable));
            rtn.Add("Overheating", FromOverheating(obj.Overheating));
            rtn.Add("Doors", obj.Doors.Select(x => FromDoor(x)).ToList());
            rtn.Add("Windows", obj.Windows.Select(x => FromWindow(x)).ToList());
            rtn.Add("RoofLights", obj.RoofLights.Select(x => FromRoofLight(x)).ToList());
            rtn.Add("Floors", obj.Floors.Select(x => FromFloor(x)).ToList());
            rtn.Add("Walls", obj.Walls.Select(x => FromWall(x)).ToList());
            rtn.Add("Roofs", obj.Roofs.Select(x => FromRoof(x)).ToList());
            rtn.Add("PFloors", obj.PartyFloors.Select(x => FromPartyFloor(x)).ToList());
            rtn.Add("PWalls", obj.PartyWalls.Select(x => FromPartyWall(x)).ToList());
            rtn.Add("PCeilings", obj.PartyCeilings.Select(x => FromPartyCeiling(x)).ToList());
            rtn.Add("IFloors", obj.InteriorFloors.Select(x => FromInteriorFloor(x)).ToList());
            rtn.Add("IWalls", obj.InteriorWalls.Select(x => FromInteriorWall(x)).ToList());
            rtn.Add("ICeilings", obj.InteriorCeilings.Select(x => FromInteriorCeiling(x)).ToList());
            rtn.Add("Thermal", FromThermal(obj.Thermal));
            rtn.Add("CoolingSystem", FromCoolingSystem(obj.CoolingSystem));
            rtn.Add("PrimaryHeating", FromPrimaryHeating(obj.PrimaryHeating));
            rtn.Add("PrimaryHeating2", FromPrimaryHeating2(obj.PrimaryHeating2));
            rtn.Add("SecondaryHeating", FromSecondaryHeating(obj.SecondaryHeating));
            rtn.Add("WaterHeating", FromWaterHeating(obj.WaterHeating));

            return rtn;
        }
    }
}
