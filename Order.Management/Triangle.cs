using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Triangle : Shape
    {
        public int TrianglePrice = 2;
        public Triangle()
        {
            Name = "Triangle";
            base.Price = TrianglePrice;
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
