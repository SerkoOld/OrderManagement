namespace Order.Management.Shapes
{
    public class Triangle : Shape
    {
        public override ShapeName Name => ShapeName.Triangle;

        public override int Price => 2;

        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles) : base(numberOfRedTriangles, numberOfBlueTriangles, numberOfYellowTriangles) { }
    }
}
