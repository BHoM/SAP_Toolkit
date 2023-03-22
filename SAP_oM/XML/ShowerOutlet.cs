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
    [XmlRoot(ElementName = "Shower-Outlet", IsNullable = false)]
    public class ShowerOutlet : IObject
    {
        [Description("Hot water type for this shower outlet.")]
        [XmlElement(ElementName = "Shower-Outlet-Type.")]
        public virtual string ShowerOutletType { get; set; } = null;

        [Description("The flow rate. Only when a shower is not instantaneous electric. Leave blank if NO flow limiter fitted.")]
        [XmlElement(ElementName = "Shower-Flow-Rate.")]
        public virtual double ShowerFlowRate { get; set; } = 0;

        [Description("The shower power, only if shower outlet type is instantaneous electric.")]
        [XmlElement(ElementName = "Shower-Power.")]
        public virtual double ShowerPower { get; set; } = 0;

        [Description("The WWHRS with which the shower is connected. If shower outlet type is instantaneous electric shower then only a storage WWHRS can be selected or none.")]
        [XmlElement(ElementName = "Shower-WWHRS.")]
        public virtual string ShowerWWHRS { get; set; } = null;
    }
}
