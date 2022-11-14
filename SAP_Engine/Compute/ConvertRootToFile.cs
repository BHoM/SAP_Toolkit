using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Base;
using System.Security.Cryptography.X509Certificates;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
     
        public static bool ConvertRootToFile(BH.oM.Environment.SAP.Stroma10.Root obj)
        {
            Dictionary<string, object> dic = BH.Engine.Environment.SAP.Stroma10.Convert.FromRoot(obj);

            string JSONFile = BH.Engine.Serialiser.Convert.ToJson(dic);

            File.WriteAllText("C:\\Users\\eadebowale\\Desktop\\SAP Toolkit Work\\Test.txt", JSONFile);

            return true;
        }       
    }
}
