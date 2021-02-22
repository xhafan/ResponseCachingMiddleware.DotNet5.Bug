using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestsGeneratorApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Wait for the web api server to be ready and press enter to send requests.");
            Console.ReadLine();
            Console.WriteLine("Randomly press CTRL+C to kill this console app and it would simulate the bug on the web api server.");

            var httpClient = new HttpClient();
            while (true)
            {
                var result = await httpClient.GetAsync("http://localhost:5000/home");
            }
        }
    }
}
