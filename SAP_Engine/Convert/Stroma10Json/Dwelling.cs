
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Dwelling> ToDwellings(List<CustomObject> dwellingsObject)
        {
            if (dwellingsObject == null)
                return null;

            List<Dwelling> rtn = new List<Dwelling>();
            foreach (var value in dwellingsObject)
            {
                rtn.Add(ToDwelling(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Dwelling ToDwelling(CustomObject dwellingObject)
        {

            if (dwellingObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Dwelling sapDwelling = new BH.oM.Environment.SAP.Stroma10.Dwelling();

            sapDwelling.ID = System.Convert.ToInt32(dwellingObject.CustomData["Id"]);

            sapDwelling.BHoM_Guid = Guid.Parse(dwellingObject.CustomData["Guid"] as string);

            sapDwelling.Selected = System.Convert.ToBoolean(dwellingObject.CustomData["Selected"]);

            sapDwelling.Name = dwellingObject.Name;

            sapDwelling.Orientation = dwellingObject.CustomData["Orientation"] as string;

            sapDwelling.IsLodged = System.Convert.ToBoolean(dwellingObject.CustomData["IsLodged"]);

            sapDwelling.DwellingVersions = ToDwellingVersions((dwellingObject.CustomData["DwellingVersions"] as List<object>).Cast<CustomObject>().ToList());

            return sapDwelling;
        }
        public static Dictionary<string, object> FromDwelling(Dwelling obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            rtn.Add("Id", obj.ID);
            rtn.Add("Guid", obj.BHoM_Guid.ToString());
            rtn.Add("Selected", obj.Selected);
            rtn.Add("Name", obj.Name);
            rtn.Add("Orientation", obj.Orientation);
            rtn.Add("IsLodged", obj.IsLodged);
            rtn.Add("DwellingVersions", obj.DwellingVersions.Select(x => FromDwellingVersion(x)).ToList());  


            return rtn;
        }
    }
}
