using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static
        List<BH.oM.Environment.SAP.Stroma10.StorageHeater> ToStorageHeaters(List<CustomObject> storageHeatersObject)
        {
            if (storageHeatersObject == null)
                return null;
            List<BH.oM.Environment.SAP.Stroma10.StorageHeater> rtn = new List<BH.oM.Environment.SAP.Stroma10.StorageHeater>();
            foreach (var value in storageHeatersObject)
            {
                rtn.Add(ToStorageHeater(value));
            }
            return rtn;
        }


        public static BH.oM.Environment.SAP.Stroma10.StorageHeater ToStorageHeater(CustomObject storageHeaterObject)
        {
            if (storageHeaterObject == null)
                return null;
            BH.oM.Environment.SAP.Stroma10.StorageHeater sapStorageHeater = new BH.oM.Environment.SAP.Stroma10.StorageHeater();

            sapStorageHeater.ID = System.Convert.ToInt32(storageHeaterObject.CustomData["Id"]);

            sapStorageHeater.NumberOfHeaters = System.Convert.ToInt32(storageHeaterObject.CustomData["NumberOfHeaters"]);

            sapStorageHeater.IndexNumber = storageHeaterObject.CustomData["IndexNumber"] as string;

            sapStorageHeater.HighRetention = System.Convert.ToBoolean(storageHeaterObject.CustomData["HighRetention"]);

            sapStorageHeater.ManufacturerName = storageHeaterObject.CustomData["ManuName"] as string;

            sapStorageHeater.BrandName = storageHeaterObject.CustomData["BrandName"] as string;

            sapStorageHeater.ModelName = storageHeaterObject.CustomData["ModelName"] as string;

            sapStorageHeater.ModelQualifier = storageHeaterObject.CustomData["ModelQualifier"] as string;

            return sapStorageHeater;
        }
    }
}
