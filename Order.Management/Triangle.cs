using System;
using System.Collections.Generic;
using System.Text;

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
