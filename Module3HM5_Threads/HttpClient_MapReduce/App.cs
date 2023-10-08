using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient_MapReduce
{
    public static class App
    {
		private static readonly HttpClient _client = new HttpClient();
        private static readonly string _filesDirectory = "../../../Files";
        
        public static async Task Run()
        {
            await ReadWebsites();

            var linesInFile1 = await ReadFileLineByLineAsync(GetFileName("site1.txt"));
            var linesInFile2 = await ReadFileLineByLineAsync(GetFileName("site2.txt"));

            var wordsInFile1 = Map(linesInFile1);
            var wordsInFile2 = Map(linesInFile2);

            var reducedResults = Reduce(wordsInFile1, wordsInFile2);

            Console.WriteLine($"Total words in file 1: {GetTotalWords(wordsInFile1)}");
            Console.WriteLine($"Total words in file 2: {GetTotalWords(wordsInFile2)}");

            Console.WriteLine($"Unique words in file 1: {wordsInFile1.Count}");
            Console.WriteLine($"Unique words in file 2: {wordsInFile2.Count}");

            Console.WriteLine("Word counts in both files combined:");
            foreach (var result in reducedResults)
            {
                Console.WriteLine($"Word: {result.Key}, Count: {result.Value}");
            }


        }

        private static int GetTotalWords(Dictionary<string, int> wordCounts)
        {
            int total = 0;
            foreach (var count in wordCounts.Values)
                total += count;

            return total;
        }

        private static async Task ReadWebsites()
		{
            string url1 = "https://learn.microsoft.com/en-us/azure/hdinsight/hadoop/apache-hadoop-dotnet-csharp-mapreduce-streaming";
            string url2 = "https://dotnettutorials.net/lesson/map-reduce-framework/";

            Task<string> taskSite1 = ReadWebsite(url1);
            Task<string> taskSite2 = ReadWebsite(url2);

            await Task.WhenAll(taskSite1, taskSite2);

            CheckDirectoryExisting();

            string site1File = GetFileName("site1.txt");
            string site2File = GetFileName("site2.txt");

            await File.WriteAllTextAsync(site1File, taskSite1.Result);
            await File.WriteAllTextAsync(site2File, taskSite2.Result);

        }
        private static async Task<string> ReadWebsite(string url)
		{
				HttpResponseMessage response = await _client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				return responseBody;
		}

        private static async Task<List<string>> ReadFileLineByLineAsync(string filePath)
        {
            var lines = new List<string>();

            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                while ((line = await file.ReadLineAsync()) != null) lines.Add(line);
            }
            return lines;
        }

        private static Dictionary<string, int> Map(List<string> lines)
        {
            var wordCounts = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (wordCounts.ContainsKey(word)) wordCounts[word]++;
                    else wordCounts[word] = 1;
                }
            }

            return wordCounts;
        }

        private static Dictionary<string,int> Reduce(Dictionary<string,int> wordsInFile1, Dictionary<string,int> wordsInFile2)
        {
            var bothFilesWords = new Dictionary<string, int>(wordsInFile1);

            foreach (var word in wordsInFile2)
            {
                if(bothFilesWords.ContainsKey(word.Key)) bothFilesWords[word.Key] += word.Value;
                else bothFilesWords[word.Key] = word.Value;
            }

            return bothFilesWords;
        }

        private static void CheckDirectoryExisting() => Directory.CreateDirectory(_filesDirectory);
        private static string GetFileName(string fileTitle) => Path.Combine(_filesDirectory, fileTitle);

	}
}
