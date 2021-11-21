using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class SquareCreator : ShapeFactory
    {
        public override Shape CreateShape(Dictionary<Color, int> colorNumbers)
        {
            return new Square(colorNumbers);
        }

        public override string GetShapeName()
        {
            return "Square";
        }
    }
}
