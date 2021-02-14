using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {
        public override string Name => "Square";
        public override int Price => 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares) : 
            base(numberOfRedSquares, numberOfBlueSquares, numberOfYellowSquares)
        {
        }

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
