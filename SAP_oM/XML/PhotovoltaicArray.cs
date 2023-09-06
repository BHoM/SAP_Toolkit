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
using BH.oM.Base.Attributes;

namespace BH.oM.Environment.SAP.XML
{
    [Serializable]
    [XmlRoot(ElementName = "PV-Array", IsNullable = false)]
    [NoAutoConstructor]
    public class PhotovoltaicArray : BHoMObject
    {
        [Description("Peak kW of photovoltaics (PVs) (kWp); 0.0 if none.")]
        [XmlElement("Peak-Power")]
        public virtual string PeakPower { get; set; } = null;

        [Description("PV orientation; only if peak kWp &gt; 0.")]
        [XmlElement("Orientation")]
        public virtual string Orientation { get; set; } = null;

        [Description("PV pitch; only if peak kWp &gt; 0.")]
        [XmlElement("Pitch")]
        public virtual string Pitch { get; set; } = null; //2

        [Description("PV overshading; only if peak kWp &gt; 0.")]
        [XmlElement("Overshading")]
        public virtual string Overshading { get; set; } = null; //2

        [Description(".")]
        [XmlElement("MCS-Certificate")]
        public virtual bool? MCSCertificate { get; set; } = null;

        [Description(".")]
        [XmlElement("MCS-Certificate-Reference")]
        public virtual string MCSCertificateReference { get; set; } = null;

        [Description(".")]
        [XmlElement("PV-Panel-Manufacturer-Name")]
        public virtual string ManufacturerName { get; set; } = null;

        [Description(".")]
        [XmlElement("Overshading-MCS")]
        public virtual string OvershadingMCS { get; set; } = null;
    }
}
