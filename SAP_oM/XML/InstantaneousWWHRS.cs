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
    [XmlRoot(ElementName = "Instantaneous-WWHRS", IsNullable = false)]
    public class InstantaneousWWHRS : IObject
    {
        [Description(".")]
        [XmlElement("WWHRS-Index-Number1")]
        public virtual string WWHRSIndexNumber1 { get; set; } = null;

        [Description("Omit if no second system.")]
        [XmlElement("WWHRS-Index-Number2")]
        public virtual string WWHRSIndexNumber2 { get; set; } = null;

        [Description(".")]
        [XmlElement("WWHRS-Efficiency1")]
        public virtual string WWHRSEfficiency1 { get; set; } = null;

        [Description("Omit if no second system.")]
        [XmlElement("WWHRS-Manufacturer1")]
        public virtual string WWHRSManufacturer1 { get; set; } = null;

        [Description(".")]
        [XmlElement("WWHRS-Model1")]
        public virtual string WWHRSModel1 { get; set; } = null;

        [Description(".")]
        [XmlElement("WWHRS-Efficiency2")]
        public virtual string WWHRSEfficiency2 { get; set; } = null;

        [Description("Omit if no second system.")]
        [XmlElement("WWHRS-Manufacturer2")]
        public virtual string WWHRSManufacturer2 { get; set; } = null;

        [Description(".")]
        [XmlElement("WWHRS-Model2")]
        public virtual string WWHRSModel2 { get; set; } = null;


    }
}
