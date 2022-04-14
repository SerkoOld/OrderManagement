using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Shape
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int AdditionalCharge { get; set; }

        //NumberOfXXXShape actually are not the attributes of Shape class, they should be moved to Order class.
        //public int NumberOfRedShape { get; set; }
        //public int NumberOfBlueShape { get; set; }
        //public int NumberOfYellowShape { get; set; }
        //public int TotalQuantityOfShape()
        //{
        //    return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        //}

        // This method isn't used, can be removed.
        //public int AdditionalChargeTotal()
        //{
        //    return NumberOfRedShape * AdditionalCharge;
        //}

        public abstract int Total(Order order);
    }
}
