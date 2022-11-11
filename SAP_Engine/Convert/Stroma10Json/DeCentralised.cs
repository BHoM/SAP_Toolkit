using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

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
    }
}
