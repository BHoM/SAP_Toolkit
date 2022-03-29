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
using System.Xml.Serialization;

namespace BH.oM.Environment.SAP.XML
{
    [Description("Details of the means by which the building is ventilated")]
    [Serializable]
    [XmlRoot(ElementName = "SAP-Ventilation", IsNullable = false)]
    public class Ventilation : IObject
    {
        [Description("The number of Open Fireplaces in the Property. An Open Fireplace is a fireplace that still allows air to pass between the inside of the Property and the outside.")]
        [XmlElement("Open-Fireplaces-Count")]
        public virtual string numOpenFireplaces { get; set; } = null;

        [Description("The number of Open Flues in the Property.")]
        [XmlElement("Open-Flues-Count")]
        public virtual string numOpenFlues { get; set; } = null;
        [Description("Do not use, for backwards compatibility only.")]
        [XmlElement("Fans-Vents-Count")]
        public virtual string FansVentCount { get; set; } = null;

        [Description("The number of flueless gas fires in the Property.")]
        [XmlElement("Flueless-Gas-Fires-Count")]
        public virtual string numFluelessGasFires { get; set; } = null;

        [Description("Whether there has been a pressure test, or whether an assumed value is used for the air permeability.")]
        [XmlElement("Pressure-Test")]
        public virtual string PressureTest { get; set; } = null;

        [Description("Air permeability; only if pressure test (yes or assumed).")]
        [XmlElement("Air-Permeability")]
        public virtual string AirPermability { get; set; } = null;

        [Description("The type of ground floor; only if no pressure test.")]
        [XmlElement("Ground-Floor-Type")]
        public virtual string GroundFloorType { get; set; } = null;

        [Description("The construction of the walls; only if no pressure test.")]
        [XmlElement("Wall-Type")]
        public virtual string WallType { get; set; } = null;

        [Description("Is there a draft lobby?  Only if no pressure test.")]
        [XmlElement("Has-Draught-Lobby")]
        public virtual bool? HasDraughtLobby { get; set; } = null;

        [Description("Draughtstripping percentage; only if no pressure test.")]
        [XmlElement("DraughtStripping")]
        public virtual string DraughtStripping { get; set; } = null;

        [Description("The number of sheltered sides in the Property.")]
        [XmlElement("Sheltered-Sides-Count")]
        public virtual string numShelteredSides { get; set; } = null;

        [Description("The type of ventilation.")]
        [XmlElement("Ventilation-Type")]
        public virtual string Type { get; set; } = null;

        [Description("Source of mechanical ventilation data; only if mechanical ventilation.")]
        [XmlElement("Mechanical-Ventilation-Data-Source")]
        public virtual string MechanicalVentilationDataSource { get; set; } = null;

        [Description("Mechanical vent system index number; if mechanical vent data from database (MEV c, MEV dc, MV, MVHR).")]
        [XmlElement("Mechanical-Vent-System-Index-Number")]
        public virtual string MechanicalVentSystemIndexNumber { get; set; } = null;

        [Description("Mechanical ventilation system make and model; if mech vent system data is manufacturer declaration.")]
        [XmlElement("Mechanical-Vent-System-Make-Model")]
        public virtual string MechanicalVentSystemMakeModel { get; set; } = null;

        [Description("Number of wet rooms, including the kitchen; if mech vent data from manufacturer declaration or database (MEV c, MV, MVHR).")]
        [XmlElement("Wet-Rooms-Count")]
        public virtual string numWetRooms { get; set; } = null;

        [Description("Mechanical vent specific fan power in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV c, MV, MVHR).")]
        [XmlElement("Mechanical-Vent-Specific-Fan-Power")]
        public virtual string MechanicalVentSpecificFanPower { get; set; } = null;

        [Description("Mechanical vent heat recovery efficiency percentage; if mechanical vent data from manufacturer declaration (MVHR).")]
        [XmlElement("Mechanical-Vent-Heat-Recovery-Efficiency")]
        public virtual string MechanicalVentHeatRecoveryEfficiency { get; set; } = null;

