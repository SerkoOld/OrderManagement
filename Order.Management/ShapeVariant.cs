namespace Order.Management
{
    public class ShapeVariant
    {
        public ShapeVariant(ShapeColors shapeColor, int qty, bool additionalCharge)
        {
            ShapeColor = shapeColor;
            Qty = qty;
            AdditionalCharge = additionalCharge;
        }

        public ShapeColors ShapeColor { get; set; }
        public int Qty { get; set; }
        public bool AdditionalCharge { get; set; }
    }
}