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
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.PrimaryHeating ToPrimaryHeating(CustomObject primaryHeatingObject)
        {
            if (primaryHeatingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.PrimaryHeating sapPrimaryHeating = new BH.oM.Environment.SAP.Stroma10.PrimaryHeating();

            sapPrimaryHeating.ID = System.Convert.ToInt32(primaryHeatingObject.CustomData["Id"]);

           
            sapPrimaryHeating.Include = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Include"]);


            sapPrimaryHeating.Group = (primaryHeatingObject.CustomData["Group"] as string); 

            
            sapPrimaryHeating.HeatingCategory = System.Convert.ToInt32(primaryHeatingObject.CustomData["HeatingCategory"]);


            sapPrimaryHeating.SubHeatingGroup = (primaryHeatingObject.CustomData["SGroup"] as string); 

            
            sapPrimaryHeating.SubHeatingCategory = System.Convert.ToInt32(primaryHeatingObject.CustomData["SubHeatingCategory"]); 

            
            sapPrimaryHeating.Source = System.Convert.ToInt32(primaryHeatingObject.CustomData["Source"]); 

            
            sapPrimaryHeating.SAPTableCode = System.Convert.ToInt32(primaryHeatingObject.CustomData["SapTableCode"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK = primaryHeatingObject.CustomData["Sedbuk"] as string; 

            
            sapPrimaryHeating.Efficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["Efficiency"]); 

            
            sapPrimaryHeating.TER = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Ter"]); 

            
            sapPrimaryHeating.WinterEfficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["WinterEfficiency"]); 

            
            sapPrimaryHeating.SummerEfficiency = System.Convert.ToDouble(primaryHeatingObject.CustomData["SummerEfficiency"]); 

            
            sapPrimaryHeating.Emitter = System.Convert.ToInt32(primaryHeatingObject.CustomData["Emitter"]); 

            
            sapPrimaryHeating.ControlCode = System.Convert.ToInt32(primaryHeatingObject.CustomData["ControlCode"]); 

            
            sapPrimaryHeating.ControlCodeProductCharacteristicsDatabase = primaryHeatingObject.CustomData["ControlCodePcdf"] as string; 

            
            sapPrimaryHeating.Fuel = System.Convert.ToInt32(primaryHeatingObject.CustomData["Fuel"]); 

            
            sapPrimaryHeating.HeatingEquipmentTestingAndApprovalsScheme = System.Convert.ToBoolean(primaryHeatingObject.CustomData["IsHetas"]);

          
            sapPrimaryHeating.Boiler = ToBoiler(primaryHeatingObject.CustomData["Boiler"] as CustomObject); 

            
            sapPrimaryHeating.ElectricityTariff = System.Convert.ToInt32(primaryHeatingObject.CustomData["ElectricityTariff"]);


            sapPrimaryHeating.Range = ToRange(primaryHeatingObject.CustomData["Range"] as CustomObject); 

            
            sapPrimaryHeating.OilPump = System.Convert.ToBoolean(primaryHeatingObject.CustomData["OilPump"]); 

            
            sapPrimaryHeating.DelayedStart = System.Convert.ToBoolean(primaryHeatingObject.CustomData["DelayedStart"]); 

            
            sapPrimaryHeating.FuelBurningType = System.Convert.ToInt32(primaryHeatingObject.CustomData["FuelBurningType"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK2005 = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Sedbuk2005"]); 

            
            sapPrimaryHeating.SeasonalEfficiencyOfDomesticBoilersUK2009 = System.Convert.ToBoolean(primaryHeatingObject.CustomData["Sedbuk2009"]);

            
            sapPrimaryHeating.WinterSummer = System.Convert.ToBoolean(primaryHeatingObject.CustomData["WinterSummer"]); 

            
            sapPrimaryHeating.MicroCertificationSchemeHeatPump = System.Convert.ToBoolean(primaryHeatingObject.CustomData["McsHeatPump"]);

            
            sapPrimaryHeating.CommunityHeating = ToCommunityHeating(primaryHeatingObject.CustomData["CommunityHeating"] as CustomObject); 


            sapPrimaryHeating.ComplianceHeatingDetails = ToComplianceHeatingDetails(primaryHeatingObject.CustomData["ComplianceHeatingDetails"] as CustomObject);


            sapPrimaryHeating.HeatPumpOnly = ToHeatPumpOnly(primaryHeatingObject.CustomData["HpOnly"] as CustomObject);


            sapPrimaryHeating.StorageHeaters = ToStorageHeaters((primaryHeatingObject.CustomData["StorageHeaters"] as List<object>).Cast<CustomObject>().ToList());


            return sapPrimaryHeating;
        }
        public static Dictionary<string, object> FromPrimaryHeating(PrimaryHeating obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("Include", obj.Include);

            rtn.Add("Group", obj.Group);

            rtn.Add("HeatingCategory", obj.HeatingCategory);

            rtn.Add("SGroup", obj.SubHeatingGroup);

            rtn.Add("SubHeatingCategory", obj.SubHeatingCategory);

            rtn.Add("Source", obj.Source);

            rtn.Add("SapTableCode", obj.SAPTableCode);

            rtn.Add("Sedbuk", obj.SeasonalEfficiencyOfDomesticBoilersUK);

            rtn.Add("Efficiency", obj.Efficiency);

            rtn.Add("Ter", obj.TER);

            rtn.Add("WinterEfficiency", obj.WinterEfficiency);

            rtn.Add("SummerEfficiency", obj.SummerEfficiency);

            rtn.Add("Emitter", obj.Emitter);

            rtn.Add("ControlCode", obj.ControlCode);

            rtn.Add("ControlCodePcdf", obj.ControlCodeProductCharacteristicsDatabase);

            rtn.Add("Fuel", obj.Fuel);

            rtn.Add("IsHetas", obj.HeatingEquipmentTestingAndApprovalsScheme);

            if (obj.Boiler == null)
                obj.Boiler = new BH.oM.Environment.SAP.Stroma10.Boiler();

            rtn.Add("Boiler", FromBoiler(obj.Boiler));

            rtn.Add("ElectricityTariff", obj.ElectricityTariff);

            if (obj.Range == null)
                obj.Range = new BH.oM.Environment.SAP.Stroma10.Range();

            rtn.Add("Range", FromRange(obj.Range));

            rtn.Add("OilPump", obj.OilPump);

            rtn.Add("DelayedStart", obj.DelayedStart);

            rtn.Add("FuelBurningType", obj.FuelBurningType);

            rtn.Add("Sedbuk2005", obj.SeasonalEfficiencyOfDomesticBoilersUK2005);

            rtn.Add("Sedbuk2009", obj.SeasonalEfficiencyOfDomesticBoilersUK2009);

            rtn.Add("WinterSummer", obj.WinterSummer);

            rtn.Add("McsHeatPump", obj.MicroCertificationSchemeHeatPump);

            if (obj.CommunityHeating == null)
                obj.CommunityHeating = new BH.oM.Environment.SAP.Stroma10.CommunityHeating();

            rtn.Add("CommunityHeating", FromCommunityHeating(obj.CommunityHeating));

            if (obj.ComplianceHeatingDetails == null)
                obj.ComplianceHeatingDetails = new BH.oM.Environment.SAP.Stroma10.ComplianceHeatingDetails();

            rtn.Add("ComplianceHeatingDetails", FromComplianceHeatingDetails(obj.ComplianceHeatingDetails));

            if (obj.HeatPumpOnly == null)
                obj.HeatPumpOnly = new BH.oM.Environment.SAP.Stroma10.HeatPumpOnly();

            rtn.Add("HpOnly", FromHeatPumpOnly(obj.HeatPumpOnly));

            if (obj.StorageHeaters != null && obj.StorageHeaters.Any(x => x != null))
                rtn.Add("StorageHeaters", obj.StorageHeaters.Select(x => FromStorageHeater(x)).ToList());
            else
            {
                List<object> temp = new List<object>();
                rtn.Add("StorageHeaters", temp);
            }


            return rtn;
        }
    }
}

