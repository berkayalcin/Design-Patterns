using System;

namespace Monostate_Singleton
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var ceo = new CEO {Name = "Berkay YALÇIN", Age = 23};
            var ceo2 = new CEO {Name = "John Smith", Age = 23};

            Console.WriteLine(ceo);
            Console.WriteLine(ceo2);
        }
    }
}