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
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.ComponentModel;
using BH.oM.Adapter;
using BH.Engine.Diffing;
using BH.oM.Environment.SAP.XML;
using BH.oM.Environment.SAP;
using BH.Engine.Base;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Environment.Elements;
using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Modify opening type from a SAP report object.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("type", "New type name for the windows.")]
        [Input("include", "A list of openings by name to modify.")]
        [Input("uvalue", "Uvalue for the new type.")]
        [Input("gvalue", "Gvalue for the new type.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport ModifyOpeningTypes(this SAPReport sapObj, string type, List<string> include, double uvalue = -1,  double gvalue = -1)
        {
            //TODO: tolerance
            if ((uvalue < 0) && (gvalue < 0))
            {
                return null;
            }

            if (type == null)
            {
                //TODO
                string name = "";

                //TODO: tolerance
                if (uvalue > 0)
                {
                    name = $"uvalue_{uvalue}_{name}";
                }

                //TODO: tolerance
                if (gvalue > 0)
                {
                    name = $"gvalue_{gvalue}_{name}";
                }

                type = name;
            }

            //Creating a dictionary with the new name of each type as the key, and the original name of the type as the value.
            var dict = include.Select(x => (type + "_" + x)).Zip(include, (v, k) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);

            //TODO: this isn't checking for the right thing
            //Has an iteration with this name been run
            var valid = dict.Select(x => (include.Contains(x.Value))).Any(x => x == true);

            if (valid)
            {
                //TODO: come back to this
                BH.Engine.Base.Compute.RecordError("Please rename your iteration."); 
                return null;
            }

            List<BH.oM.Environment.SAP.XML.OpeningType> openingsList = sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType;

            //Add the new openings to the list of existing openings
            var results = openingsList.InsertOpeningTypes(dict, uvalue, gvalue);


            openingsList = results.Item1;
            Dictionary<string,string> namesAndTypes= results.Item2;


            var includeNames = openingsList.Select( x => new {Key = x.Name, Value = x.Description}).ToDictionary(x => x.Key, x => x.Value);

            //List of existing opening types
            sapObj.SAP10Data.PropertyDetails.OpeningTypes.OpeningType = openingsList;

            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartList = new List<oM.Environment.SAP.XML.BuildingPart>();

            foreach (var b in sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart)
            {
                BH.oM.Environment.SAP.XML.BuildingPart partObj = b;
                List<BH.oM.Environment.SAP.XML.Opening> openingList = new List<oM.Environment.SAP.XML.Opening> ();

                //For each opening, check if it's mentioned in the list and then change it's opening type.
                foreach (var o in b.Openings.Opening)
                {
                    BH.oM.Environment.SAP.XML.Opening openingObj = o;

                    if (include.Contains(includeNames[o.Type]))
                    {
                        openingObj = openingObj.ModifyOpeningType(namesAndTypes[dict[includeNames[o.Type]]]);
                    }

                    openingList.Add(openingObj);
                }

                partObj.Openings.Opening = openingList;
                buildingPartList.Add(partObj);  
            }

            sapObj.SAP10Data.PropertyDetails.BuildingParts.BuildingPart = buildingPartList;

            return sapObj;
        }

        [Description("Insert opening types into the list of existing opening types.")]
        [Input("typeObj", "Existing opening types.")]
        [Input("dict", "Dictionary of opening types to add into existing list.")]
        [Input("uvalue", "uvalue for new type.")]
        [Input("gvalue", "gvalue for new type.")]
        [Output("openingTypes", "The modified SAP openingtypes list.")]
        public static Output<List<BH.oM.Environment.SAP.XML.OpeningType>, Dictionary<string, string>> InsertOpeningTypes(this List<BH.oM.Environment.SAP.XML.OpeningType> typeObj, Dictionary<string, string> dict, double uvalue = -1, double gvalue = -1)
        {   
            //Gets a list of all the existing opening type names
            List<string> typeNames = typeObj.Select(x => x.Description).ToList();

            //
            List<BH.oM.Environment.SAP.XML.OpeningType> newTypes = new List<oM.Environment.SAP.XML.OpeningType>();

            //List of all the types descriptions and the highest number assigned to them
            Dictionary<string,int> counts = typeObj.Select(x => x.Name).ToList().CountOpeningType();

            //A conversion between type of opening and name assigned to them
            Dictionary<string, string> conventions = new Dictionary<string, string>
            {
                { "1", "Doors" },
                { "2", "Doors" },
                { "3", "Doors" },
                { "4", "Windows"},
                { "5", "Roof Windows"},
                { "6", "Roof Windows"}
            };

            Dictionary<string, string> nameAndType = new Dictionary<string, string>();

            //For each type that has been renamed
            foreach (var t in dict)
            {
                //for types that exist
                if (typeNames.Contains(t.Key))
                {
                    //Finds matching type
                    var test = typeObj.Where(x => x.Description == t.Key).ToList();

                    if (test.IsNullOrEmpty())
                    {
                        //TODO: please fix this :(
                        BH.Engine.Base.Compute.RecordError("AHHHHHHHH");
                        continue;
                    }

                    BH.oM.Environment.SAP.XML.OpeningType newOpening = test.FirstOrDefault().ShallowClone();

                    //Figuring out new name for opening
                    var name = conventions[newOpening.Type];
                    if (counts.ContainsKey(name))
                    {
                        counts[name]++;
                    }
                    else
                    {
                        counts[name] = 1;
                    }
                    
                    newOpening.Name = $"{name} ({counts[name]})";
                    newOpening.Description = t.Value;

                    nameAndType.Add(newOpening.Description,newOpening.Name);

                    //TODO: tolerance
                    if (uvalue > 0)
                    {
                        newOpening.UValue = uvalue.ToString();
                    }
                    //TODO: tolerance
                    if (gvalue > 0)
                    {
                        newOpening.gValue = gvalue.ToString();
                    }

                    newTypes.Add(newOpening);
                }
            }
            typeObj = typeObj.Concat(newTypes).ToList();

            Console.WriteLine(nameAndType.Count);
            return new Output<List<BH.oM.Environment.SAP.XML.OpeningType>, Dictionary<string, string>>()
            {
                Item1 = typeObj,
                Item2 = nameAndType
            };
        }

        [Description("Change the opening types of an opening.")]
        [Input("opening", "Opening to modify the type of.")]
        [Input("type", "Type to change to.")]
        [Output("opening", "Modified opening.")]
        public static BH.oM.Environment.SAP.XML.Opening ModifyOpeningType(this BH.oM.Environment.SAP.XML.Opening opening, string type)
        {
            opening.Type = type;
            return opening;
        }

        [Description("Counts how many type of each name is listed.")]
        [Input("openingNames", "List of all opening names.")]
        [Output("openingCount", "A dictionary that counts how many of each type are named.")]
        public static Dictionary<string,int> CountOpeningType(this List<string> openingNames)
        {
            List<(string,int)> val = new List<(string,int)> ();

            foreach (var i in openingNames)
            {
                var start = i.LastIndexOf("(");
                var end = i.LastIndexOf(")");
                var r = end - start - 1;

                try
                {
                    var count = int.Parse(i.Substring(start + 1, r));
                    var t = i.Substring(0, start -1);
                    val.Add((t, count));
                }
                catch(Exception ex)
                {
                    var e = $"Opening type {i} may not be named in convention with the schema";
                    BH.Engine.Base.Compute.RecordWarning(e);
                }
            }

            var res = val.GroupBy(x => x.Item1).Select(x => new { Key = x.Key, Value = x.Select(y => y.Item2).Max() }).ToDictionary(x => x.Key, x => x.Value);
            
            return res;
        }
    }
}