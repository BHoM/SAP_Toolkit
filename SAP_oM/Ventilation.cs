/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
    [Description("Details of the means by which the building is ventilated")]
    public class Ventilation : BHoMObject
    {
<<<<<<< HEAD
        [Description("The number of sheltered sides in the Property. Min/max 0/4.")]
        public virtual string numShelteredSides { get; set; } = "0";

        [Description("The ventilation rates of the dwelling.")]
        public virtual VentilationRates VentilationRates { get; set; } = new VentilationRates();

        [Description("Details about the air permability and whether a pressure test has been made.")]
        public virtual AirPermability AirPermability { get; set; } = new AirPermability();

        [Description("The ventilation strategy for the dwelling.")]
        public virtual VentilationStrategy VentilationStrategy { get; set; } = new VentilationStrategy();

=======
        [Description("The number of Open Fireplaces in the Property. An Open Fireplace is a fireplace that still allows air to pass between the inside of the Property and the outside.")]
        public virtual string numOpenFireplaces { get; set; } = "0";

        [Description("The number of Open Flues in the Property.")]
        public virtual string numOpenFlues { get; set; } = "0";

        [Description("The number of flueless gas fires in the Property.")]
        public virtual string numFluelessGasFires { get; set; } = "0";

        [Description("Whether there has been a pressure test, or whether an assumed value is used for the air permeability.")]
        public virtual PressureTest PressureTest { get; set; } = new PressureTest(); //Enum

        [Description("The number of sheltered sides in the Property.")]
        public virtual string numShelteredSides { get; set; } = "2";

        [Description("The type of ventilation.")] //Enum, probably a component enum done
        public virtual VentilationType Type { get; set; } = new VentilationType();

        [Description("")]
        public virtual string PSVCount { get; set; } = "0"; //maybe separate 

        [Description("")]
        public virtual bool IsMechanicalVentApprovedInstallerScheme { get; set; } = true; //maybe separate 

        [Description("Mechanical vent ducts index number; if applicable.")]
        public virtual string MechanicalVentDuctsIndexNumber { get; set; } = "2"; //maybe separate 
>>>>>>> 021cc72 (initial code)
    }
}