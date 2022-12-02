using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BH.oM.Environment.SAP.Stroma10;
using BH.oM.Base;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        public static Root ConvertFileToRoot(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string line = sr.ReadToEnd();
            sr.Close();

            CustomObject obj = BH.Engine.Serialiser.Convert.FromJson(line) as CustomObject;

            return BH.Engine.Environment.SAP.Stroma10.Convert.ToRoot(obj);
        }
    }
}
