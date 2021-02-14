using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Shape
    {
        protected Shape(int numberOfRedShape, int numberOfBlueShape, int numberOfYellowShape)
        {
            NumberOfRedShape = numberOfRedShape;
            NumberOfBlueShape = numberOfBlueShape;
            NumberOfYellowShape = numberOfYellowShape;
        }

        public abstract string Name { get; }
        public abstract int Price { get; }
        public virtual int AdditionalCharge { get => 1; }
        public int NumberOfRedShape { get; private set; }
        public int NumberOfBlueShape { get; private set; }
        public int NumberOfYellowShape { get; private set; }
        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        public abstract int Total();

    }
}
