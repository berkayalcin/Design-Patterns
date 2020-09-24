using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Prototype
{
    public static class ExtensionsMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        public static T DeepCopyJson<T>(this T self)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(self));
        }
    }


    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person()
        {
        }

        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }


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