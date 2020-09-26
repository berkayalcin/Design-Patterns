namespace Generic_Value_Adapter
{
    static class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector2I(1, 2);

            var vv = new Vector2I(3, 4);

            var result = v + vv;

            var vector3f = Vector3F.Create(1f, 2f, 3f);
        }
    }
}