using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace testcsharp
{
    internal class AyncExampleFileReader
    {
        public void run()
        {
            readFileAsync().Wait();
        }

        /*

            This method returns a Task.
            Notice that there are no return statements that return a
            Task object. Instead, that Task object is created by code the compiler generates when you use the await operator. You can imagine that this method returns when it reaches an await. 

             */
        private static async Task readFileAsync()
        {
            var words = ReadFrom("example.txt");
            foreach (var word in words)
            {
                Console.Write(word);
                if (!string.IsNullOrWhiteSpace(word))
                {
                    await Task.Delay(200);
                }
            }

        }

        /*

             The object returned by the ReadFrom method contains
             the code to generate each item in the sequence.
             In this example, that involves reading the next line
             of text from the source file, and returning that string. Each time the calling code requests the next item from the sequence, the code reads the next line of text from the file and returns it. When the file is completely read, the sequence indicates that there are no more items.


        */
        static IEnumerable<string> ReadFrom(string file)
        {
            string line;

            /*

             The using statement in this method manages resource cleanup.
             The variable that is initialized in the using statement (reader, in this example) must implement the IDisposable interface.
             That interface defines a single method, Dispose, that should be called when the resource should be released.
             The compiler generates that call when execution reaches the closing brace of the using statement. The compiler-generated code ensures that the resource is released even if an exception is thrown from the code in the block defined by the using statement.

             */

            /*

              var defines an implicitly typed local variable.
              That means the type of the variable is determined by the compile-time type of the object assigned to the variable.

              */
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(' ');

                    var lineLength = 0;

                    foreach (var word in words)
                    {
                        yield return word + " ";

                        lineLength += word.Length + 1;
                        if (lineLength > 70)
                        {
                            yield return Environment.NewLine;
                            lineLength = 0;
                        }

                    }
                    yield return Environment.NewLine;
                }
            }
        }
    }
}
