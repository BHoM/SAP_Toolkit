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
    [Description("")]
    public enum TypeOfShowerOutlet { VentedHotWater = 1, VentedHotWaterAndPump = 2, UnventedHotWaterSystem = 3, InstantaneousElectricShower = 4, PartG2015Compliant = 5 }
}

/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfShowerOutlet typeOfShowerOutlet)
{
	switch (typeOfShowerOutlet)
	{
		case BH.oM.Environment.SAP.TypeOfShowerOutlet.VentedHotWater:
			return "1";

		case BH.oM.Environment.SAP.TypeOfShowerOutlet.VentedHotWaterAndPump:
			return "2";

		case BH.oM.Environment.SAP.TypeOfShowerOutlet.UnventedHotWaterSystem:
			return "3";

		case BH.oM.Environment.SAP.TypeOfShowerOutlet.InstantaneousElectricShower:
			return "4";

		case BH.oM.Environment.SAP.TypeOfShowerOutlet.PartG2015Compliant:
			return "5";

		default:
			return"";
	}
}


 */

