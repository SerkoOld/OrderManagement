using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        public int circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            Name = "Circle";
            base.Price = circlePrice;
            AdditionalCharge = 1;
            base.NumberOfRedShape = red;
            base.NumberOfBlueShape = blue;
            base.NumberOfYellowShape = yellow;
        }
        public override double Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        public double RedCirclesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public double BlueCirclesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public double YellowCirclesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
