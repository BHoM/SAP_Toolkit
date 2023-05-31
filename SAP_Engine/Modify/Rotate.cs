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
            if (sapObj == null)
            {
                BH.Engine.Base.Compute.RecordError("No sap object inputted to mirror.");
                return null;
            }

            BH.oM.Environment.SAP.XML.PropertyDetails propertyDetailsObj = sapObj.SAP10Data.PropertyDetails;

            propertyDetailsObj.Orientation = propertyDetailsObj.Orientation.RotateOrientation(rotation);

            try
            {
                List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> PVArrays = propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray;
                foreach (var array in PVArrays)
                {
                    if (!(array == null))
                    {
                        if (array.Orientation == "0" || array.Orientation == "9")
                        {
                            BH.Engine.Base.Compute.RecordWarning("PV is horizontal and therefore can't be rotated");
                            continue;
                        }
                        array.Orientation = array.Orientation.RotateOrientation(rotation);
                    }
                    else
                    {
                        continue;
                    }
                }
                propertyDetailsObj.EnergySource.PhotovoltaicArrays.PhotovoltaicArray = PVArrays;
            }
            catch (Exception e)
            {
                BH.Engine.Base.Compute.RecordWarning("If you have no PV ignore this warning, otherwise:" + e.Message);
            }
            try
            {
                List<MainHeating> heatingObjs = propertyDetailsObj.Heating.MainHeatingDetails.MainHeating;
                foreach (var heating in heatingObjs)
                {
                    List<BH.oM.Environment.SAP.XML.PhotovoltaicArray> FGHRSPVArrays = heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray;
                    foreach (var array in FGHRSPVArrays)
                    {
                        if (!(array == null))
                        {
                            if (array.Orientation == "0" || array.Orientation == "9")
                            {
                                BH.Engine.Base.Compute.RecordWarning("PV is horizontal and therefore can't be rotated");
                                continue;
                            }
                            array.Orientation = array.Orientation.RotateOrientation(rotation);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    heating.FGHRSEnergySource.PhotovoltaicArrays.PhotovoltaicArray = FGHRSPVArrays;
                }
                propertyDetailsObj.Heating.MainHeatingDetails.MainHeating = heatingObjs;

            }
            catch (Exception e)
            {
                BH.Engine.Base.Compute.RecordWarning("If you have no PV ignore this warning, otherwise:" + e.Message);
            }


            List<BH.oM.Environment.SAP.XML.BuildingPart> buildingPartObj = propertyDetailsObj.BuildingParts.BuildingPart;
            foreach (var b in buildingPartObj)
            {
                List<BH.oM.Environment.SAP.XML.Opening> openingObjs = b.Openings.Opening;
                foreach (var o in openingObjs)
                {
                    if (o.Orientation == "0" || o.Orientation == "9")
                    {
                        BH.Engine.Base.Compute.RecordWarning("Window is horizontal and therefore can't be rotated");
                        continue;
                    }
                    o.Orientation = o.Orientation.RotateOrientation(rotation);
                }
                b.Openings.Opening = openingObjs;
            }

            propertyDetailsObj.BuildingParts.BuildingPart = buildingPartObj;
            sapObj.SAP10Data.PropertyDetails = propertyDetailsObj;

            return sapObj;
        }

        [Description("Rotate orientation to new orientation.")]
        [Input("orientation", "Orientation to switch.")]
        [Input("rotation", "How much the dwelling is rotated by.")]
        [Output("Orientation", "New orientation.")]
        public static string RotateOrientation(this string orientation, string rotation)
        {
            if (orientation == null || orientation == "0" || orientation == "9") return null;
            if (rotation == null || rotation == "0" || rotation == "9") return null;
            
            int compassdirection = (Int32.Parse(orientation) + Int32.Parse(rotation)) % 8;

            if (compassdirection <= 0)
            {
                compassdirection += 8;
            }
            return compassdirection.ToString();
        }
        
    }
}

