using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        public Circle(int numberOfRedCircle, int numberOfBlueCircle, int numberOfYellowCircle)
        :base(numberOfRedCircle, numberOfBlueCircle, numberOfYellowCircle)
        {
            Name = "Circle";
            this.Price = 3;
        }
    }
}
