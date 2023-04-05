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
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "SAP-Thermal-Bridges", IsNullable = false)]
    public class ThermalBridges : IObject
    {
        [Description("Code which indicates how the thermal bridge data has been recorded.")]
        [XmlElement("Thermal-Bridge-Code")]
        public virtual string ThermalBridgeCode { get; set; } = "1";

        [Description("Global y-value for all thermal bridges in watts per square metre per kelvin; only if thermal bridge code is: user defined (global y-value).")]
        [XmlElement(ElementName = "User-Defined-Y-Value")]
        public virtual string UserDefinedYValue { get; set; } = null;

        [Description("Reference to the details of the calculation of the global y-value; only if thermal bridging is user defined global y-value.")]
        [XmlElement(ElementName = "Calculation-Reference")]
        public virtual string CalculationReference { get; set; } = null;

        [Description("Various measurements for each thermal bridge that makes up a particular Building-Part.")]
        [XmlElement(ElementName = "SAP-Thermal-Bridge")]
        public virtual List<ThermalBridge> ThermalBridge { get; set; } = null;
    }
}

