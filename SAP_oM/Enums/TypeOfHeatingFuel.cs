/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using BH.oM.Base;


namespace BH.oM.Environment.SAP
{
    [Description("Code which indicates the type of heating fuel, as defined in SAP table 12.")]
    public enum TypeOfHeatingFuel
    {
        MainsGas = 1,
        BulkLPG,
        BottledLPG,
        HeatingOil,
        Biogas = 7,
        LNG,
        LPGSpecialCondition,
        SolidFuelMineralAndWood,
        HouseCoal,
        ManufacturedSmokelessFuel,
        Anthracite = 15,
        WoodLogs = 20,
        WoodChips,
        WoodPelletsSecondaryHeating,
        WoodPelletsMainHeating,
        ElectricitySoldToGrid = 36,
        ElectricityDisplacedFromGrid,
        ElectricityUnspecTariff = 39,
        CommunityHeatPump = 41,
        CommunityBoilersWaste,
        CommunityBoilersBiomass,
        CommunityBoilersBiogas,
        CommunityWastePowerStations,
        CommunityGeothermal,
        CommunityCHP = 48,
        CommunityElectricityCHP,
        CommunityElectricityNetwork,
        CommunityMainsGas,
        CommunityLPG,
        CommunityOil,
        CommunityCoal,
        CommunityB30D,
        CommunityBoilersMineralOilBiodiesel,
        CommunityBoilersBiodiesel,
        CommunityBiodieselVegetableOil,
        Biodiesel = 71,
        BiodieselUsedCookingOil,
        BiodieselVegetableOil,
        MineralOilLiquidBiofuel,
        B30K,
        Bioethanol,
        FuelDataFromPcdb = 99
    }
}
