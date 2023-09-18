using BH.oM.Environment.SAP;
using BH.oM.Environment.SAP.XML;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace BH.Engine.Environment.SAP
{
    public static partial class Query
    {
        public static string IterationName(this IIteration iteration)
        {
            return Name(iteration as dynamic);
        }

        private static string Name(FloorIteration iteration)
        {
            return $"F{iteration.UValue.ToString("#.##")}";
        }

        private static string Name(OpeningIteration iteration)
        {
            return $"O-W{iteration.Width.ToString("#.##")}H{iteration.Height.ToString("#.##")}P{iteration.Pitch}";
        }

        private static string Name(OpeningTypeGValueIteration iteration)
        {
            return $"OGV{iteration.GValue.ToString("#.##")}";
        }

        private static string Name(OpeningTypeUValueIteration iteration)
        {
            return $"OUV{iteration.UValue.ToString("#.##")}";
        }

        private static string Name(OrientationIteration iteration)
        {
            return $"ORIM{iteration.Mirror.ToString()}R{iteration.Rotation.ToString()}";
        }

        private static string Name(RoofIteration iteration)
        {
            return $"R{iteration.UValue.ToString("#.##")}";
        }

        private static string Name(ThermalBridgeIteration iteration)
        {
            return $"PSI{iteration.PsiValue.ToString("#.##")}";
        }

        private static string Name(WallIteration iteration)
        {
            return $"WU{iteration.UValue.ToString("#.##")}CW{iteration.IsCurtainWall.ToString()}";
        }

        private static string Name(object obj)
        {
            return "";
        }
    }
}
