using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace example
{
    class Program
    {

        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();


            string[] words = new string[]{"hello", "hi", "ola"};

            /*
            Retrieving subset of data using LINQ

            NOTE: A query is not executed until you iterate over the query variable, for example, in a foreach statement.
             */

             // Query Expression.
            IEnumerable<string> query = //query variable
                from word in words //required
                where word == "hello" // optional
                select word; //must end with select or group

            // Execute the query to produce the results            
            foreach(string word in query){
                Console.WriteLine(word);
            }    

             // If you want you can also use the keyword "var"
             // so the types will be infered at compile time
             var ordering = 
                from word in words
                orderby word descending
                select word;

            foreach(string word in ordering){

                Console.WriteLine(word);

            }  



             /**
             
             Transformation of a string collection
             using LINQ to objects of a class
              */
             IEnumerable<ParsedLine> transformation = 
                from word in words
                orderby word descending
                select new ParsedLine(word, word);

            foreach(ParsedLine word in transformation){

                Console.WriteLine(word);

            } 


            /*
            
            Retrieving a value such as total or count
             */

            // retrieve an int wich is a count
             int numOfWords  =
                (from word in words
                where word == "hello"
                select word)
                .Count();

                //convert to List 
                List<string> listWords =
                (from word in words
                where word == "hello"
                select word)
                .ToList();


            Console.WriteLine($"Number of records: {numOfWords}");

            

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


// RESOURCES:
// https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq
