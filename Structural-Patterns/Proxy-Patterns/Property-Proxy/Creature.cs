namespace Property_Proxy
{
    public class Creature
    {
        private Property<int> _agility = new Property<int>();

        public int Agility
        {
            get => _agility.Value;
            set => _agility.Value = value;
        }
    }
}