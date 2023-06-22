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
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("An object that holds the main results from a SAPReport.")]
    public class SAPExcelResults : IObject
    {
        [Description("The type of dwelling (the plot reference).")]
        public virtual string Dwelling { get; set; } = null;

        [Description("The name of the iteration file.")]
        public virtual string Iteration { get; set; } = null;

        [Description("The total wall area of the dwelling.")]
        public virtual double WallArea { get; set; } = 0;

        [Description("The total window area of the dwelling.")]
        public virtual double WindowArea { get; set; } = 0;

        [Description("The total floor area of the dwelling..")]
        public virtual double TFA { get; set; } = 0;

        [Description("The DER of the property.")]
        [XmlElement(ElementName = "DER")]
        public virtual string DER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "TER")]
        public virtual string TER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "DPER")]
        public virtual string DPER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "TPER")]
        public virtual string TPER { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "DFEE")]
        public virtual string DFEE { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "TFEE")]
        public virtual string TFEE { get; set; } = null;
    }
}