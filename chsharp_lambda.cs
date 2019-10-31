using System;
using System.Threading.Tasks;

namespace testlambdas
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // store a lambda without input and without returning any value
            // to a variable
            Action test = () => { Console.WriteLine("ffff"); };

            // call it
            test();

            // store a lambda with one input and without returning any value
            Action<int> lambdaWithOneInputAndNoReturnValue = (int a) => Console.WriteLine("passed :" + a);

            // call it
            lambdaWithOneInputAndNoReturnValue(10);

            // store a lambda function that take no input an return
            // a value, in this case a string
            Func<string> test2 = () => "Hi";

            // call it
            Console.WriteLine(test2());

            // store a lambda function that take an input and return
            // a value, in this case a string
            Func<int, string> lambdaWithOneInputReturnString = (int a) => "used:" + a;

            // call it
            Console.WriteLine(lambdaWithOneInputReturnString(100));

            //Sometimes it's impossible for the compiler to infer the input types.
            // you should tell the types of lambda inputs:
            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;


            // storing an async lambda into a variable that will 
            // be called later
            Func<int, Task<string>> x = async (int a) => "using from async lambda:" + a;

            // call the async lambda, but do not await here
            var hhh = x(10);

            // await the async lambda to finish
            Console.WriteLine(await hhh);


            Console.WriteLine("Hello World!");
        }  
    }
}
