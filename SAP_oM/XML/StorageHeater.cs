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
    [XmlRoot(ElementName = "Storage-Heater", IsNullable = false)]
    public class StorageHeater : IObject
    {
        [Description("The number of storage heaters with this index number.")]
        [XmlElement("Number-Of-Heaters.")]
        public virtual int NumberOfHeaters { get; set; } = 0;

        [Description("The index number of the heater from the product database.")]
        [XmlElement("Index-Number.")]
        public virtual string IndexNumber { get; set; } = null;

        [Description("Whether heater is high heat retention type.")]
        [XmlElement("High-Heat-Retention.")]
        public virtual bool? HighHeatRetention { get; set; } = null;
    }
}
