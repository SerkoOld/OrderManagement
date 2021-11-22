namespace Order.Management
{
    class Triangle : Shape
    {
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            base.NumberOfRedShape = numberOfRedTriangles;
            base.NumberOfBlueShape = numberOfBlueTriangles;
            base.NumberOfYellowShape = numberOfYellowTriangles;
        }
        public override string Name { get => "Triangle"; }
        public override int Price { get => 2; }
        public override int Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public int RedTrianglesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueTrianglesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowTrianglesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }

    }
}
