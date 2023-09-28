using BH.oM.Adapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BH.Engine.Environment.SAP
{
    public static partial class Compute
    {
        public static List<FileSettings> FileSettings(string dir)
        {
            var allFiles = Directory.EnumerateFiles(dir);
            List<FileSettings> fs = new List<FileSettings>();

            foreach(var file in allFiles)
            {
                fs.Add(new FileSettings()
                {
                    Directory = dir,
                    FileName = Path.GetFileName(file),
                });
            }

            return fs;
        }
    }
}
