using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CircleCreator:ShapeFactory
    {
        public override Shape CreateShape(int numberOfRedBlock, int numberOfBlueBlock, int numberOfYellowBlock)
        {
            return new Circle(numberOfRedBlock, numberOfBlueBlock, numberOfYellowBlock);
        }
    }
}
