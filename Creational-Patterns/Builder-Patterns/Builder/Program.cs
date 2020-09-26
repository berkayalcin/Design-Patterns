using System;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Without Builder Pattern
            
            var hello = "Hello";
            var sb = new StringBuilder();
            sb.AppendLine("<p>");
            sb.AppendLine(hello);
            sb.AppendLine("</p>");
            Console.WriteLine(sb);

            var words = new[] {"hello", "world"};
            sb.Clear();
            sb.AppendLine("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            
            sb.AppendLine("</ul>");
            
            Console.WriteLine(sb);
            
            // Builder Pattern Usage


            var builder = new HtmlBuilder("ul");
            builder.AddChild("li","Hello");
            builder.AddChild("li","World");
            Console.WriteLine(builder);
        }
    }
}