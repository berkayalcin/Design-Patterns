namespace Generic_Value_Adapter
{
    public class Vector2I : VectorOfInt<Vector2I, Dimensions.Two>
    {
        public Vector2I()
        {
        }

        public Vector2I(params int[] values) : base(values)
        {
        }
    }
}