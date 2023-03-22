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
    [XmlRoot(ElementName = "Storage-WWHRS", IsNullable = false)]
    public class StorageWWHRS : IObject
    {
        [Description(".")]
        [XmlElement("WWHRS-Index-Number.")]
        public virtual string WWHRSIndexNumber { get; set; } = null;

        [Description("Dedicated store volume in litres.")]
        [XmlElement("WWHRS-Store-Volume.")]
        public virtual string WWHRSStoreVolume { get; set; } = null;

        [Description(".")]
        [XmlElement("Storage-WWHRS-Efficiency.")]
        public virtual string StorageWWHRSEfficiency { get; set; } = null;

        [Description(".")]
        [XmlElement("Storage-WWHRS-Manufacturer.")]
        public virtual string StorageWWHRSManufacturer { get; set; } = null;

        [Description(".")]
        [XmlElement("Storage-WWHRS-Model.")]
        public virtual string StorageWWHRSModel { get; set; } = null;

    }
}
