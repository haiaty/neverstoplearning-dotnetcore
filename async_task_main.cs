using System;
using System.Threading.Tasks;

namespace AsyncMain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var helloWorld = await GetHelloWorldAsync();
            Console.WriteLine(helloWorld);
        }

        static Task<string> GetHelloWorldAsync()
        {
            return Task.FromResult("Hello Async World");
        }
    }
}
