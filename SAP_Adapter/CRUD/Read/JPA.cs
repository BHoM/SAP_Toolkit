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
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter : BHoMAdapter
    {
        public static SAPReport ReadJPA(FileSettings fileSettingsInput)
        {
            CleanJPA(fileSettingsInput);

            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            XmlSerializer szer = new XmlSerializer(typeof(SAPReport));

            TextReader tr = new StreamReader(Path.Combine(fileSettingsInput.Directory, fileSettingsInput.FileName));
            var data = (SAPReport)szer.Deserialize(tr);
            tr.Close();

            return data;
        }

        public static bool CleanJPA(FileSettings fileSettingsInput)
        {
            var path = Path.Combine(fileSettingsInput.Directory, fileSettingsInput.FileName);
            var xmlFile = File.ReadAllLines(path);

            int startIndex = Array.IndexOf(xmlFile, xmlFile.Where(x => x.Contains("<JPA-SAP-Project>")).ToList().FirstOrDefault());
            int endIndex = Array.IndexOf(xmlFile, xmlFile.Where(x => x.Contains("</JPA-SAP-Project>")).ToList().FirstOrDefault());

            if (startIndex != -1 && endIndex != -1)
            {
                var myList = xmlFile.ToList();
                myList.RemoveRange(startIndex, endIndex - startIndex + 1);
                xmlFile = myList.ToArray();

                File.Delete(path); File.WriteAllLines(path, xmlFile);
            }
            
            return true;
        }
    }
}
