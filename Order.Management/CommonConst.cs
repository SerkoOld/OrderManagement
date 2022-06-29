using System.Collections.Generic;

namespace Order.Management
{
    class CommonConst
    {
        public const decimal SquarePrice = 1;
        public const decimal TrianglePrice = 2;
        public const decimal CirclePrice = 3;
        public const decimal RedAdditionalCharge = 1;

        public  static List<Shape> ShapeList = new List<Shape>()
        {
            Shape.Square,
            Shape.Triangle,
            Shape.Circle,
        };

        public static List<Color> ColorList = new List<Color>()
        { 
            Color.Red,
            Color.Blue,
            Color.Yellow
        };
    }
}
