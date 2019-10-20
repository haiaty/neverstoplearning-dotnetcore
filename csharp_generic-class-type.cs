using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // When the generic class is used,
            // type arguments must be provided for each of the type parameters:

            Pair<int, string> a = new Pair<int, string>
            {
                First = 1,
                Second = "two"
            };

            // a is called "constructed type"


            Console.WriteLine(a);
            Console.WriteLine(a.First);
            Console.WriteLine(a.Second);
            
            
            // another way to create a new objct
            // of generic class wothout passing in the constructor
            // but setting properties later

            // NOTE: types are different and properties are
            // set latter

            Pair<string, string> b = new Pair<string, string>();

            b.First = "hello";
            b.Second = "world";

            Console.WriteLine(b);
            Console.WriteLine(b.First);
            Console.WriteLine(b.Second);

        }
    }

    //======================
    // GENERIC CLASS TYPE
    //=======================
    // Tfirst and Tsecond are types (int, string, etc..)
    class Pair<Tfirst, Tsecond>
    {
        public Tfirst First;
        public Tsecond Second;
    }
}
