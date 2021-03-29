namespace Order.Management
{
    internal class Triangle : Shape
    {
        private const int TrianglePrice = 2;
        private const string TriangleName = "Triangle";

        public Triangle(int red, int blue, int yellow) : base(red, blue, yellow)
        {
            Name = TriangleName;
            Price = TrianglePrice;
        }
    }
}
