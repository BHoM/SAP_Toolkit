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
    [XmlRoot(ElementName = "Energy-Feature", IsNullable = false)]
    [NoAutoConstructor]
    public class EnergyFeature : SAPXMLObject
    {
        [Description("Energy saved or generated in kWh/year.")]
        [XmlElement("Energy-Saved-Or-Generated")]
        public virtual string EnergySavedOrGenerated { get; set; } = null;
        
        [Description(".")]
        [XmlElement("Saved-Or-Generated-Fuel")]
        public virtual string SavedOrGeneratedFuel { get; set; } = null;

        [Description("Energy used in kWh/year.")]
        [XmlElement("Energy-Used")]
        public virtual string EnergyUsed { get; set; } = null;

        [Description(".")]
        [XmlElement("Energy-Used-Fuel")]
        public virtual string EnergyUsedFuel { get; set; } = null;

        [Description("For Appendix Q procedure that provides air change rates. Only one Special Feature can have data on air change rates.")]
        [XmlElement("Air-Change-Rates")]
        public virtual AirChangeRates AirChangeRates { get; set; } = null;
    }
}
