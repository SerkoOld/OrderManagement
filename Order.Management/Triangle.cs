using System.Collections.Generic;

namespace Order.Management
{
    class Triangle : Shape
    {
        public Triangle(Dictionary<Color, int> colorNumbers)
        : base(colorNumbers)
        {
            Name = "Triangle";
            this.Price = 2;
        }
    }
}
