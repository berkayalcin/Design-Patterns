using System;

// Not Working On C#
namespace Static_Decorator_Compasition
{
    class Program
    {
        static void Main(string[] args)
        {
            var redSquare = new TransparentShape<Circle>(50.0f);
            Console.WriteLine(redSquare.AsString());
        }
    }
}