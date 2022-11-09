using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Photovoltaic2> ToPhotovoltaic2s(CustomObject photovoltaic2sObject)
        {
            List<BH.oM.Environment.SAP.Stroma10.Photovoltaic2> rtn = new List<BH.oM.Environment.SAP.Stroma10.Photovoltaic2>();
            foreach (var value in photovoltaic2sObject.CustomData["Photovoltaic2s"] as List<CustomObject>)
            {
                rtn.Add(ToPhotovoltaic2(value));
            }
            return rtn;
        }
        public static BH.oM.Environment.SAP.Stroma10.Photovoltaic2 ToPhotovoltaic2(CustomObject photovoltaic2Object)
        {
            BH.oM.Environment.SAP.Stroma10.Photovoltaic2 sapPhotovoltaic2 = new BH.oM.Environment.SAP.Stroma10.Photovoltaic2();

            sapPhotovoltaic2.ID = System.Convert.ToInt32(photovoltaic2Object.CustomData["ID"]);

            sapPhotovoltaic2.PanelPower = System.Convert.ToDouble(photovoltaic2Object.CustomData["PanelPower"]);

            sapPhotovoltaic2.PhotovoltaicTilt = System.Convert.ToInt32(photovoltaic2Object.CustomData["PhotovoltaicTilt"]);

            sapPhotovoltaic2.PhotovoltaicOrientation = System.Convert.ToInt32(photovoltaic2Object.CustomData["PhotovoltaicOrientation"]);

            sapPhotovoltaic2.PhotovoltaicOvershading = System.Convert.ToInt32(photovoltaic2Object.CustomData["PhotovoltaicOvershading"]);

            sapPhotovoltaic2.DirectlyConnected = System.Convert.ToBoolean(photovoltaic2Object.CustomData["DirectlyConnected"]);



            sapPhotovoltaic2.FlatConnection = System.Convert.ToInt32(photovoltaic2Object.CustomData["FlatConnection"]);

            sapPhotovoltaic2.MicroCertificationSchemeCertificate = System.Convert.ToBoolean(photovoltaic2Object.CustomData["MicroCertificationSchemeCertificate"]);

            sapPhotovoltaic2.OverShadingFactor = System.Convert.ToDouble(photovoltaic2Object.CustomData["OverShadingFactor"]);

            sapPhotovoltaic2.Manufacturer = (photovoltaic2Object.CustomData["Manufacturer"] as CustomObject);

            sapPhotovoltaic2.MicroCertificationSchemeCertificateReference = (photovoltaic2Object.CustomData["MicroCertificationSchemeCertificateReference"] as CustomObject);


            return sapPhotovoltaic2;
        }
    }
}
