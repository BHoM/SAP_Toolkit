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
    [Description("Code which indicates an improvement measure for a property.")]
    public enum ImprovementMeasureCode
    {
        LoftInsulation = 1,
        FlatRoofInsulation,
        RoomInRoofInsulation,
        CavityWallInsulation,
        HotWaterCylinderInsulation,
        Draughtproofing,
        LowEnergyLights,
        CylinderThermostat,
        HeatingControlsForWetCentralHeatingSystem,
        HeatingControlsForWarmAirSystem,
        UpgradeBoiler,
        SameFuel,
        Biomasboiler,
        BiomasboilerAsAlternativeImprovement,
        BiomassRoomHeaterWithBoiler,
        NewOrReplacementFanAssistedStorageHeaters,
        NewOrReplacementHighHeatRetentionStorageHeaters,
        ReplacementWarmAirUnit,
        SolarWaterHeating,
        ReplacementDoubleGlazedWindows,
        ReplacementDoubleGlazingUnits,
        SecondaryGlazing,
        SolidWallInsulation,
        ExternalInsulationWithCavityWallInsulation,
        CondensingOilBoiler,
        ChangeHeatingToBandAGasCondensingBoilerNoFuelSwitch,
        ChangeHeatingToBandAGasCondensingBoilerFuelSwitch,
        FlueGasHeatRecovery,
        Photovoltaics,
        WindTurbineRoofMounted,
        WindTurbineOnMast,
        FloorInsulation,
        InsulatedDoors,
        InstantaneousWasteWaterHeatRecovery,
        StorageWasteWaterHeatRecovery,
        AirOrGroundSourceHeatPump,
        AirOrGroundSourceHeatPumpWithUnderfloorHeating,
        MicroCHP
    }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.ImprovementMeasureCode improvementMeasureCode)
{
    switch (improvementMeasureCode)
    {
        case BH.oM.Environment.SAP.ImprovementMeasureCode.LoftInsulation:
            return "A";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.FlatRoofInsulation:
            return "A2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.RoomInRoofInsulation:
            return "A3";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.CavityWallInsulation:
            return "B";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.HotWaterCylinderInsulation:
            return "C";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.Draughtproofing:
            return "D";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.LowEnergyLights:
            return "E";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.CylinderThermostat:
            return "F";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.HeatingControlsForWetCentralHeatingSystem:
            return "G";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.HeatingControlsForWarmAirSystem:
            return "H";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.UpgradeBoiler,SameFuel:
            return "I";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.Biomasboiler:
            return "J";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.BiomasboilerAsAlternativeImprovement:
            return "J2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.BiomassRoomHeaterWithBoiler:
            return "K";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.NewOrReplacementFanAssistedStorageHeaters:
            return "L";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.NewOrReplacementHighHeatRetentionStorageHeaters:
            return "L2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.ReplacementWarmAirUnit:
            return "M";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.SolarWaterHeating:
            return "N";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.ReplacementDoubleGlazedWindows:
            return "O";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.ReplacementDoubleGlazingUnits:
            return "O3";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.SecondaryGlazing:
            return "P";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.SolidWallInsulation:
            return "Q";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.ExternalInsulationWithCavityWallInsulation:
            return "Q2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.CondensingOilBoiler:
            return "R";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.ChangeHeatingToBandAGasCondensingBoiler(NoFuelSwitch):
            return "S";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.ChangeHeatingToBandAGasCondensingBoiler(FuelSwitch):
            return "T";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.FlueGasHeatRecovery:
            return "T2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.Photovoltaics:
            return "U";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.WindTurbine(RoofMounted):
            return "V";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.WindTurbine(OnMast):
            return "V2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.FloorInsulation:
            return "W";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.InsulatedDoors:
            return "X";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.InstantaneousWasteWaterHeatRecovery:
            return "Y";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.StorageWasteWaterHeatRecovery:
            return "Y2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.AirOrGroundSourceHeatPump:
            return "Z1";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.AirOrGroundSourceHeatPumpWithUnderfloorHeating:
            return "Z2";

        case BH.oM.Environment.SAP.ImprovementMeasureCode.MicroCHP:
            return "Z3";

        default:
            return "";
    }
}
*/