//dotnet add package Newtonsoft.Json --version 12.0.3
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


/*
These are extension methods. Basically you can "decorate" any class with these methods
thanks to generics



*/
namespace ParallelTasks
{
    static class ObjectHelper
    {
    
        // extension method. NOTE: note the this keyword before the param type.
        
        // Example of usage 
        
        // var a = new Myobject();
        // a.Dump();
       
        public static void Dump<T>(this T x)
        {
            string json = JsonConvert.SerializeObject(x, Formatting.Indented);
            Console.WriteLine(json);
            
            // this stops the execution 
            Environment.Exit(0);
        }

        public static bool IsNullOrEmpty<T>(this T Source)
        {
            if (Source == null) return true;

            return Source.Equals("");
        }

    }
}
