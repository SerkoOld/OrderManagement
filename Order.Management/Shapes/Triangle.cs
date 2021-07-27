using Order.Management.Colors;

namespace Order.Management.Shapes
{
    internal class Triangle : Shape
    {
        private const int TrianglePrice = 2;
        public Triangle(BaseColor color, int quantity) : base(nameof(Triangle), color, quantity)
        {
            Price = TrianglePrice;
        }
    }
}
