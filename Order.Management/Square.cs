using System.Collections.Generic;

namespace Order.Management
{
    class Square : Shape
    {
        public Square(Dictionary<Color, int> colorNumbers)
        :base (colorNumbers){
            Name = "Square";
            this.Price = 1;
        }
    }
}
