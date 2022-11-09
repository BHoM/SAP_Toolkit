using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static Root ToRoot(CustomObject rootObject)
        {
            Root sapRoot = new Root();

            sapRoot.ID = System.Convert.ToInt32(rootObject.CustomData["ID"]);

            sapRoot.BHoM_Guid = (Guid)rootObject.CustomData["GUID"];

            sapRoot.DateTimeCreated = System.Convert.ToDateTime(rootObject.CustomData["DateTimeCreated"]);

            sapRoot.DateTimeSaved = System.Convert.ToDateTime(rootObject.CustomData["DateTimeCreated"]);

            sapRoot.UserID = System.Convert.ToInt32(rootObject.CustomData["UserID"]);

            sapRoot.Reference = rootObject.CustomData["Reference"] as string;

            sapRoot.Dwellings = ToDwellings(rootObject.CustomData["Dwellings"] as CustomObject);

            sapRoot.Address = ToAddress(rootObject.CustomData["Address"] as CustomObject);

            sapRoot.ClientDetails = ToClientDetails(rootObject.CustomData["ClientDetails"] as CustomObject);

            sapRoot.Elements = ToElements(rootObject.CustomData["Elements"] as CustomObject);

            sapRoot.Assessor = ToAssessor(rootObject.CustomData["Assessor"] as CustomObject);

            return sapRoot;
        }
    }
}
