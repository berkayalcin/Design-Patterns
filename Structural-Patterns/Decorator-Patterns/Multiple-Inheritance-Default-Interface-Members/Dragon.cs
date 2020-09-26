namespace Multiple_Inheritance_Default_Interface_Members
{
    public class Dragon : Organism, IBird, ILizard
    {
        public int Age { get; set; }
    }
}