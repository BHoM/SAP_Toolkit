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
            BH.oM.Environment.SAP.Stroma10.WindTurbine sapWindTurbine = new BH.oM.Environment.SAP.Stroma10.WindTurbine();

            sapWindTurbine.ID = System.Convert.ToInt32(windTurbineObject.CustomData["ID"]);

            sapWindTurbine.Include = System.Convert.ToBoolean(windTurbineObject.CustomData["Include"]);

            sapWindTurbine.ID = System.Convert.ToInt32(windTurbineObject.CustomData["ID"]);

            sapWindTurbine.WindTurbineRotarDiameter = System.Convert.ToDouble(windTurbineObject.CustomData["WindTurbineRotarDiameter"]);

            sapWindTurbine.WindTurbineHeight = System.Convert.ToDouble(windTurbineObject.CustomData["WindTurbineHeight"]);

            sapWindTurbine.Certificate =(windTurbineObject.CustomData["Certificate"] as CustomObject);

            return sapWindTurbine;
        }
    }
}
