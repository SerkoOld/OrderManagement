using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class SquareCreator : ShapeFactory
    {
        private readonly string _name = "Square";
        public override Shape CreateShape(Dictionary<Color, int> colorNumbers)
        {
            return new Square(colorNumbers);
        }
        public override string Name { get { return _name; } }
    }
}
