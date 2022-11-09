using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.DwellingVersion> ToDwellingVersions(CustomObject dwellingVersionsObject)
        {
            List<DwellingVersion> rtn = new List<DwellingVersion>();
            foreach (var value in dwellingVersionsObject.CustomData["DwellingVersions"] as List<CustomObject>)
            {
                rtn.Add(ToDwellingVersion(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.DwellingVersion ToDwellingVersion(CustomObject dwellingVersionObject)
        {
            BH.oM.Environment.SAP.Stroma10.DwellingVersion sapDwellingVersion = new BH.oM.Environment.SAP.Stroma10.DwellingVersion();

            sapDwellingVersion.ID = System.Convert.ToInt32(dwellingVersionObject.CustomData["ID"]);


            sapDwellingVersion.ReportReferenceNumber = dwellingVersionObject.CustomData["ReportReferenceNumber"] as CustomObject;


            sapDwellingVersion.Reference = dwellingVersionObject.CustomData["Reference"] as string;


            sapDwellingVersion.Address = ToAddress(dwellingVersionObject.CustomData["Address"] as CustomObject);


            sapDwellingVersion.BHoM_Guid = (Guid)dwellingVersionObject.CustomData["GUID"];


            sapDwellingVersion.Selected = System.Convert.ToBoolean(dwellingVersionObject.CustomData["Selected"]);


            sapDwellingVersion.DwellingDetails = ToDwellingDetails(dwellingVersionObject.CustomData["DwellingDetails"] as CustomObject);


            sapDwellingVersion.TotalFloorArea = System.Convert.ToInt32(dwellingVersionObject.CustomData["TotalFloorArea"]);


            sapDwellingVersion.TotalVolume = System.Convert.ToInt32(dwellingVersionObject.CustomData["TotalVolume"]);

            
            sapDwellingVersion.Dimensions = ToDimensions(dwellingVersionObject.CustomData["Dimensions"] as CustomObject);


            sapDwellingVersion.LivingArea = System.Convert.ToDouble(dwellingVersionObject.CustomData["LivingArea"]);


            sapDwellingVersion.LivingAreaFraction = System.Convert.ToDouble(dwellingVersionObject.CustomData["LivingAreaFraction"]);


            sapDwellingVersion.AirTestResult = System.Convert.ToDouble(dwellingVersionObject.CustomData["AirTestResult"]);


            sapDwellingVersion.GrossAreas = System.Convert.ToBoolean(dwellingVersionObject.CustomData["GrossAreas"]);

            
            sapDwellingVersion.Floors = ToFloors(dwellingVersionObject.CustomData["Floors"] as CustomObject);

            
            sapDwellingVersion.Walls = ToWalls(dwellingVersionObject.CustomData["Walls"] as CustomObject);

            
            sapDwellingVersion.Roofs = ToRoofs(dwellingVersionObject.CustomData["Roofs"] as CustomObject);


            sapDwellingVersion.PartyFloors = (List<object>)dwellingVersionObject.CustomData["PartyFloors"];


            sapDwellingVersion.PartyWalls = (List<object>)dwellingVersionObject.CustomData["PartyWalls"];


            sapDwellingVersion.PartyCeilings = (List<object>)dwellingVersionObject.CustomData["PartyCeilings"];

          
            sapDwellingVersion.InteriorFloors = ToInteriorFloors(dwellingVersionObject.CustomData["InteriorFloors"] as CustomObject);


            sapDwellingVersion.InteriorWalls = (List<object>)dwellingVersionObject.CustomData["InteriorWalls"];


            sapDwellingVersion.InteriorCeilings = ToInteriorCeilings(dwellingVersionObject.CustomData["InteriorCeilings"] as CustomObject);


            sapDwellingVersion.Doors = (List<object>)dwellingVersionObject.CustomData["Doors"];


            sapDwellingVersion.Windows = ToWindows(dwellingVersionObject.CustomData["Windows"] as CustomObject);


            sapDwellingVersion.RoofLights = (List<object>)dwellingVersionObject.CustomData["RoofLights"];


            sapDwellingVersion.Ventilation = ToVentilation(dwellingVersionObject.CustomData["Ventilation"] as CustomObject);


            sapDwellingVersion.Renewable = ToRenewable(dwellingVersionObject.CustomData["Renewable"] as CustomObject);


            sapDwellingVersion.Overheating = ToOverheating(dwellingVersionObject.CustomData["Overheating"] as CustomObject);


            sapDwellingVersion.DwellingPhotos = (List<object>)dwellingVersionObject.CustomData["DwellingPhotots"];


            sapDwellingVersion.ElementSelections = ToElementSelections(dwellingVersionObject.CustomData["ElementSelections"] as CustomObject);


            sapDwellingVersion.Thermal = ToThermal(dwellingVersionObject.CustomData["Thermal"] as CustomObject);


            sapDwellingVersion.CoolingSystem = ToCoolingSystem(dwellingVersionObject.CustomData["CoolingSystem"] as CustomObject);


            sapDwellingVersion.PrimaryHeating = ToPrimaryHeating(dwellingVersionObject.CustomData["PrimaryHeating"] as CustomObject);
            

            sapDwellingVersion.PrimaryHeating2 = ToPrimaryHeating2(dwellingVersionObject.CustomData["PrimaryHeating2"] as CustomObject);
            

            sapDwellingVersion.SecondaryHeating = ToSecondaryHeating(dwellingVersionObject.CustomData["SecondaryHeating"] as CustomObject);


            sapDwellingVersion.WaterHeating = ToWaterHeating(dwellingVersionObject.CustomData["WaterHeating"] as CustomObject);


            sapDwellingVersion.SecondaryHeatingFraction = System.Convert.ToDouble(dwellingVersionObject.CustomData["SecondaryHeatingFraction"]);


            sapDwellingVersion.HeatSystemInteraction = System.Convert.ToInt32(dwellingVersionObject.CustomData["HeatSystemInteraction"]);


            sapDwellingVersion.WaterOnlyHeatPump = System.Convert.ToBoolean(dwellingVersionObject.CustomData["WaterOnlyHeatPump"]);


            sapDwellingVersion.LowestFloorArea = System.Convert.ToDouble(dwellingVersionObject.CustomData["LowestFloorArea"]);



            return sapDwellingVersion;
        }
    }
}
