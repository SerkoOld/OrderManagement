using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    abstract class Shape
    {
        public Shape(Dictionary<Color, int> colorNumbers)
        {
            this.ColorNumbers = colorNumbers;
            this.AdditionalCharge = 1;
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AdditionalCharge { get; set; }

        public  Dictionary<Color, int> ColorNumbers { get; set; }
        
        public int TotalQuantityOfShape()
        {
            return ColorNumbers[Color.Red] + ColorNumbers[Color.Blue] + ColorNumbers[Color.Yellow];
        }

        public int AdditionalChargeTotal()
        {
            return ColorNumbers[Color.Red] * AdditionalCharge;
        }
        
        public int Total()
        {
            return TotalQuantityOfShape() * this.Price;
        }
    }

    public enum Color
    { 
        Red = 1,
        Blue = 2,
        Yellow = 3
    }
}
