using System.Collections.Generic;
using Order.Management.Colors;

namespace Order.Management.Shapes
{
    public class BaseShape : IShape
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public IColor Color { get; set; }

        public BaseShape(IColor color, int quantity)
        {
            Color = color;
            Quantity = quantity;
        }

        public double Total()
        {
            return Quantity * Price + AdditionalChargeTotal();
        }

        public double AdditionalChargeTotal()
        {
            return Quantity * Color.AdditionalCharge;
        }
    }
}