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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Environment.SAP
{
    [Description("Set up configuration settings for pulling from Bluebeam SAP markups.")]
    public class BluebeamConfig : BHoMObject
    {
        [Description("What is the layer name used in the Bluebeam SAP markups to define openings.")]
        public virtual string OpeningLayerName { get; set; } = "Openings";

        [Description("What is the layer name used in the Bluebeam SAP markups to define walls (external or internal).")]
        public virtual string WallLayerName { get; set; } = "External Walls";

        [Description("What is the layer name used in the Bluebeam SAP markups to define roofs.")]
        public virtual string RoofLayerName { get; set; } = "Roofs";

        [Description("What is the layer name used in the Bluebeam SAP markups to define floor areas.")]
        public virtual string FloorLayerName { get; set; } = "Floor Areas";

        [Description("What is the layer name used in the Bluebeam SAP markups to define thermal bridging.")]
        public virtual string ThermalBridgeLayerName { get; set; } = "Thermal Bridging";

        [Description("What is the layer name used in the Bluebeam SAP markups to define living zones.")]
        public virtual string LivingAreaLayerName { get; set; } = "Zone 1";
    }
}