using Order.Management.Colors;

namespace Order.Management.Shapes
{
    public class BaseShape : IShape
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public IColor Color { get; set; }
        public string ShapeName { get; set; }

        protected BaseShape(IColor color, int quantity, string shapeName)
        {
            Color = color;
            Quantity = quantity;
            ShapeName = shapeName;
        }

        public double Total()
        {
            return Quantity * Price;
        }

        public double AdditionalChargeTotal()
        {
            return Quantity * Color.AdditionalCharge;
        }
    }
}