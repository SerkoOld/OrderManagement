using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Triangle : Shape
    {
        private double trianglePrice = 2;
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            Name = "Triangle";
            Price = trianglePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedTriangles;
            NumberOfBlueShape = numberOfBlueTriangles;
            NumberOfYellowShape = numberOfYellowTriangles;
        }

        public override double Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public double RedTrianglesTotal()
        {
            return (NumberOfRedShape * Price);
        }
        public double BlueTrianglesTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public double YellowTrianglesTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    
}
}
