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

namespace BH.oM.Environment.SAP
{
    [Description("Cylinder Specification.")]
    public class CylinderSpecification : BHoMObject
    {
        [Description("Cylinder volume in litres.")]
        public virtual string Volume { get; set; } = null;

        [Description("Only if specified manufacturer loss factor.")]
        public virtual string DeclaredLossFactor { get; set; } = null;

        [Description(".")]
        public virtual DataSourceCode DeclaredLossFactorSource { get; set; } = DataSourceCode.ManufacturerDeclaration;

        [Description(".")]
        public virtual TypeOfHotWaterStoreInsulation InsulationType { get; set; } = TypeOfHotWaterStoreInsulation.FactoryApplied;

        [Description(".")]
        public virtual string InsulationThickness { get; set; } = null;

        [Description(".")]
        public virtual bool InHeatedSpace { get; set; } = false;

        [Description("Has Cylinder Thermostat.")]
        public virtual bool Cylinderstat { get; set; } = false;

        [Description(".")]
        public virtual PipeworkInsulationCode PrimaryPipeworkInsulated { get; set; } = PipeworkInsulationCode.NotInsulated;

        [Description("Only if primary pipework is insulated.")]
        public virtual string InsulatedAmount { get; set; } = null;

        [Description(".")]
        public virtual bool TimedSeperatly { get; set; } = false;

        [Description(".")]
        public virtual Details CyclinderDetails { get; set; } = null;

    }
}
