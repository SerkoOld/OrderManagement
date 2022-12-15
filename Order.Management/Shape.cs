using System;
using System.Collections.Generic;
using System.Text;
// INSP RS Unused imports.

namespace Order.Management
{
    abstract class Shape
    {
        // INSP RS Restrict access to as many of the below properties. Currently any class in the namespace can freely edit them and getters/setters are redundant.
        // INSP RS Name could be derived from ".NameOf()" method instead of hard coded in subclasses by a magic string.
        public string Name { get; set; }
        // INSP RS Use a more appropriate data type for currency such as System.Decimal.
        public int Price { get; set; }
        // INSP RS Make this field const and protected and initialize it here instead of with a magic number in the subclasses.
        public int AdditionalCharge { get; set; }
        // INSP RS Consider a single dictionary method for storing the numbers of shape colours.
        // INSP RS Then, move this information to the Order class as a static member because these are not the responsibility of the shapes themselves.
        public int NumberOfRedShape { get; set; }
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }
        // INSP RS Open/closed principle: If we add new kinds of shapes, we have to modify code in other places.
        // After implementing dictionary, adjust this method so the code doesn't need to know how many kinds of shapes there are.
        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }
        // INSP RS Remove unused method.
        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        // INSP RS Consider a more self-documenting name.
        public abstract int Total();

    }
}
