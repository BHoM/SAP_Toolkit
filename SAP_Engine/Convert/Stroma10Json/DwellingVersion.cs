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
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.DwellingVersion> ToDwellingVersions(List<CustomObject> dwellingVersionsObject)
        {
            if (dwellingVersionsObject == null)
                return null;

            List<DwellingVersion> rtn = new List<DwellingVersion>();
            foreach (var value in dwellingVersionsObject)
            {
                rtn.Add(ToDwellingVersion(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.DwellingVersion ToDwellingVersion(CustomObject dwellingVersionObject)
        {
            if (dwellingVersionObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.DwellingVersion sapDwellingVersion = new BH.oM.Environment.SAP.Stroma10.DwellingVersion();

            sapDwellingVersion.ID = System.Convert.ToInt32(dwellingVersionObject.CustomData["Id"]);


            sapDwellingVersion.Name = dwellingVersionObject.Name;


            sapDwellingVersion.ReportReferenceNumber = dwellingVersionObject.CustomData["RRN"] as string;


            sapDwellingVersion.Reference = dwellingVersionObject.CustomData["Reference"] as string;


            sapDwellingVersion.Address = ToAddress(dwellingVersionObject.CustomData["Address"] as CustomObject);


            sapDwellingVersion.BHoM_Guid = (Guid.Parse(dwellingVersionObject.CustomData["Guid"] as string));


            sapDwellingVersion.Selected = System.Convert.ToBoolean(dwellingVersionObject.CustomData["Selected"]);


            sapDwellingVersion.DwellingDetails = ToDwellingDetails(dwellingVersionObject.CustomData["DwellingDetails"] as CustomObject);


            sapDwellingVersion.TotalFloorArea = System.Convert.ToDouble(dwellingVersionObject.CustomData["TotalFloorArea"]);


            sapDwellingVersion.TotalVolume = System.Convert.ToDouble(dwellingVersionObject.CustomData["TotalVolume"]);

            
            sapDwellingVersion.Dimensions = ToDimensions((dwellingVersionObject.CustomData["Dimensions"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.LivingArea = System.Convert.ToDouble(dwellingVersionObject.CustomData["LivingArea"]);


            sapDwellingVersion.LivingAreaFraction = System.Convert.ToDouble(dwellingVersionObject.CustomData["LivingAreaFraction"]);


            sapDwellingVersion.AirTestResult = System.Convert.ToDouble(dwellingVersionObject.CustomData["ArTestResult"]);


            sapDwellingVersion.GrossAreas = System.Convert.ToBoolean(dwellingVersionObject.CustomData["GrossAreas"]);


            sapDwellingVersion.Floors = ToFloors((dwellingVersionObject.CustomData["Floors"] as List<object>).Cast<CustomObject>().ToList()); ;

            
            sapDwellingVersion.Walls = ToWalls((dwellingVersionObject.CustomData["Walls"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.Roofs = ToRoofs((dwellingVersionObject.CustomData["Roofs"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.PartyFloors = ToPartyFloors((dwellingVersionObject.CustomData["PFloors"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.PartyWalls = ToPartyWalls((dwellingVersionObject.CustomData["PWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.PartyCeilings = ToPartyCeilings((dwellingVersionObject.CustomData["PCeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.InteriorFloors = ToInteriorFloors((dwellingVersionObject.CustomData["IFloors"] as List<object>).Cast<CustomObject>().ToList());


   
            sapDwellingVersion.InteriorWalls = ToInteriorWalls((dwellingVersionObject.CustomData["IWalls"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.InteriorCeilings = ToInteriorCeilings((dwellingVersionObject.CustomData["ICeilings"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.Doors = ToDoors((dwellingVersionObject.CustomData["Doors"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.Windows = ToWindows((dwellingVersionObject.CustomData["Windows"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.RoofLights = ToRoofLights((dwellingVersionObject.CustomData["RoofLights"] as List<object>).Cast<CustomObject>().ToList());


            sapDwellingVersion.Ventilation = ToVentilation(dwellingVersionObject.CustomData["Ventilation"] as CustomObject);


            sapDwellingVersion.Renewable = ToRenewable(dwellingVersionObject.CustomData["Renewable"] as CustomObject);


            sapDwellingVersion.Overheating = ToOverheating(dwellingVersionObject.CustomData["Overheating"] as CustomObject);

            sapDwellingVersion.DwellingPhotos = (List<object>)dwellingVersionObject.CustomData["DwellingPhotos"];
            

            sapDwellingVersion.ElementSelections = ToElementSelections(dwellingVersionObject.CustomData["ElementSelections"] as CustomObject);


            sapDwellingVersion.Thermal = ToThermal(dwellingVersionObject.CustomData["Thermal"] as CustomObject);


            sapDwellingVersion.CoolingSystem = ToCoolingSystem(dwellingVersionObject.CustomData["CoolingSystem"] as CustomObject);


            sapDwellingVersion.PrimaryHeating = ToPrimaryHeating(dwellingVersionObject.CustomData["PrimaryHeating"] as CustomObject);
            

            sapDwellingVersion.PrimaryHeating2 = ToPrimaryHeating2(dwellingVersionObject.CustomData["PrimaryHeating2"] as CustomObject);
            

            sapDwellingVersion.SecondaryHeating = ToSecondaryHeating(dwellingVersionObject.CustomData["SecondaryHeating"] as CustomObject);


            sapDwellingVersion.WaterHeating = ToWaterHeating(dwellingVersionObject.CustomData["WaterHeating"] as CustomObject);


            sapDwellingVersion.SecondaryHeatingFraction = System.Convert.ToDouble(dwellingVersionObject.CustomData["HeatFractionSec"]);


            sapDwellingVersion.HeatSystemInteraction = System.Convert.ToInt32(dwellingVersionObject.CustomData["HeatSystemInteraction"]);


            sapDwellingVersion.WaterOnlyHeatPump = System.Convert.ToBoolean(dwellingVersionObject.CustomData["WaterOnlyHeatPump"]);


            sapDwellingVersion.LowestFloorArea = System.Convert.ToDouble(dwellingVersionObject.CustomData["LowestFloorArea"]);


            return sapDwellingVersion;
        }
        public static Dictionary<string, object> FromDwellingVersion(DwellingVersion obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Name", obj.Name);

            rtn.Add("RRN", obj.ReportReferenceNumber);

            rtn.Add("Reference", obj.Reference);

            if (obj.Address == null)
                obj.Address = new BH.oM.Environment.SAP.Stroma10.Address();

            rtn.Add("Address", FromAddress(obj.Address));

            rtn.Add("Guid", obj.BHoM_Guid.ToString());

            rtn.Add("Selected", obj.Selected);

            if (obj.DwellingDetails == null)
                obj.DwellingDetails = new BH.oM.Environment.SAP.Stroma10.DwellingDetails();

            rtn.Add("DwellingDetails", FromDwellingDetails(obj.DwellingDetails));

            rtn.Add("TotalFloorArea", obj.TotalFloorArea);

            rtn.Add("TotalVolume", obj.TotalVolume);

            if (obj.Dimensions != null && obj.Dimensions.Any(x => x != null))
                rtn.Add("Dimensions", obj.Dimensions.Select(x => FromDimension(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("Dimensions", temp);
            }

            rtn.Add("LivingArea", obj.LivingArea);

            rtn.Add("LivingAreaFraction", obj.LivingAreaFraction);

            rtn.Add("ArTestResult", obj.AirTestResult);

            rtn.Add("GrossAreas", obj.GrossAreas);

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


            if (obj.Ventilation == null)
                obj.Ventilation = new BH.oM.Environment.SAP.Stroma10.Ventilation();
            rtn.Add("Ventilation", FromVentilation(obj.Ventilation));

            if (obj.Renewable == null)
                obj.Renewable = new BH.oM.Environment.SAP.Stroma10.Renewable();

            rtn.Add("Renewable", FromRenewable(obj.Renewable));

            if (obj.Overheating == null)
                obj.Overheating = new BH.oM.Environment.SAP.Stroma10.Overheating();

            rtn.Add("Overheating", FromOverheating(obj.Overheating));


            rtn.Add("DwellingPhotos", obj.DwellingPhotos); 

            if (obj.ElementSelections == null)
                obj.ElementSelections = new BH.oM.Environment.SAP.Stroma10.ElementSelections();

            rtn.Add("ElementSelections", FromElementSelections(obj.ElementSelections));

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

            rtn.Add("HeatFractionSec", obj.SecondaryHeatingFraction);

            rtn.Add("HeatSystemInteraction", obj.HeatSystemInteraction);

            rtn.Add("WaterOnlyHeatPump", obj.WaterOnlyHeatPump);

            rtn.Add("LowestFloorArea", obj.LowestFloorArea);

            return rtn;
        }
    }
}
