using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {

        public int SquarePrice = 1;

        public Square()
        {
            Name = "Square";
            base.Price = SquarePrice;
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
    }
}
