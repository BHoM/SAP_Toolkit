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
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BH.Adapter.SAP.Argyle
{
    public partial class ArgyleAdapter : BHoMAdapter
    {
        public static bool CreateArgyle(BH.oM.Environment.SAP.XML.SAPReport data, FileSettings fileSettings)
        {
            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            XmlSerializer szer = new XmlSerializer(typeof(BH.oM.Environment.SAP.XML.SAPReport));

            TextWriter ms = new StreamWriter(Path.Combine(fileSettings.Directory, fileSettings.FileName));
            szer.Serialize(ms, data, xns);
            ms.Close();

            RemoveNil(fileSettings);

            return true;
        }

        private static bool RemoveNil(FileSettings file)
        {
            //Properties with type bool?, if left as null, will serialize to have value xsi:nil, this method removes these
            var path = Path.Combine(file.Directory, file.FileName);
            var xmlFile = File.ReadAllLines(path);

            xmlFile = xmlFile.Where(x => !x.Trim().Contains("xsi:nil")).ToArray();
            xmlFile = xmlFile.Where(x => x != null).ToArray();

            File.Delete(path);
            File.WriteAllLines(path, xmlFile);

            return true;
        }
    }
}
