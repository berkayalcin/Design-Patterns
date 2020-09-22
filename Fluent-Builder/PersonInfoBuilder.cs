namespace Fluent_Builder
{
    public class PersonInfoBuilder<SELF> :
        PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            Person.Name = name;
            return (SELF) this;
        }
    }
}