using System;

namespace Solid_Principles
{
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if(name==null)
                throw new ArgumentNullException(nameof(name));
            
            Name = name;
            Color = color;
            Size = size;
        }
    }
}