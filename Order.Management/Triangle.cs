using System.Collections.Generic;

namespace Order.Management
{
    class Triangle : Shape
    {
        public Triangle(Dictionary<Color, int> colorNumbers)
        : base(colorNumbers)
        {
            Name = "Triangles";
            this.Price = 2;
        }
    }
}
