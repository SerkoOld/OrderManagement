using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    // Does not need to be an abstract class anymore (see comment in Square.cs)
    abstract class Shape
    {
        // Create a base class constructor
        // Variables can have private setters and be set in the base class constructor
        public string Name { get; set; }
        public int Price { get; set; }
        public int AdditionalCharge { get; set; }
        public int NumberOfRedShape { get; set; }
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }
        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        // Remove unused method
        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        // See comment in Square.cs
        public abstract int Total();

    }
}
