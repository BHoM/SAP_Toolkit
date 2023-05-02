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
using BH.oM.Environment.SAP;

namespace BH.oM.Environment.SAP
{
    [Description("Code which indicates a particular low or zero carbon energy source.")]
    public enum LZCEnergySourceCode
    {
        BiofuelMainHeating = 1,
        BiofuelCommunityHeating = 2,
        BiofuelCommunityHeatingForSomeOfHeatGeneration = 3,
        BiofuelSecondaryHeating = 4,
        GeothermalHeatSource = 5,
        CommunityCombinedHeatAndPower = 6,
        GroundSourceHeatPump = 7,
        WaterSourceHeatPump = 8,
        AirSourceHeatPump = 9,
        SolarWaterHeating = 10,
        SolarPhotovoltaics = 11,
        WindTurbine = 12,
        CommunityHeatPump = 13,
        HydroElectricGeneration = 14,
        MicroCHP = 15,
        ExhaustAirHeatPump = 16,
        SolarAssistedHeatPump = 17
    }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.LZCEnergySourceCode LZCEnergySourceCode)
{
    switch (LZCEnergySourceCode)
    {
        case BH.oM.Environment.SAP.LZCEnergySourceCode.BiofuelMainHeating:
            return "1";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.BiofuelCommunityHeating:
            return "2";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.BiofuelCommunityHeatingForSomeOfHeatGeneration:
            return "3";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.BiofuelSecondaryHeating:
            return "4";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.GeothermalHeatSource:
            return "5";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.CommunityCombinedHeatAndPower:
            return "6";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.GroundSourceHeatPump:
            return "7";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.WaterSourceHeatPump:
            return "8";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.AirSourceHeatPump:
            return "9";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.SolarWaterHeating:
            return "10";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.SolarPhotovoltaics:
            return "11";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.WindTurbine:
            return "12";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.CommunityHeatPump:
            return "13";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.HydroElectricGeneration:
            return "14";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.MicroCHP:
            return "15";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.ExhaustAirHeatPump:
            return "16";

        case BH.oM.Environment.SAP.LZCEnergySourceCode.SolarAssistedHeatPump:
            return "17";

        default:
            return "";
    }
}

*/
