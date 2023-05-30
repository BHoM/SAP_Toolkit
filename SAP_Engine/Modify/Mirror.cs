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

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Mirror all orientations listed in a dwelling.")]
        [Input("sapObj", "The sap report object to modify.")]
        [Input("mirrorLine", "The line to mirror across.")]
        [Output("sapReport", "The modified SAP Report object.")]
        public static SAPReport MirrorDwelling(this SAPReport sapObj, Mirror mirrorLine)
        {
            if (sapObj == null)
            {
                BH.Engine.Base.Compute.RecordError("No sap object inputted to mirror.");
                return null;
            }

            BH.oM.Environment.SAP.XML.PropertyDetails propertyDetailsObj = sapObj.SAP10Data.PropertyDetails;

            propertyDetailsObj.Orientation = propertyDetailsObj.Orientation.MirrorOrientation(mirrorLine);

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
                        array.Orientation = array.Orientation.MirrorOrientation(mirrorLine);
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
                            array.Orientation = array.Orientation.MirrorOrientation(mirrorLine);
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
                    o.Orientation = o.Orientation.MirrorOrientation(mirrorLine);
                }
                b.Openings.Opening = openingObjs;
            }

            propertyDetailsObj.BuildingParts.BuildingPart = buildingPartObj;
            sapObj.SAP10Data.PropertyDetails = propertyDetailsObj;

            return sapObj;

        }

        [Description("Change compass direction by mirroring across common lines.")]
        [Input("orientation", "Orientation to switch.")]
        [Input("mirrorLine", "Line to mirror across.")]
        [Output("Orientation", "New orientation.")]
        public static string MirrorOrientation(this string orientation, Mirror mirrorLine)
        {
            if (orientation == null || orientation == "0")
            {
                BH.Engine.Base.Compute.RecordError("No orientation to mirror.");
                return null;
            }

            List<int> compassPoints = new List<int>();
            if (mirrorLine == Mirror.EastToWest)
            {
                compassPoints = new List<int>{3,7};
            }
            else if (mirrorLine == Mirror.NorthWestToSouthEast)
            {
                compassPoints = new List<int>{4,8};
            }
            else if (mirrorLine == Mirror.NorthToSouth)
            {
                compassPoints = new List<int> {1,5};
            }
            else
            {
               compassPoints = new List<int> {2,6};
            };

            int orientationValue = Int32.Parse(orientation);
            int distance = compassPoints.Select(x => (x - orientationValue)).ToList().Min();
            int compassdirection = (orientationValue + 2 * (distance)) % 8;

            if (compassdirection <= 0)
            {
                compassdirection = compassdirection + 8;
            }
            

            return compassdirection.ToString();

        }
        
    }
}

