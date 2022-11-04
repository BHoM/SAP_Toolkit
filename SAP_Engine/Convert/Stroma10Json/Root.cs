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

            sapRoot.Id = System.Convert.ToInt32(rootObject.CustomData["Id"]);

            sapRoot.Address = ToAddress(rootObject.CustomData["Address"] as CustomObject);

            return sapRoot;
        }
    }
}
