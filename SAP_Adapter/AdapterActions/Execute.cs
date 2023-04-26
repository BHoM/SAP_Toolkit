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
using System.Text;

using BH.oM.Base;
using BH.oM.Adapter;
using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.XML;
using BH.Engine.Environment.SAP;

using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        public override Output<List<object>, bool> Execute(IExecuteCommand command, ActionConfig actionConfig = null)
        {
            var output = new Output<List<object>, bool>() { Item1 = null, Item2 = false };

            List<object> blah = new List<object>() { RunCommand(command as dynamic) };
            output.Item1 = blah;
            output.Item2 = true;

            return output;
        }

        public async Task<IResultObject> RunCommand(RunAnalysisCommand command)
        {
            string postURL = command.PostURL;
            string xmlData = System.IO.File.ReadAllText(command.fileSettingsInput.Directory + "\\" + command.fileSettingsInput.FileName);
            
            HttpResponseMessage b = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(postURL);
                httpClient.DefaultRequestHeaders.Add("x-api-key", command.APIKey);
                
                var r = new HttpRequestMessage(HttpMethod.Post, postURL);
                r.Content = new StringContent(xmlData, Encoding.UTF8, "application/xml");

                b = await httpClient.SendAsync(r);
            }
                string text = await b.Content.ReadAsStringAsync();

            try
            {
                ResultJson resultjson = JsonSerializer.Deserialize<ResultJson>(text);

                return resultjson;
            }

            catch
            {
                try
                {
                    var tmpFilePath = @"C:\Temp\SAPXML.xml";
                    if (File.Exists(tmpFilePath))
                        File.Delete(tmpFilePath);

                    StreamWriter sw = new StreamWriter(tmpFilePath);
                    sw.WriteLine(text);
                    sw.Close();

                    XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
                    XmlSerializer szer = new XmlSerializer(typeof(SAPReport));
                    TextReader tr = new StreamReader(tmpFilePath);
                    var data = (SAPReport)szer.Deserialize(tr);
                    tr.Close();

                    var destFilePath = Path.Combine(command.fileSettingsOutput.Directory, command.fileSettingsOutput.FileName);
                    File.Copy(tmpFilePath, destFilePath, true);

                    try
                    {
                        File.Delete(tmpFilePath);
                    }
                    catch { }

                    return data;
                }

                catch
                {
                    if(command.fileSettingsOutput == null || string.IsNullOrEmpty(command.fileSettingsOutput.Directory) || string.IsNullOrEmpty(command.fileSettingsOutput.FileName))
                    {
                        BH.Engine.Base.Compute.RecordError("To use this endpoint, add a directory to a .txt file in the RunAnalysisCommand.");
                        return null;
                    }
                    string filePath = command.fileSettingsOutput.Directory + "\\" + command.fileSettingsOutput.FileName;
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.Write(text);
                    sw.Close();
                    ResultText txt = new ResultText();
                    BH.Engine.Base.Compute.RecordNote("You have used the endpoint returning a .txt file. Check your output folder.");
                    txt.txt = filePath;
                    return txt;
                }
            } 
        }
    }
}


