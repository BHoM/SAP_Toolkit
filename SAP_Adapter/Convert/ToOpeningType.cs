using BH.oM.Base.Attributes;
using BH.oM.Base;
using BH.oM.Environment.SAP.Bluebeam;
using SXML = BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BH.oM.Environment.SAP.Excel;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static SXML.OpeningType ToOpeningType(Openings openingDefinition, string openingType)
        {
            SXML.OpeningType type = new SXML.OpeningType();

            type.Name = openingDefinition.OpeningType;
            type.Description = openingDefinition.OpeningType;
            type.DataSource = ((int)openingDefinition.DataSource).ToString();
            type.UValue = openingDefinition.UValue.ToString();
            type.Type = openingType;
            type.GlazingType = ((int)openingDefinition.TypeOfGlazing).ToString();
            type.GlazingType = ((int)openingDefinition.GlazingGap).ToString();
            type.IsArgonFilled = openingDefinition.ArgonFilled;
            type.IsKryptonFilled = openingDefinition.KryptonFilled;
            type.FrameType = ((int)openingDefinition.FrameType).ToString();
            type.GValue = openingDefinition.GValue.ToString();
            type.FrameFactor = openingDefinition.FrameFactor.ToString();

            return type;
        }
    }
}
