using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {

        public int SquarePrice = 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            Name = "Square";
            base.Price = SquarePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedSquares;
            base.NumberOfBlueShape = numberOfBlueSquares;
            base.NumberOfYellowShape = numberOfYellowSquares;
        }

        public override double Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        public double RedSquaresTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public double BlueSquaresTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public double YellowSquaresTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
