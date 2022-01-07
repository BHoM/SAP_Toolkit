/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
    [Description("Details of the means by which the building is ventilated")]
    public class VentilationRates : BHoMObject
    {
        [Description("The number of Open Fireplaces in the Property. An Open Fireplace is a fireplace that still allows air to pass between the inside of the Property and the outside.")]
        public virtual string OpenFireplaces { get; set; } = null;

        [Description("The number of Open Flues in the Property.")]
        public virtual string OpenFlues { get; set; } = null;

        [Description("Total amount of fans in the dwelling.")]
        public virtual int? FansCount { get; set; } = null;

        [Description("The number of passive stack vents.")]
        public virtual string PSVCount { get; set; } = null;

        [Description("The number of flueless gas fires in the Property.")]
        public virtual string FluelessGasFires { get; set; } = null;
    }
}
