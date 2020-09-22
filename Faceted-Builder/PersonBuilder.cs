namespace Faceted_Builder
{
    public class PersonBuilder // Facade
    {
        // Reference
        protected Person Person = new Person();

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.Person;
        }

        public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);
        public PersonJobBuilder Works => new PersonJobBuilder(Person);
    }
}