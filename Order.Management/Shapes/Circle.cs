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

        public int RedCirclesTotal()
        {
            return (NumberOfRedShape * Price);
        }
        public int BlueCirclesTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal()
        {
            return (NumberOfYellowShape * Price);
        }
    }
}
