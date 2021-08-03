using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {

        public int SquarePrice = 1;

        // Can make use of the base constructor and pass in the common variables for assignment (See Shape.cs)
        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            Name = "Square";
            base.Price = SquarePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedSquares;
            base.NumberOfBlueShape = numberOfBlueSquares;
            base.NumberOfYellowShape = numberOfYellowSquares;
        }

        // All the total methods seem to be the same for all the shapes, so they can be in the base class
        // The sub total methods (E.g. RedSquaresTotal, BlueSquaresTotal etc) can be private methods
        public override int Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        public int RedSquaresTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueSquaresTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowSquaresTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
