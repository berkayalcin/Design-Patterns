namespace Multiple_Inheritance
{
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