using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class TriangleCreator:ShapeFactory
    {
        public override Shape CreateShape(Dictionary<Color, int> colorNumbers)
        {
            return new Triangle(colorNumbers);
        }
        public override string GetShapeName()
        {
            return "Triangle";
        }

    }
}
