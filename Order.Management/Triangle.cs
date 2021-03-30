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
            base.Price = TrianglePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedTriangles;
            base.NumberOfBlueShape = numberOfBlueTriangles;
            base.NumberOfYellowShape = numberOfYellowTriangles;
        }

        public override double Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public double RedTrianglesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public double BlueTrianglesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public double YellowTrianglesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    
}
}
