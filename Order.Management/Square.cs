using System.Collections.Generic;

namespace Order.Management
{
    internal class Square : Shape
    {
        private const int SquarePrice = 1;
        public Square(List<ShapeVariant> shapeVariants) : base(shapeVariants)
        {
            Name = "Square";
            Price = SquarePrice;
        }
    }
}