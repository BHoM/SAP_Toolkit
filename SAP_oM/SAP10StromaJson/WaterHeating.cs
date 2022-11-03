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
    public class WaterHeating : BHoMObject
    {
        [Description("")]
        public virtual int Id { get; set; } = 0;

        [Description("")]
        public virtual SolarWater SolarWater { get; set; } = null;

        [Description("")]
        public virtual int System { get; set; } = 0;

        [Description("")]
        public virtual int Fuel { get; set; } = 0;

        [Description("")]
        public virtual Cylinder Cylinder { get; set; } = null;

        [Description("")]
        public virtual double CpsuTemp { get; set; } = 0;

        [Description("")]
        public virtual CommunityWater CommunityWater { get; set; } = null;

        [Description("")]
        public virtual Thermal Thermal { get; set; } = null;

        [Description("")]
        public virtual int CombiType { get; set; } = 0;

        [Description("")]
        public virtual Wwhrs Wwhrs { get; set; } = null;

        [Description("")]
        public virtual FlueGasHeatRecovery FlueGasHeatRecovery { get; set; } = null;

        [Description("")]
        public virtual bool DhwVessel { get; set; } = false;

        [Description("")]
        public virtual List<object> ShowerUnits { get; set; } = null;

        [Description("")]
        public virtual int WaterSource { get; set; } = 0;

        [Description("")]
        public virtual int NoBaths { get; set; } = 0;

        [Description("")]
        public virtual string ControllerManufacturer { get; set; } = null;

        [Description("")]
        public virtual string Model { get; set; } = null;
    }
}
