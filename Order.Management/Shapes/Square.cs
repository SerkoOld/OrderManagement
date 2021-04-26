namespace Order.Management.Shapes
{
    class Square : Shape
    {
        public override string Name => "Square";

        public override int Price => 1;

        public Square(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles) : base(numberOfRedTriangles, numberOfBlueTriangles, numberOfYellowTriangles) { }
    }
}
