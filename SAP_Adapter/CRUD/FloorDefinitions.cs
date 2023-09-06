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

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        private List<Floors> ReadFloorDefinitions(SAPConfig config)
        {
            if(config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<Floors>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if(string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<Floors>();
            }

            if(config.FloorDefinitionsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Floor Definitions Request stating the worksheet and range to read from Excel for the Floor Definition objects.");
                return new List<Floors>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.FloorDefinitionsRequest).OfType<TableRow>().ToList();

            List<Floors> floorDefinitions = new List<Floors>();

            foreach(var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 4)
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                Floors floorDefinition = new Floors();
                floorDefinition.Dwelling = content[0].Value.ToString();
                floorDefinition.Storey = content[2].Value.ToString();

                var type = Enum.Parse(typeof(TypeOfFloor), content[1].Value.ToString());
                if(type != null)
                    floorDefinition.Type = (TypeOfFloor)type;

                try
                {
                    floorDefinition.UValue = double.Parse(content[3].Value.ToString());
                }
                catch
                {

                }

                floorDefinitions.Add(floorDefinition);
            }

            return floorDefinitions;
        }
    }
}
