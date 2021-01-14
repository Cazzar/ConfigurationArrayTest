using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConfigurationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Newtonsoft.JSON");
            var config = new ConfigurationBuilder().AddNewtonsoftJsonStream(new MemoryStream(Encoding.ASCII.GetBytes("{ \"Example\": [ \"Item 2\" ] }"))).Build();
            var obj = config.Get<ConfigType>();

            Console.WriteLine($"Item Count: {obj.Example.Length}");
            Console.WriteLine($"Items in array: {string.Join(", ", obj.Example)}");

            Console.WriteLine("\n\nSystem.Net.Json");
            config = new ConfigurationBuilder().AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes("{ \"Example\": [ \"Item 2\" ] }"))).Build();
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
