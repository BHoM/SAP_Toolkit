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
    [XmlRoot(ElementName = "Insurance-Details", IsNullable = false)]
    [NoAutoConstructor]
    public class InsuranceDetails : BHoMObject
    {
        [Description("The name of the insurance company that underwrites / issued the insurance policy.")]
        [XmlElement(ElementName = "Insurer")]
        public virtual string Insurer { get; set; } = null;

        [Description("The policy number of the insurance policy.")]
        [XmlElement(ElementName = "Policy-No")]
        public virtual string PolicyNo { get; set; } = null;

        [Description("The date that the insurance policy becomes effective. In the form yyyy-mm-dd")]
        [XmlElement(ElementName = "Effective-Date")]
        public virtual string EffectiveDate { get; set; } = null;

        [Description("The date that the insurance policy is supposed to expire. In the form yyyy-mm-dd")]
        [XmlElement(ElementName = "Expiry-Date")]
        public virtual string ExpiryDate { get; set; } = null;

        [Description("The upper limit of the Professional Indemnity cover provided by the insurance policy.")]
        [XmlElement(ElementName = "PI-Limit")]
        public virtual Money PILimit { get; set; } = null;

    }
}

