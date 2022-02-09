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
            BH.oM.Environment.SAP.XML.Heating xmlHeating = new BH.oM.Environment.SAP.XML.Heating();
            xmlHeating.WaterHeatingCode = null;
            xmlHeating.WaterFuelType = null;
            xmlHeating.HasHotWaterCylinder = null;
            xmlHeating.SecondaryHeatingCategory = heating.SecondaryHeating.HeatingDetails.HeatingGroup;
            xmlHeating.SecondaryHeatingDataSource = heating.SecondaryHeating.HeatingDetails.Source;
            xmlHeating.SecondaryHeatingCode = heating.SecondaryHeating.HeatingDetails.HeatingType;
            xmlHeating.SecondaryFuelType = heating.SecondaryHeating.Fuel;
            xmlHeating.SecondaryHeatingFlueType = heating.SecondaryHeating.HeatingDetails.FlueType;
            xmlHeating.ThermalStore = null ;
            xmlHeating.HasFixedAirConditioning = null;
            xmlHeating.ImmersionHeatingType = null;
            xmlHeating.IsHeatPumpAssistedByImmersion = null;
            xmlHeating.IsImmersionForSummerUse = null;
            xmlHeating.IsSecondaryHeatingHETASApproved = heating.SecondaryHeating.HETASApproved;
            xmlHeating.HotWaterStoreSize = null;
            xmlHeating.HotWaterStoreHeatTransferArea = null;
            xmlHeating.HotWaterStoreHeatLossSource = null;
            xmlHeating.HotWaterStoreHeatLoss = null;
            xmlHeating.HotWaterStoreInsulationType = null;
            xmlHeating.HotWaterInsulationThickness = null;
            xmlHeating.IsThermalStoreNearBoiler = null;
            xmlHeating.IsThermalStoreOrCPSUInAiringCupboard = null;
            xmlHeating.HasCylinderThermostat = null;
            xmlHeating.IsCylinderInHeatedSpace = null;
            xmlHeating.IsHotWaterSeperatlyTimed = null;
            xmlHeating.CommunityHeatingSystems = null;
            xmlHeating.MainHeatingDetails = null;
            xmlHeating.HeatingDesignWaterUse = null;
            xmlHeating.MainHeatingSystemsInteraction = null;
            xmlHeating.SecondaryHeatingDeclaredValues = null;
            xmlHeating.PrimaryPipeworkInsulation = null;
            xmlHeating.SolarHeatingDetails = null;
            xmlHeating.InstantaneousWHRS = null;
            xmlHeating.StorageWHRS = null;

            return xmlHeating;
        }
    }
}