namespace Order.Management
{
    internal abstract class Shape
    {
        protected Shape(int numberOfRedShapes, int numberOfBlueShapes, int numberOfYellowShapes)
        {
            NumberOfRedShape = numberOfRedShapes;
            NumberOfBlueShape = numberOfBlueShapes;
            NumberOfYellowShape = numberOfYellowShapes;
        }

        internal string Name { get; set; }
        internal int Price { get; set; }
        internal int AdditionalCharge { get; set; }

        public int NumberOfRedShape { get; set; }
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }

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