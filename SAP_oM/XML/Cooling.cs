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
    [XmlRoot(ElementName = "SAP-Cooling", IsNullable = false)]
    public class Cooling : IObject
    {
        [Description("Cooled-Area")]
        [XmlElement("Cooled-Area")]
        public virtual string CooledArea { get; set; } = null;

        [Description("Cooling-System-Data-Source")]
        [XmlElement("Cooling-System-Data-Source")]
        public virtual string CoolingSystemDataSource { get; set; } = null;

        [Description("Cooling-System-Type")]
        [XmlElement("Cooling-System-Type")]
        public virtual string CoolingSystemType { get; set; } = null;

        [Description("Data set includes either class or EER, not both.")]
        [XmlElement("Cooling-System-Class")]
        public virtual string CoolingSystemClass { get; set; } = null;

        [Description("Energy Efficiency Ratio.  Data set includes either class or EER, not both.")]
        [XmlElement("Cooling-System-EER")]
        public virtual string CoolingSystemEER { get; set; } = null;

        [Description("Cooling-System-Control")]
        [XmlElement("Cooling-System-Control")]
        public virtual string CoolingSystemControl { get; set; } = null;
    }
}

