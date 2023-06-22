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
    [XmlRoot(ElementName = "SAP-Floor-Dimension", IsNullable = false)]
    public class FloorDimension : IObject
    {
        [Description("A name describing the floor dimensioned.")]
        [XmlElement("Name")]
        public virtual string Name { get; set; } = "Floor(1)";

        [Description("Descriptive notes about the floor.")]
        [XmlElement("Description")]
        public virtual string Description { get; set; } = null;

        [Description("Type of floor (exposure).")]
        [XmlElement("Floor-Type")]
        public virtual string Type { get; set; } = "4";

        [Description("Building storey on which the floor is located.")]
        [XmlElement("Storey")]
        public virtual string Storey { get; set; } =  "1";

        [Description("Average height of the storey in metres.")]
        [XmlElement("Storey-Height")]
        public virtual string StoreyHeight { get; set; } = "3";

        [Description("The total floor area of the storey in square metres.")]
        [XmlElement("Total-Floor-Area")]
        public virtual string Area { get; set; } = "0";

        [Description("Heat loss floor U-value.")]
        [XmlElement("U-Value")]
        public virtual string UValue { get; set; } = "0.14";

        [Description("The estimated total heat loss area for the floor in square metres.")]
        [XmlElement("Heat-Loss-Area")]
        public virtual string HeatLossArea { get; set; } = "0";

        [Description("Heat capacity of floor per unit area in kJ/m�K.")]
        [XmlElement("Kappa-Value")]
        public virtual string KappaValue { get; set; } = null;

        [Description("Heat capacity of ceiling below.  Applies to the non-heat-loss area of an upper floor.")]
        [XmlElement("Kappa-Value-From-Below")]
        public virtual string KappaValueFromBelow { get; set; } = null;
    }


}

