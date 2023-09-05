﻿using BH.Engine.Adapter;
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
            List<TableRow> excelRows = excelAdapter.Pull(config.OpeningDefinitionsRequest.CellContentsRequest).OfType<TableRow>().ToList();

            List<Openings> openingDefinitions = new List<Openings>();

            foreach (var tableRow in excelRows)
            {
                if (tableRow.Content.Count < 10)
                    continue;

                var content = tableRow.Content.OfType<CellContents>().ToList();

                Openings openingDefinition = new Openings();
                openingDefinition.OpeningType = content[0].Value.ToString();

                try
                {
                    openingDefinition.UValue = double.Parse(content[1].Value.ToString());
                }
                catch { }

                try
                {
                    openingDefinition.GValue = double.Parse(content[2].Value.ToString());
                }
                catch { }

                var glazingType = Enum.Parse(typeof(TypeOfGlazing), content[3].Value.ToString());
                if (glazingType != null)
                    openingDefinition.TypeOfGlazing = (TypeOfGlazing)glazingType;

                var glazingGap = Enum.Parse(typeof(GlazingGap), content[4].Value.ToString());
                if(glazingGap != null)
                    openingDefinition.GlazingGap = (GlazingGap)glazingGap;

                try
                {
                    openingDefinition.FrameFactor = double.Parse(content[5].Value.ToString());
                }
                catch { }

                var frameType = Enum.Parse(typeof(TypeOfFrame), content[6].Value.ToString());
                if (frameType != null)
                    openingDefinition.FrameType = (TypeOfFrame)frameType;

                try
                {
                    openingDefinition.ArgonFilled = bool.Parse(content[7].Value.ToString());
                }
                catch { }

                try
                {
                    openingDefinition.KryptonFilled = bool.Parse(content[8].Value.ToString());
                }
                catch { }

                var dataSource = Enum.Parse(typeof(OpeningDataSource), content[9].Value.ToString());
                if (dataSource != null)
                    openingDefinition.DataSource = (OpeningDataSource)dataSource;

                openingDefinitions.Add(openingDefinition);
            }

            return openingDefinitions;
        }
    }
}
