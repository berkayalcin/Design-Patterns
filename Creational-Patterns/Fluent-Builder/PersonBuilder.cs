namespace Fluent_Builder
{
    public abstract class PersonBuilder
    {
        protected readonly Person Person = new Person();
        public Person Build() => Person;
    }
}