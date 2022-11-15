using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.DeCentralised ToDeCentralised(CustomObject deCentralisedObject)
        {
            if (deCentralisedObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.DeCentralised sapDeCentralised = new BH.oM.Environment.SAP.Stroma10.DeCentralised();

            sapDeCentralised.ID = System.Convert.ToInt32(deCentralisedObject.CustomData["Id"]);

            sapDeCentralised.KitchenFanPower1 = System.Convert.ToDouble(deCentralisedObject.CustomData["KspF1"]);

            sapDeCentralised.KitchenFanPower2 = System.Convert.ToDouble(deCentralisedObject.CustomData["KspF2"]);

            sapDeCentralised.KitchenFanPower3 = System.Convert.ToDouble(deCentralisedObject.CustomData["KspF3"]);

            sapDeCentralised.OtherRoomFanPower1 = System.Convert.ToDouble(deCentralisedObject.CustomData["OspF1"]);

            sapDeCentralised.OtherRoomFanPower2 = System.Convert.ToDouble(deCentralisedObject.CustomData["OspF2"]);

            sapDeCentralised.OtherRoomFanPower3 = System.Convert.ToDouble(deCentralisedObject.CustomData["OspF3"]);

            sapDeCentralised.KitchenNumberOfFans1 = System.Convert.ToDouble(deCentralisedObject.CustomData["Ktp1"]);

            sapDeCentralised.KitchenNumberOfFans2 = System.Convert.ToDouble(deCentralisedObject.CustomData["Ktp2"]);

            sapDeCentralised.KitchenNumberOfFans3 = System.Convert.ToDouble(deCentralisedObject.CustomData["Ktp3"]);

            sapDeCentralised.OtherRoomNumberOfFans1 = System.Convert.ToDouble(deCentralisedObject.CustomData["Otp1"]);

            sapDeCentralised.OtherRoomNumberOfFans2 = System.Convert.ToDouble(deCentralisedObject.CustomData["Otp2"]);

            sapDeCentralised.OtherRoomNumberOfFans3 = System.Convert.ToDouble(deCentralisedObject.CustomData["Otp3"]);

            return sapDeCentralised;
        }
        public static Dictionary<string, object> FromDeCentralised(DeCentralised obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            rtn.Add("KspF1", obj.KitchenFanPower1);

            rtn.Add("KspF2", obj.KitchenFanPower2);

            rtn.Add("KspF3", obj.KitchenFanPower3);

            rtn.Add("OspF1", obj.OtherRoomFanPower1);

            rtn.Add("OspF2", obj.OtherRoomFanPower2);

            rtn.Add("OspF3", obj.OtherRoomFanPower3);

            rtn.Add("Ktp1", obj.KitchenNumberOfFans1);

            rtn.Add("Ktp2", obj.KitchenNumberOfFans2);

            rtn.Add("Ktp3", obj.KitchenNumberOfFans3);

            rtn.Add("Otp1", obj.OtherRoomNumberOfFans1);

            rtn.Add("Otp2", obj.OtherRoomNumberOfFans2);

            rtn.Add("Otp3", obj.OtherRoomNumberOfFans3);

            return rtn;
        }
    }
}
