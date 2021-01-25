/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;
using BH.oM.Environment.SAP;


namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create a SAP export object from SAP objects. ")]
        [Input("dwellingInfo", "A BHoMObject for SAP analysis. Contains general info about each dwelling")]
        [Input("tfa", "A BHoMObject for SAP analysis. Contains info about dwelling areas")]
        [Input("walls", "A BHoMObject for SAP analysis. Contains info about wall lengths and heights")]
        [Input("window", "A BHoMObject for SAP analysis. Contains info about window properties and overhang")]
        [Output("SAPExport", "a SAP export object ready for conversion to XML")]
        public static Export SAPExport(DwellingInfo dwellingInfo, TFA tfa, Walls walls, Window window)
        {
            Export sapExport = new Export();
            sapExport.Reference = dwellingInfo.Reference;
            sapExport.WetRooms = dwellingInfo.WetRooms;
            sapExport.ShelteredSides = dwellingInfo.ShelteredSides;
            sapExport.CrossVentilation = dwellingInfo.CrossVentilation;
            sapExport.TotalArea = tfa.TotalArea;
            sapExport.LivingArea = tfa.LivingArea;
            sapExport.CoolingArea = tfa.CoolingArea;
            sapExport.ExtFloorArea = tfa.ExternalFloorArea;
            sapExport.ExtRoofArea = tfa.ExternalRoofArea;
            sapExport.PartyFloor = tfa.TotalArea - tfa.ExternalFloorArea;
            sapExport.PartyRoof = tfa.TotalArea - tfa.ExternalRoofArea;
            sapExport.CeilingHeight = walls.CeilingHeight;
            sapExport.ExternalWallHeight = walls.ExternalWallHeight;
            sapExport.ExternalWallLength = walls.ExternalWallLength;

            if (dwellingInfo.OrientationDegrees <= 45 || dwellingInfo.OrientationDegrees > 315 )
            {
                sapExport.Orientation = "North";
            }

            if (dwellingInfo.OrientationDegrees <= 135 || dwellingInfo.OrientationDegrees > 45)
            {
                sapExport.Orientation = "East";
            }

            if (dwellingInfo.OrientationDegrees <= 225 || dwellingInfo.OrientationDegrees > 135)
            {
                sapExport.Orientation = "South";
            }

            if (dwellingInfo.OrientationDegrees <= 225 || dwellingInfo.OrientationDegrees > 315)
            {
                sapExport.Orientation = "West";
            }

            sapExport.WindowLength = window.Width;
            sapExport.WindowHeight = window.Height;
            sapExport.WindowOrientation = window.Orientation;
            sapExport.WideOverhang = window.WideOverhang;
            sapExport.OverhangRatio = window.OverhangRatio;

            return sapExport;
        }

    }
}