using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "hello";

            string b = "world";

            //======
            // CONCATENATION
            //======
            Console.WriteLine(a + b);


            //======
            // INTERPOLATION
            //======
            Console.WriteLine($"Hello {a}");


            //======
            // TRIM
            //======

            string greeting = "      Hello World!       ";
            Console.WriteLine($"[{greeting}]");

            string trimmedGreeting = greeting.TrimStart();
            Console.WriteLine($"[{trimmedGreeting}]");

            trimmedGreeting = greeting.TrimEnd();
            Console.WriteLine($"[{trimmedGreeting}]");

            trimmedGreeting = greeting.Trim();
            Console.WriteLine($"[{trimmedGreeting}]");

            //=======
            // REPLACING
            //===========

            string tobereplaced = "Hi all";

            //first param is string to search
            string newString = tobereplaced.Replace("Hi", "hello");

            Console.WriteLine(newString);


            //=======
            // SEARCHING
            //===========
            string tosearch = "a new string to search";

            //find if contains
            Console.WriteLine(tosearch.Contains("string"));

            //find if starts with

            // NOTE: we add the second param as current culture because
            // we need to know if we are working on localized or globally
            // sorting or comparing strings is not always a culture-sensitive operation

            //BEST PRACTICE: Use overloads that explicitly specify the string comparison rules for string operations.
            //Typically, this involves calling a method overload that has a parameter of type StringComparison.

            //CurrentCulture -- Performs a case-sensitive comparison using the current culture.
            Console.WriteLine(tosearch.StartsWith("a", StringComparison.CurrentCulture));

            // find if ends
            Console.WriteLine(tosearch.EndsWith("search", StringComparison.CurrentCulture));


            //=======
            // TO UPPER
            //===========
            Console.WriteLine(newString.ToUpper());


            //=======
            // TO LOWER
            //===========
            Console.WriteLine(newString.ToLower());

        }
    }
}
