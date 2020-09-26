namespace Generic_Value_Adapter
{
    public class VectorOfFloat<TSelf, D> : Vector<TSelf, float, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf, float, D>, new()

    {
    }
}