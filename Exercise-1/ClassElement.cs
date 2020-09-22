using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class ClassElement : CodeElement
    {
        public readonly string AccessModifier = "public";

        private readonly List<FieldElement> _fields =
            new List<FieldElement>();

        public ClassElement(string name,
            string accessModifier) : base(name)
        {
            AccessModifier = accessModifier ??
                             throw new ArgumentNullException(nameof(accessModifier));
        }

        public override string ToString()
        {
            return ToStringImpl();
        }

        public void AddField(FieldElement field) => _fields.Add(field);

        private string ToStringImpl()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{AccessModifier}" +
                          $"{new string(' ', 1)}" +
                          $"class" +
                          $"{new string(' ', 1)}" +
                          $"{Name};");
            sb.AppendLine("{");
            foreach (var field in _fields)
            {
                sb.AppendLine(field.ToString());
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}