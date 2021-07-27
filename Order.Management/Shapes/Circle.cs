using Order.Management.Colors;

namespace Order.Management.Shapes
{
    internal class Circle : Shape
    {
        private const int CirclePrice = 3;
        public Circle(BaseColor color, int quantity) : base(nameof(Circle), color, quantity)
        {
            Price = CirclePrice;
        }
    }
}
