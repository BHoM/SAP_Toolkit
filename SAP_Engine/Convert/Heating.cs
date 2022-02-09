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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Convert
    {
        [Description("Convert SAP Heating to XML Heating.")]
        [Input("sapHeating", "SAP Heating object to convert.")]
        [Output("xmlHeating", "XML Heating object.")]
        public static BH.oM.Environment.SAP.XML.Heating ToXML(this BH.oM.Environment.SAP.Heating heating)
        {
           /* BH.oM.Environment.SAP.XML.Heating xmlHeating = new BH.oM.Environment.SAP.XML.Heating();
            xmlHeating.WaterHeatingCode = "0";
            xmlHeating.WaterFuelType = "Type-" + sapFloor.Type.ToString() + "_Area-" + sapFloor.Area.ToString() + "_Uvalue-" + "0.13"; ;
            xmlHeating.HasHotWaterCylinder = sapFloor.Type.FromSAPToXMLNumber();
            xmlHeating.SecondaryHeatingCategory = sapFloor.Area;
            xmlHeating.SecondaryHeatingDataSource = 0;
            xmlHeating.SecondaryHeatingCode = 0;
            xmlHeating.SecondaryFuelType = 0.13;
            xmlHeating.SecondaryHeatingFlueType = 80;
            xmlHeating.ThermalStore = 0;
            xmlHeating.HasFixedAirConditioning = 0;
            xmlHeating.ImmersionHeatingType = 0.13;
            xmlHeating.IsHeatPumpAssistedByImmersion = 80;
            xmlHeating.IsImmersionForSummerUse = 0;
            xmlHeating.IsSecondaryHeatingHETASApproved = 0;
            xmlHeating.HotWaterStoreSize = 0.13;
            xmlHeating.HotWaterStoreHeatTransferArea = 80;
            xmlHeating.HotWaterStoreHeatLossSource = 0;
            xmlHeating.HotWaterStoreHeatLoss = 0;
            xmlHeating.HotWaterStoreInsulationType = 0.13;
            xmlHeating.HotWaterInsulationThickness = 80;
            xmlHeating.IsThermalStoreNearBoiler = 0;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = 0;
            xmlHeating.HasCylinderThermostat = 0.13;
            xmlHeating.IsCylinderInHeatedSpace = 80;
            xmlHeating.IsHotWaterSeperatlyTimed = 0;
            xmlHeating.CommunityHeatingSystems = 0;
            xmlHeating.MainHeatingDetails = 0.13;
            xmlHeating.HeatingDesignWaterUse = 80;
            xmlHeating.MainHeatingSystemsInteraction = 0;
            xmlHeating.SecondaryHeatingDeclaredValues = 0;
            xmlHeating.PrimaryPipeworkInsulation = 0.13;
            xmlHeating.SolarHeatingDetails = 80;
            xmlHeating.InstantaneousWHRS = 0;
            xmlHeating.StorageWHRS = 0;*/

            return null;
        }
    }
}