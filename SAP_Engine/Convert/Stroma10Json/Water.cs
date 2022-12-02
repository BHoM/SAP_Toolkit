/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

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


            sapWater.Name = waterObject.Name;


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
        public static Dictionary<string, object> FromWater(Water obj)
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


            if (obj.InteriorWalls!= null && obj.InteriorWalls.Any(x => x != null))
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

