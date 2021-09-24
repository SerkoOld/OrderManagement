using Order.Management.Enums;

namespace Order.Management.Models
{
    public class Shape
    {
        public Shapes Name { get; set; }
        public ShapeColours Colour { get; set; }

        public Shape(Shapes name, ShapeColours colour)
        {
            Name = name;
            Colour = colour;
        }
    }
}
