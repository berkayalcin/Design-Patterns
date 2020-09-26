namespace Generic_Value_Adapter
{
    public class VectorOfInt<TSelf, D> : Vector<TSelf, int, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf, int, D>, new()
    {
        public VectorOfInt()
        {
        }

        public VectorOfInt(params int[] values) : base(values)
        {
        }

        public static VectorOfInt<TSelf, D> operator +(VectorOfInt<TSelf, D> lhs, VectorOfInt<TSelf, D> rhs)
        {
            var result = new VectorOfInt<TSelf, D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }
}