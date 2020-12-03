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
            sapExport.ExtFloorArea = tfa.ExtFloorArea;
            sapExport.ExtRoofArea = tfa.ExtRoofArea;
            sapExport.PartyFloor = tfa.TotalArea - tfa.ExtFloorArea;
            sapExport.PartyRoof = tfa.TotalArea - tfa.ExtRoofArea;
            sapExport.CeilingHeight = walls.CeilingHeight;
            sapExport.ExtWallHeight = walls.ExtWallHeight;
            sapExport.ExtWallLength = walls.ExtWallLength;

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