namespace Order.Management.Shapes
{
    class Circle : Shape
    {
        public override string Name => "Circle";

        public override int Price => 3;

        public Circle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles) : base(numberOfRedTriangles, numberOfBlueTriangles, numberOfYellowTriangles) { }
    }
}
