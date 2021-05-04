namespace Order.Management
{
    internal class Square : Shape
    {
        private const int SquarePrice = 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
            : base(numberOfRedSquares, numberOfBlueSquares, numberOfYellowSquares)
        {
            Name = "Square";
            Price = SquarePrice;
            AdditionalCharge = 1;
        }

        public override int Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        public int RedSquaresTotal()
        {
            return NumberOfRedShape * Price;
        }
        public int BlueSquaresTotal()
        {
            return NumberOfBlueShape * Price;
        }
        public int YellowSquaresTotal()
        {
            return NumberOfYellowShape * Price;
        }
    }
}