using Order.Management.Colors;

namespace Order.Management.Shapes
{
    public abstract class Shape : IShape
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public BaseColor Color { get; set; }
        public int NumberOfShapes { get; set; }

        protected Shape(string name, BaseColor color, int numberOfShapes)
        {
            Name = name;
            Color = color;
            NumberOfShapes = numberOfShapes;
        }

        public decimal SurchargeTotal()
        {
            return NumberOfShapes * Color.Surcharge;
        }

        public decimal Total()
        {
            return NumberOfShapes * Price;
        }
    }
}
