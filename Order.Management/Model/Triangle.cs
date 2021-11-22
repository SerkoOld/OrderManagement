namespace Order.Management.Model
{
    class Triangle : Shape
    {
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            NumberOfRedShape = numberOfRedTriangles;
            NumberOfBlueShape = numberOfBlueTriangles;
            NumberOfYellowShape = numberOfYellowTriangles;
        }
        public override string Name { get => "Triangle"; }
        public override int Price { get => 2; }
        public override int Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public int RedTrianglesTotal()
        {
            return NumberOfRedShape * Price;
        }
        public int BlueTrianglesTotal()
        {
            return NumberOfBlueShape * Price;
        }
        public int YellowTrianglesTotal()
        {
            return NumberOfYellowShape * Price;
        }

    }
}
