/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
    [Description("")]
    public class Parametrics : BHoMObject
    {
        [Description("Default thermal bridges y-value")]
        public virtual double Yvalue { get; set; } = 0;

        public virtual string SunlightShade { get; set; } = "";

        public virtual string CurtainType { get; set; } = "";

        public virtual int CurtainsClosed { get; set; } = 0;

        public virtual string WindowsOpen { get; set; } = "";

        public virtual int AirChangeRate { get; set; } = 0;

        public virtual double WallUValue { get; set; } = 0;

        public virtual double GlazUValue { get; set; } = 0;

        public virtual double GValue { get; set; } = 0;

        public virtual double FloorUValue { get; set; } = 0;

        public virtual double RoofUValue { get; set; } = 0;

        public virtual double Q50 { get; set; } = 0;

        public virtual string MechVentType { get; set; } = "";


        public virtual double AddRotation { get; set; } = 0;

        public virtual string System { get; set; } = "";

        public virtual bool CalculateThermalBridges { get; set; } = false;

        
        //public virtual Dictionary MVHRWeetrooms { get; set; };
        //public virtual Dictionary MEVWeetrooms { get; set; };
        //public virtual Dictionary System { get; set; };

    }
}