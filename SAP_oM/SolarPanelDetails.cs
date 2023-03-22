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
using System.Xml.Serialization;
using BH.oM.Base;

namespace BH.oM.Environment.SAP
{
    [Description("Solar Panel Details.")]
    public class SolarPanelDetails : BHoMObject
    {
        [Description(".")]
        public virtual TypeOfSolarCollector CollectorType { get; set; } = TypeOfSolarCollector.Unglazed;

        [Description("Zero-loss collector efficiency.")]  
        public virtual string CollectorEfficiencyη0 { get; set; } = null;

        [Description("Heat loss coefficient of collector a1.")]
        public virtual string Coefficienta1 { get; set; } = null;

        [Description("2nd order heat loss coefficient of collector a2.")]
        public virtual string Coefficienta2 { get; set; } = null;

        [Description(".")]
        public virtual string AreaCollector { get; set; } = null;

        [Description(".")]
        public virtual VerticalPitchCode TiltOfCollector { get; set; } = VerticalPitchCode._30Degrees;

        [Description(".")]
        public virtual CompassDirectionCode Orientation { get; set; } = CompassDirectionCode.North;

        [Description(".")]
        public virtual SolarCollectorOvershadingCode Overshading { get; set; } = SolarCollectorOvershadingCode.Modest;

        [Description(".")]
        public virtual string DedicatedSolarStoreVolume { get; set; } = null;


        [Description(".")]
        public virtual bool? IsSolarStoreCombined { get; set; } = null;

        [Description(".")]
        public virtual bool? SolarPoweredPump { get; set; } = null;

        [Description("Is Solar Community.")]
        public virtual bool? IsCommunitySolar { get; set; } = null;
    }
}
