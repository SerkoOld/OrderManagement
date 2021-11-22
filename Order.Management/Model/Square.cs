namespace Order.Management.Model
{
    class Square : Shape
    {
        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {

            NumberOfRedShape = numberOfRedSquares;
            NumberOfBlueShape = numberOfBlueSquares;
            NumberOfYellowShape = numberOfYellowSquares;
        }
        public override int Price { get => 1; }
        public override string Name { get => "Square"; }
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
