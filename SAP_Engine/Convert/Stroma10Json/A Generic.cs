//using System;
//using System.Collections.Generic;
//using System.Text;

//using BH.oM.Base;

//namespace BH.Engine.Environment.SAP.Stroma10
//{
//    public static partial class Convert
//    {
//        public static
//        List<BH.oM.Environment.SAP.Stroma10.Roof> ToRoofs(List<CustomObject> roofsObject)
//        {
            //if (fabricsObject == null)
            //    return null;
//            List<BH.oM.Environment.SAP.Stroma10.Roof> rtn = new List<BH.oM.Environment.SAP.Stroma10.Roof>();
//            foreach (var value in roofsObject)
//            {
//                rtn.Add(ToRoof(value));
//            }
//            return rtn;
//        }


//        public static BH.oM.Environment.SAP.Stroma10.Roof ToRoof(CustomObject roofObject)
//        {
            //if (fabricObject == null)
            //    return null;
//            BH.oM.Environment.SAP.Stroma10.Roof sapRoof = new BH.oM.Environment.SAP.Stroma10.Roof();

//            sapRoof.ID = System.Convert.ToInt32(roofObject.CustomData["Id"]);

//            sapRoof.BHoM_Guid = (Guid.Parse(roofObject.CustomData["Guid"] as string));

//            sapRoof.Dub = System.Convert.ToDouble(roofObject.CustomData["Dub"]);

//            sapRoof.Bol = System.Convert.ToBoolean(roofObject.CustomData["Bol"]);

//            sapRoof.LO= (List<object>)roofObject.CustomData["LO"];

//            sapRoof.str = roofObject.CustomData["str"] as string;

//            sapRoof.CC = ToCC(roofObject.CustomData["CC"] as CustomObject);

//            return sapRoof;
//        }
//    }
//}
