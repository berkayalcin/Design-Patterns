using System;

namespace Exercise_1
{
    public abstract class CodeElement
    {
        protected readonly string Name;
        protected const int IndentSize = 2;

        protected CodeElement(string name)
        {
            Name = name ??
                   throw new ArgumentNullException(nameof(name));
        }
    }
}