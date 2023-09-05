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

using BH.oM.Adapter;
using BH.oM.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BH.Engine.Adapter;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;

namespace BH.Adapter.SAP.Argyle
{
    public partial class ArgyleAdapter : BHoMAdapter
    {
        protected override IEnumerable<IBHoMObject> IRead(Type type, IList ids, ActionConfig actionConfig = null)
        {
            /*ArgyleConfig config = (ArgyleConfig)actionConfig;
            if(config == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Argyle Config to pull with the Argyle Adapter.");
                return new List<IBHoMObject>();
            }*/

            if(type == typeof(SAPReport))
                return new List<IBHoMObject>() { ReadArgyle(m_Settings.FileSettings) };

            return new List<IBHoMObject>();
        }
    }
}
