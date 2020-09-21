using System;
using System.Collections.Generic;

namespace Solid_Principles
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    // low-lewel

    public class Relationships
    {
        private List<(Person, Relationship, Person)> _relations =
            new List<(Person, Relationship, Person)>();

        public List<(Person, Relationship, Person)> Relations => _relations;

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string parentName);
    }

    public class RelationshipBrowser : IRelationshipBrowser
    {
        public IEnumerable<Person> FindAllChildrenOf(string parentName)
        {
            throw new NotImplementedException();
        }
    }
}