using BH.Engine.Adapter;
using BH.oM.Base;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BH.Adapter.XML;
using BH.oM.XML;
using BH.oM.Adapters.XML;
using BH.oM.Environment.SAP.Bluebeam;
using BH.oM.Data.Requests;
using System.Linq;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<IBHoMObject> ReadSAPMarkupSummary(SAPConfig config)
        {
            if(config.SAPMarkupFile == null)
            {
                BH.Engine.Base.Compute.RecordError("Please provide a valid SAP Markup File Location.");
                return new List<IBHoMObject>();
            }

            string fullFileName = config.SAPMarkupFile.GetFullFileName();
            if(string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<IBHoMObject>();
            }

            XMLConfig xmlConfig = new XMLConfig() { Schema = oM.Adapters.XML.Enums.Schema.Undefined };
            XMLAdapter xmlAdapter = new XMLAdapter(config.SAPMarkupFile);
            FilterRequest xmlRequest = BH.Engine.Data.Create.FilterRequest(typeof(SAPMarkupSummary), "");

            return xmlAdapter.Pull(xmlRequest, actionConfig: xmlConfig).OfType<IBHoMObject>().ToList();
            ;
        }
    }
}
