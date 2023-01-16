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
        [XmlElement("Storey")]
        public virtual int Storey { get; set; } = 0;

        [XmlElement("Description")]
        public virtual string Description { get; set; } = "A dwelling storey";

        [XmlElement("Floor-Type")]
        public virtual string Type { get; set; } = "0";

        [XmlElement("Total-Floor-Area")]
        public virtual double Area { get; set; } = 0;

        [XmlElement("Storey-Height")]
        public virtual double StoreyHeight { get; set; } = 0;

        [XmlElement("Heat-Loss-Area")]
        public virtual double HeatLossArea { get; set; } = 0;

        [XmlElement("U-Value")]
        public virtual double uValue { get; set; } = 0;

        [XmlElement("Kappa-Value")]
        public virtual string KappaValue { get; set; } = null;

        [XmlElement("Kappa-Value-From-Below")]
        public virtual string KappaValueFromBelow { get; set; } = null;//check - null
    }
}

