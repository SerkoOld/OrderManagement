using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CircleCreator:ShapeFactory
    {
        private readonly string _name = "Circle";
        public override Shape CreateShape(Dictionary<Color, int> colorNumbers)
        {
            return new Circle(colorNumbers);
        }
        public override string Name { get { return _name; } }
    }
}
