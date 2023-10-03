using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Module3HM4_Threads
{
    public static class App
    {
        public static async Task WriteDataInFilesAsync()
        {
            string fileDirecory = "../../../Files";
            string helloFilePath = Path.Combine(fileDirecory, "Hello.txt");
            string worldFilePath = Path.Combine(fileDirecory, "World.txt");

            Directory.CreateDirectory(fileDirecory);

            await File.WriteAllTextAsync(helloFilePath, "Hello");
            await File.WriteAllTextAsync(worldFilePath, "World");

        }

        public static async Task<string> ReadDataFromFileAsync(string fileName)
        {
            try
            {
                string data = await File.ReadAllTextAsync(fileName);
                return data;
            }
            catch (Exception)
            {
                Console.Write("file path error");
                return null;
            }    
        }

        public static async Task<string> ParallelExecutionConcatenationAsync()
        {
            var executeMethod1 = ReadDataFromFileAsync("../../../Files/Hello.txt");
            var executeMethod2 = ReadDataFromFileAsync("../../../Files/World.txt");

            await Task.WhenAll(executeMethod1, executeMethod2);
            return String.Concat(executeMethod1.Result, executeMethod2.Result);

        }

    }
}
