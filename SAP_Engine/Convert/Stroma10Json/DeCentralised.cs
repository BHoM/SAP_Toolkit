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
            BH.oM.Environment.SAP.Stroma10.DeCentralised sapDeCentralised = new BH.oM.Environment.SAP.Stroma10.DeCentralised();

            sapDeCentralised.ID = System.Convert.ToInt32(deCentralisedObject.CustomData["ID"]);

            sapDeCentralised.KitchenFanPower1 = System.Convert.ToDouble(deCentralisedObject.CustomData["KitchenFanPower1"]);

            sapDeCentralised.KitchenFanPower2 = System.Convert.ToDouble(deCentralisedObject.CustomData["KitchenFanPower2"]);

            sapDeCentralised.KitchenFanPower3 = System.Convert.ToDouble(deCentralisedObject.CustomData["KitchenFanPower3"]);

            sapDeCentralised.OtherRoomFanPower1 = System.Convert.ToDouble(deCentralisedObject.CustomData["OtherRoomFanPower1"]);

            sapDeCentralised.OtherRoomFanPower2 = System.Convert.ToDouble(deCentralisedObject.CustomData["OtherRoomFanPower2"]);

            sapDeCentralised.OtherRoomFanPower3 = System.Convert.ToDouble(deCentralisedObject.CustomData["OtherRoomFanPower3"]);

            sapDeCentralised.KitchenNumberOfFans1 = System.Convert.ToDouble(deCentralisedObject.CustomData["KitchenNumberOfFans1"]);

            sapDeCentralised.KitchenNumberOfFans2 = System.Convert.ToDouble(deCentralisedObject.CustomData["KitchenNumberOfFans2"]);

            sapDeCentralised.KitchenNumberOfFans3 = System.Convert.ToDouble(deCentralisedObject.CustomData["KitchenNumberOfFans3"]);

            sapDeCentralised.OtherRoomNumberOfFans1 = System.Convert.ToDouble(deCentralisedObject.CustomData["OtherRoomNumberOfFans1"]);

            sapDeCentralised.OtherRoomNumberOfFans2 = System.Convert.ToDouble(deCentralisedObject.CustomData["OtherRoomNumberOfFans2"]);

            sapDeCentralised.OtherRoomNumberOfFans3 = System.Convert.ToDouble(deCentralisedObject.CustomData["OtherRoomNumberOfFans3"]);

            return sapDeCentralised;
        }
    }
}
