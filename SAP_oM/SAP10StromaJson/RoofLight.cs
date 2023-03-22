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
using BH.oM.Environment.SAP.Stroma10;

namespace BH.oM.Environment.SAP.Stroma10
{
    [Description("Roof Openings.")]
    public class RoofLight : BHoMObject
    {
        [Description(".")]
        public virtual int ID
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual string Guid
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual string Location
        {
            get;
            set;
        }

        = null;
        [Description(".")]
        public virtual int UValueSource
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
        public virtual int OverShading
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int GlazingType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int AirGap
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int FrameType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int ThermalBreak
        {
            get;
            set;
        }

        = 0;
        [Description("Area of roof opening m2.")]
        public virtual double Area
        {
            get;
            set;
        }

        = 0;
        [Description("Width of roof opening mm.")]
        public virtual int Width
        {
            get;
            set;
        }

        = 0;
        [Description("Height of roof opening mm.")]
        public virtual int Height
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int Count
        {
            get;
            set;
        }

        = 0;
        [Description("Overhang width of roof opening mm.")]
        public virtual int OverhangWidth
        {
            get;
            set;
        }

        = 0;
        [Description("Overhang depth of roof opening mm.")]
        public virtual int OverhangDepth
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int CurtainType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double FractionClosed
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double Transmittance
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double FrameFactor
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double UValue
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool FromXml
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual int OpeningType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual int DoorType
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual double Pitch
        {
            get;
            set;
        }

        = 0;
        [Description(".")]
        public virtual bool PitchKnown
        {
            get;
            set;
        }

        = false;
        [Description(".")]
        public virtual bool IsArgonFilled
        {
            get;
            set;
        }

        = false;
    }
}
