using System.Collections.Generic;

namespace Composite_Proxy
{
    public class Creatures
    {
        private readonly int _size;
        private byte[] _ages;
        private int[] _x, _y;

        public Creatures(int size)
        {
            _size = size;
            _ages = new byte[size];
            _x = new int[size];
            _y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures _creatures;
            private readonly int _index;

            public CreatureProxy(Creatures creatures, int index)
            {
                _creatures = creatures;
                _index = index;
            }

            public ref byte Age => ref _creatures._ages[_index];
            public ref int X => ref _creatures._x[_index];
            public ref int Y => ref _creatures._y[_index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (var pos = 0; pos < _size; ++pos)
            {
                yield return new CreatureProxy(this, pos);
            }
        }
    }
}