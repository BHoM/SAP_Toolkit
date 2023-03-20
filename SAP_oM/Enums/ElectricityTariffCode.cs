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
    [Description("Code which indicates the type of electricity tariff.")]
    public enum ElectricityTariffCode { StandardTariff = 1, OffPeak7Hour = 2, OffPeak10Hour = 3, _24Hour = 4, OffPeak18Hour = 5, NotApplicable }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.ElectricityTariffCode electricityTariffCode)
{
	switch (electricityTariffCode)
	{
		case BH.oM.Environment.SAP.ElectricityTariffCode.StandardTariff:
			return "1";

		case BH.oM.Environment.SAP.ElectricityTariffCode.OffPeak7Hour:
			return "2";

		case BH.oM.Environment.SAP.ElectricityTariffCode.OffPeak10Hour:
			return "3";

		case BH.oM.Environment.SAP.ElectricityTariffCode._24Hour:
			return "4";

		case BH.oM.Environment.SAP.ElectricityTariffCode.OffPeak18Hour:
			return "5";

		case BH.oM.Environment.SAP.ElectricityTariffCode.NotApplicable:
			return "ND";

		default:
			return"";
	}
}

 */