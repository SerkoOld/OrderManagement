using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        public override string Name => "Circle";

        public override int Price => 3;

        public Circle(int red, int blue, int yellow) :base(red, blue, yellow)
        {
        }
    }
}
