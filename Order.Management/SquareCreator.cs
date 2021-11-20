using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class SquareCreator : ShapeFactory
    {
        public override Shape CreateShape(int numberOfRedBlock, int numberOfBlueBlock, int numberOfYellowBlock)
        {
            return new Square(numberOfRedBlock,numberOfBlueBlock,numberOfYellowBlock);
        }
    }
}
