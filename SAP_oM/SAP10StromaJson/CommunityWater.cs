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

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description(".")]
    public class CommunityWater : BHoMObject
    {
        [Description(".")]
        public virtual int ID
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool CylinderInDwelling
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual double CHPRatio
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool KnownLossFactor
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual double LossFactor
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double CHPPowerEfficiency
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int HeatDistributionSystem
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int HeatSourceType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double Efficiency
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double Boiler1Fraction
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int ChargingSystem
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool ChargingLinkedToHeatUse
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual int NumberOfAdditionalHeatSources
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool FromDatabase
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual string SystemReference
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual string SubNetworkName
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual bool HeatNetworkExisting
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual int CHPElectricityGeneration
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual List<HeatSource> HeatSources
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual string CommunityHeatingName
        {
            get;
            set;
        }

        = null;
    }
}
