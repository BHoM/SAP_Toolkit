/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
            sapHeating.RoofLights = ToRoofLights((heatingObject.CustomData["RoofLights"] as List<object>).Cast<CustomObject>().ToList());
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
            if (obj == null)
                return null;

            Dictionary<string, object> rtn = new Dictionary<string, object>();
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
                rtn.Add("Doors", new List<object>());
            }

            if (obj.Windows != null && obj.Windows.Any(x => x != null))
                rtn.Add("Windows", obj.Windows.Select(x => FromWindow(x)).ToList());
            else
            {
                rtn.Add("Windows", new List<object>());
            }

            if (obj.RoofLights != null && obj.RoofLights.Any(x => x != null))
                rtn.Add("RoofLights", obj.RoofLights.Select(x => FromRoofLight(x)).ToList());
            else
            {
                rtn.Add("RoofLights", new List<object>());
            }

            if (obj.Floors != null && obj.Floors.Any(x => x != null))
                rtn.Add("Floors", obj.Floors.Select(x => FromFloor(x)).ToList());
            else
            {
                rtn.Add("Floors", new List<object>());
            }

            if (obj.Walls != null && obj.Walls.Any(x => x != null))
                rtn.Add("Walls", obj.Walls.Select(x => FromWall(x)).ToList());
            else
            {
                rtn.Add("Walls", new List<object>());
            }

            if (obj.Roofs != null && obj.Roofs.Any(x => x != null))
                rtn.Add("Roofs", obj.Roofs.Select(x => FromRoof(x)).ToList());
            else
            {
                rtn.Add("Roofs", new List<object>());
            }

            if (obj.PartyFloors != null && obj.PartyFloors.Any(x => x != null))
                rtn.Add("PFloors", obj.PartyFloors.Select(x => FromPartyFloor(x)).ToList());
            else
            {
                rtn.Add("PFloors", new List<object>());
            }

            if (obj.PartyWalls != null && obj.PartyWalls.Any(x => x != null))
                rtn.Add("PWalls", obj.PartyWalls.Select(x => FromPartyWall(x)).ToList());
            else
            {
                rtn.Add("PWalls", new List<object>());
            }

            if (obj.PartyCeilings != null && obj.PartyCeilings.Any(x => x != null))
                rtn.Add("PCeilings", obj.PartyCeilings.Select(x => FromPartyCeiling(x)).ToList());
            else
            { 
                rtn.Add("PCeilings", new List<object>());
            }

            if (obj.InteriorFloors != null && obj.InteriorFloors.Any(x => x != null))
                rtn.Add("IFloors", obj.InteriorFloors.Select(x => FromInteriorFloor(x)).ToList());
            else
            {
                rtn.Add("IFloors", new List<object>());
            }

            if (obj.InteriorWalls != null && obj.InteriorWalls.Any(x => x != null))
                rtn.Add("IWalls", obj.InteriorWalls.Select(x => FromInteriorWall(x)).ToList());
            else
            {
                rtn.Add("IWalls", new List<object>());
            }

            if (obj.InteriorCeilings != null && obj.InteriorCeilings.Any(x => x != null))
                rtn.Add("ICeilings", obj.InteriorCeilings.Select(x => FromInteriorCeiling(x)).ToList());
            else
            {
                rtn.Add("ICeilings", new List<object>());
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
