namespace Order.Management.Shapes
{
    public class Square : Shape
    {
        public override ShapeName Name => ShapeName.Square;

        public override int Price => 1;

        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares) : base(numberOfRedSquares, numberOfBlueSquares, numberOfYellowSquares) { }
    }
}
