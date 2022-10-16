using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.ApplicationServices;

namespace SPI.BackupFiles
{
    public static class BackupAction
    {
        public static void Backup(string sourcePath, string targetPath, DateTime initialDateTime, DateTime endDateTime)
        {
            try 
            {
                string[] sourceDirectoryFiles = Directory.GetFiles(sourcePath);

                IEnumerable<string> filteredFilesByDate = FilterByDate(sourceDirectoryFiles, initialDateTime, endDateTime).AsEnumerable();

                MoveFiles(filteredFilesByDate, targetPath);

            }           
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }
        }

        private static List<string> FilterByDate(string[] sourceDirectoryFiles, DateTime initialDateTime, DateTime endDateTime)
        {
            List<string> filesByDateRange = new List<string>();

            foreach(var file in sourceDirectoryFiles)
            {
                var currentFile = File.GetCreationTime(file);

                if(currentFile.Date > initialDateTime.Date && currentFile.Date < endDateTime.Date)
                    filesByDateRange.Add(file);
            }

            return filesByDateRange;
        }

        private static void MoveFiles(IEnumerable<string> files, string targetPath)
        {
            foreach (var file in files)
            { 
                var fileName = Path.GetFileName(file);
                File.Copy(file, targetPath + "\\" + fileName);
            }
        }
        public static DirectoryPaths? GetDirectoryPaths()
        {
            string pathAppSettings = @"C:\Users\gabri\Documents\Dotnet\SPI.BackupFiles\SPI.BackupFiles\AppSettings.json"
;
            DirectoryPaths? paths = JsonSerializer.Deserialize<DirectoryPaths>(File.ReadAllText(pathAppSettings));

            Console.WriteLine(pathAppSettings);

            return paths;
        }
    }

    public class DirectoryPaths
    {
        public string? SourcePath { get; set; }
        public string? TargetPath { get; set; }
    }
}
