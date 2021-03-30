using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    /*
    The main Math class
    Contains all methods for performing basic math functions
*/
    /// <summary>
    /// The main Shape class.
    /// Abstract class contains all methods for performing basic shape functions.
    /// </summary>
    /// <remarks>
    /// <para>More specific shapes can inherit this class.</para>
    /// </remarks>
    abstract class Shape
    {
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

        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        public abstract int Total();

    }
}
