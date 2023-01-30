using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Management
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int AdditionalCharge { get; set; }
        public Dictionary<string, int> ColourCounts { get; set; }

        public Shape(string name, int price, int additionalCharge, Dictionary<string, int> colourCounts)
        {
            Name = name;
            Price = price;
            AdditionalCharge = additionalCharge;
            ColourCounts = colourCounts;
        }

        public int TotalNoOfShapes() => ColourCounts.Select(a => a.Value).ToList().Sum();

        public int ShapeColourCount(string colour) => ColourCounts.TryGetValue(colour, out var val) ? val : 0;

        public abstract int Total();

        //TODO: Maybe need accuracy 
        public int AdditionalChargeTotal() => ColourCounts.TryGetValue("Red", out var val) ? val : 0  * AdditionalCharge;

    }
}
