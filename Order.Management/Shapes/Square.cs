using Order.Management.Colors;

namespace Order.Management.Shapes
{
    internal class Square : BaseShape
    {
        private const int SquarePrice = 1;

        public Square(IColor color, int quantity) : base(color, quantity, nameof(Square))
        {
            Price = SquarePrice;
        }
    }
}