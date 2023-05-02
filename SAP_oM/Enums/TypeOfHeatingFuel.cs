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

/*private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfHeatingFuel typeOfHeatingFuel)
{
    switch (typeOfHeatingFuel)
    {
        case BH.oM.Environment.SAP.TypeOfHeatingFuel.MainsGas:
            return "1";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.BulkLPG:
            return "2";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.BottledLPG:
            return "3";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.HeatingOil:
            return "4";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.Biogas:
            return "7";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.LNG:
            return "8";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.LPGSpecialCondition:
            return "9";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.SolidFuelMineralAndWood:
            return "10";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.HouseCoal:
            return "11";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.ManufacturedSmokelessFuel:
            return "12";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.Anthracite:
            return "15";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodLogs:
            return "20";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodChips:
            return "21";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodPelletsSecondaryHeating:
            return "22";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.WoodPelletsMainHeating:
            return "23";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.ElectricitySoldToGrid:
            return "36";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.ElectricityDisplacedFromGrid:
            return "37";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.ElectricityUnspecTariff:
            return "39";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityHeatPump:
            return "41";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersWaste:
            return "42";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersBiomass:
            return "43";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersBiogas:
            return "44";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityWastePowerStations:
            return "45";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityGeothermal:
            return "46";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityCHP:
            return "48";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityElectricityCHP:
            return "49";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityElectricityNetwork:
            return "50";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityMainsGas:
            return "51";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityLPG:
            return "52";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityOil:
            return "53";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityCoal:
            return "54";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityB30D:
            return "55";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersMineralOilBiodiesel:
            return "56";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBoilersBiodiesel:
            return "57";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.CommunityBiodieselVegetableOil:
            return "58";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.Biodiesel:
            return "71";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.BiodieselUsedCookingOil:
            return "72";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.BiodieselVegetableOil:
            return "73";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.MineralOilLiquidBiofuel:
            return "74";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.B30K:
            return "75";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.Bioethanol:
            return "76";

        case BH.oM.Environment.SAP.TypeOfHeatingFuel.FuelDataFromPcdb:
            return "99";

        default:
            return "";
    }
}
 */