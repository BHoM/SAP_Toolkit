using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Base;

namespace BH.Engine.Environment.SAP.Stroma10
{
    public static partial class Convert
    {
        public static BH.oM.Environment.SAP.Stroma10.WindTurbine ToWindTurbine(CustomObject windTurbineObject)
        {
            if (windTurbineObject == null)
                return null;

            BH.oM.Environment.SAP.Stroma10.WindTurbine sapWindTurbine = new BH.oM.Environment.SAP.Stroma10.WindTurbine();

            sapWindTurbine.ID = System.Convert.ToInt32(windTurbineObject.CustomData["Id"]);

            sapWindTurbine.Include = System.Convert.ToBoolean(windTurbineObject.CustomData["Include"]);

            sapWindTurbine.WindTurbineNumber = System.Convert.ToInt32(windTurbineObject.CustomData["WNumber"]);

            sapWindTurbine.WindTurbineRotarDiameter = System.Convert.ToDouble(windTurbineObject.CustomData["WrDiameter"]);

            sapWindTurbine.WindTurbineHeight = System.Convert.ToDouble(windTurbineObject.CustomData["WHeight"]);

            sapWindTurbine.Certificate =(windTurbineObject.CustomData["Certificate"] as CustomObject);

            return sapWindTurbine;
        }
    }
}
