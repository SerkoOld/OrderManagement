using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        public int circlePrice = 3;

        public Circle(int numberOfRedCircles, int numberOfBlueCircles, int numberOfYellowCircles)
        {
            Name = "Circle";
            Price = circlePrice;
            AdditionalCharge = 1;
            NumberOfRedShape = numberOfRedCircles;
            NumberOfBlueShape = numberOfBlueCircles;
            NumberOfYellowShape = numberOfYellowCircles;
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
