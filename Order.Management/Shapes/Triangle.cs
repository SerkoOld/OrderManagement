using System.Collections.Generic;

namespace Order.Management.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(string name, int price, Dictionary<string, Colour> colours) : base(name, price, colours)
        { }
        public override int Total() => TotalNoOfShapes() * Price;
    }
}
