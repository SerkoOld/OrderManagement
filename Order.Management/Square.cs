using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {

       private const int SquarePrice = 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            Name = "Square";
            Price = SquarePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedSquares;
            NumberOfBlueShape = numberOfBlueSquares;
            NumberOfYellowShape = numberOfYellowSquares;
        }

        public override int Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        private int RedSquaresTotal()
        {
            return (NumberOfRedShape * Price);
        }
        private int BlueSquaresTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        private int YellowSquaresTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
