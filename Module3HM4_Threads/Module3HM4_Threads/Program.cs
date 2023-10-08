using Module3HM4_Threads;

await App.WriteDataInFilesAsync();
Console.WriteLine(await App.ReadDataFromFileAsync("../../../Files/Hello.txt"));
Console.WriteLine(await App.ReadDataFromFileAsync("../../../Files/World.txt"));
Console.WriteLine(App.ParallelExecutionConcatenationAsync().Result);