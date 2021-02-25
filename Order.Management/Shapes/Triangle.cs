namespace Order.Management
{
    public class Triangle : Shape
    {
        public const int TrianglePrice = 2;
        public const string TriangleName = "Triangle";

        public Triangle(int redAmount, int blueAmount, int yellowAmount) : base(redAmount, blueAmount, yellowAmount)
        {
            Name = TriangleName;
            Price = TrianglePrice;
        }
    
}
}
