using System;
using System.Security.Principal;

namespace ThreadingExampleApp
{
    internal class Program
    {
         static async Task<string>  GetDataAsync()
        {
            Console.WriteLine("Processing to get the data.......");
            await Task.Delay(5000);
            return "Data is ready";
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting the execution");
            string data = await GetDataAsync();
            Console.WriteLine($"The data received is {data}");
            Console.WriteLine("Ending the execution");
        }
    }
}