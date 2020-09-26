namespace Multiple_Inheritance_Default_Interface_Members
{
    class Program
    {
        static void Main(string[] args)
        {
            var dragon = new Dragon()
            {
                Age = 5
            };

            if (dragon is IBird bird)
                bird.Fly();
            if (dragon is ILizard lizard)
                lizard.Crawl();
        }
    }
}