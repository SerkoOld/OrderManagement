// 0. Remove no longer required code conveniently could make code cleaner
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        // 1. magic number
        public int circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            // 2. hard-coded string
            Name = "Circle";
            base.Price = circlePrice;
            AdditionalCharge = 1;
            // 3. we could use a better way: 'base(red, blue, yellow)' assigning values to the fields that defined in base class
            base.NumberOfRedShape = red;
            base.NumberOfBlueShape = blue;
            base.NumberOfYellowShape = yellow;
        }
        // 4. bad method name: you cannot know the exact meaning of `total`, a better name could be PriceTotal
        public override int Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        // 5. if I were the author, I would like use properties for the following methods
        public int RedCirclesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }

        public int BlueCirclesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
