using BH.Engine.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BH.oM.Adapters.Excel;
using BH.Adapter.Excel;
using System.Linq;
using BH.oM.Environment.SAP.Excel;
using BH.oM.Environment.SAP.XML;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<SAPReport> ReadSAPReport(SAPConfig config)
        {
            var sapMarkupSummary = ReadSAPMarkupSummary(config)?[0];
            if(sapMarkupSummary == null)
            {
                BH.Engine.Base.Compute.RecordError("Mark Up Summary did not return a viable object to produce a SAP Report with.");
                return new List<SAPReport>();
            }

            //Openings
            var openingSummaries = sapMarkupSummary.Markup.Where(x => x.Layer == "Openings").ToList();
        }
    }
}
