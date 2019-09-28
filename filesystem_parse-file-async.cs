// resources:
// Official documentation: https://docs.microsoft.com/en-us/dotnet/standard/io/asynchronous-file-i-o

/*
NOTE1: In order to use "await" on the main method, it should be declared async and must 
return a Task. 

PS: This snippet was run on console project context.
*/

/*

NOTE2: you can use the following command to generate a simple console application:

dotnet new console -n parsefile

then you can copy and paste the snippet

*/



using System;
using System.IO;
using System.Threading.Tasks;

namespace parsefile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = "/path/to/file.csv";
            string nextLine;

            using (StreamReader reader = File.OpenText(filePath))
            {
                while ((nextLine = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(nextLine);
                }
            }
        }
    }
}
