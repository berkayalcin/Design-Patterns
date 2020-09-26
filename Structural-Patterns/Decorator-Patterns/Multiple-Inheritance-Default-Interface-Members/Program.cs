using System;

namespace Multiple_Inheritance_Default_Interface_Members
{
    public interface ICreature
    {
        int Age { get; set; }
    }

    public interface ILizard : ICreature
    {
        void Crawl()
        {
            if (Age < 10)
                Console.WriteLine("I'm crawling");
        }
    }

    public interface IBird : ICreature
    {
        void Fly()
        {
            if (Age >= 10)
                Console.WriteLine("I'm flaying");
        }
    }

    public class Organism
    {
    }

    public class Dragon : ICreature
    {
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}