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
using System.IO;
using System.Text;
using System.Linq;
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Base;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Serialization;
using System.ComponentModel;
using BH.oM.Base.Attributes;
using BH.oM.Adapter;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        [Description("Converting a SAP object to an XML files.")] 
        [Input("data", "A SAPReport object to convert to an xml file.")]
        [Input("fileSettings", "Location of the XML files to push from.")]
        [Input("run", "Run the method.")]
        [Output("success","Has the method run.")]
        public static bool PushToXML(BH.oM.Environment.SAP.XML.SAPReport data, FileSettings fileSettings, bool run = false)
        {

            if (!run)
                return false;

            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            XmlSerializer szer = new XmlSerializer(typeof(BH.oM.Environment.SAP.XML.SAPReport));

            TextWriter ms = new StreamWriter(Path.Combine(fileSettings.Directory, fileSettings.FileName));
            szer.Serialize(ms, data, xns);
            ms.Close();

            return true;
        }
    }
}
