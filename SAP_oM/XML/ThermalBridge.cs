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
    [XmlRoot(ElementName = "SAP-Thermal-Bridge", IsNullable = false)]
    public class ThermalBridge : IObject
    {
        [Description("Code to indicate a particular type of thermal bridge; only if thermal bridge code is: user defined (individual values).")]
        [XmlElement("Thermal-Bridge-Type")]
        public virtual string Type { get; set; } = "E2"; //check - null values for file

        [Description("Length of the thermal bridge in metres; only if thermal bridge code is: user defined (individual values).")]
        [XmlElement("Length")]
        public virtual double Length { get; set; } = 0;

        [Description("Linear thermal transmittance (psi-value); only if thermal bridging is user defined individual values.")]
        [XmlElement("Psi-Value")]
        public virtual double PsiValue { get; set; } = 0;

        [Description("")]
        [XmlElement("Psi-Value-Source")]
        public virtual string PsiSource { get; set; } = "4";

        [Description("Reference to the details of the calculation of the psi-value.")]
        [XmlElement("Psi-Value-Calculation-Reference")]
        public virtual string CalculationReference { get; set; }
    }
}

