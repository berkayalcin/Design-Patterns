using System;

namespace Faceted_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new PersonBuilder()
                .Works
                .At("Trendyol")
                .AsA("Engineer")
                .Earning(999999)
                .Lives
                .At("Şişli")
                .WithPostCode("34000")
                .In("ISTANBUL");

            Console.WriteLine(person);
        }
    }
}