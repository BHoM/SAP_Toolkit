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
    public class InteriorFloor : BHoMObject
    {
        public virtual int ID { get; set; } = 0;
        public virtual string GUID { get; set; } = null;
        public virtual int Type { get; set; } = 0;
        public virtual int Construction { get; set; } = 0;
        public virtual double Area { get; set; } = 0;
        public virtual double UValueStart { get; set; } = 0;
        public virtual double UValue { get; set; } = 0;
        public virtual double ResultantUValue { get; set; } = 0;
        public virtual bool Curtain { get; set; } = false;
        public virtual bool ManualInputKappa { get; set; } = false;
        public virtual double Kappa { get; set; } = 0;
        public virtual List<Dim> Dims { get; set; } = null;
        public virtual int UValueSelectionID { get; set; } = 0;
        public virtual bool UValueSelected { get; set; } = false;
        public virtual string EnergyPerformanceCertificateDescription { get; set; } = null;
        public virtual string LoftInsulation { get; set; } = null;
    }
}
