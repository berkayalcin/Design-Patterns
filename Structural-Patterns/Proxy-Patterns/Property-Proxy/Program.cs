namespace Property_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var creature = new Creature();
            creature.Agility = 10;
            creature.Agility = 10;
        }
    }
}