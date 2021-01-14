using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace ConfigurationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Newtonsoft.JSON");
            var config = new ConfigurationBuilder().AddNewtonsoftJsonFile("example.json").Build();
            var obj = config.Get<ConfigType>();

            Console.WriteLine($"Item Count: {obj.Example.Length}");
            Console.WriteLine($"Items in array: {string.Join(", ", obj.Example)}");

            Console.WriteLine("\n\nJSON.net");
            config = new ConfigurationBuilder().AddJsonFile("example.json").Build();
            obj = config.Get<ConfigType>();

            Console.WriteLine($"Item Count: {obj.Example.Length}");
            Console.WriteLine($"Items in array: {string.Join(", ", obj.Example)}");

        }
    }

    class ConfigType
    {
        public string[] Example { get; set; } = {"Item 1"};
    }
}
