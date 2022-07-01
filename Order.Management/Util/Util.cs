using System;
using System.Collections.Generic;
using Order.Management.Enums;

namespace Order.Management.Util
{
    public static class Util
    {
        public static List<Shape> ShapeList = new List<Shape>()
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
