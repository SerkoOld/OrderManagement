namespace Order.Management.Shapes
{
    internal abstract class Shape
    {
        public int Price { get; protected set; }
        public int AdditionalCharge { get; protected set; }
        public int NumberOfRedShape { get; protected set; }
        public int NumberOfBlueShape { get; protected set; }
        public int NumberOfYellowShape { get; protected set; }

        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }

        public abstract int Total();
    }
}