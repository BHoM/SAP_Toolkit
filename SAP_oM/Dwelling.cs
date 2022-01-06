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
    [Description("The dwelling")]
    public class Dwelling : BHoMObject
    {
        [Description("Project spec")]
        public virtual ProjectSpecification ProjectSpec { get; set; } = new ProjectSpecification();

        [Description("The storeys that make up the levels of the dwelling")]
        public virtual List<Storey> Storeys { get; set; } = new List<Storey>();

        [Description("The total living area of the dwelling")]
        public virtual double LivingArea { get; set; } = 0.0;

        [Description("The total cooling area of the dwelling")]
        public virtual double CooledArea { get; set; } = 0.0;

        [Description("Walls")]
        public virtual List<SAP.Wall> Walls { get; set; } = new List<SAP.Wall>();

        [Description("Floors")]
        public virtual List<SAP.Floor> Floors { get; set; } = new List<SAP.Floor>();

        [Description("Roofs")]
        public virtual List<SAP.Roof> Roofs { get; set; } = new List<SAP.Roof>();

        [Description("Thermal bridges")]
        public virtual List<SAP.ThermalBridge> ThermalBridges { get; set; } = new List<SAP.ThermalBridge>();
    }
}
