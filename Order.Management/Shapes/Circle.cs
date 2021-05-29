using Order.Management.Colors;

namespace Order.Management.Shapes
{
    internal class Circle : BaseShape
    {
        private const int CirclePrice = 3;

        public Circle(IColor color, int quantity) : base(color, quantity)
        {
            Price = CirclePrice;
        }
    }
}