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
        [Description("Convert SAP BuildingPart to XML BuildingPart.")]
        [Input("buildingPart", "SAP BuildingPart to convert.")]
        [Output("buildingPart", "XML BuildingPart.")]
        public static BH.oM.Environment.SAP.XML.BuildingPart xmlBuildingPart(this BH.oM.Environment.SAP.Wall sapBuildingPart)
        {
            BH.oM.Environment.SAP.XML.BuildingPart xmlBuildingPart = new BH.oM.Environment.SAP.XML.BuildingPart();
           /* xmlBuildingPart.BuildingPartNumber = ;
            xmlBuildingPart.Identifier = ;
            xmlBuildingPart.ConstructionYear = ;
            xmlBuildingPart.Overshading = ;
            xmlBuildingPart.Openings = ;
            xmlBuildingPart.Floors = ;
            xmlBuildingPart.Roofs = ;
            xmlBuildingPart.Walls = ;*/



            return xmlBuildingPart;
        }
            
    }
}
