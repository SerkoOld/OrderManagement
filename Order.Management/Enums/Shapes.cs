using Order.Management.Exceptions;

namespace Order.Management.Enums
{
    public enum Shapes
    {
        Circle,
        Square,
        Triangle,
    }

    public static class ShapesExtensions
    {
        public static decimal GetUnitPrice(this Shapes shape)
        {
            switch (shape)
            {
                case Shapes.Circle:
                    return Constants.CirclePrice;
                case Shapes.Square:
                    return Constants.SquarePrice;
                case Shapes.Triangle:
                    return Constants.TrianglePrice;
                default:
                    throw new UnknownShapeException(shape.ToString());
            }
        }
    }
}