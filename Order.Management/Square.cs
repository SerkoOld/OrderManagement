namespace Order.Management
{
    class Square : Shape
    {

        public int SquarePrice = 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            Name = "Square";
            Price = SquarePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedSquares;
            NumberOfBlueShape = numberOfBlueSquares;
            NumberOfYellowShape = numberOfYellowSquares;
        }

        public override int Total => RedSquaresTotal+ BlueSquaresTotal+ YellowSquaresTotal;

        public int RedSquaresTotal => (NumberOfRedShape * Price);

        public int BlueSquaresTotal => (NumberOfBlueShape * Price);

        public int YellowSquaresTotal => (NumberOfYellowShape * Price);
    }
}
