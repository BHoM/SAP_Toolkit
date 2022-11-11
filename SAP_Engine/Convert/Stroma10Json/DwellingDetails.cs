using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.DwellingDetails ToDwellingDetails(CustomObject dwellingDetailsObject)
        {
            if (dwellingDetailsObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.DwellingDetails sapDwellingDetails = new BH.oM.Environment.SAP.Stroma10.DwellingDetails();

            sapDwellingDetails.ID = System.Convert.ToInt32(dwellingDetailsObject.CustomData["Id"]);

            sapDwellingDetails.PropertyType = System.Convert.ToInt32(dwellingDetailsObject.CustomData["PropertyType"]);

            sapDwellingDetails.AssessmentType = System.Convert.ToInt32(dwellingDetailsObject.CustomData["AssessmentType"]);

            sapDwellingDetails.TransactionType = System.Convert.ToInt32(dwellingDetailsObject.CustomData["TransactionType"]);

            sapDwellingDetails.TenureType = System.Convert.ToInt32(dwellingDetailsObject.CustomData["TenureType"]);

            sapDwellingDetails.RelatedParty = System.Convert.ToInt32(dwellingDetailsObject.CustomData["RelatedParty"]);

            sapDwellingDetails.ThermalMass = System.Convert.ToInt32(dwellingDetailsObject.CustomData["ThermalMass"]);

            sapDwellingDetails.IndicativeValue = System.Convert.ToInt32(dwellingDetailsObject.CustomData["IndicativeValue"]);

            sapDwellingDetails.UserThermalMass = System.Convert.ToDouble(dwellingDetailsObject.CustomData["UserThermalMass"]); 

            sapDwellingDetails.BuiltForm = System.Convert.ToInt32(dwellingDetailsObject.CustomData["BuiltForm"]);

            sapDwellingDetails.FlatType = System.Convert.ToInt32(dwellingDetailsObject.CustomData["FlatType"]);

            sapDwellingDetails.Location = System.Convert.ToInt32(dwellingDetailsObject.CustomData["Location"]);

            sapDwellingDetails.Terrain = System.Convert.ToInt32(dwellingDetailsObject.CustomData["Terrain"]);

            sapDwellingDetails.Orientation = System.Convert.ToInt32(dwellingDetailsObject.CustomData["Orientation"]);

            sapDwellingDetails.SmokeControl = System.Convert.ToInt32(dwellingDetailsObject.CustomData["SmokeControl"]);

            sapDwellingDetails.OverShading = System.Convert.ToInt32(dwellingDetailsObject.CustomData["OverShading"]);

            sapDwellingDetails.Country = System.Convert.ToInt32(dwellingDetailsObject.CustomData["Country"]);

            sapDwellingDetails.Language = System.Convert.ToInt32(dwellingDetailsObject.CustomData["Language"]);

            sapDwellingDetails.DateOfAssessment = System.Convert.ToDateTime(dwellingDetailsObject.CustomData["DateOfAssessment"]);

            sapDwellingDetails.DateOfCertificate = System.Convert.ToDateTime(dwellingDetailsObject.CustomData["DateOfCertificate"]);

            sapDwellingDetails.YearBuilt = System.Convert.ToInt32(dwellingDetailsObject.CustomData["YearBuilt"]);

            sapDwellingDetails.RoomInRoof = System.Convert.ToBoolean(dwellingDetailsObject.CustomData["RoomInRoof"]);

            sapDwellingDetails.StoreysInBlock = System.Convert.ToInt32(dwellingDetailsObject.CustomData["StoreysInBlock"]);

            sapDwellingDetails.IsGasMeter = System.Convert.ToBoolean(dwellingDetailsObject.CustomData["IsGasMeter"]);

            sapDwellingDetails.IsElectricMeter = System.Convert.ToBoolean(dwellingDetailsObject.CustomData["IsElectricMeter"]);

            sapDwellingDetails.IsCableExport = System.Convert.ToBoolean(dwellingDetailsObject.CustomData["IsCableExport"]);

            return sapDwellingDetails;
        }
    }
}
