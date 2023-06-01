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
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.oM.Environment.SAP.XML

{
    [Description(".")]
    public class Parameters : IObject
    {
        [Description("CurrentIterator name.")]
        public virtual string IterationName { get; set; } = null;

        [Description("List of opening type iterators.")]
        public virtual List<OpeningTypeIterator> OpeningTypes { get; set; } = null;

        [Description("List of opening iterators.")]
        public virtual List<OpeningIterator> Openings { get; set; } = null;

        [Description("List of wall iterators.")]
        public virtual List<WallIterator> Walls { get; set; } = null;

        [Description("Orientation Iterator")]
        public virtual OrientationIterator Orientation { get; set; } = null;

        [Description("List of roof iterators.")]
        public virtual List<RoofIterator> Roofs { get; set; } = null;

        [Description("List of floor iterators.")]
        public virtual List<FloorIterator> Floors { get; set; } = null;

        [Description("TB to change psi values - iterator")]
        public virtual List<ThermalBridgeIterator> ThermalBridges { get; set; } = null;
    }
}


