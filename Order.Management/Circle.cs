using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        public int circlePrice = 3;
        //public Circle(int red, int blue, int yellow)
        //{
        //    Name = "Circle";
        //    base.Price = circlePrice;
        //    AdditionalCharge = 1;
        //    base.NumberOfRedShape = red;
        //    base.NumberOfBlueShape = blue;
        //    base.NumberOfYellowShape = yellow;
        //}
        public Circle()
        {
            Name = "Circle";
            base.Price = circlePrice;
            AdditionalCharge = 1;
        }
        public override int Total(Order order)
        {
            return ColorCirclesTotal(order, "Red") + ColorCirclesTotal(order, "Blue") + ColorCirclesTotal(order, "Yellow");
        }

        public int ColorCirclesTotal(Order order, string color)
        {
            int TotalPrice = order.NumberOfColorShape[color] * Price;
            return TotalPrice;
        }
        //public int RedCirclesTotal()
        //{
        //    return (Order.NumberOfRedShape * Price);
        //}
        //public int BlueCirclesTotal()
        //{
        //    return (base.NumberOfBlueShape * Price);
        //}
        //public int YellowCirclesTotal()
        //{
        //    return (base.NumberOfYellowShape * Price);
        //}
    }
}
