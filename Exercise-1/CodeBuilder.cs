namespace Exercise_1
{
    public class CodeBuilder
    {
        private string _className;
        private ClassElement _classElement;

        public CodeBuilder(string className)
        {
            _className = className;
            _classElement = new ClassElement(className, "public");
        }

        public CodeBuilder AddField(string fieldName, string type)
        {
            _classElement.AddField(new FieldElement(fieldName, "public",
                type));
            return this;
        }

        public override string ToString()
        {
            return _classElement.ToString();
        }

        public CodeBuilder Clear()
        {
            _classElement = new ClassElement(_className, "public");
            return this;
        }
    }
}