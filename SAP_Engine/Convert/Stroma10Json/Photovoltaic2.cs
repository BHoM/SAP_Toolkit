/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */
using System;
using System.Collections.Generic;
using System.Text;
using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static List<BH.oM.Environment.SAP.Stroma10.Photovoltaic2> ToPhotovoltaic2s(List<CustomObject> photovoltaic2sObject)
        {
            if (photovoltaic2sObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.Photovoltaic2> rtn = new List<BH.oM.Environment.SAP.Stroma10.Photovoltaic2>();
            foreach (var value in photovoltaic2sObject)
            {
                rtn.Add(ToPhotovoltaic2(value));
            }

            return rtn;
        }

        public static BH.oM.Environment.SAP.Stroma10.Photovoltaic2 ToPhotovoltaic2(CustomObject photovoltaic2Object)
        {
            if (photovoltaic2Object == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.Photovoltaic2 sapPhotovoltaic2 = new BH.oM.Environment.SAP.Stroma10.Photovoltaic2();
            sapPhotovoltaic2.ID = System.Convert.ToInt32(photovoltaic2Object.CustomData["Id"]);
            sapPhotovoltaic2.PeakPower = System.Convert.ToDouble(photovoltaic2Object.CustomData["PPower"]);
            sapPhotovoltaic2.PhotovoltaicTilt = System.Convert.ToInt32(photovoltaic2Object.CustomData["PvTilt"]);
            sapPhotovoltaic2.PhotovoltaicOrientation = System.Convert.ToInt32(photovoltaic2Object.CustomData["PvOrientation"]);
            sapPhotovoltaic2.PhotovoltaicOvershading = System.Convert.ToInt32(photovoltaic2Object.CustomData["PvOvershading"]);
            sapPhotovoltaic2.DirectlyConnected = System.Convert.ToBoolean(photovoltaic2Object.CustomData["DirectlyConnected"]);
            sapPhotovoltaic2.FlatConnection = System.Convert.ToInt32(photovoltaic2Object.CustomData["FlatConnection"]);
            sapPhotovoltaic2.MicroCertificationSchemeCertificate = System.Convert.ToBoolean(photovoltaic2Object.CustomData["McsCert"]);
            sapPhotovoltaic2.OverShadingFactor = System.Convert.ToDouble(photovoltaic2Object.CustomData["OverShadingFactor"]);
            sapPhotovoltaic2.Manufacturer = (photovoltaic2Object.CustomData["Manufacturer"] as string);
            sapPhotovoltaic2.MicroCertificationSchemeCertificateReference = (photovoltaic2Object.CustomData["McsCertificateReference"] as string);
            return sapPhotovoltaic2;
        }

        public static Dictionary<string, object> FromPhotovoltaic2(BH.oM.Environment.SAP.Stroma10.Photovoltaic2 obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            if (obj == null)
                return null;
            rtn.Add("Id", obj.ID);
            rtn.Add("PPower", obj.PeakPower);
            rtn.Add("PvTilt", obj.PhotovoltaicTilt);
            rtn.Add("PvOrientation", obj.PhotovoltaicOrientation);
            rtn.Add("PvOvershading", obj.PhotovoltaicOvershading);
            rtn.Add("DirectlyConnected", obj.DirectlyConnected);
            rtn.Add("FlatConnection", obj.FlatConnection);
            rtn.Add("McsCert", obj.MicroCertificationSchemeCertificate);
            rtn.Add("OverShadingFactor", obj.OverShadingFactor);
            rtn.Add("Manufacturer", obj.Manufacturer);
            rtn.Add("McsCertificateReference", obj.MicroCertificationSchemeCertificateReference);
            return rtn;
        }
    }
}
