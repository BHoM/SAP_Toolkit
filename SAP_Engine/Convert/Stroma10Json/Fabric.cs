/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
