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

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description(".")]
    public class Cylinder : BHoMObject
    {
        [Description(".")]
        public virtual int ID
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double Volume
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool ManufacturerSpecified
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual double DeclaredLoss
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Insulation
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double InsulationThickness
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool InHeatedSpace
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool Thermostat
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool PipeWorkInsulated
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual int PipeWorkInsulation
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool Timed
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool SummerImmersion
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual int Immersion
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool ImmersionHeater
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual double HeatPumpExchanger
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual string Manufacturer
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual string Model
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual string CommissioningCertificate
        {
            get;
            set;
        }

        = null;
    }
}