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
using System.Linq;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter : BHoMAdapter
    {
        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
            if (m_Settings.SAPType == oM.Environment.SAP.SAPType.Stroma)
            {
                var objList = objects.Where(x => x is BH.oM.Environment.SAP.Stroma10.Root).Select(x => x as BH.oM.Environment.SAP.Stroma10.Root).ToList();
                objList.ForEach(x => CreateStroma(x, m_Settings.FileSettings.GetFullFileName()));
            }
            if (m_Settings.SAPType == oM.Environment.SAP.SAPType.Argyle)
            {
                var objList = objects.Where(x => x is BH.oM.Environment.SAP.XML.SAPReport).Select(x => x as BH.oM.Environment.SAP.XML.SAPReport).ToList();
                objList.ForEach(x => CreateArgyle(x, m_Settings.FileSettings));

            }
            return true;
        }
    }
}
