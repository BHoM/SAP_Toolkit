using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Geometry;
using BH.oM.Geometry.SettingOut;
using BH.oM.Reflection.Attributes;


namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create TFA BHoMObjects for SAP analysis")]
        [Input("dwellings", "")] // TODO
        [Output("tfa", "A BHoMObject for SAP analysis. Contains info about dwelling areas")]

        public static List<TFA> TFA(List<Dwelling> dwellings, List<Level> levels, double tolerance = BH.oM.Geometry.Tolerance.Distance)
        {
            List<TFA> tfas = new List<TFA>();

            double minElevation = levels.Min(x => x.Elevation);
            double maxElevation = levels.Max(x => x.Elevation);

            for (int x = 0; x < dwellings.Count; x++)
            {
                Dwelling dwelling = dwellings[x];
                TFA tfa = new TFA();

                tfa.DwellingName = dwelling.Name;
                tfa.Reference = dwelling.Reference;
                tfa.ID = (x + 1);

                tfa.TotalArea = dwelling.Perimeter.IArea();

                double livingFloorArea = 0;
                List<BH.oM.Environment.SAP.Space> rooms = dwelling.Rooms.Where(y => y.Type == SAPSpaceType.LivingRoom).ToList();
                livingFloorArea = rooms.Select(y => y.Perimeter.IArea()).Sum();

                //Add the area of rooms connected to the living areas by air walls
                List<string> spacesToAdd = new List<string>(); //To prevent adding the same space twice
                foreach(BH.oM.Environment.SAP.Space s in rooms)
                {
                    List<Panel> airPanels = s.Panels.Where(y => y.Type == PanelType.Air).ToList();
                    List<string> connectedSpaces = new List<string>();
                    foreach(Panel p in airPanels)
                        connectedSpaces.AddRange(p.ConnectedSpaces.Where(y => y != s.Name));

                    connectedSpaces = connectedSpaces.Distinct().ToList();

                    connectedSpaces = connectedSpaces.Where(y => spacesToAdd.IndexOf(y) == -1).ToList();
                    spacesToAdd.AddRange(connectedSpaces);
                    spacesToAdd = spacesToAdd.Distinct().ToList();
                }

                foreach(string s in spacesToAdd)
                {
                    livingFloorArea += dwelling.Rooms.Where(y => y.Name == s).First().Perimeter.IArea();
                }

                tfa.LivingArea = livingFloorArea;

                tfa.CoolingArea = dwelling.Rooms.Where(y => y.Type == SAPSpaceType.Kitchen || y.Type == SAPSpaceType.LivingRoom || y.Type == SAPSpaceType.Bedroom).Select(y => y.Perimeter.IArea()).Sum();

                double maxZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Max() + tolerance;
                double minZ = dwelling.Perimeter.IControlPoints().Select(y => y.Z).Min() - tolerance;

                if(minElevation >= minZ && minElevation <= maxZ)
                {
                    //Dwelling is on the ground
                    tfa.ExternalFloorArea = dwelling.Perimeter.IArea();
                }
                if(maxElevation >= minZ && maxElevation <= maxZ)
                {
                    //Dwelling is on the top floor
                    tfa.ExternalRoofArea = dwelling.Perimeter.IArea();
                }

                tfas.Add(tfa);
            }

            return tfas;
        }
    }
}
