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
using System.Xml.Serialization;
using BH.oM.Base.Attributes;

namespace BH.oM.Environment.SAP.XML
{
    [Description("Details of the means by which the building is ventilated.")]
    [Serializable]
    [XmlRoot(ElementName = "SAP-Ventilation", IsNullable = false)]
    [NoAutoConstructor]
    public class Ventilation : SAPXMLObject
    {
        [Description("The number of Closed Flues or chimneys in the Property.")]
        [XmlElement(ElementName = "Closed-Flues-Count")]
        public virtual string ClosedFluesCount { get; set; } = null;

        [Description("The number of Boiler Flues or chimneys in the Property.")]
        [XmlElement(ElementName = "Boilers-Flues-Count")]
        public virtual string BoilerFluesCount { get; set; } = null;

        [Description("The number of Other Flues or chimneys in the Property.")]
        [XmlElement(ElementName = "Other-Flues-Count")]
        public virtual string OtherFluesCount { get; set; } = null;

        [Description("The number of Open Chimneys in the Property.")]
        [XmlElement(ElementName = "Open-Chimneys-Count")]
        public virtual string OpenChimneysCount { get; set; } = null;

        [Description("The number of Blocked Chimneys in the Property.")]
        [XmlElement(ElementName = "Blocked-Chimneys-Count")]
        public virtual string BlockedChimneysCount { get; set; } = null;

        [Description("The number of Open Flues in the Property.")]
        [XmlElement(ElementName = "Open-Flues-Count")]
        public virtual string OpenFluesCount { get; set; } = null;

        [Description(".")]
        [XmlElement(ElementName = "Extract-Fans-Count")]
        public virtual string ExtractFansCount { get; set; } = null;

        [Description("The number of passive stack vents.")]
        [XmlElement(ElementName = "PSV-Count")]
        public virtual string PSVCount { get; set; } = null;

        [Description("Do not use, for backwards compatibility only.")]
        [XmlElement("Fans-Vents-Count")]
        public virtual string FansVentCount { get; set; } = null;

        [Description("The number of flueless gas fires in the Property.")]
        [XmlElement(ElementName = "Flueless-Gas-Fires-Count")]
        public virtual string FluelessGasFiresCount { get; set; } = null;

        [Description("The number of sheltered sides in the Property.")]
        [XmlElement(ElementName = "Sheltered-Sides-Count")]
        public virtual string ShelteredSidesCount { get; set; } = null;

        [Description("Whether there has been a pressure test, or whether an assumed value is used for the air permeability.")]
        [XmlElement(ElementName = "Pressure-Test")]
        public virtual string PressureTest { get; set; } = null;//3

        [Description("Whether there has been a pressure test, or whether an assumed value is used for the air permeability.")]
        [XmlElement(ElementName = "Pressure-Test-Certificate-Number")]
        public virtual string PressureTestCertificateNumber { get; set; } = null;

        [Description("Air permeability; only if pressure test (yes or assumed).")]
        [XmlElement(ElementName = "Air-Permeability")]
        public virtual string AirPermeability { get; set; } = null;

        [Description("Is there a draft lobby?  Only if no pressure test.")]
        [XmlElement(ElementName = "Has-Draught-Lobby")]
        public virtual bool? HasDraughtLobby { get; set; } = false;

        [Description("Draughtstripping percentage; only if no pressure test.")]
        [XmlElement("DraughtStripping")]
        public virtual string DraughtStripping { get; set; } = null;

        [Description("Source of mechanical ventilation data; only if mechanical ventilation.")]
        [XmlElement(ElementName = "Mechanical-Ventilation-Data-Source")]
        public virtual string MechanicalVentilationDataSource { get; set; } = null; //2

        [Description("Mechanical vent system index number; if mechanical vent data from database (MEV c, MEV dc, MV, MVHR).")]
        [XmlElement(ElementName = "Mechanical-Vent-System-Index-Number")]
        public virtual string MechanicalVentSystemIndexNumber { get; set; } = null;

        [Description("Mechanical ventilation Commissioning certificate number.")]
        [XmlElement(ElementName = "Mechanical-Vent-Comissioning-Certificate-Number")]
        public virtual string MechanicalVentComissioningCertificateNumber { get; set; } = null;

        [Description("Mechanical ventilation installation engineer registration reference.")]
        [XmlElement(ElementName = "Mechanical-Vent-Installation-Engineer")]
        public virtual string MechanicalVentInstallationEngineer { get; set; } = null;

        [Description("Mechanical ventilation system make and model.")]
        [XmlElement(ElementName = "Mechanical-Vent-System-Make-Model")]
        public virtual string MechanicalVentSystemMakeModel { get; set; } = null;

        [Description("Number of wet rooms, including the kitchen; if mech vent data from manufacturer declaration or database (MEV c, MV, MVHR).")]
        [XmlElement(ElementName = "Wet-Rooms-Count")]
        public virtual string WetRoomsCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Mechanical-Vent-Specific-Fan-Power")]
        public virtual string MechanicalVentSpecificFanPower { get; set; } = null;

