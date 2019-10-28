using System;
using System.Text.Json;
using System.IO;

namespace testcsharp
{
    public class WorkingWithJson
    {

        internal void run()
        {
            getSingleProperty();

            getAllPropertiesJson();

            getAllPropertiesArray();

        }

        private void getAllPropertiesArray()
        {
            var jsonString = File.ReadAllText("testArray.json");

            Console.WriteLine("#########");
            Console.WriteLine("Get all elements of array");
            Console.WriteLine("#########");
            // if you want you can pass some options to parse
            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };

            var json = JsonDocument.Parse(jsonString, options);

            var rootElement = json.RootElement;

            foreach (JsonElement element in rootElement.EnumerateArray())
            {
                Console.WriteLine("Element");
                Console.WriteLine(element);
            }
        }

        private void getAllPropertiesJson()
        {
            var jsonString = File.ReadAllText("test.json");

            Console.WriteLine("#########");
            Console.WriteLine("Get all properties JSON");
            Console.WriteLine("#########");
            // if you want you can pass some options to parse
            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };

            var json = JsonDocument.Parse(jsonString, options);

            var rootElement = json.RootElement;

            foreach (JsonProperty property in rootElement.EnumerateObject())
            {
                Console.WriteLine("Property");
                Console.WriteLine(property);
            }



        }

        private void getSingleProperty()
        {
            var jsonString = File.ReadAllText("test.json");

            Console.WriteLine("#########");
            Console.WriteLine("Get single property JSON");
            Console.WriteLine("#########");
            // when we parse a Json string we get an instance
            // of System.Text.Json.JsonDocument
            // see: https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsondocument?view=netcore-3.0
            var json = JsonDocument.Parse(jsonString);

            // in the root element we have access to
            // the json . If we use it in the Console.Write we will see the whole json
            var rootElement = json.RootElement;

            //Console.WriteLine(rootElement);

            // in order to take an element from the json
            // we can use the TryGetProperty.
            // we should pass a JsonElement because if the property exists
            // it will be returned on that variable
            // 
            JsonElement foundElement;
            var found = rootElement.TryGetProperty("property2", out foundElement);

            Console.WriteLine(foundElement);

        }
    }
}
