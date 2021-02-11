namespace Order.Management
{
    class Triangle : Shape
    {
        public int TrianglePrice = 2;

        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            Name = "Triangle";
            Price = TrianglePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedTriangles;
            NumberOfBlueShape = numberOfBlueTriangles;
            NumberOfYellowShape = numberOfYellowTriangles;
        }

        public override int Total => RedTrianglesTotal+ BlueTrianglesTotal+ YellowTrianglesTotal;

        public int RedTrianglesTotal => (NumberOfRedShape * Price);

        public int BlueTrianglesTotal => (NumberOfBlueShape * Price);

        public int YellowTrianglesTotal => (NumberOfYellowShape * Price);
    }
}
