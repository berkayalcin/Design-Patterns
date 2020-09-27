using System;
using System.Diagnostics;

namespace Value_Proxy
{
    [DebuggerDisplay("{value*100.0f}%")]
    public struct Percentage : IEquatable<Percentage>
    {
        private readonly float _value;

        internal Percentage(float value)
        {
            _value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p._value;
        }

        public static float operator +(Percentage f, Percentage p)
        {
            return f._value + p._value;
        }

        public override string ToString()
        {
            return $"{_value * 100}%";
        }

        public bool Equals(Percentage other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !left.Equals(right);
        }
    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(10f * 5.Percent());
            Console.WriteLine(10.Percent() + 5.Percent());
        }
    }
}