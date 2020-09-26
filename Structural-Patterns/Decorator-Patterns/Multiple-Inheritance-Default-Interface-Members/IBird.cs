using System;

namespace Multiple_Inheritance_Default_Interface_Members
{
    public interface IBird : ICreature
    {
        void Fly()
        {
            if (Age >= 10)
                Console.WriteLine("I'm flaying");
        }
    }
}