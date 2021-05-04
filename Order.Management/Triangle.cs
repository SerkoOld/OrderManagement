namespace Order.Management
{
    internal class Triangle : Shape
    {
        private const int TrianglePrice = 2;
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
            : base(numberOfRedTriangles, numberOfBlueTriangles, numberOfYellowTriangles) 
        { 
            Name = "Triangle";
            Price = TrianglePrice;
            AdditionalCharge = 1;
        }

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