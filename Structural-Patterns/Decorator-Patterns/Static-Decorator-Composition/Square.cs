namespace Static_Decorator_Compasition
{
    public class Square : Shape
    {
        private float _side;

        public Square() : this(0.0f)
        {
        }

        public Square(float side)
        {
            _side = side;
        }

        public override string AsString()
        {
            return $"A Square with side {_side}";
        }
    }
}