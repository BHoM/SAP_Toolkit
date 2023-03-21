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
    [Description("Code which indicates the type of boiler fuel feed.")]
    public enum HeatingControlCode {
		None = 2699, Boiler_OnlyDHW = 2100, Boiler_NoTimeOrThermostaticControl, Boiler_ProgrammerOnly, Boiler_ThermostatOnly,
        Boiler_ProgrammerAndThermostat, Boiler_ProgrammerAndMoreThanOneThermostat, Boiler_ThermostatAndTRVs = 2113, Boiler_ProgrammerThermostatAndTRVs = 2106, 
		Boiler_TRVsAndBypass = 2111,Boiler_ProgrammerTRVsAndBypass = 2107, Boiler_ProgrammerTRVsAndFlowSwitch, Boiler_ProgrammerTRVsAndEnergyManager, 
		Boiler_TimeAndTempControlByPlumbingAndElectrical, Boiler_TimeAndTempControlByPCDB = 2112, HeatPump_NoTimeOrThermostaticControl = 2201,
		HeatPump_ProgrammerOnly, HeatPump_ThermostatOnly, HeatPump_ProgrammerAndThermostat, HeatPump_ProgrammerAndMoreThanOneThermostat,HeatPump_ThermostatAndTRVs = 2209, 
		HeatPump_ProgrammerThermostatAndTRVs = 2210, HeatPump_ProgrammerTRVsAndBypass = 2206, HeatPump_TimeAndTempControlByPlumbingAndElectrical,
		HeatPump_TimeAndTempControlByPCDB = 2208, HeatNetworks_FlatRateNoThermostaticControl = 2301, HeatNetworks_FlatRateProgrammerOnly = 2302, 
		HeatNetworks_FlatRateThermostatOnly, HeatNetworks_FlatRateProgrammerAndThermostat, HeatNetworks_FlatRateThermostatAndTRVs = 2313, HeatNetworks_FlatRateTRVs = 2307,
        HeatNetworks_FlatRateProgrammerAndTRVs = 2305, HeatNetworks_FlatRateProgrammerAndMoreThanOneThermostat = 2311, HeatNetworks_ChargingSystemThermostatOnly = 2308,
        HeatNetworks_ChargingSystemProgrammerAndThermostat, HeatNetworks_ChargingSystemThermostatAndTRVs = 2314, HeatNetworks_ChargingSystemTRVs = 2310,
        HeatNetworks_ChargingSystemProgrammerAndTRVs = 2306, HeatNetworks_ChargingSystemProgrammerAndMoreThanOneThermostat = 2312,ElectricStorage_Manual = 2401,
        ElectricStorage_Automatic, ElectricStorage_CelectType, ElectricStorage_ControlsForHighHeatRetention, WarmAir_NoTimeOrThermostaticControl = 2501,
        WarmAir_ProgrammerOnly, WarmAir_ThermostatOnly, WarmAir_ProgrammerAndThermostat, WarmAir_ProgrammerAndMoreThanOneThermostat, WarmAir_TimeAndTemperatureZoneControl,
		RooomHeater_NoThermostaticControl = 2601, RooomHeater_ApplianceThermostats, RooomHeater_ProgrammerAndApplianceThermostats, RooomHeater_RoomThermostatsOnly,
		RooomHeater_ProgrammerAndRoomThermostats, Other_NoTimeOrThermostaticControl = 2701, Other_ProgrammerOnly, Other_RoomThermostatOnly, Other_ProgrammerAndRoomThermostat,
        Other_TemperatureZoneControl, Other_TimeAndTemperatureZoneControl
    }
}

/*
 * private static string FromSAPToXML(this BH.oM.Environment.SAP.BoilerFuelFeedCode boilerFuelFeedCode)
{
	switch (boilerFuelFeedCode)
	{
		case BH.oM.Environment.SAP.BoilerFuelFeedCode.Gravity:
			return "1";

		case BH.oM.Environment.SAP.BoilerFuelFeedCode.Manual:
			return "2";

		case BH.oM.Environment.SAP.BoilerFuelFeedCode.Screw:
			return "3";

		case BH.oM.Environment.SAP.BoilerFuelFeedCode.Other:
			return "4";

		default:
			return"";
	}
}

 */

