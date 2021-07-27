using Order.Management.Colors;

namespace Order.Management.Shapes
{
    internal class Square : Shape
    {
        private const int SquarePrice = 1;
        public Square(BaseColor color, int quantity) : base(nameof(Square), color, quantity)
        {
            Price = SquarePrice;
        }
    }
}
