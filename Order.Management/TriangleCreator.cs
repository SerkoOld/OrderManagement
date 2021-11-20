using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class TriangleCreator:ShapeFactory
    {
        public override Shape CreateShape(int numberOfRedBlock, int numberOfBlueBlock, int numberOfYellowBlock)
        {
            return new Triangle(numberOfRedBlock, numberOfBlueBlock, numberOfYellowBlock);
        }
    }
}
