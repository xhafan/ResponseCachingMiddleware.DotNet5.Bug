using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RequestsGeneratorApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Randomly press CTRL+C to kill this console app and it would simulate the bug on the web api server.");

            var httpClient = new HttpClient();
            while (true)
            {
                try
                {
                    Console.WriteLine("Sending GET request to the server.");
                    var result = await httpClient.GetAsync("http://localhost:5000/home");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await Task.Delay(1000);
                }
            }
        }
    }
}
