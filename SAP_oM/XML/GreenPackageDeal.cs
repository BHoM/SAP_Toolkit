/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using BH.oM.Base.Attributes;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "Green-Deal-Improvement", IsNullable = false)]
    [NoAutoConstructor]
    public class GreenPackageDeal : BHoMObject
    {
        [Description(".")]
        [XmlElement(ElementName = "Green-Deal-Improvement")]
        public virtual GreenDealImprovement Improvement { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Electricity-Saving")]
        public virtual Money ElectricitySaving { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Gas-Saving")]
        public virtual Money GasSaving { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Other-Fuel-Saving")]
        public virtual Money OtherFuelSaving { get; set; } = null;


    }
}

