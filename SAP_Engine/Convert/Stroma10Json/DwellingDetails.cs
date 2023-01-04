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
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

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
            sapDwellingDetails.SummerOverheating = System.Convert.ToBoolean(dwellingDetailsObject.CustomData["SummerOverheating"]);
            sapDwellingDetails.WaterUseLessThan125 = System.Convert.ToBoolean(dwellingDetailsObject.CustomData["WaterLess125"]);
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

        public static Dictionary<string, object> FromDwellingDetails(DwellingDetails obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("PropertyType", obj.PropertyType);
            rtn.Add("AssessmentType", obj.AssessmentType);
            rtn.Add("TransactionType", obj.TransactionType);
            rtn.Add("TenureType", obj.TenureType);
            rtn.Add("RelatedParty", obj.RelatedParty);
            rtn.Add("ThermalMass", obj.ThermalMass);
            rtn.Add("IndicativeValue", obj.IndicativeValue);
            rtn.Add("UserThermalMass", obj.UserThermalMass);
            rtn.Add("BuiltForm", obj.BuiltForm);
            rtn.Add("FlatType", obj.FlatType);
            rtn.Add("Location", obj.Location);
            rtn.Add("Terrain", obj.Terrain);
            rtn.Add("Orientation", obj.Orientation);
            rtn.Add("SmokeControl", obj.SmokeControl);
            rtn.Add("OverShading", obj.OverShading);
            rtn.Add("Country", obj.Country);
            rtn.Add("Language", obj.Language);
            rtn.Add("SummerOverheating", obj.SummerOverheating);
            rtn.Add("WaterLess125", obj.WaterUseLessThan125);
            rtn.Add("DateOfAssessment", obj.DateOfAssessment.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            rtn.Add("DateOfCertificate", obj.DateOfCertificate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            rtn.Add("YearBuilt", obj.YearBuilt);
            rtn.Add("RoomInRoof", obj.RoomInRoof);
            rtn.Add("StoreysInBlock", obj.StoreysInBlock);
            rtn.Add("IsGasMeter", obj.IsGasMeter);
            rtn.Add("IsElectricMeter", obj.IsElectricMeter);
            rtn.Add("IsCableExport", obj.IsCableExport);
            return rtn;
        }
    }
}
