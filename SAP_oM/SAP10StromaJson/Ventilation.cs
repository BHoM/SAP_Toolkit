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
    public class Ventilation : BHoMObject
    {
        [Description("")]
        public virtual int Id { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysMain { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysSec { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysOther { get; set; } = 0;

        [Description("")]
        public virtual int Chimneys { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysClosedFire { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysClosedFireMain { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysClosedFireSec { get; set; } = 0;

        [Description("")]
        public virtual int ChimneysClosedFireOther { get; set; } = 0;

        [Description("")]
        public virtual int FluesSolidBoiler { get; set; } = 0;

        [Description("")]
        public virtual int FluesSolidBoilerMain { get; set; } = 0;

        [Description("")]
        public virtual int FluesSolidBoilerSec { get; set; } = 0;

        [Description("")]
        public virtual int FluesSolidBoilerOther { get; set; } = 0;

        [Description("")]
        public virtual int FluesOtherHeater { get; set; } = 0;

        [Description("")]
        public virtual int FluesOtherHeaterMain { get; set; } = 0;

        [Description("")]
        public virtual int FluesOtherHeaterSec { get; set; } = 0;

        [Description("")]
        public virtual int FluesOtherHeaterOther { get; set; } = 0;

        [Description("")]
        public virtual int ChimneyBlocked { get; set; } = 0;

        [Description("")]
        public virtual int FluesMain { get; set; } = 0;

        [Description("")]
        public virtual int FluesSec { get; set; } = 0;

        [Description("")]
        public virtual int FluesOther { get; set; } = 0;

        [Description("")]
        public virtual int Flues { get; set; } = 0;

        [Description("")]
        public virtual int Fans { get; set; } = 0;

        [Description("")]
        public virtual int Vents { get; set; } = 0;

        [Description("")]
        public virtual int Fires { get; set; } = 0;

        [Description("")]
        public virtual double Shelter { get; set; } = 0;

        [Description("")]
        public virtual int MechVent { get; set; } = 0;

        [Description("")]
        public virtual int Parameters { get; set; } = 0;

        [Description("")]
        public virtual int WetRooms { get; set; } = 0;

        [Description("")]
        public virtual int DuctType { get; set; } = 0;

        [Description("")]
        public virtual int DuctSpec { get; set; } = 0;

        [Description("")]
        public virtual int SystemPosition { get; set; } = 0;

        [Description("")]
        public virtual int ProductId { get; set; } = 0;

        [Description("")]
        public virtual bool ApprovedScheme { get; set; } = false;

        [Description("")]
        public virtual bool MeasuredInstallation { get; set; } = false;

        [Description("")]
        public virtual double MeasuredSfp { get; set; } = 0;

        [Description("")]
        public virtual DeCentralised DeCentralised { get; set; } = null;

        [Description("")]
        public virtual MvDetails MvDetails { get; set; } = null;

        [Description("")]
        public virtual int Pressure { get; set; } = 0;

        [Description("")]
        public virtual double DesignAir { get; set; } = 0;

        [Description("")]
        public virtual double AssumedAir { get; set; } = 0;

        [Description("")]
        public virtual double MeasuredAir { get; set; } = 0;

        [Description("")]
        public virtual double MeasuredPulse { get; set; } = 0;

        [Description("")]
        public virtual DateTime DateAir { get; set; } = DateTime.Now;   

        [Description("")]
        public virtual bool AveragePerm { get; set; } = false;

        [Description("")]
        public virtual int ConstructType { get; set; } = 0;

        [Description("")]
        public virtual int LobbyDetail { get; set; } = 0;

        [Description("")]
        public virtual int FloorDetail { get; set; } = 0;

        [Description("")]
        public virtual double Draught { get; set; } = 0;

        [Description("")]
        public virtual bool MultiSystem { get; set; } = false;

        [Description("")]
        public virtual int DuctPlacement { get; set; } = 0;

        [Description("")]
        public virtual ComplianceVent ComplianceVent { get; set; } = null;

        [Description("")]
        public virtual double PressureTestResult { get; set; } = 0;
    }
}
