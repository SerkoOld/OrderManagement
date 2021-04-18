using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Triangle : Shape
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

        private int RedTrianglesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        private int BlueTrianglesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        private int YellowTrianglesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    
}
}
