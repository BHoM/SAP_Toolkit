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
    [Description("A ThermalBridges object for SAP analysis")]
    public class ThermalBridgeNames : BHoMObject
    {

        [Description("Dwelling name")]
        public virtual string DwellingName { get; set; } = "";

        [Description("Full dwelling name, including window settings and glazing value")]
        public virtual string Reference { get; set; } = "";

        [Description("Dwelling number, resets with each floor")]
        public virtual int ID { get; set; } = 0;

        [Description("Window lintels")]
        public virtual double E2 { get; set; }

        [Description("Window sills")]
        public virtual double E3 { get; set; }

        [Description("Window jambs")]
        public virtual double E4 { get; set; }

        [Description("Party floor")]
        public virtual double E7 { get; set; }

        [Description("Balconies")]
        public virtual double E23 { get; set; }

        [Description("Eaves")]
        public virtual double E10 { get; set; }

        [Description("Roof")]
        public virtual double E15 { get; set; }

        [Description("Corner normal")]
        public virtual double E16 { get; set; }

        [Description("Corner inverted")]
        public virtual double E17 { get; set; }

        [Description("Party wall")]
        public virtual double E18 { get; set; }

        [Description("Staggered something")]
        public virtual double E25 { get; set; }

    }
}


