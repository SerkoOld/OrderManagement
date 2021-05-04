using System;
using System.Collections.Generic;

namespace Order.Management
{
    internal static class ShapeFactory
    {
        public static Shape GetShape(int shapeType, List<ShapeVariant> shapeVariants)
        {
            return shapeType switch
            {
                (int)ShapeTypes.Circle => new Circle(shapeVariants),
                (int)ShapeTypes.Square => new Square(shapeVariants),
                (int)ShapeTypes.Triangle => new Triangle(shapeVariants),
                _ => throw new NotImplementedException() // Fail Fast
            };
        }
    }
}