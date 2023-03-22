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
    public class DwellingDetails : BHoMObject
    {
        [Description(".")]
        public virtual int ID
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int PropertyType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int AssessmentType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int TransactionType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int TenureType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int RelatedParty
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int ThermalMass
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int IndicativeValue
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double UserThermalMass
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int BuiltForm
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int FlatType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Location
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Terrain
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Orientation
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int SmokeControl
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int OverShading
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Country
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Language
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool SummerOverheating
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool WaterUseLessThan125
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual DateTime DateOfAssessment
        {
            get;
            set;
        }

        = DateTime.Now;
        [Description(".")]
        public virtual DateTime DateOfCertificate
        {
            get;
            set;
        }

        = DateTime.Now;
        [Description(".")]
        public virtual int YearBuilt
        {
            get;
            set;
        }

        = (DateTime.Now.Year);
        [Description(".")]
        public virtual bool RoomInRoof
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual int StoreysInBlock
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool IsGasMeter
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool IsElectricMeter
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool IsCableExport
        {
            get;
            set;
        }

        = false;
    }
}
