namespace Order.Management.Shapes
{
    public class Circle : Shape
    {
        public override ShapeName Name => ShapeName.Circle;

        public override decimal Price => 3;

        public Circle(int numberOfRedCircles, int numberOfBlueCircles, int numberOfYellowCircles) : base(numberOfRedCircles, numberOfBlueCircles, numberOfYellowCircles) { }
    }
}
