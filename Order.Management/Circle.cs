using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        private double circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            Name = "Circle";
            Price = circlePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = red;
            NumberOfBlueShape = blue;
            NumberOfYellowShape = yellow;
        }
        public override double Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        public double RedCirclesTotal()
        {
            return (NumberOfRedShape * Price);
        }
        public double BlueCirclesTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public double YellowCirclesTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
