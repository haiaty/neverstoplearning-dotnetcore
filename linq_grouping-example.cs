using System;
using System.Collections.Generic;
using System.Linq;

namespace example
{
    class Program
    {

        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();


            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            
            
            /**
            
            Group the strings by their first letter

             */
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];

            foreach(IGrouping<char, string> vegs in queryFoodGroups){

                // here we know the keys that items are grouped
                Console.WriteLine(vegs.Key);

                // and with this loop we take elements
                // of that group
                foreach(var veg in vegs) {

                    Console.WriteLine(veg);

                }
            }

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            
            
        }
    }

}


// RESOURCES:
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/group-clause
