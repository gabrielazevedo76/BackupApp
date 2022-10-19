using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;

namespace SPI.BackupFiles
{
    public class BackupAction
    {
        public static ValueHandler valueHandler = new ValueHandler();

        public static void Backup(string sourcePath, string targetPath, DateTime initialDateTime, DateTime endDateTime)
        {

            try 
            {
                IEnumerable<string> sourceDirectoryFiles = Directory.GetFiles(sourcePath).AsEnumerable();

                List<string> filteredFilesByDate = FilterByDate(sourceDirectoryFiles, initialDateTime, endDateTime);

                MoveFiles(filteredFilesByDate, targetPath);

            }           
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }
        }

        private static List<string> FilterByDate(IEnumerable<string> sourceDirectoryFiles, DateTime initialDateTime, DateTime endDateTime)
        {
            List<string> filesByDateRange = new List<string>();

            //TODO exception para caso não tenho nenhum item

            foreach(var file in sourceDirectoryFiles)
            {
                var currentFile = File.GetCreationTime(file);

                if(currentFile.Date >= initialDateTime.Date && currentFile.Date <= endDateTime.Date)
                    filesByDateRange.Add(file);
            }

            return filesByDateRange;
        }

        private static void MoveFiles(List<string> files, string targetPath)
        {
            for(var i = 0; i<files.Count(); i++)
            { 
                var fileName = Path.GetFileName(files[i]);
                File.Copy(files[i], targetPath + "\\" + fileName);

                valueHandler.Value = i;
            }
        }

        public static DirectoryPaths? GetDirectoryPaths()
        {
            string pathAppSettings = @"C:\Users\gabri\Documents\Dotnet\SPI.BackupFiles\SPI.BackupFiles\AppSettings.json"
;
            DirectoryPaths? paths = JsonSerializer.Deserialize<DirectoryPaths>(File.ReadAllText(pathAppSettings));

            return paths;
        }
    }

    public class DirectoryPaths
    {
        public string? SourcePath { get; set; }
        public string? TargetPath { get; set; }
    }
}
