using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Dwelling> ToDwellings(CustomObject dwellingsObject)
        {
            List<Dwelling> rtn = new List<Dwelling>();
            foreach (var value in dwellingsObject.CustomData["Dwellings"] as List<CustomObject>)
            {
                rtn.Add(ToDwelling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Dwelling ToDwelling(CustomObject dwellingObject)
        {
            BH.oM.Environment.SAP.Stroma10.Dwelling sapDwelling = new BH.oM.Environment.SAP.Stroma10.Dwelling();

            sapDwelling.ID = System.Convert.ToInt32(dwellingObject.CustomData["ID"]);

            sapDwelling.Selected = System.Convert.ToBoolean(dwellingObject.CustomData["Selected"]);

            sapDwelling.Orientation = dwellingObject.CustomData["Orientation"] as string;

            sapDwelling.IsLodged = System.Convert.ToBoolean(dwellingObject.CustomData["IsLodged"]);

            sapDwelling.DwellingVersions = ToDwellingVersions(dwellingObject.CustomData["DwellingVersions"] as CustomObject);

            return sapDwelling;
        }
    }
}
