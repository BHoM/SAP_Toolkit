using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;
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


            sapDwellingVersion.ReportReferenceNumber = dwellingVersionObject.CustomData["RRN"] as string;


            sapDwellingVersion.Reference = dwellingVersionObject.CustomData["Reference"] as string;


            sapDwellingVersion.Address = ToAddress(dwellingVersionObject.CustomData["Address"] as CustomObject);


            sapDwellingVersion.BHoM_Guid = (Guid.Parse(dwellingVersionObject.CustomData["Guid"] as string));


            sapDwellingVersion.Selected = System.Convert.ToBoolean(dwellingVersionObject.CustomData["Selected"]);


            sapDwellingVersion.DwellingDetails = ToDwellingDetails(dwellingVersionObject.CustomData["DwellingDetails"] as CustomObject);


            sapDwellingVersion.TotalFloorArea = System.Convert.ToInt32(dwellingVersionObject.CustomData["TotalFloorArea"]);


            sapDwellingVersion.TotalVolume = System.Convert.ToInt32(dwellingVersionObject.CustomData["TotalVolume"]);

            
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

            //404
            sapDwellingVersion.DwellingPhotos = (List<object>)dwellingVersionObject.CustomData["DwellingPhotos"];
            //sapDwellingVersion.DwellingPhotos = ToDwellingPhotos((dwellingVersionObject.CustomData["DwellingPhotos"] as List<object>).Cast<CustomObject>().ToList());


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
    }
}
