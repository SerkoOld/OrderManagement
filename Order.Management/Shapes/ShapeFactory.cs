using Order.Management.Colors;

namespace Order.Management.Shapes
{
    public static class ShapeFactory
    {
        public static Shape Create<T>(BaseColor color, int quantity) where T : IShape
        {
            if (typeof(T) == typeof(Circle))
            {
                return new Circle(color, quantity);
            }

            if (typeof(T) == typeof(Square))
            {
                return new Square(color, quantity);
            }

            if (typeof(T) == typeof(Triangle))
            {
                return new Triangle(color, quantity);
            }

            return null;
        }
    }
}
