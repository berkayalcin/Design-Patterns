using System;

namespace Composite_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var creatures = new Creature[100];
            foreach (Creature creature in creatures)
            {
                creature.X++;
            }


            var creatures2 = new Creatures(100);
            foreach (Creatures.CreatureProxy creature in creatures2)
            {
                creature.X++;
            }
        }
    }
}