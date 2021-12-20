﻿/*
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
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Description("Details of the means by which the building is ventilated")]
    [Serializable]
    [XmlRoot(ElementName = "SAP-Ventilation", IsNullable = false)]
    public class Ventilation : IObject
    {
        [Description("The number of Open Fireplaces in the Property. An Open Fireplace is a fireplace that still allows air to pass between the inside of the Property and the outside.")]
        public virtual string numOpenFireplaces { get; set; } = null;

        [Description("The number of Open Flues in the Property.")]
        public virtual string numOpenFlues { get; set; } = null;

        [Description("The number of flueless gas fires in the Property.")]
        public virtual string numFluelessGasFires { get; set; } = null;

        [Description("Whether there has been a pressure test, or whether an assumed value is used for the air permeability.")]
        public virtual string PressureTest { get; set; } = null;

        [Description("Air permeability; only if pressure test (yes or assumed).")]
        public virtual string AirPermability { get; set; } = null;

        [Description("The type of ground floor; only if no pressure test.")]
        public virtual string GroundFloorType { get; set; } = null;

        [Description("The construction of the walls; only if no pressure test.")]
        public virtual string WallType { get; set; } = null;

        [Description("Is there a draft lobby?  Only if no pressure test.")]
        public virtual bool? HasDraughtLobby { get; set; } = null;

        [Description("Draughtstripping percentage; only if no pressure test.")]
        public virtual string DraughtStripping { get; set; } = null;

        [Description("The number of sheltered sides in the Property.")]
        public virtual string numShelteredSides { get; set; } = null;

        [Description("The type of ventilation.")]
        public virtual string Type { get; set; } = null;

        [Description("Source of mechanical ventilation data; only if mechanical ventilation.")]
        public virtual string MechanicalVentilationDataSource { get; set; } = null;

        [Description("Mechanical vent system index number; if mechanical vent data from database (MEV c, MEV dc, MV, MVHR).")]
        public virtual string MechanicalVentSystemIndexNumber { get; set; } = null;

        [Description("Mechanical ventilation system make and model; if mech vent system data is manufacturer declaration.")]
        public virtual string MechanicalVentSystemMakeModel { get; set; } = null;

        [Description("Number of wet rooms, including the kitchen; if mech vent data from manufacturer declaration or database (MEV c, MV, MVHR).")]
        public virtual string numWetRooms { get; set; } = null;

        [Description("Mechanical vent specific fan power in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV c, MV, MVHR).")]
        public virtual string MechanicalVentSpecificFanPower { get; set; } = null;

        [Description("Mechanical vent heat recovery efficiency percentage; if mechanical vent data from manufacturer declaration (MVHR).")]
        public virtual string MechanicalVentHeatRecoveryEfficiency { get; set; } = null;

        [Description("Mechanical vent duct type; if MEV c, MV or MVHR.")]
        public virtual string MechanicalVentDuctType { get; set; } = null;

        [Description("Mechanical vent duct insulation; if MVHR.")]
        public virtual string MechanicalVentDuctInsulation { get; set; } = null;

        [Description("MEV dc, number of fans in room, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int? numKitchenRoomFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string KitchenRoomFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans in room, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int? numNonKitchenRoomFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string NonKitchenRoomFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans via duct, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int? numKitchenDuctFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans via duct, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string KitchenDuctFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans via duct, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int? numNonKitchenDuctFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans via duct, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string NonKitchenDuctFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans through wall, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int? numKitchenWallFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans through wall, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string KitchenWallFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans through wall, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        public virtual int? numNonKitchenWallFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans through wall, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        public virtual string NonKitchenWallFansSpecificPower { get; set; } = null;

        [Description("")]
        public virtual int? ExtractFansCount { get; set; } = null;

        [Description("")]
        public virtual string PSVCount { get; set; } = null;

        [Description("")]
        public virtual bool? IsMechanicalVentApprovedInstallerScheme { get; set; } = null;

        [Description("Mechanical vent ducts index number; if applicable.")]
        public virtual string MechanicalVentDuctsIndexNumber { get; set; } = null;
    }
}