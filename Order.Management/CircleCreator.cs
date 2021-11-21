using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CircleCreator:ShapeFactory
    {
        public override Shape CreateShape(Dictionary<Color, int> colorNumbers)
        {
            return new Circle(colorNumbers);
        }
        public override string GetShapeName()
        {
            return "Circle";
        }
    }
}
