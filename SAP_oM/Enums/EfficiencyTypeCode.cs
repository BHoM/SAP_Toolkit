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
    [Description(".")]
    public enum TypeOfEfficiency
    {
        NotGasOrOilBoiler = 1,
        SEDBUK2005 = 2,
        SEDBUK2009 = 3,
        WinterAndSummer = 4
    }
}

/*private static string FromSAPToXML(this BH.oM.Environment.SAP.TypeOfEfficiency typeOfEfficiency)
{
	switch (typeOfEfficiency)
	{
		case BH.oM.Environment.SAP.TypeOfEfficiency.NotGasOrOilBoiler:
			return "1";

		case BH.oM.Environment.SAP.TypeOfEfficiency.SEDBUK2005:
			return "2";

		case BH.oM.Environment.SAP.TypeOfEfficiency.SEDBUK2009:
			return "3";

		case BH.oM.Environment.SAP.TypeOfEfficiency.WinterAndSummer:
			return "4";

		default:
			return"";
	}
}

 */
