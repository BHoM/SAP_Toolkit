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
        private List<Openings> ReadOpeningDefinitions(SAPConfig config)
        {
            if (config.ExcelFile == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid SAP Excel file location.");
                return new List<Openings>();
            }

            string fullFileName = config.ExcelFile.GetFullFileName();
            if (string.IsNullOrEmpty(fullFileName) || !File.Exists(fullFileName))
            {
                BH.Engine.Base.Compute.RecordError($"Could not load file from {fullFileName}. Check the file exists.");
                return new List<Openings>();
            }

            if (config.OpeningDefinitionsRequest == null || config.OpeningDefinitionsRequest.CellContentsRequest == null)
            {
                BH.Engine.Base.Compute.RecordError($"Please provide a valid Opening Definitions Request stating the worksheet and range to read from Excel for the Opening Definition objects.");
                return new List<Openings>();
            }

            ExcelAdapter excelAdapter = new ExcelAdapter(config.ExcelFile);
            List<TableRow> excelRows = excelAdapter.Pull(config.PsiValuesRequest.CellContentsRequest).OfType<TableRow>().ToList();

            List<Openings> openingDefinitions = new List<Openings>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 10)
                    continue;

                Openings openingDefinition = new Openings();
                openingDefinition.OpeningType = tableRow.Content[0].ToString();

                try
                {
                    openingDefinition.UValue = double.Parse(tableRow.Content[1].ToString());
                }
                catch { }

                try
                {
                    openingDefinition.GValue = double.Parse(tableRow.Content[2].ToString());
                }
                catch { }

                var glazingType = Enum.Parse(typeof(TypeOfGlazing), tableRow.Content[3].ToString());
                if (glazingType != null)
                    openingDefinition.TypeOfGlazing = (TypeOfGlazing)glazingType;

                var glazingGap = Enum.Parse(typeof(GlazingGap), tableRow.Content[4].ToString());
                if(glazingGap != null)
                    openingDefinition.GlazingGap = (GlazingGap)glazingGap;

                try
                {
                    openingDefinition.FrameFactor = double.Parse(tableRow.Content[5].ToString());
                }
                catch { }

                var frameType = Enum.Parse(typeof(TypeOfFrame), tableRow.Content[6].ToString());
                if (frameType != null)
                    openingDefinition.FrameType = (TypeOfFrame)frameType;

                try
                {
                    openingDefinition.ArgonFilled = bool.Parse(tableRow.Content[7].ToString());
                }
                catch { }

                try
                {
                    openingDefinition.KryptonFilled = bool.Parse(tableRow.Content[8].ToString());
                }
                catch { }

                var dataSource = Enum.Parse(typeof(OpeningDataSource), tableRow.Content[9].ToString());
                if (dataSource != null)
                    openingDefinition.DataSource = (OpeningDataSource)dataSource;

                openingDefinitions.Add(openingDefinition);
            }

            return openingDefinitions;
        }
    }
}
