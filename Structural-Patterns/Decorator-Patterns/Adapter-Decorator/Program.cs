using System;

namespace Adapter_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStringBuilder builder = "Builder";
            builder += " My String Builder";
            builder.Append("Test ");

            Console.WriteLine(builder);
        }
    }
}