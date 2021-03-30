using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {

        private double squarePrice = 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            Name = "Square";
            Price = squarePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedSquares;
            NumberOfBlueShape = numberOfBlueSquares;
            NumberOfYellowShape = numberOfYellowSquares;
        }

        public override double Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        public double RedSquaresTotal()
        {
            return (NumberOfRedShape * Price);
        }
        public double BlueSquaresTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public double YellowSquaresTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