        [Description("Mechanical vent heat recovery efficiency percentage; if mechanical vent (MVHR).")]
        [XmlElement(ElementName = "Mechanical-Vent-Heat-Recovery-Efficiency")]
        public virtual string MechanicalVentHeatRecoveryEfficiency { get; set; } = null;

        [Description("Mechanical vent duct type; if MEV c, MV or MVHR.")]
        [XmlElement(ElementName = "Mechanical-Vent-Duct-Type")]
        public virtual string MechanicalVentDuctType { get; set; } = null;

        [Description("Mechanical vent duct insulation; if MVHR.")]
        [XmlElement(ElementName = "Mechanical-Vent-Duct-Insulation")]
        public virtual string MechanicalVentDuctInsulation { get; set; } = null;

        [Description("Mechanical vent duct insulation; if MVHR.")]
        [XmlElement(ElementName = "Mechanical-Vent-Duct-Insulation-Level")]
        public virtual string MechanicalVentDuctInsulationLevel { get; set; } = null;

        [Description("Mechanical ventilation duct insulation; if MVHR.")]
        [XmlElement(ElementName = "Mechanical-Vent-Duct-Placement")]
        public virtual string MechanicalVentDuctPlacement { get; set; } = null;

        [Description("Mechanical ventilation SPF measured in situ; if MVHR or balanced.")]
        [XmlElement(ElementName = "Mechanical-Vent-Measured-Installation")]
        public virtual bool? MechanicalVentMeasuredInstallation { get; set; } = null;

        [Description("MEV dc, number of fans in room, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Kitchen-Room-Fans-Count")]
        public virtual string KitchenRoomFansCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Kitchen-Room-Fans-Specific-Power")]
        public virtual string KitchenRoomFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans in room, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Non-Kitchen-Room-Fans-Count")]
        public virtual string NonKitchenRoomFansCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans in room, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Non-Kitchen-Room-Fans-Specific-Power")]
        public virtual string NonKitchenRoomFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans via duct, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Kitchen-Duct-Fans-Count")]
        public virtual string KitchenDuctFansCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans via duct, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Kitchen-Duct-Fans-Specific-Power")]
        public virtual string KitchenDuctFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans via duct, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Non-Kitchen-Duct-Fans-Count")]
        public virtual string NonKitchenDuctFansCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans via duct, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Non-Kitchen-Duct-Fans-Specific-Power")]
        public virtual string NonKitchenDuctFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans through wall, kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Kitchen-Wall-Fans-Count")]
        public virtual string KitchenWallFansCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans through wall, kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Kitchen-Wall-Fans-Specific-Power")]
        public virtual string KitchenWallFansSpecificPower { get; set; } = null;

        [Description("MEV dc, number of fans through wall, rooms other than kitchen; if mechanical vent data from database or manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Non-Kitchen-Wall-Fans-Count")]
        public virtual string NonKitchenWallFansCount { get; set; } = null;

        [Description("MEV dc, specific fan power of fans through wall, rooms other than kitchen, in watts per (litres per second); if mechanical vent data from manufacturer declaration (MEV dc).")]
        [XmlElement(ElementName = "Non-Kitchen-Wall-Fans-Specific-Power")]
        public virtual string NonKitchenWallFansSpecificPower { get; set; } = null;

        [Description(".")]
        [XmlElement("Is-Mechanical-Vent-Approved-Installer-Scheme")]
        public virtual bool? IsMechanicalVentApprovedInstallerScheme { get; set; } = null;

        [Description("Mechanical vent ducts index number; if applicable.")]
        [XmlElement("Mechanical-Vent-Ducts-Index-Number")]
        public virtual string MechanicalVentDuctsIndexNumber { get; set; } = null;

        [Description("The type of ventilation.")]
        [XmlElement(ElementName = "Ventilation-Type")]
        public virtual string VentilationType { get; set; } = null; //1

        [Description("The type of ground floor; only if no pressure test.")]
        [XmlElement("Ground-Floor-Type")]
        public virtual string GroundFloorType { get; set; } = null; //1

        [Description("The construction of the walls; only if no pressure test.")]
        [XmlElement("Wall-Type")]
        public virtual string WallType { get; set; } = null;

        /*

        public virtual bool ShouldSerializenumKitchenRoomFans()
        {
            return numKitchenRoomFans.HasValue;
        }
        public virtual bool ShouldSerializenumNonKitchenRoomFans()
        {
            return numNonKitchenRoomFans.HasValue;
        }
        public virtual bool ShouldSerializenumKitchenDuctFans()
        {
            return numKitchenDuctFans.HasValue;
        }
        public virtual bool ShouldSerializenumNonKitchenDuctFans()
        {
            return numNonKitchenDuctFans.HasValue;
        }
        public virtual bool ShouldSerializenumKitchenWallFans()
        {
            return numKitchenWallFans.HasValue;
        }
        public virtual bool ShouldSerializenumNonKitchenWallFans()
        {
            return numNonKitchenWallFans.HasValue;
        }
        public virtual bool ShouldSerializeIsMechanicalVentApprovedInstallerScheme()
        {
            return IsMechanicalVentApprovedInstallerScheme.HasValue;
        }
        public virtual bool ShouldSerializeHasDraughtLobby()
        {
            return HasDraughtLobby.HasValue;
        }

        */
    }
}
