using System.Collections.Generic;

namespace Order.Management
{
    internal class Triangle : Shape
    {
        private const int TrianglePrice = 2;
        public Triangle(List<ShapeVariant> shapeVariants) : base(shapeVariants)
        {
            Name = "Triangle";
            Price = TrianglePrice;
        }
    }
}