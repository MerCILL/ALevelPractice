using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Module2_HW5_Logger
{
    internal class FileService
    {
        private const string _directoryPath = @"./Logs";
        private const int _maxFilesCount = 3;
        private string _filePath;

        public FileService()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            _filePath = Path.Combine(_directoryPath, $"{DateTime.Now:MM-dd-yyyy hh-mm-ss-fff tt}.txt");
            CheckFilesCount();
        }

        public void WriteToFile(Result result)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(result);
            File.AppendAllText(_filePath, json + Environment.NewLine);
        }

        private void CheckFilesCount()
        {
            var files = Directory.GetFiles(_directoryPath)
                .Select(f => new FileInfo(f))
                .OrderBy(f => f.CreationTime)
                .ToList();

            while (files.Count > _maxFilesCount - 1)
            {
                files[0].Delete();
                files.RemoveAt(0);
            }
        }

    }
}
