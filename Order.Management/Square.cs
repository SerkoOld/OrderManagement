using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    public class Square : Shape
    {

        public Square(string name, int price, int additionalCharge, Dictionary<string, int> colourCounts) : base(name, price, additionalCharge, colourCounts)
        { }
        public override int Total() => TotalNoOfShapes() * Price;

    }
}
