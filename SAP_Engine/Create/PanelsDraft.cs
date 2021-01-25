using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;
using BH.oM.Environment.SAP;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;


namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create a SAP export object from SAP objects. ")]
        [Input("dwellingPanels", "The dwelling geometry as ")]
        [Output("tfa", "A BHoMObject for SAP analysis. Contains general info about each dwelling")]
        public static List<TFA> TFA(List<List<List<Panel>>> dwellingFloorPanels, List<List<List<Panel>>> dwellingRoofPanels, List<double> livingArea)
            // Need to just extract the floor and roof panels

        {
            List<TFA> tfa = new List<TFA>();
            for (int x = 0; x < dwellingFloorPanels.Count; x++) // floor
            {
                for (int y = 0; y < dwellingFloorPanels[x].Count; y++) // dwellings
                {
                    TFA tFA = new TFA();
                    List<string> reference = dwellingFloorPanels[x][y][0].ConnectedSpaces[0].Split('_').ToList();
                    tFA.Reference = reference[0] + "_" + reference[1] + "_" + reference[2] + "_" + reference[4] + "_" + reference[5];
                    tFA.Name = reference[0] + "_" + reference[1] + "_" + reference[2];
                    tFA.ID = y+1;

                    double totalArea = 0.0;
                    double coolingArea = 0.0;
                    double extFloorArea = 0.0;
                    double extRoofArea = 0.0;

                    for (int z = 0; z < dwellingFloorPanels[x][y].Count; z++) // Rooms
                    {
                        totalArea = totalArea + dwellingFloorPanels[x][y][z].Area(); // Need to extraxt just the floor panels

                        List<string> rooms = dwellingFloorPanels[x][y][z].ConnectedSpaces[0].Split('_').ToList();
                        string roomtype = rooms[3];
                        if (roomtype == "Kitchen" || roomtype == "LivingRoom" || roomtype == "Bedroom")
                        {
                            coolingArea = coolingArea + dwellingFloorPanels[x][y][z].Area();
                        }


                    }

                    tFA.TotalArea = totalArea;
                    tFA.LivingArea = livingArea[y]; 
                    tFA.CoolingArea = coolingArea;
                    tFA.ExternalFloorArea = extFloorArea;
                    tFA.ExternalRoofArea = extRoofArea;

                }

            }
            return tfa;
        }
    }
}