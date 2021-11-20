using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class ShapeFactory
    {
        public abstract Shape CreateShape(int numberOfRedBlock, int numberOfBlueBlock, int numberOfYellowBlock);
    }
}
