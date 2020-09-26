using System;
using System.Collections.Generic;

namespace Abstract_Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is sensational!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bag,boil water,pour {amount} ml,add lemon,enjoy !");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans,boil water,pour {amount} ml,add cream and sugar, enjoy !");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> _factories =
            new List<Tuple<string, IHotDrinkFactory>>();


        public HotDrinkMachine()
        {
            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(type) &&
                    !type.IsInterface)
                {
                    _factories.Add(Tuple.Create(
                        type.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory) Activator.CreateInstance(type)
                    ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available Drinks : ");
            for (var index = 0; index < _factories.Count; index++)
            {
                var machines = _factories[index];
                Console.WriteLine($"{index} : {machines.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i)
                                                     && i >= 0 && i < _factories.Count)
                {
                    Console.WriteLine("Specify the amount");
                    s = Console.ReadLine();
                    if (s != null && int.TryParse(s, out int amount)
                                  && amount > 0)
                    {
                        return _factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again!");
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();

            var coffee = machine.MakeDrink();
            var tea = machine.MakeDrink();
        }
    }
}