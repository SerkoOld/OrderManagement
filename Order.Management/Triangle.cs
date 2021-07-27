namespace Order.Management
{
    internal class Triangle : Shape
    {
        private const int TrianglePrice = 2;
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            Name = "Triangle";
            Price = TrianglePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedTriangles;
            NumberOfBlueShape = numberOfBlueTriangles;
            NumberOfYellowShape = numberOfYellowTriangles;
        }

        public override int Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public int RedTrianglesTotal()
        {
            return (NumberOfRedShape * Price);
        }
        public int BlueTrianglesTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public int YellowTrianglesTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    
}
}
