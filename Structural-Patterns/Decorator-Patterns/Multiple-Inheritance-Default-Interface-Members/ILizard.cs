using System;

namespace Multiple_Inheritance_Default_Interface_Members
{
    public interface ILizard : ICreature
    {
        void Crawl()
        {
            if (Age < 10)
                Console.WriteLine("I'm crawling");
        }
    }
}