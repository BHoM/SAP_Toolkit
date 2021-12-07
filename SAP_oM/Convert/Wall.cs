using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;


namespace BH.oM.Environment.SAP.Convert
{
    public static partial class Convert
    {
        [Description("Convert SAP wall to XML wall.")]
        [Input("wall", "SAP wall to convert.")]
        [Output("wall", "XML wall.")]
        public static BH.oM.Environment.SAP.XML.Wall xmlWall(this BH.oM.Environment.SAP.Wall sapWall)
        {
            BH.oM.Environment.SAP.XML.Wall xmlWall = new BH.oM.Environment.SAP.XML.Wall();
            xmlWall.Name = sapWall.Name;
            xmlWall.Description = "This is a wall"; //Descriptive notes about the wall.
            xmlWall.Type = "2"; //Type of wall (exposure). 2 = exposed wall
            xmlWall.Area = sapWall.Area;
            xmlWall.UValue = 0.18;
            xmlWall.KappaValue = 14;
            xmlWall.CurtainWall = sapWall.CurtainWall;

            return xmlWall;
        }
    }
}
