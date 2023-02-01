using System.Collections.Generic;

namespace Order.Management.Shapes
{
    public class Circle : Shape
    {
        public Circle(string name, int price, Dictionary<string, Colour> colours) : base(name, price, colours)
        { }


        public override int Total() => TotalNoOfShapes() * Price;

    }
}
