using Order.Management.Colors;

namespace Order.Management.Shapes
{
    public interface IShape
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public IColor Color { get; set; }

        public double Total();
        public double AdditionalChargeTotal();
    }
}