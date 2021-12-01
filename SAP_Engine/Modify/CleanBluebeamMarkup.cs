using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Reflection.Attributes;
using BH.oM.Environment.SAP;

using System.ComponentModel;

using BH.Engine.Base;
using System.IO;

namespace BH.Engine.Environment.SAP
{
    public static partial class Modify
    {
        [Description("Cleaning Bluebeam XML export.")]
        [Input("fileSettings", "Full directory to the file.")]
        [Input("fileSettingsOutput", "Full directory for the output file.")]
        [Input("run", "Toggle to activate the component.")]
        [Output("outputDirectory", "Directory to the new file.")]
        public static string CleanBluebeamMarkup(BH.oM.Adapter.FileSettings fileSettings = null, BH.oM.Adapter.FileSettings fileSettingsOutput = null, bool run = false)
        {
            if (!run)
                return null;

            if (fileSettings == null || fileSettingsOutput == null)
            {
                BH.Engine.Reflection.Compute.RecordError("Please set the File Settings correctly to enable the component to read the correct file.");
                return null;
            }

            if (!Path.HasExtension(fileSettings.FileName) || (Path.GetExtension(fileSettings.FileName) != ".xml") || !Path.HasExtension(fileSettingsOutput.FileName) || (Path.GetExtension(fileSettingsOutput.FileName) != ".xml"))
            {
                BH.Engine.Reflection.Compute.RecordError("File name must contain a file extension.");
                return null;
            }

            string id = @"" + fileSettings.Directory + "\\" + fileSettings.FileName;

            if (!File.Exists(id))
            {
                BH.Engine.Reflection.Compute.RecordError("Input directory contains a null value or does not exist. Please check your inputs.");
                return null;
            }

            string outputDirectory = fileSettingsOutput.Directory + "\\" + fileSettingsOutput.FileName;
            File.WriteAllLines(outputDirectory, File.ReadAllLines(id).Where(line => !(line.Trim().StartsWith("<") && line.Trim().Contains("/>"))));
            return outputDirectory;
        }
    }
}