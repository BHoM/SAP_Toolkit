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
using BH.oM.Environment.SAP.Stroma10;

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description("")]
    public class Thermal : BHoMObject
    {
        [Description("")]
        public virtual int Id { get; set; } = 0;

        [Description("")]
        public virtual string Guid { get; set; } = null;

        [Description("")]
        public virtual bool ManualHtb { get; set; } = false;

        [Description("")]
        public virtual double HtbValue { get; set; } = 0;

        [Description("")]
        public virtual object ConstDetails { get; set; } = null;

        [Description("")]
        public virtual bool ManualY { get; set; } = false;

        [Description("")]
        public virtual double YValue { get; set; } = 0;

        [Description("")]
        public virtual bool CustomApproved { get; set; } = false;

        [Description("")]
        public virtual List<ExternalJunction> ExternalJunctions { get; set; } = null;

        [Description("")]
        public virtual List<PartyJunction> PartyJunctions { get; set; } = null;

        [Description("")]
        public virtual List<RoofJunction> RoofJunctions { get; set; } = null;

        [Description("")]
        public virtual bool Reference { get; set; } = false;

        [Description("")]
        public virtual bool Include { get; set; } = false;

        [Description("")]
        public virtual int Type { get; set; } = 0;

        [Description("")]
        public virtual int Location { get; set; } = 0;

        [Description("")]
        public virtual int Connection { get; set; } = 0;
    }
}