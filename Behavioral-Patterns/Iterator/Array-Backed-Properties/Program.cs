using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Array_Backed_Properties
{
    public class Creature : IEnumerable<int>
    {
        private int[] _stats = new int[3];

        public int Strength
        {
            get => _stats[0];
            set => _stats[0] = value;
        }

        public int Agilitiy
        {
            get => _stats[1];
            set => _stats[1] = value;
        }

        public int Intelligence
        {
            get => _stats[2];
            set => _stats[2] = value;
        }

        public double AverageStat => _stats.Average();

        public IEnumerator<int> GetEnumerator()
        {
            return _stats.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var creature = new Creature();
            creature.Agilitiy = 10;
            creature.Strength = 10;
            creature.Intelligence = 10;

            foreach (var prop in creature)
            {
                Console.WriteLine(prop);
            }
        }
    }
}