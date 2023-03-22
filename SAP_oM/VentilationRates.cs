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

namespace BH.oM.Environment.SAP
{
    [Description("Details of the means by which the building is ventilated.")]
    public class VentilationRates : BHoMObject
    {
        [Description("The number of Closed Flues in the Property.")]
        public virtual string ClosedFlues { get; set; } = "0";

        [Description("The number of Open Flues in the Property.")]
        public virtual string OpenFlues { get; set; } = "0";

        [Description("The number of Boiler Flues or chimneys in the Property.")]
        public virtual string BoilerFlues { get; set; } = "0";

        [Description("The number of Other Flues or chimneys in the Property.")]
        public virtual string OtherFlues { get; set; } = "0";

        [Description("The number of Open Chimneys in the Property.")]
        public virtual string OpenChimneys { get; set; } = "0";

        [Description("The number of Blocked Chimneys in the Property.")]
        public virtual string BlockedChimneys { get; set; } = "0";

        [Description("Total amount of fans in the dwelling.")]
        public virtual string FansCount { get; set; } = "0";

        [Description("The number of passive stack vents.")]
        public virtual string PSV { get; set; } = "0";

        
    }
}

