using System.Collections.Generic;

namespace Order.Management
{
    internal class Circle : Shape
    {
        private const int CirclePrice = 3;
        public Circle(List<ShapeVariant> shapeVariants) : base(shapeVariants)
        {
            Name = "Circle";
            Price = CirclePrice;
        }
    }
}