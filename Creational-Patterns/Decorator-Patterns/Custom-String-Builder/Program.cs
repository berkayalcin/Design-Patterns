using System;
using System.Collections.Generic;

namespace Custom_String_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var codeBuilder = new CodeBuilder();
            codeBuilder.AppendLine("class Foo")
                .AppendLine("{")
                .AppendLine("}");
            Console.WriteLine(codeBuilder);
        }
    }
}