using System;
using System.Collections.Generic;
using System.Text;
using FD = BH.oM.Environment.SAP.XML;
using SXML = BH.oM.Environment.SAP.XML;

namespace BH.Adapter.SAP
{
    public static partial class Convert
    {
        public static SXML.FlatDetails ToFlatDetails(this FD.FlatDetails flatDetails)
        {
            SXML.FlatDetails fd = new SXML.FlatDetails();

            fd.Storeys = flatDetails.Storeys;
            fd.Level = flatDetails.Level;

            return fd;
        }
    }
}
