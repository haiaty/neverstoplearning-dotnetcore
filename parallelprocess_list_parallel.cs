using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace parsefile
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            string filePath = "/file/path.csv";
            string nextLine;

            List<ParsedLine> lines = new List<ParsedLine>();

            using (StreamReader reader = File.OpenText(filePath))
            {
                while ((nextLine = await reader.ReadLineAsync()) != null)
                {
                    // since the line is a csv file separated by ','
                    // we take the different fields 
                    string[] tokens = nextLine.Split(',');

                    lines.Add(new ParsedLine(tokens[0], tokens[1]));

                }
            }

        
            // parallel processing
            // of the lines
            
            Parallel.ForEach(lines, line => {
                Console.WriteLine(line);
            });


            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            
            
        }
    }

    class ParsedLine {

        public ParsedLine(string attribute1, string attribute2) {
            this.attribute1 = attribute1;
            this.attribute2 = attribute2;
        }
         public string attribute1 { get; set;}
         public string attribute2 { get; set;}
    }


}

// NOTE1: In order to use "await" on the main method, it should be declared async and must 
// return a task

//NOTE2: sometimes for some tasks, it is faster not to process using parallelism. This is because there is some overhead on creating 
// the Threads

