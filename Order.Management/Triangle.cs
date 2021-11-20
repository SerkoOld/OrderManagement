
namespace Order.Management
{
    class Triangle : Shape
    {
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        : base(numberOfRedTriangles, numberOfBlueTriangles, numberOfYellowTriangles)
        {
            Name = "Triangle";
            this.Price = 2;
        }
    }
}
