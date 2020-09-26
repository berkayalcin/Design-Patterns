using System;

namespace Multiple_Inheritance
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird _bird = new Bird();
        private Lizard _lizard = new Lizard();
        private int _weight;

        public int Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                _bird.Weight = value;
                _lizard.Weight = value;
            }
        }

        public void Fly()
        {
            _bird.Fly();
        }


        public void Crawl()
        {
            _lizard.Crawl();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dragon = new Dragon();
            dragon.Weight = 123;
            dragon.Crawl();
            dragon.Fly();
        }
    }
}