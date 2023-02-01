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
        public Dictionary<string, Colour> Colours { get; set; }

        public Shape(string name, int price, Dictionary<string, Colour> colours)
        {
            Name = name;
            Price = price;
            Colours = colours;
        }

        public int TotalNoOfShapes() => Colours.Select(a => a.Value.ColourNos).ToList().Sum();

        public int ShapeColourCount(string colour) => Colours.TryGetValue(colour, out var val) ? val.ColourNos : 0;

        public abstract int Total();

    }
}
