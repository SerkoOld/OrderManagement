using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        public Circle(Dictionary<Color, int> colorNumbers)
        :base(colorNumbers)
        {
            Name = "Circle";
            this.Price = 3;
        }
    }
}
