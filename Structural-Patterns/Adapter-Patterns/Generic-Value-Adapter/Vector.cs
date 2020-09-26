using System;

namespace Generic_Value_Adapter
{
    public class Vector<TSelf, T, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf, T, D>, new()
    {
        protected T[] Data;

        public Vector()
        {
            Data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            Data = new T[requiredSize];
            var providedSize = values.Length;
            for (var i = 0; i < Math.Min(requiredSize, providedSize); i++) Data[i] = values[i];
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.Data = new T[requiredSize];
            var providedSize = values.Length;
            for (var i = 0; i < Math.Min(requiredSize, providedSize); i++) result.Data[i] = values[i];
            return result;
        }

        public T this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public T X
        {
            get => Data[0];
            set => Data[0] = value;
        }
    }
}