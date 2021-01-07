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
        [Output("dwellingInfo", "A BHoMObject for SAP analysis. Contains general info about each dwelling")]
        public static List<DwellingInfo> DwellingInfo(List<List<Panel>> dwellingPanels)
        {
            List<DwellingInfo> dInfo = new List<DwellingInfo>();

            for (int x = 0; x < dwellingPanels.Count; x++) // Floors
            {

                List<List<Panel>> panelsAsSpaces = dwellingPanels[x].ToSpaces();

                for (int y = 0; y < panelsAsSpaces.Count; y++) // Dwellings
                {
                    DwellingInfo dwellingInfo = new DwellingInfo();
                    List<string> reference = panelsAsSpaces[y][0].ConnectedSpaces[0].Split('_').ToList();
                    dwellingInfo.Reference = reference[0] + "_" + reference[1] + "_" + reference[2] + "_" + reference[4] + "_" + reference[5] + "_" + reference[6];
                    dwellingInfo.DwellingName = reference[0] + "_" + reference[1] + "_" + reference[2];
                    dwellingInfo.ID = y + 1;

                    for (int z = 0; z < panelsAsSpaces[y].Count; z++)
                    {

                        int noOfBathrooms = 0;
                        dwellingInfo.TotalRooms = panelsAsSpaces[y].Count; // Where to place this?
                        List<string> referens = panelsAsSpaces[y][z].ConnectedSpaces[0].Split('_').ToList();
                        string roomType = referens[3];
                        if (roomType == "Bathroom")
                        {
                            noOfBathrooms = noOfBathrooms + 1;
                        }

                        dwellingInfo.WetRooms = noOfBathrooms;


                    

                    List<Opening> openings = panelsAsSpaces[y][z].Openings;

                            for (int i = 0; i < openings.Count; i++)
                            {
                                List<double> orientation = new List<double>();
                                orientation.Add(Query.Orientation(openings[i]).Value);
                                string crossvent = "False";
                                List<int> shelteredSides = new List<int>();
                                int sS = 3;
                                int comp = 0;
                                int o = 360;
                                int tolerance = 30;

                                if (orientation[i] == 0) 
                                {
                                    orientation[i] = 360;
                                }

                                dwellingInfo.OrientationDegrees = orientation[0];

                                foreach (int or in orientation)
                                {
                                    if (or == 0)
                                    {
                                        o = 360;
                                    }

                                    else
                                    {
                                        o = or;
                                    }

                                    if (comp == 0 && Math.Abs(orientation[i] - o) > (180 - tolerance) && Math.Abs(orientation[i] - o) < (180 + tolerance))
                                    {
                                        crossvent = "True";
                                        comp = 1;
                                    }

                                    if (sS != 2 && (Math.Abs(orientation[i] - o) > (90 - tolerance) && Math.Abs(orientation[i] - o) < (90 + tolerance)) || (Math.Abs(orientation[i] - o) > (270 - tolerance) && Math.Abs(orientation[i] - o) < (270 + tolerance)))
                                    {
                                        sS = 2;
                                    }

                                    
                                    dwellingInfo.ShelteredSides = sS;
                                    dwellingInfo.CrossVentilation = crossvent;



                                }

                            }

                        dInfo.Add(dwellingInfo);
                    }

                }
            }

            return dInfo;

        }

    }
}