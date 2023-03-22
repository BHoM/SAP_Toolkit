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

/*

//I dont think we need this one right??????
//:( I can't think of a good way to do this rn
//****
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
	[Description("")]
	public enum ConstructionDateCode
	{
		EnglandAndWalesPre1900ScotlandAndNIPre1919, EnglandAndWalesAndSoctlandAndNIPre1930, EnglandAndWalesAndSoctlandAndNIPre1950,
		EnglandAndWales:19301949;
		Scotland:19301949;
		NorthernIreland:19301949 = C, EnglandAndWales:19501966;
		Scotland:19501964;
		NorthernIreland:19501973 = D, EnglandAndWales:19671975;
		Scotland:19651975;
		NorthernIreland:19741977 = E, EnglandAndWales:19761982;
		Scotland:19761983;
		NorthernIreland:19781985 = F, EnglandAndWales:19831990;
		Scotland:19841991;
		NorthernIreland:19861991 = G, EnglandAndWales:19911995;
		Scotland:19921998;
		NorthernIreland:19921999 = H, EnglandAndWales:19962002;
		Scotland:19992002;
		NorthernIreland:20002006 = I, EnglandAndWales:20032006;
		Scotland:20032007;
		NorthernIreland:NotApplicable = J, EnglandAndWales:20072011;
		Scotland:20082011;
		NorthernIreland:20072013 = K, EnglandAndWales:2012Onwards;
		Scotland:2012Onwards;
		NorthernIreland:2014Onwards = L
	}
}



/*
private static string FromSAPToXML(this BH.oM.Environment.SAP.ConstructionDateCode constructionDateCode)
{
	switch (constructionDateCode)
	{
		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:Before1900;
Scotland:Before1919;
NorthernIreland:Before1919:
			return "A";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19001929;
Scotland:19191929;
NorthernIreland:19191929:
			return "B";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19301949;
Scotland:19301949;
NorthernIreland:19301949:
			return "C";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19501966;
Scotland:19501964;
NorthernIreland:19501973:
			return "D";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19671975;
Scotland:19651975;
NorthernIreland:19741977:
			return "E";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19761982;
Scotland:19761983;
NorthernIreland:19781985:
			return "F";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19831990;
Scotland:19841991;
NorthernIreland:19861991:
			return "G";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19911995;
Scotland:19921998;
NorthernIreland:19921999:
			return "H";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:19962002;
Scotland:19992002;
NorthernIreland:20002006:
			return "I";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:20032006;
Scotland:20032007;
NorthernIreland:NotApplicable:
			return "J";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:20072011;
Scotland:20082011;
NorthernIreland:20072013:
			return "K";

		case BH.oM.Environment.SAP.ConstructionDateCode.EnglandAndWales:2012Onwards;
Scotland:2012Onwards;
NorthernIreland:2014Onwards:
			return "L";

		default:
			return"";
	}
}
 */
