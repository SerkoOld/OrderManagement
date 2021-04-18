using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        private const int circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            Name = "Circle";
            Price = circlePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = red;
            NumberOfBlueShape = blue;
            NumberOfYellowShape = yellow;
        }
        public override int Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        private int RedCirclesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        private int BlueCirclesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        private int YellowCirclesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
