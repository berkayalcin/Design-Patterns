namespace Fluent_Builder
{
    public class PersonJobBuilder<SELF> :
        PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            Person.Position = position;
            return (SELF) this;
        }
    }
}