using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BH.oM.Base;
using BH.oM.Environment.SAP.Stroma10;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.Elements ToElements(CustomObject elementsObject)
        {
            if (elementsObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.Elements sapElements = new BH.oM.Environment.SAP.Stroma10.Elements();

            sapElements.ID = System.Convert.ToInt32(elementsObject.CustomData["Id"]);

            sapElements.Fabrics = ToFabrics((elementsObject.CustomData["Fabric"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Heatings = ToHeatings((elementsObject.CustomData["Heating"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Waters = ToWaters((elementsObject.CustomData["Water"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Ventilations = ToVentilations((elementsObject.CustomData["Ventilation"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Renewables = ToRenewables((elementsObject.CustomData["Renewable"] as List<object>).Cast<CustomObject>().ToList());

            sapElements.Overheatings = ToOverheatings((elementsObject.CustomData["Overheating"] as List<object>).Cast<CustomObject>().ToList());

            return sapElements;
        }
        public static Dictionary<string, object> FromElements(Elements obj)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();

            if (obj == null)
                return null;

            rtn.Add("Id", obj.ID);

            if (obj.Fabrics != null && obj.Fabrics.Any(x => x != null))
                rtn.Add("Fabric", obj.Fabrics.Select(x => FromFabric(x)).ToList());

            if (obj.Heatings != null && obj.Heatings.Any(x => x != null))
                rtn.Add("Heating", obj.Heatings.Select(x => FromHeating(x)).ToList());

            if (obj.Waters != null && obj.Waters.Any(x => x != null))
                rtn.Add("Water", obj.Waters.Select(x => FromWater(x)).ToList());

            if (obj.Ventilations != null && obj.Ventilations.Any(x => x != null))
                rtn.Add("Ventilation", obj.Ventilations.Select(x => FromVentilation(x)).ToList());

            if (obj.Renewables != null && obj.Renewables.Any(x => x != null))
                rtn.Add("Renewable", obj.Renewables.Select(x => FromRenewable(x)).ToList());

            if (obj.Overheatings != null && obj.Overheatings.Any(x => x != null))
                rtn.Add("Overheating", obj.Overheatings.Select(x => FromOverheating(x)).ToList());

            return rtn;
        }
    }
}
