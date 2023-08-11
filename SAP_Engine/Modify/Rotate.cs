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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;

using System.ComponentModel;

using BH.Engine.Base;
using System.IO;
using BH.oM.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP.XML;
using System.Runtime.InteropServices.ComTypes;
using BH.oM.Adapter.Commands;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Mirror a sap dwelling.")]
        [Input("sapObj", "Input the SAPReport object to modify.")]
        [Input("rotation", "How much the dwelling is rotated by.")]
        [Output("sapReport", "The mirrored report.")]
        public static SAPReport RotateDwelling(this SAPReport sapObj, string rotation)
        {
            //Null sapObj input
            if (sapObj == null)
            {
                BH.Engine.Base.Compute.RecordError("No sap object inputted to mirror.");
                return null;
            }

            if (rotation == null)
            {
                return sapObj;
            }

            BH.oM.Environment.SAP.XML.PropertyDetails propertyDetailsObj = sapObj.SAP10Data.PropertyDetails;

            //Rotate the orientation of the dwelling if the orientation of the dwelling is not null
            if (propertyDetailsObj.Orientation != null)
            {
                string orientation = propertyDetailsObj.Orientation.RotateOrientation(rotation);

                propertyDetailsObj.Orientation = orientation;
            }
            else
            {
                BH.Engine.Base.Compute.RecordError("Please input an orientation for the dwelling.");
            }

            //Rotate the PV in EnergySource
            if (propertyDetailsObj.EnergySource != null && propertyDetailsObj.EnergySource.PhotovoltaicArrays != null && propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray != null)
            {
                //List of existing PVArrays in Energy source
                List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> PVArrays = propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray;

                //Assign the list of modified arrays to the property details obj
                propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray = PVArrays.RotatePV(rotation);
            }

            //Rotate the PV in MainHeating
            //Checking if Mainheating object is defined and if it isn't: side eye
            if (propertyDetailsObj.Heating != null && propertyDetailsObj.Heating.MainHeatingDetails != null && propertyDetailsObj.Heating.MainHeatingDetails.MainHeating != null)
            {
                //List of existing heating systems in report
                List<MainHeating> heatingObjs = propertyDetailsObj.Heating.MainHeatingDetails.MainHeating;

                //For each heating system
                foreach (var heating in heatingObjs)
                {
                    //Check if pv is defined in the report
                    if (heating.FGHRSEnergySource != null && heating.FGHRSEnergySource.PhotovoltaicArrays != null && heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray != null)
                    {
                        //A list of existing PV arrays in the Main Heating section
                        List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> fghrsPVArrays = heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray;

                        heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray = fghrsPVArrays.RotatePV(rotation);
                    }
                }
                propertyDetailsObj.Heating.MainHeatingDetails.MainHeating = heatingObjs;
            }

            sapObj.SAP10Data.PropertyDetails = propertyDetailsObj.RotateOpening(rotation);

            return sapObj;
        }

        [Description("Modify the orientation of the openings.")]
        [Input("propertyDetailsObj", "PropertyDetails object to modify the openings within.")]
        [Input("rotation", "Line to rotate across.")]
        [Output("propertyDetails", "Modified openings contained in the property details object.")]
        public static BH.oM.Environment.SAP.XML.PropertyDetails RotateOpening(this BH.oM.Environment.SAP.XML.PropertyDetails propertyDetailsObj, string rotation)
        {
            //Rotate each opening in the dwelling
            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartObj = propertyDetailsObj.BuildingParts.BuildingPart;
            List<BH.oM.Environment.SAP.XML.OpeningType> types = propertyDetailsObj.OpeningTypes.OpeningType;

            //Dictionary for the conversion between the name of the type given by the user and the name of the opening that matches the schema.
            Dictionary<string, string> typeMap = types.Select(x => new { Key = x.Name, Value = x.Description }).ToDictionary(x => x.Key, x => x.Value);

            foreach (var b in buildingPartObj)
            {
                //List of existing openings
                List<BH.oM.Environment.SAP.XML.Opening> openingObjs = b.Openings.Opening;
                foreach (var o in openingObjs)
                {
                    if (o.Orientation == "0" || o.Orientation == "9")
                    {
                        continue;
                    }

                    //Find the new orientation of the opening
                    string orientation = o.Orientation.RotateOrientation(rotation);

                    //Changing orientation
                    o.Orientation = orientation;
                }
                b.Openings.Opening = openingObjs;
            }

            propertyDetailsObj.BuildingParts.BuildingPart = buildingPartObj;

            return propertyDetailsObj;
        }


        [Description("Modify the orientation of the PV.")]
        [Input("PVArrays", "List of photovoltaic arrays to modify the orientation of.")]
        [Input("rotateLine", "Line to rotate across.")]
        [Output("PVarrayObject", "List of modified PV objects.")]
        public static List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> RotatePV(this List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> PVArrays, string rotation)
        {
            //For each pv array
            foreach (var array in PVArrays)
            {
                if (array != null)
                {
                    //If array orientation is ND - horizontal or NR not defined
                    if (array.Orientation == "ND" || array.Orientation == "NR" || array.Orientation == null)
                    {
                        array.Orientation = "ND";
                        continue;
                    }

                    //Find the rotateed orientation
                    string orientation = array.Orientation.RotateOrientation(rotation);

                    //Assign new orientation to array
                    array.Orientation = orientation;
                }
                else
                {
                    continue;
                }
            }
            return PVArrays;
        }

        [Description("Rotate orientation to new orientation.")]
        [Input("orientation", "Orientation to switch.")]
        [Input("rotation", "How much the dwelling is rotated by.")]
        [Output("Orientation", "New orientation.")]
        public static string RotateOrientation(this string orientation, string rotation)
        {
            //IF orientation is null or horizontal or not defined
            if (orientation == null || orientation == "0" || orientation == "9" || orientation == "ND" || orientation == "NR")
            {
                return orientation;
            }

            if (rotation == null || rotation == "0" || rotation == "9")
            {
                return null;
            }
            
            int compassDirection = (Int32.Parse(orientation) + Int32.Parse(rotation)) % 8;

            if (compassDirection <= 0)
            {
                compassDirection += 8;
            }
            return compassDirection.ToString();
        }
    }
}

