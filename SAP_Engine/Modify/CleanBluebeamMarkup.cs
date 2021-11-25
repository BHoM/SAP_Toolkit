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
        [Input("inputDirectory", "Full directory to the file.")]
        [Input("run", "Toggle to acitvate the component.")]
        [Output("outputDirectory","Directory to the new file.")]
        public static string CleanBluebeamMarkup(string inputDirectory, bool run = false)
        {
            if (!run)
                return null;

            if (!File.Exists(inputDirectory))
            {
                BH.Engine.Reflection.Compute.RecordError("Input directory contains a null value or does not exist. Please check your inputs.");
                return null;
            }
            string id = @"" + inputDirectory;
            string outputDirectory = id.Replace(".xml", "_cleaned.xml");
            File.WriteAllLines(outputDirectory, File.ReadAllLines(id).Where(line => !(line.Trim().StartsWith("<") && line.Trim().Contains("/>"))));
            return outputDirectory;
        }
    }
}