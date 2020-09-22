using System;

namespace Exercise_1
{
    public class FieldElement : CodeElement
    {
        public readonly string AccessModifier = "public";
        public readonly string Type;

        public FieldElement(string name,
            string accessModifier,
            string type) : base(name)
        {
            AccessModifier = accessModifier ??
                             throw new ArgumentNullException(nameof(accessModifier));
            Type = type ??
                   throw new ArgumentNullException(nameof(type));
        }

        public override string ToString()
        {
            return ToStringImpl();
        }

        private string ToStringImpl()
        {
            return $"{new string(' ', IndentSize + 1)}" +
                   $"{AccessModifier}" +
                   $"{new string(' ', 1)}" +
                   $"{Type}" +
                   $"{new string(' ', 1)}" +
                   $"{Name};";
        }
    }
}