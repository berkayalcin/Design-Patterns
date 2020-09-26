using System;

namespace Functional_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder().Called("Berkay")
                .WorksAs("Software Engineer")
                .Build()
                .Name;
            Console.WriteLine(person);
        }
    }
}