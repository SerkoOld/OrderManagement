using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class TriangleCreator:ShapeFactory
    {
        private readonly string _name = "Triangle";
        public override Shape CreateShape(Dictionary<Color, int> colorNumbers)
        {
            return new Triangle(colorNumbers);
        }
        public override string Name { get { return _name; } }
    }
}
