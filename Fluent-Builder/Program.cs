using System;

namespace Fluent_Builder
{
    // Class Foo : Bar<Foo> Recursive Generics

    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.New.Called("Berkay")
                .WorksAsA("Software Engineer")
                .Build();
            Console.WriteLine(person.ToString());
        }
    }
}