using System;
using System.Xml.Serialization;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[]
            {
                "John", "Smith"
            }, new Address("London Road", 123));
            var jane = john.DeepCopyJson();
            jane.Address.StreetName = "London Way";
            Console.WriteLine(jane);
            Console.WriteLine(john);
        }
    }
}