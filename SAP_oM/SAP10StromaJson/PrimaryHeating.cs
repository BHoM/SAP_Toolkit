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
    public class PrimaryHeating : BHoMObject
    {
        [Description("")]
        public virtual int ID { get; set; } = 0;

        [Description("")]
        public virtual bool Include { get; set; } = true;

        [Description("")]
        public virtual string Group { get; set; } = null;

        [Description("")]
        public virtual int HeatingCategory { get; set; } = 0;

        [Description("")]
        public virtual string SubHeatingGroup { get; set; } = null;

        [Description("")]
        public virtual int SubHeatingCategory { get; set; } = 0;

        [Description("")]
        public virtual int Source { get; set; } = 0;

        [Description("")]
        public virtual int SAPTableCode { get; set; } = 0;

        [Description("")]
        public virtual string SeasonalEfficiencyOfDomesticBoilersUK { get; set; } = null;

        [Description("")]
        public virtual double Efficiency { get; set; } = 0;

        [Description("")]
        public virtual bool TER { get; set; } = false;

        [Description("")]
        public virtual double WinterEfficiency { get; set; } = 0;

        [Description("")]
        public virtual double SummerEfficiency { get; set; } = 0;

        [Description("")]
        public virtual int Emitter { get; set; } = 0;

        [Description("")]
        public virtual int ControlCode { get; set; } = 0;

        [Description("")]
        public virtual string ControlCodeProductCharacteristicsDatabase { get; set; } = "";

        [Description("")]
        public virtual int Fuel { get; set; } = 0;

        [Description("")]
        public virtual bool HeatingEquipmentTestingAndApprovalsScheme { get; set; } = false;

        [Description("")]
        public virtual Boiler Boiler { get; set; } = null;

        [Description("")]
        public virtual int ElectricityTariff { get; set; } = 0;

        [Description("")]
        public virtual Range Range { get; set; } = null;

        [Description("")]
        public virtual bool OilPump { get; set; } = false;

        [Description("")]
        public virtual bool DelayedStart { get; set; } = false;

        [Description("")]
        public virtual int FuelBurningType { get; set; } = 0;

        [Description("")]
        public virtual bool SeasonalEfficiencyOfDomesticBoilersUK2005 { get; set; } = false;

        [Description("")]
        public virtual bool SeasonalEfficiencyOfDomesticBoilersUK2009 { get; set; } = false;

        [Description("")]
        public virtual bool WinterSummer { get; set; } = false;

        [Description("")]
        public virtual bool MicroCertificationSchemeHeatPump { get; set; } = false;

        [Description("")]
        public virtual CommunityHeating CommunityHeating { get; set; } = null;

        [Description("")]
        public virtual ComplianceHeatingDetails ComplianceHeatingDetails { get; set; } = null;

        [Description("")]
        public virtual HeatPumpOnly HeatPumpOnly { get; set; } = null;

        [Description("")]
        public virtual List<StorageHeater> StorageHeaters { get; set; } = null; 
    }
}
