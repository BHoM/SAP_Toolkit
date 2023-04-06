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

using BH.Engine.Base;
using BH.oM.Base;
using BH.oM.Environment.Elements;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.Engine.Units;
using BH.oM.Analytical.Elements;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using System;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

using BH.oM.Environment.SAP;
using BH.oM.Base;
using BH.oM.Adapter;
using System.IO;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        public static bool RemoveNil(this FileSettings file, bool run)
        {
            if (run == false)
            {
                return false;
            }
            var path = file.Directory + "\\" +file.FileName;
            var xmlFile = File.ReadAllLines(path);

            for (int x = 0; x < xmlFile.Length; x++)
            {
                if (xmlFile[x].Trim().Contains("xsi:nil"))
                {
                    xmlFile[x] = null;
                }
   
            }

            File.Delete(path);
            File.WriteAllLines(path, xmlFile);
            return true;
        }
        
    }
}

