using System;
using Builder;

namespace Fluent_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HtmlBuilder("ul");
            builder
                .AddChild("li","Hello")
                .AddChild("li","World");
            Console.WriteLine(builder);
        }
    }
}