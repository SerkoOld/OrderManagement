using Order.Management.Colors;

namespace Order.Management.Shapes
{
    internal class Triangle : BaseShape
    {
        private const int TrianglePrice = 2;

        public Triangle(IColor color, int quantity) : base(color, quantity)
        {
            Price = TrianglePrice;
        }
    }
}