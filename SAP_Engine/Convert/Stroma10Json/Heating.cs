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


            sapHeating.Name = heatingObject.Name;


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
        public static Dictionary<string, object> FromHeating(Heating obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Guid", obj.BHoM_Guid.ToString());

            rtn.Add("Name", obj.Name);

            rtn.Add("ItemId", obj.ItemID);

            rtn.Add("ElementType", obj.ElementType);

            rtn.Add("ElementTypeName", obj.ElementTypeName);

            if (obj.Ventilation == null)
                obj.Ventilation = new BH.oM.Environment.SAP.Stroma10.Ventilation();

            rtn.Add("Ventilation", FromVentilation(obj.Ventilation));

            if (obj.Renewable == null)
                obj.Renewable = new BH.oM.Environment.SAP.Stroma10.Renewable();

            rtn.Add("Renewable", FromRenewable(obj.Renewable));

            if (obj.Overheating == null)
                obj.Overheating = new BH.oM.Environment.SAP.Stroma10.Overheating();

            rtn.Add("Overheating", FromOverheating(obj.Overheating));


            if (obj.Doors != null && obj.Doors.Any(x => x != null))
                rtn.Add("Doors", obj.Doors.Select(x => FromDoor(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Doors", temp);
            }


            if (obj.Windows != null && obj.Windows.Any(x => x != null))
                rtn.Add("Windows", obj.Windows.Select(x => FromWindow(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Windows", temp);
            }



            if (obj.RoofLights != null && obj.RoofLights.Any(x => x != null))
                rtn.Add("RoofLights", obj.RoofLights.Select(x => FromRoofLight(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("RoofLights", temp);
            }



            if (obj.Floors != null && obj.Floors.Any(x => x != null))
                rtn.Add("Floors", obj.Floors.Select(x => FromFloor(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Floors", temp);
            }



            if (obj.Walls != null && obj.Walls.Any(x => x != null))
                rtn.Add("Walls", obj.Walls.Select(x => FromWall(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Walls", temp);
            }



            if (obj.Roofs != null && obj.Roofs.Any(x => x != null))
                rtn.Add("Roofs", obj.Roofs.Select(x => FromRoof(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Roofs", temp);
            }


            if (obj.PartyFloors != null && obj.PartyFloors.Any(x => x != null))
                rtn.Add("PFloors", obj.PartyFloors.Select(x => FromPartyFloor(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("PFloors", temp);
            }


            if (obj.PartyWalls != null && obj.PartyWalls.Any(x => x != null))
                rtn.Add("PWalls", obj.PartyWalls.Select(x => FromPartyWall(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("PWalls", temp);
            }


            if (obj.PartyCeilings != null && obj.PartyCeilings.Any(x => x != null))
                rtn.Add("PCeilings", obj.PartyCeilings.Select(x => FromPartyCeiling(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("PCeilings", temp);
            }



            if (obj.InteriorFloors != null && obj.InteriorFloors.Any(x => x != null))
                rtn.Add("IFloors", obj.InteriorFloors.Select(x => FromInteriorFloor(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("IFloors", temp);
            }


            if (obj.InteriorWalls != null && obj.InteriorWalls.Any(x => x != null))
                rtn.Add("IWalls", obj.InteriorWalls.Select(x => FromInteriorWall(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("IWalls", temp);
            }


            if (obj.InteriorCeilings != null && obj.InteriorCeilings.Any(x => x != null))
                rtn.Add("ICeilings", obj.InteriorCeilings.Select(x => FromInteriorCeiling(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("ICeilings", temp);
            }

            if (obj.Thermal == null)
                obj.Thermal = new BH.oM.Environment.SAP.Stroma10.Thermal();

            rtn.Add("Thermal", FromThermal(obj.Thermal));

            if (obj.CoolingSystem == null)
                obj.CoolingSystem = new BH.oM.Environment.SAP.Stroma10.CoolingSystem();

            rtn.Add("CoolingSystem", FromCoolingSystem(obj.CoolingSystem));

            if (obj.PrimaryHeating == null)
                obj.PrimaryHeating = new BH.oM.Environment.SAP.Stroma10.PrimaryHeating();

            rtn.Add("PrimaryHeating", FromPrimaryHeating(obj.PrimaryHeating));

            if (obj.PrimaryHeating2 == null)
                obj.PrimaryHeating2 = new BH.oM.Environment.SAP.Stroma10.PrimaryHeating2();

            rtn.Add("PrimaryHeating2", FromPrimaryHeating2(obj.PrimaryHeating2));

            if (obj.SecondaryHeating == null)
                obj.SecondaryHeating = new BH.oM.Environment.SAP.Stroma10.SecondaryHeating();

            rtn.Add("SecondaryHeating", FromSecondaryHeating(obj.SecondaryHeating));

            if (obj.WaterHeating == null)
                obj.WaterHeating = new BH.oM.Environment.SAP.Stroma10.WaterHeating();

            rtn.Add("WaterHeating", FromWaterHeating(obj.WaterHeating));

            return rtn;
        }
    }
}
