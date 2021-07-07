using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.SAP;
using BH.Engine.Geometry;


namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<ThermalBridges> ThermalBridges(List<ThermalBridgesCurves> thermalBridgesCurves)
        {
            List<ThermalBridges> thermalBridges = new List<ThermalBridges>();


            for (int x = 0; x < thermalBridgesCurves.Count; x++)
            {
               ThermalBridgesCurves thermalBridgeCurves = thermalBridgesCurves[x];
                ThermalBridges thermalBridge= new ThermalBridges();
                thermalBridge.DwellingName = thermalBridgeCurves.Name;
                thermalBridge.Reference = thermalBridgeCurves.Reference;
                thermalBridge.ID = thermalBridgeCurves.ID;

                thermalBridge.E2 = thermalBridgeCurves.E2.Select(y => y.Length()).Sum();
                thermalBridge.E3 = thermalBridgeCurves.E3.Select(y => y.Length()).Sum();
                thermalBridge.E4 = thermalBridgeCurves.E4.Select(y => y.Length()).Sum();
                thermalBridge.E7 = thermalBridgeCurves.E7.Select(y => y.Length()).Sum();

                if (thermalBridgeCurves.E23 != null)
                {
                    thermalBridge.E23 = thermalBridgeCurves.E23.Select(y => y.Length()).Sum();
                }

                //if (thermalBridgeCurves.E10 != null)
                //{
                //    thermalBridge.E10 = thermalBridgeCurves.E10.Select(y => y.Length()).Sum();
                //}

                if (thermalBridgeCurves.E15 != null)
                {
                    thermalBridge.E15 = thermalBridgeCurves.E15.Select(y => y.Length()).Sum();
                }

                if (thermalBridgeCurves.E16 != null)
                {
                    thermalBridge.E16 = thermalBridgeCurves.E16.Select(y => y.Length()).Sum();
                }

                if (thermalBridgeCurves.E17 != null)
                {
                    thermalBridge.E17 = thermalBridgeCurves.E17.Select(y => y.Length()).Sum();
                }

                if (thermalBridgeCurves.E18 != null)
                {
                    thermalBridge.E18 = thermalBridgeCurves.E18.Select(y => y.Length()).Sum();
                }

                if (thermalBridgeCurves.E25 != null)
                {
                    thermalBridge.E25 = thermalBridgeCurves.E25.Select(y => y.Length()).Sum();
                }


                thermalBridges.Add(thermalBridge);

            }

            return thermalBridges;
        }
    }
}