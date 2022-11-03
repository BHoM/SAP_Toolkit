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
    public class SolarWater : BHoMObject
    {
        [Description("")]
        public virtual int Id { get; set; } = 0;

        [Description("")]
        public virtual bool Include { get; set; } = false;

        [Description("")]
        public virtual int SolarWaterCollectorType { get; set; } = 0;

        [Description("")]
        public virtual bool OverRide { get; set; } = false;

        [Description("")]
        public virtual double SolarZero { get; set; } = 0;

        [Description("")]
        public virtual double SolarHLoss { get; set; } = 0;

        [Description("")]
        public virtual double SolarHLoss2 { get; set; } = 0;

        [Description("")]
        public virtual double SolarArea { get; set; } = 0;

        [Description("")]
        public virtual bool Gross { get; set; } = false;

        [Description("")]
        public virtual int SolarTilt { get; set; } = 0;

        [Description("")]
        public virtual double SolarPitch { get; set; } = 0;

        [Description("")]
        public virtual int SolarOrientation { get; set; } = 0;

        [Description("")]
        public virtual int SolarOverShading { get; set; } = 0;

        [Description("")]
        public virtual double SolarVolume { get; set; } = 0;

        [Description("")]
        public virtual bool SolarSeparate { get; set; } = false;

        [Description("")]
        public virtual bool Pumped { get; set; } = false;

        [Description("")]
        public virtual int ShowerType { get; set; } = 0;

        [Description("")]
        public virtual double NloopDeclared { get; set; } = 0;

        [Description("")]
        public virtual double Nloop { get; set; } = 0;

        [Description("")]
        public virtual double Khem { get; set; } = 0;

        [Description("")]
        public virtual double HlSystem { get; set; } = 0;

        [Description("")]
        public virtual int ServiceProvision { get; set; } = 0;

        [Description("")]
        public virtual object Manufacturer { get; set; } = null;

        [Description("")]
        public virtual object Certificate { get; set; } = null;

    }
}