        [Description("Mechanical vent duct type; if MEV c, MV or MVHR.")]
        [XmlElement("Mechanical-Vent-Duct-Type")]
        public virtual string MechanicalVentDuctType { get; set; } = null;

        [Description("Mechanical vent duct insulation; if MVHR.")]
        [XmlElement("Mechanical-Vent-Duct-Insulation")]
        public virtual string MechanicalVentDuctInsulation { get; set; } = null;

        [Description("MEV dc, number of fans in room, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement("Kitchen-Room-Fans-Count")]
        public virtual int? numKitchenRoomFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement("Kitchen-Room-Fans-Specific-Power")]
        public virtual string KitchenRoomFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans in room, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement("Non-Kitchen-Room-Fans-Count")]
        public virtual int? numNonKitchenRoomFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement("Non-Kitchen-Room-Fans-Specific-Power")]
        public virtual string NonKitchenRoomFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans via duct, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement("Kitchen-Duct-Fans-Count")]
        public virtual int? numKitchenDuctFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans via duct, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement("Kitchen-Duct-Fans-Specific-Power")]
        public virtual string KitchenDuctFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans via duct, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement("Non-Kitchen-Duct-Fans-Count")]
        public virtual int? numNonKitchenDuctFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans via duct, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement("Non-Kitchen-Duct-Fans-Specific-Power")]
        public virtual string NonKitchenDuctFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans through wall, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement("Kitchen-Wall-Fans-Count")]
        public virtual int? numKitchenWallFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans through wall, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement("Kitchen-Wall-Fans-Specific-Power")]
        public virtual string KitchenWallFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans through wall, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement("Non-Kitchen-Wall-Fans-Count")]
        public virtual int? numNonKitchenWallFans { get; set; } = null;

        [Description("MEV dc, specific fan power of fans through wall, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement("Non-Kitchen-Wall-Fans-Specific-Power")]
        public virtual string NonKitchenWallFansSpecificPower { get; set; } = null;

        [Description("Extract-Fans-Count")]
        [XmlElement("")]
        public virtual int? ExtractFansCount { get; set; } = null;

        [Description("")]
        [XmlElement("PSV-Count")]
        public virtual string PSVCount { get; set; } = null;

        [Description("")]
        [XmlElement("Is-Mechanical-Vent-Approved-Installer-Scheme")]
        public virtual bool? IsMechanicalVentApprovedInstallerScheme { get; set; } = null;

        [Description("Mechanical vent ducts index number; if applicable.")]
        [XmlElement("Mechanical-Vent-Ducts-Index-Number")]
        public virtual string MechanicalVentDuctsIndexNumber { get; set; } = null;

        public bool ShouldSerializenumKitchenRoomFans()
        {
            return numKitchenRoomFans.HasValue;
        }
        public bool ShouldSerializenumNonKitchenRoomFans()
        {
            return numNonKitchenRoomFans.HasValue;
        }
        public bool ShouldSerializenumKitchenDuctFans()
        {
            return numKitchenDuctFans.HasValue;
        }
        public bool ShouldSerializenumNonKitchenDuctFans()
        {
            return numNonKitchenDuctFans.HasValue;
        }
        public bool ShouldSerializenumKitchenWallFans()
        {
            return numKitchenWallFans.HasValue;
        }
        public bool ShouldSerializenumNonKitchenWallFans()
        {
            return numNonKitchenWallFans.HasValue;
        }
        public bool ShouldSerializeIsMechanicalVentApprovedInstallerScheme()
        {
            return IsMechanicalVentApprovedInstallerScheme.HasValue;
        }
        public bool ShouldSerializeHasDraughtLobby()
        {
            return HasDraughtLobby.HasValue;
        }
    }
}